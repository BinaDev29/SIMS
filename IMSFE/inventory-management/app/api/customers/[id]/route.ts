import { type NextRequest, NextResponse } from "next/server"

// Import mock data from parent route
const mockCustomers = [
  {
    id: 1,
    name: "ABC Corporation",
    contactPerson: "John Smith",
    phoneNumber: "+1-555-123-4567",
    email: "john.smith@abc-corp.com",
  },
  {
    id: 2,
    name: "DEF Enterprises",
    contactPerson: "Sarah Johnson",
    phoneNumber: "+1-555-234-5678",
    email: "sarah.johnson@def-ent.com",
  },
  {
    id: 3,
    name: "GHI Solutions Ltd",
    contactPerson: "Mike Wilson",
    phoneNumber: "+1-555-345-6789",
    email: "mike.wilson@ghi-sol.com",
  },
]

export async function GET(request: NextRequest, { params }: { params: { id: string } }) {
  try {
    const customerId = Number.parseInt(params.id)
    const customer = mockCustomers.find((c) => c.id === customerId)

    if (!customer) {
      return NextResponse.json(
        {
          success: false,
          message: "Customer not found",
        },
        { status: 404 },
      )
    }

    return NextResponse.json({
      success: true,
      data: customer,
      message: "Customer retrieved successfully",
    })
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
    const customerId = Number.parseInt(params.id)
    const customerIndex = mockCustomers.findIndex((c) => c.id === customerId)

    if (customerIndex === -1) {
      return NextResponse.json(
        {
          success: false,
          message: "Customer not found",
        },
        { status: 404 },
      )
    }

    const updateData = await request.json()

    // Validate required fields
    const requiredFields = ["name", "contactPerson", "phoneNumber", "email"]
    for (const field of requiredFields) {
      if (!updateData[field]) {
        return NextResponse.json(
          {
            success: false,
            message: `${field} is required`,
          },
          { status: 400 },
        )
      }
    }

    // Email validation
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/
    if (!emailRegex.test(updateData.email)) {
      return NextResponse.json(
        {
          success: false,
          message: "Email must be a valid email address",
        },
        { status: 400 },
      )
    }

    mockCustomers[customerIndex] = {
      ...mockCustomers[customerIndex],
      ...updateData,
      id: customerId, // Ensure ID doesn't change
    }

    return NextResponse.json({
      success: true,
      data: mockCustomers[customerIndex],
      message: "Customer Updated Successfully",
    })
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
    const customerId = Number.parseInt(params.id)
    const customerIndex = mockCustomers.findIndex((c) => c.id === customerId)

    if (customerIndex === -1) {
      return NextResponse.json(
        {
          success: false,
          message: "Customer not found",
        },
        { status: 404 },
      )
    }

    mockCustomers.splice(customerIndex, 1)

    return NextResponse.json({
      success: true,
      message: "Customer Deleted Successfully",
    })
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
