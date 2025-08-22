"use client"

import { useState } from "react"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Textarea } from "@/components/ui/textarea"
import { Package, AlertCircle } from "lucide-react"
import { Alert, AlertDescription } from "@/components/ui/alert"
import { AuthService } from "@/lib/auth"

// Define a type-safe interface for the form data
interface InwardsFormData {
  transactionDate: string
  itemId: string
  supplierId: string
  godownId: string
  quantity: string
  unitPrice: string
  notes: string
}

export function InwardsForm() {
  const [formData, setFormData] = useState<InwardsFormData>({
    transactionDate: "",
    itemId: "",
    supplierId: "",
    godownId: "",
    quantity: "",
    unitPrice: "",
    notes: "",
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
      // Convert number fields to the correct type before sending
      const payload = {
        ...formData,
        quantity: Number.parseFloat(formData.quantity) || 0,
        unitPrice: Number.parseFloat(formData.unitPrice) || 0,
      }

      const response = await fetch("/api/inwards", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          ...AuthService.getAuthHeaders(),
        },
        body: JSON.stringify(payload),
      })

      const result = await response.json()

      if (result.success) {
        setSuccess(result.message || "Transaction recorded successfully!")
        setFormData({
          transactionDate: "",
          itemId: "",
          supplierId: "",
          godownId: "",
          quantity: "",
          unitPrice: "",
          notes: "",
        })
      } else {
        setError(result.message || "Failed to record transaction.")
      }
    } catch (error: unknown) {
      setError("Network error occurred: " + (error as Error).message)
    } finally {
      setIsLoading(false)
    }
  }

  const handleInputChange = (field: keyof InwardsFormData, value: string) => {
    setFormData((prev) => ({ ...prev, [field]: value }))
  }

  return (
    <Card>
      <CardHeader>
        <div className="flex items-center space-x-2">
          <Package className="h-5 w-5 text-accent" />
          <CardTitle className="font-[family-name:var(--font-space-grotesk)]">New Inward Transaction</CardTitle>
        </div>
        <CardDescription>Record items received from suppliers</CardDescription>
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
          <div className="grid gap-4 md:grid-cols-2">
            <div className="space-y-2">
              <Label htmlFor="transactionDate">Transaction Date</Label>
              <Input
                id="transactionDate"
                type="date"
                value={formData.transactionDate}
                onChange={(e) => handleInputChange("transactionDate", e.target.value)}
                required
                disabled={isLoading}
              />
            </div>
            <div className="space-y-2">
              <Label htmlFor="quantity">Quantity</Label>
              <Input
                id="quantity"
                type="number"
                placeholder="Enter quantity"
                value={formData.quantity}
                onChange={(e) => handleInputChange("quantity", e.target.value)}
                required
                disabled={isLoading}
              />
            </div>
          </div>

          <div className="space-y-2">
            <Label htmlFor="itemId">Item</Label>
            <Select value={formData.itemId} onValueChange={(value: string) => handleInputChange("itemId", value)}>
              <SelectTrigger>
                <SelectValue placeholder="Select an item" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="item1">Product A - Electronics</SelectItem>
                <SelectItem value="item2">Product B - Furniture</SelectItem>
                <SelectItem value="item3">Product C - Clothing</SelectItem>
              </SelectContent>
            </Select>
          </div>

          <div className="space-y-2">
            <Label htmlFor="supplierId">Supplier</Label>
            <Select value={formData.supplierId} onValueChange={(value: string) => handleInputChange("supplierId", value)}>
              <SelectTrigger>
                <SelectValue placeholder="Select a supplier" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="supplier1">Supplier XYZ Ltd.</SelectItem>
                <SelectItem value="supplier2">ABC Manufacturing</SelectItem>
                <SelectItem value="supplier3">Global Supplies Inc.</SelectItem>
              </SelectContent>
            </Select>
          </div>

          <div className="grid gap-4 md:grid-cols-2">
            <div className="space-y-2">
              <Label htmlFor="godownId">Godown</Label>
              <Select value={formData.godownId} onValueChange={(value: string) => handleInputChange("godownId", value)}>
                <SelectTrigger>
                  <SelectValue placeholder="Select godown" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="godown1">Warehouse A - Main</SelectItem>
                  <SelectItem value="godown2">Warehouse B - Secondary</SelectItem>
                  <SelectItem value="godown3">Warehouse C - Cold Storage</SelectItem>
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-2">
              <Label htmlFor="unitPrice">Unit Price</Label>
              <Input
                id="unitPrice"
                type="number"
                step="0.01"
                placeholder="0.00"
                value={formData.unitPrice}
                onChange={(e) => handleInputChange("unitPrice", e.target.value)}
                required
                disabled={isLoading}
              />
            </div>
          </div>

          <div className="space-y-2">
            <Label htmlFor="notes">Notes (Optional)</Label>
            <Textarea
              id="notes"
              placeholder="Additional notes about this transaction"
              value={formData.notes}
              onChange={(e) => handleInputChange("notes", e.target.value)}
              rows={3}
              disabled={isLoading}
            />
          </div>

          <Button type="submit" className="w-full bg-accent hover:bg-accent/90" disabled={isLoading}>
            {isLoading ? "Recording..." : "Record Inward Transaction"}
          </Button>
        </form>
      </CardContent>
    </Card>
  )
}