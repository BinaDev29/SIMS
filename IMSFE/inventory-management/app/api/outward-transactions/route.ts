import { type NextRequest, NextResponse } from "next/server"

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

let nextId = 3

export async function GET() {
  try {
    return NextResponse.json({
      success: true,
      data: mockTransactions,
      message: "Outward transactions retrieved successfully",
    })
  } catch (error) {
    return NextResponse.json(
      {
        success: false,
        message: "Failed to retrieve outward transactions",
      },
      { status: 500 },
    )
  }
}

export async function POST(request: NextRequest) {
  try {
    const transactionData = await request.json()

    // Validate required fields matching C# CreateOutwardTransactionDto
    const requiredFields = ["itemId", "customerId", "godownId", "quantity", "transactionDate"]
    for (const field of requiredFields) {
      if (!transactionData[field]) {
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
    if (transactionData.quantity <= 0) {
      return NextResponse.json(
        {
          success: false,
          message: "Quantity must be greater than 0",
        },
        { status: 400 },
      )
    }

    const newTransaction = {
      id: nextId++,
      ...transactionData,
      itemName: `Item #${transactionData.itemId}`,
      customerName: `Customer #${transactionData.customerId}`,
      godownName: `Godown #${transactionData.godownId}`,
    }

    mockTransactions.push(newTransaction)

    return NextResponse.json({
      success: true,
      data: newTransaction,
      message: "Outward Transaction Created Successfully",
    })
  } catch (error) {
    return NextResponse.json(
      {
        success: false,
        message: "Failed to create outward transaction",
      },
      { status: 500 },
    )
  }
}
