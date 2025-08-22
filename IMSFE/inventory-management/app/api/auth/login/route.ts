import { type NextRequest, NextResponse } from "next/server"

// Mock user data - in production this would come from your C# backend
const mockUsers = [
  { username: "admin", password: "admin123", role: "Admin" },
  { username: "manager", password: "manager123", role: "Manager" },
  { username: "user", password: "user123", role: "User" },
]

export async function POST(request: NextRequest) {
  try {
    const { username, password } = await request.json()

    // In production, this would call your C# backend API
    // For demo purposes, using mock authentication
    const user = mockUsers.find((u) => u.username === username && u.password === password)

    if (user) {
      // Mock JWT token - in production this comes from your C# JWT generator
      const mockToken = `mock-jwt-token-${user.username}-${Date.now()}`

      return NextResponse.json({
        success: true,
        message: `Login Successful. Token: ${mockToken}`,
        user: {
          username: user.username,
          role: user.role,
          token: mockToken,
        },
      })
    } else {
      return NextResponse.json(
        {
          success: false,
          message: "Invalid username or password.",
        },
        { status: 401 },
      )
    }
  } catch (error) {
    return NextResponse.json(
      {
        success: false,
        message: "Server error occurred.",
      },
      { status: 500 },
    )
  }
}
