import { NextResponse } from "next/server"
import { AuthService } from "@/lib/auth"

export async function GET() {
  try {
    const baseUrl = process.env.NEXT_PUBLIC_BACKEND_URL
    if (!baseUrl) {
      return NextResponse.json(
        { success: false, message: "Backend URL is not configured." },
        { status: 500 }
      )
    }
    const response = await fetch(`${baseUrl}/api/Item`, {
      headers: AuthService.getAuthHeaders(),
      cache: "no-store",
    })

    if (!response.ok) {
      throw new Error("Failed to fetch items from the backend.")
    }

    const data = await response.json()

    return NextResponse.json({
      success: true,
      data: data,
      message: "Items retrieved successfully",
    })
  } catch (error) {
    console.error("Error in API route:", error)
    return NextResponse.json(
      {
        success: false,
        message: "Failed to retrieve items.",
      },
      { status: 500 }
    )
  }
}