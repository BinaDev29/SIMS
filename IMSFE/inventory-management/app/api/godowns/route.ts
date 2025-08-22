import { type NextRequest, NextResponse } from "next/server"

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

let nextId = 4

export async function GET() {
  try {
    return NextResponse.json({
      success: true,
      data: mockGodowns,
      message: "Godowns retrieved successfully",
    })
  } catch (error) {
    return NextResponse.json(
      {
        success: false,
        message: "Failed to retrieve godowns",
      },
      { status: 500 },
    )
  }
}

export async function POST(request: NextRequest) {
  try {
    const godownData = await request.json()

    // Validate required fields matching C# CreateGodownDto
    const requiredFields = ["name", "location", "capacity"]
    for (const field of requiredFields) {
      if (!godownData[field]) {
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
    if (godownData.capacity <= 0) {
      return NextResponse.json(
        {
          success: false,
          message: "Capacity must be greater than 0",
        },
        { status: 400 },
      )
    }

    const newGodown = {
      id: nextId++,
      ...godownData,
    }

    mockGodowns.push(newGodown)

    return NextResponse.json({
      success: true,
      data: newGodown,
      message: "Godown Created Successfully",
    })
  } catch (error) {
    return NextResponse.json(
      {
        success: false,
        message: "Failed to create godown",
      },
      { status: 500 },
    )
  }
}
