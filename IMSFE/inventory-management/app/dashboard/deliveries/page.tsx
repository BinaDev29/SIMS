"use client"

import { useState } from "react"
import { DashboardLayout } from "@/components/dashboard-layout"
import { GodownsForm } from "@/components/godowns-form"
import { GodownsTable } from "@/components/godowns-table"
import { GodownsStats } from "@/components/godowns-stats"
import { AuthGuard } from "@/components/auth-guard"

// Define a type for the godown object to avoid 'any'
interface Godown {
  id: number
  name: string
  location: string
  // Add other properties as they are defined in your backend
}


export default function GodownsPage() {
  const [refreshTrigger, setRefreshTrigger] = useState(0)
  const [editingGodown, setEditingGodown] = useState<Godown | null>(null) // Corrected type

  const handleGodownAdded = () => {
    setRefreshTrigger((prev) => prev + 1)
  }

  const handleEditGodown = (godown: Godown) => { // Corrected type
    setEditingGodown(godown)
  }

  const handleCancelEdit = () => {
    setEditingGodown(null)
  }

  return (
    <AuthGuard requiredRole="Manager">
      <DashboardLayout>
        <div className="flex-1 space-y-6 p-6">
          <div>
            <h1 className="text-3xl font-bold text-foreground font-[family-name:var(--font-space-grotesk)]">
              Godown Management
            </h1>
            <p className="text-muted-foreground">Manage warehouse and storage locations</p>
          </div>

          <GodownsStats refreshTrigger={refreshTrigger} />

          <div className="grid gap-6 lg:grid-cols-3">
            <div className="lg:col-span-2">
              <GodownsTable refreshTrigger={refreshTrigger} onEditGodown={handleEditGodown} />
            </div>
            <div>
              <GodownsForm
                onGodownAdded={handleGodownAdded}
                editingGodown={editingGodown}
                onCancelEdit={handleCancelEdit}
              />
            </div>
          </div>
        </div>
      </DashboardLayout>
    </AuthGuard>
  )
}