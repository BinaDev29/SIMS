import { type NextRequest, NextResponse } from "next/server"

export async function GET(request: NextRequest, { params }: { params: { id: string } }) {
  try {
    const { id } = params
    const baseUrl = process.env.NEXT_PUBLIC_BACKEND_URL
    if (!baseUrl) {
      return NextResponse.json({ success: false, message: "Backend URL is not configured." }, { status: 500 })
    }
    const response = await fetch(`${baseUrl}/api/Customer/${id}`)

    if (!response.ok) {
      if (response.status === 404) {
        return NextResponse.json(
          {
            success: false,
            message: "Customer not found in the backend",
          },
          { status: 404 },
        )
      }
      return NextResponse.json(
        {
          success: false,
          message: "Failed to retrieve customer from the backend",
        },
        { status: response.status },
      )
    }

    const data = await response.json()

    return NextResponse.json({ success: true, data: data, message: "Customer retrieved successfully" })
  } catch (error) {
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
    const customerId = params.id
    const updateData = await request.json()
    
    // Add the ID to the update data object to send it to the backend
    const dataWithId = { ...updateData, id: Number.parseInt(customerId) }

    const baseUrl = process.env.NEXT_PUBLIC_BACKEND_URL
    if (!baseUrl) {
      return NextResponse.json({ success: false, message: "Backend URL is not configured." }, { status: 500 })
    }
    const response = await fetch(`${baseUrl}/api/Customer`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(dataWithId),
    })

    const result = await response.json()

    if (!response.ok) {
      return NextResponse.json(
        {
          success: false,
          message: result.message || "Failed to update customer in the backend",
        },
        { status: response.status },
      )
    }
    
    return NextResponse.json({ success: true, data: result.data, message: "Customer Updated Successfully" })
  } catch (error) {
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
    const { id } = params
    const baseUrl = process.env.NEXT_PUBLIC_BACKEND_URL
    if (!baseUrl) {
      return NextResponse.json({ success: false, message: "Backend URL is not configured." }, { status: 500 })
    }
    const response = await fetch(`${baseUrl}/api/Customer/${id}`, {
      method: "DELETE",
    })

    if (!response.ok) {
        return NextResponse.json(
          {
            success: false,
            message: "Failed to delete customer from the backend",
          },
          { status: response.status },
        )
    }

    return NextResponse.json({ success: true, message: "Customer Deleted Successfully" })
  } catch (error) {
    return NextResponse.json(
      {
        success: false,
        message: "Failed to delete customer",
      },
      { status: 500 },
    )
  }
}