import { type NextRequest, NextResponse } from "next/server"

export async function POST(request: NextRequest) {
  try {
    const { username, password } = await request.json()
    const baseUrl = process.env.NEXT_PUBLIC_BACKEND_URL
    if (!baseUrl) {
      return NextResponse.json({ success: false, message: "Backend URL is not configured." }, { status: 500 })
    }
    const apiResponse = await fetch(`${baseUrl}/api/Login`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        username,
        password,
      }),
    })

    const result = await apiResponse.json()

    if (apiResponse.ok) {
      return NextResponse.json(result, { status: apiResponse.status })
    } else {
      return NextResponse.json(result, { status: apiResponse.status })
    }
  } catch (error) {
    console.error("Login API route error:", error)
    return NextResponse.json(
      {
        success: false,
        message: "Server error occurred.",
      },
      { status: 500 },
    )
  }
}