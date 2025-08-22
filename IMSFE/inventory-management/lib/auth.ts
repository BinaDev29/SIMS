export interface User {
  username: string
  role: string
  token: string
}

export interface LoginResponse {
  success: boolean
  message: string
  user?: User
}

export class AuthService {
  private static readonly TOKEN_KEY = "inventory_token"
  private static readonly USER_KEY = "inventory_user"

  static async login(username: string, password: string): Promise<LoginResponse> {
    try {
      const response = await fetch("/api/auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ username, password }),
      })

      const data = await response.json()

      if (data.success && data.user) {
        this.setToken(data.user.token)
        this.setUser(data.user)
        return { success: true, message: data.message, user: data.user }
      }

      return { success: false, message: data.message }
    } catch (error) {
      console.error("Login error:", error)
      return { success: false, message: "Network error occurred. Please check your connection." }
    }
  }

  static logout(): void {
    localStorage.removeItem(this.TOKEN_KEY)
    localStorage.removeItem(this.USER_KEY)
  }

  static getToken(): string | null {
    if (typeof window === "undefined") return null
    return localStorage.getItem(this.TOKEN_KEY)
  }

  static getUser(): User | null {
    if (typeof window === "undefined") return null
    const userStr = localStorage.getItem(this.USER_KEY)
    return userStr ? JSON.parse(userStr) : null
  }

  static isAuthenticated(): boolean {
    return this.getToken() !== null
  }

  static hasRole(role: string): boolean {
    const user = this.getUser()
    return user?.role === role
  }

  private static setToken(token: string): void {
    localStorage.setItem(this.TOKEN_KEY, token)
  }

  private static setUser(user: User): void {
    localStorage.setItem(this.USER_KEY, JSON.stringify(user))
  }

  static getAuthHeaders(): HeadersInit {
    const token = this.getToken()
    return token ? { Authorization: `Bearer ${token}` } : {}
  }

  static async refreshToken(): Promise<boolean> {
    try {
      const token = this.getToken()
      if (!token) return false

      const response = await fetch("/api/auth/refresh", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
      })

      const data = await response.json()

      if (data.success && data.token) {
        this.setToken(data.token)
        return true
      }

      return false
    } catch (error) {
      console.error("Token refresh error:", error)
      return false
    }
  }

  static isTokenExpired(): boolean {
    const token = this.getToken()
    if (!token) return true

    try {
      // Simple JWT expiration check (in production, use a proper JWT library)
      const payload = JSON.parse(atob(token.split(".")[1]))
      const currentTime = Date.now() / 1000
      return payload.exp < currentTime
    } catch (error) {
      return true
    }
  }

  static async validateSession(): Promise<boolean> {
    if (!this.isAuthenticated()) return false

    if (this.isTokenExpired()) {
      const refreshed = await this.refreshToken()
      if (!refreshed) {
        this.logout()
        return false
      }
    }

    return true
  }
}
