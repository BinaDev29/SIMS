import { NextResponse } from "next/server";
import { AuthService } from "@/lib/auth";

const getBackendUrl = () => process.env.NEXT_PUBLIC_BACKEND_URL || "";

export async function GET() {
  try {
    const baseUrl = getBackendUrl();
    if (!baseUrl) {
      return NextResponse.json({ success: false, message: "Backend URL is not configured." }, { status: 500 });
    }
    const response = await fetch(`${baseUrl}/api/Employee`, {
      headers: AuthService.getAuthHeaders(),
      cache: "no-store",
    });

    if (!response.ok) {
      const errorData = await response.json();
      throw new Error(errorData.message || "Failed to fetch employees from the backend.");
    }

    const data = await response.json();
    return NextResponse.json({ success: true, data: data, message: "Employees retrieved successfully" });
  } catch (error) {
    console.error("Error fetching employees:", error);
    return NextResponse.json({ success: false, message: "Failed to fetch employees." }, { status: 500 });
  }
}

export async function DELETE(request: Request) {
  try {
    const { id } = await request.json();
    if (!id) {
      return NextResponse.json({ success: false, message: "Employee ID is required." }, { status: 400 });
    }

    const baseUrl = getBackendUrl();
    if (!baseUrl) {
      return NextResponse.json({ success: false, message: "Backend URL is not configured." }, { status: 500 });
    }
    const response = await fetch(`${baseUrl}/api/Employee/${id}`, {
      method: "DELETE",
      headers: {
        "Content-Type": "application/json",
        ...AuthService.getAuthHeaders(),
      },
    });

    if (!response.ok) {
      const errorData = await response.json();
      throw new Error(errorData.message || "Failed to delete employee.");
    }

    return NextResponse.json({ success: true, message: "Employee deleted successfully." });
  } catch (error) {
    console.error("Error deleting employee:", error);
    return NextResponse.json(
      { success: false, message: error instanceof Error ? error.message : "Failed to delete employee." },
      { status: 500 }
    );
  }
}