import { type NextRequest, NextResponse } from "next/server"

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

let nextId = 4

export async function GET() {
  try {
    return NextResponse.json({
      success: true,
      data: mockCustomers,
      message: "Customers retrieved successfully",
    })
  } catch (error) {
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

    // Validate required fields matching C# CreateCustomerDto
    const requiredFields = ["name", "contactPerson", "phoneNumber", "email"]
    for (const field of requiredFields) {
      if (!customerData[field]) {
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
    if (!emailRegex.test(customerData.email)) {
      return NextResponse.json(
        {
          success: false,
          message: "Email must be a valid email address",
        },
        { status: 400 },
      )
    }

    const newCustomer = {
      id: nextId++,
      ...customerData,
    }

    mockCustomers.push(newCustomer)

    return NextResponse.json({
      success: true,
      data: newCustomer,
      message: "Customer Created Successfully",
    })
  } catch (error) {
    return NextResponse.json(
      {
        success: false,
        message: "Failed to create customer",
      },
      { status: 500 },
    )
  }
}
