import { type NextRequest, NextResponse } from "next/server"

// Import mock data from parent route
const mockGodowns = [
  {
    id: 1,
    name: "Main Warehouse A",
    location: "123 Industrial Ave, Manufacturing District, City",
    capacity: 15000,
    description: "Primary storage facility for general goods",
  },
  {
    id: 2,
    name: "Electronics Storage B",
    location: "456 Tech Blvd, Electronics Hub, City",
    capacity: 8000,
    description: "Climate-controlled storage for electronic components",
  },
  {
    id: 3,
    name: "Cold Storage C",
    location: "789 Refrigeration St, Food District, City",
    capacity: 5000,
    description: "Temperature-controlled facility for perishable goods",
  },
]

export async function GET(request: NextRequest, { params }: { params: { id: string } }) {
  try {
    const godownId = Number.parseInt(params.id)
    const godown = mockGodowns.find((g) => g.id === godownId)

    if (!godown) {
      return NextResponse.json(
        {
          success: false,
          message: "Godown not found",
        },
        { status: 404 },
      )
    }

    return NextResponse.json({
      success: true,
      data: godown,
      message: "Godown retrieved successfully",
    })
  } catch (error) {
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
    const godownIndex = mockGodowns.findIndex((g) => g.id === godownId)

    if (godownIndex === -1) {
      return NextResponse.json(
        {
          success: false,
          message: "Godown not found",
        },
        { status: 404 },
      )
    }

    const updateData = await request.json()

    // Validate required fields
    const requiredFields = ["name", "location", "capacity"]
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

    // Validate capacity is a positive number
    if (updateData.capacity <= 0) {
      return NextResponse.json(
        {
          success: false,
          message: "Capacity must be greater than 0",
        },
        { status: 400 },
      )
    }

    mockGodowns[godownIndex] = {
      ...mockGodowns[godownIndex],
      ...updateData,
      id: godownId, // Ensure ID doesn't change
    }

    return NextResponse.json({
      success: true,
      data: mockGodowns[godownIndex],
      message: "Godown Updated Successfully",
    })
  } catch (error) {
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
    const godownId = Number.parseInt(params.id)
    const godownIndex = mockGodowns.findIndex((g) => g.id === godownId)

    if (godownIndex === -1) {
      return NextResponse.json(
        {
          success: false,
          message: "Godown not found",
        },
        { status: 404 },
      )
    }

    mockGodowns.splice(godownIndex, 1)

    return NextResponse.json({
      success: true,
      message: "Godown Deleted Successfully",
    })
  } catch (error) {
    return NextResponse.json(
      {
        success: false,
        message: "Failed to delete godown",
      },
      { status: 500 },
    )
  }
}
