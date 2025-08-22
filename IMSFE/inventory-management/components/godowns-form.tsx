"use client"

import type React from "react"
import { useState } from "react"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Alert, AlertDescription } from "@/components/ui/alert"
import { Textarea } from "@/components/ui/textarea"
import { Plus, Warehouse, AlertCircle } from "lucide-react"
import { AuthService } from "@/lib/auth"

interface GodownFormData {
  name: string
  location: string
  capacity: string
  description?: string
}

interface GodownsFormProps {
  onGodownAdded?: () => void
  editingGodown?: any
  onCancelEdit?: () => void
}

export function GodownsForm({ onGodownAdded, editingGodown, onCancelEdit }: GodownsFormProps) {
  const [formData, setFormData] = useState<GodownFormData>({
    name: editingGodown?.name || "",
    location: editingGodown?.location || "",
    capacity: editingGodown?.capacity?.toString() || "",
    description: editingGodown?.description || "",
  })
  const [isLoading, setIsLoading] = useState(false)
  const [error, setError] = useState("")
  const [success, setSuccess] = useState("")

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setIsLoading(true)
    setError("")
    setSuccess("")

    try {
      const url = editingGodown ? `/api/godowns/${editingGodown.id}` : "/api/godowns"
      const method = editingGodown ? "PUT" : "POST"

      const payload = editingGodown
        ? { id: editingGodown.id, ...formData, capacity: Number.parseInt(formData.capacity) }
        : { ...formData, capacity: Number.parseInt(formData.capacity) }

      const response = await fetch(url, {
        method,
        headers: {
          "Content-Type": "application/json",
          ...AuthService.getAuthHeaders(),
        },
        body: JSON.stringify(payload),
      })

      const result = await response.json()

      if (result.success) {
        setSuccess(result.message)
        if (!editingGodown) {
          // Reset form only for new godowns
          setFormData({
            name: "",
            location: "",
            capacity: "",
            description: "",
          })
        }
        onGodownAdded?.()
        if (editingGodown && onCancelEdit) {
          setTimeout(() => onCancelEdit(), 1000)
        }
      } else {
        setError(result.message || "Operation failed")
      }
    } catch (error) {
      setError("Network error occurred")
    } finally {
      setIsLoading(false)
    }
  }

  const handleInputChange = (field: keyof GodownFormData, value: string) => {
    setFormData((prev) => ({ ...prev, [field]: value }))
  }

  return (
    <Card>
      <CardHeader>
        <div className="flex items-center space-x-2">
          <Warehouse className="h-5 w-5 text-accent" />
          <CardTitle className="font-[family-name:var(--font-space-grotesk)]">
            {editingGodown ? "Edit Godown" : "Add New Godown"}
          </CardTitle>
        </div>
        <CardDescription>
          {editingGodown ? "Update godown information" : "Register a new warehouse or storage location"}
        </CardDescription>
      </CardHeader>
      <CardContent>
        {error && (
          <Alert variant="destructive" className="mb-4">
            <AlertCircle className="h-4 w-4" />
            <AlertDescription>{error}</AlertDescription>
          </Alert>
        )}

        {success && (
          <Alert className="mb-4 border-green-200 bg-green-50">
            <AlertCircle className="h-4 w-4 text-green-600" />
            <AlertDescription className="text-green-800">{success}</AlertDescription>
          </Alert>
        )}

        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="space-y-2">
            <Label htmlFor="name">Godown Name *</Label>
            <Input
              id="name"
              placeholder="Enter godown name"
              value={formData.name}
              onChange={(e) => handleInputChange("name", e.target.value)}
              required
              disabled={isLoading}
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="location">Location *</Label>
            <Textarea
              id="location"
              placeholder="Enter complete address"
              value={formData.location}
              onChange={(e) => handleInputChange("location", e.target.value)}
              rows={2}
              required
              disabled={isLoading}
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="capacity">Capacity (m³) *</Label>
            <Input
              id="capacity"
              type="number"
              placeholder="Enter capacity in cubic meters"
              value={formData.capacity}
              onChange={(e) => handleInputChange("capacity", e.target.value)}
              required
              disabled={isLoading}
              min="1"
            />
          </div>

          <div className="space-y-2">
            <Label htmlFor="description">Description</Label>
            <Textarea
              id="description"
              placeholder="Additional details about the godown"
              value={formData.description}
              onChange={(e) => handleInputChange("description", e.target.value)}
              rows={3}
              disabled={isLoading}
            />
          </div>

          <div className="flex gap-2">
            <Button type="submit" className="flex-1 bg-accent hover:bg-accent/90" disabled={isLoading}>
              <Plus className="mr-2 h-4 w-4" />
              {isLoading ? "Processing..." : editingGodown ? "Update Godown" : "Add Godown"}
            </Button>
            {editingGodown && onCancelEdit && (
              <Button type="button" variant="outline" onClick={onCancelEdit} disabled={isLoading}>
                Cancel
              </Button>
            )}
          </div>
        </form>
      </CardContent>
    </Card>
  )
}
