import { type NextRequest, NextResponse } from "next/server"

// Base URL for your C# backend
const BACKEND_URL = "https://localhost:7280"

// Mock data and token generation removed.
// The code now makes direct calls to the C# backend.

export async function GET() {
  try {
    const backendUrl = `${BACKEND_URL}/api/Customer`
    
    const backendResponse = await fetch(backendUrl)
    const data = await backendResponse.json()

    if (backendResponse.ok) {
      return NextResponse.json(data)
    } else {
      return NextResponse.json(data, { status: backendResponse.status })
    }
  } catch { // <-- እዚህ ላይ `(error)` ተወግዷል
    return NextResponse.json(
      {
        success: false,
        message: "Failed to retrieve customers",
      },
      { status: 500 },
    )
  }
}

export async function POST(request: NextRequest) {
  try {
    const customerData = await request.json()
    const backendUrl = `${BACKEND_URL}/api/Customer`

    const backendResponse = await fetch(backendUrl, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(customerData),
    })

    const data = await backendResponse.json()

    if (backendResponse.ok) {
      return NextResponse.json(data)
    } else {
      return NextResponse.json(data, { status: backendResponse.status })
    }
  } catch { // <-- እዚህ ላይ `(_error)` ተወግዷል
    return NextResponse.json(
      {
        success: false,
        message: "Failed to create customer",
      },
      { status: 500 },
    )
  }
}