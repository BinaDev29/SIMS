import { type NextRequest, NextResponse } from "next/server"

// Import mock data from parent route
const mockTransactions = [
  {
    id: 1,
    itemId: 1,
    customerId: 1,
    godownId: 1,
    quantity: 25,
    transactionDate: "2024-01-15T10:30:00Z",
    notes: "Standard delivery to main office",
    itemName: "Product A - Electronics",
    customerName: "ABC Corporation",
    godownName: "Main Warehouse A",
  },
  {
    id: 2,
    itemId: 2,
    customerId: 2,
    godownId: 2,
    quantity: 15,
    transactionDate: "2024-01-14T14:20:00Z",
    notes: "Express delivery requested",
    itemName: "Product B - Furniture",
    customerName: "DEF Enterprises",
    godownName: "Electronics Storage B",
  },
]

export async function GET(request: NextRequest, { params }: { params: { id: string } }) {
  try {
    const transactionId = Number.parseInt(params.id)
    const transaction = mockTransactions.find((t) => t.id === transactionId)

    if (!transaction) {
      return NextResponse.json(
        {
          success: false,
          message: "Outward Transaction not found",
        },
        { status: 404 },
      )
    }

    return NextResponse.json({
      success: true,
      data: transaction,
      message: "Outward transaction retrieved successfully",
    })
  } catch (error) {
    return NextResponse.json(
      {
        success: false,
        message: "Failed to retrieve outward transaction",
      },
      { status: 500 },
    )
  }
}

export async function PUT(request: NextRequest, { params }: { params: { id: string } }) {
  try {
    const transactionId = Number.parseInt(params.id)
    const transactionIndex = mockTransactions.findIndex((t) => t.id === transactionId)

    if (transactionIndex === -1) {
      return NextResponse.json(
        {
          success: false,
          message: "Outward Transaction not found",
        },
        { status: 404 },
      )
    }

    const updateData = await request.json()

    // Validate required fields
    const requiredFields = ["itemId", "customerId", "godownId", "quantity", "transactionDate"]
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

    // Validate quantity is positive
    if (updateData.quantity <= 0) {
      return NextResponse.json(
        {
          success: false,
          message: "Quantity must be greater than 0",
        },
        { status: 400 },
      )
    }

    mockTransactions[transactionIndex] = {
      ...mockTransactions[transactionIndex],
      ...updateData,
      id: transactionId, // Ensure ID doesn't change
      itemName: `Item #${updateData.itemId}`,
      customerName: `Customer #${updateData.customerId}`,
      godownName: `Godown #${updateData.godownId}`,
    }

    return NextResponse.json({
      success: true,
      data: mockTransactions[transactionIndex],
      message: "Outward Transaction Updated Successfully",
    })
  } catch (error) {
    return NextResponse.json(
      {
        success: false,
        message: "Failed to update outward transaction",
      },
      { status: 500 },
    )
  }
}

export async function DELETE(request: NextRequest, { params }: { params: { id: string } }) {
  try {
    const transactionId = Number.parseInt(params.id)
    const transactionIndex = mockTransactions.findIndex((t) => t.id === transactionId)

    if (transactionIndex === -1) {
      return NextResponse.json(
        {
          success: false,
          message: "Outward Transaction not found",
        },
        { status: 404 },
      )
    }

    mockTransactions.splice(transactionIndex, 1)

    return NextResponse.json({
      success: true,
      message: "Outward Transaction Deleted Successfully",
    })
  } catch (error) {
    return NextResponse.json(
      {
        success: false,
        message: "Failed to delete outward transaction",
      },
      { status: 500 },
    )
  }
}
