import { NextResponse } from "next/server";
import { AuthService } from "@/lib/auth";

const getBackendUrl = () => process.env.NEXT_PUBLIC_BACKEND_URL || "";

export async function GET() {
  try {
    const baseUrl = getBackendUrl();
    if (!baseUrl) {
      return NextResponse.json({ success: false, message: "Backend URL is not configured." }, { status: 500 });
    }
    const response = await fetch(`${baseUrl}/api/OutwardTransaction/with-details`, {
      headers: AuthService.getAuthHeaders(),
      cache: "no-store",
    });

    if (!response.ok) {
      throw new Error("Failed to fetch transactions from the backend.");
    }

    const data = await response.json();
    return NextResponse.json({
      success: true,
      data: data,
      message: "Transactions retrieved successfully",
    });
  } catch (error) {
    console.error("Error fetching transactions:", error);
    return NextResponse.json({ success: false, message: "Failed to fetch transactions." }, { status: 500 });
  }
}

export async function DELETE(request: Request) {
  try {
    const { id } = await request.json();
    if (!id) {
      return NextResponse.json({ success: false, message: "Transaction ID is required." }, { status: 400 });
    }

    const baseUrl = getBackendUrl();
    if (!baseUrl) {
      return NextResponse.json({ success: false, message: "Backend URL is not configured." }, { status: 500 });
    }
    const response = await fetch(`${baseUrl}/api/OutwardTransaction/${id}`, {
      method: "DELETE",
      headers: AuthService.getAuthHeaders(),
    });

    if (!response.ok) {
      const errorData = await response.json();
      throw new Error(errorData.message || "Failed to delete transaction.");
    }

    return NextResponse.json({ success: true, message: "Transaction deleted successfully." });
  } catch (error) {
    console.error("Error deleting transaction:", error);
    return NextResponse.json(
      { success: false, message: error instanceof Error ? error.message : "Failed to delete transaction." },
      { status: 500 }
    );
  }
}