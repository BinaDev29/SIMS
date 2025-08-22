import { type NextRequest, NextResponse } from "next/server"

export async function POST(request: NextRequest) {
  try {
    const { username, password } = await request.json()

    // C# ባክኤንድዎን በHTTP ፕሮቶኮል በመጠቀም በቀጥታ ያነጋግሩ
    const backendUrl = "http://localhost:5140/api/Login"

    const backendResponse = await fetch(backendUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ username, password }),
    })

    const data = await backendResponse.json()

    if (backendResponse.ok) {
      return NextResponse.json(data)
    } else {
      return NextResponse.json(data, { status: backendResponse.status })
    }
  } catch {
    return NextResponse.json(
      {
        success: false,
        message: "Server error occurred.",
      },
      { status: 500 },
    )
  }
}