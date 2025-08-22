import { type NextRequest, NextResponse } from "next/server"

// Base URL for your C# backend
const BACKEND_URL = "https://localhost:7280"

export async function GET(request: NextRequest, { params }: { params: { id: string } }) {
  try {
    const godownId = params.id
    const backendUrl = `${BACKEND_URL}/api/Godown/${godownId}`

    const backendResponse = await fetch(backendUrl)

    if (backendResponse.ok) {
      const data = await backendResponse.json()
      return NextResponse.json(data)
    } else {
      const errorData = await backendResponse.json()
      return NextResponse.json(errorData, { status: backendResponse.status })
    }
  } catch { // <-- እዚህ ላይ `_error` ተወግዷል
    return NextResponse.json(
      {
        success: false,
        message: "Failed to retrieve godown",
      },
      { status: 500 },
    )
  }
}

export async function PUT(request: NextRequest, { params }: { params: { id: string } }) {
  try {
    const godownId = Number.parseInt(params.id)
    const updateData = await request.json()

    const backendUrl = `${BACKEND_URL}/api/Godown`
    
    // The C# backend expects the ID in the body for PUT requests
    const updatedGodownDto = { ...updateData, id: godownId }

    const backendResponse = await fetch(backendUrl, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(updatedGodownDto),
    })

    const data = await backendResponse.json()

    if (backendResponse.ok) {
      return NextResponse.json(data)
    } else {
      return NextResponse.json(data, { status: backendResponse.status })
    }
  } catch { // <-- እዚህ ላይ `error` ተወግዷል
    return NextResponse.json(
      {
        success: false,
        message: "Failed to update godown",
      },
      { status: 500 },
    )
  }
}

export async function DELETE(request: NextRequest, { params }: { params: { id: string } }) {
  try {
    const godownId = params.id
    const backendUrl = `${BACKEND_URL}/api/Godown/${godownId}`

    const backendResponse = await fetch(backendUrl, {
      method: "DELETE",
    })

    const data = await backendResponse.json()

    if (backendResponse.ok) {
      return NextResponse.json(data)
    } else {
      return NextResponse.json(data, { status: backendResponse.status })
    }
  } catch { // <-- እዚህ ላይ `error` ተወግዷል
    return NextResponse.json(
      {
        success: false,
        message: "Failed to delete godown",
      },
      { status: 500 },
    )
  }
}