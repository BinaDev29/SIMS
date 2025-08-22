import { type NextRequest, NextResponse } from "next/server"

const BACKEND_URL = "https://localhost:7280"

export async function GET(request: NextRequest, { params }: { params: { id: string } }) {
  try {
    const customerId = params.id
    const backendUrl = `${BACKEND_URL}/api/Customer/${customerId}`

    const backendResponse = await fetch(backendUrl)

    if (backendResponse.ok) {
      const data = await backendResponse.json()
      return NextResponse.json(data)
    } else {
      const errorData = await backendResponse.json()
      return NextResponse.json(errorData, { status: backendResponse.status })
    }
  } catch {
    return NextResponse.json(
      {
        success: false,
        message: "Failed to retrieve customer",
      },
      { status: 500 },
    )
  }
}

export async function PUT(request: NextRequest, { params }: { params: { id: string } }) {
  try {
    const customerId = Number.parseInt(params.id)
    const updateData = await request.json()

    const backendUrl = `${BACKEND_URL}/api/Customer`
    
    const updatedCustomerDto = { ...updateData, id: customerId }

    const backendResponse = await fetch(backendUrl, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(updatedCustomerDto),
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
        message: "Failed to update customer",
      },
      { status: 500 },
    )
  }
}

export async function DELETE(request: NextRequest, { params }: { params: { id: string } }) {
  try {
    const customerId = params.id
    const backendUrl = `${BACKEND_URL}/api/Customer/${customerId}`

    const backendResponse = await fetch(backendUrl, {
      method: "DELETE",
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
        message: "Failed to delete customer",
      },
      { status: 500 },
    )
  }
}