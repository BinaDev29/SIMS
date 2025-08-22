"use client"

import { useState } from "react"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Textarea } from "@/components/ui/textarea"
import { RotateCcw, AlertCircle } from "lucide-react"
import { Alert, AlertDescription } from "@/components/ui/alert"
import { AuthService } from "@/lib/auth"

// Define a type-safe interface for the form data
interface ReturnsFormData {
  returnDate: string
  itemId: string
  customerId: string
  quantity: string
  reason: string
  condition: string
  notes: string
}

export function ReturnsForm() {
  const [formData, setFormData] = useState<ReturnsFormData>({
    returnDate: "",
    itemId: "",
    customerId: "",
    quantity: "",
    reason: "",
    condition: "",
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
        quantity: Number.parseInt(formData.quantity) || 0,
      }

      const response = await fetch("/api/returns", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          ...AuthService.getAuthHeaders(),
        },
        body: JSON.stringify(payload),
      })

      const result = await response.json()

      if (result.success) {
        setSuccess(result.message || "Return transaction processed successfully!")
        setFormData({
          returnDate: "",
          itemId: "",
          customerId: "",
          quantity: "",
          reason: "",
          condition: "",
          notes: "",
        })
      } else {
        setError(result.message || "Failed to process return.")
      }
    } catch (error: unknown) {
      setError("Network error occurred: " + (error as Error).message)
    } finally {
      setIsLoading(false)
    }
  }

  const handleInputChange = (field: keyof ReturnsFormData, value: string) => {
    setFormData((prev) => ({ ...prev, [field]: value }))
  }

  return (
    <Card>
      <CardHeader>
        <div className="flex items-center space-x-2">
          <RotateCcw className="h-5 w-5 text-accent" />
          <CardTitle className="font-[family-name:var(--font-space-grotesk)]">New Return Transaction</CardTitle>
        </div>
        <CardDescription>Process returned items from customers</CardDescription>
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
              <Label htmlFor="returnDate">Return Date</Label>
              <Input
                id="returnDate"
                type="date"
                value={formData.returnDate}
                onChange={(e) => handleInputChange("returnDate", e.target.value)}
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
              <SelectTrigger disabled={isLoading}>
                <SelectValue placeholder="Select returned item" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="item1">Product A - Electronics</SelectItem>
                <SelectItem value="item2">Product B - Furniture</SelectItem>
                <SelectItem value="item3">Product C - Clothing</SelectItem>
              </SelectContent>
            </Select>
          </div>

          <div className="space-y-2">
            <Label htmlFor="customerId">Customer</Label>
            <Select value={formData.customerId} onValueChange={(value: string) => handleInputChange("customerId", value)}>
              <SelectTrigger disabled={isLoading}>
                <SelectValue placeholder="Select customer" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="customer1">Customer ABC Corp.</SelectItem>
                <SelectItem value="customer2">DEF Enterprises</SelectItem>
                <SelectItem value="customer3">GHI Solutions Ltd.</SelectItem>
              </SelectContent>
            </Select>
          </div>

          <div className="grid gap-4 md:grid-cols-2">
            <div className="space-y-2">
              <Label htmlFor="reason">Return Reason</Label>
              <Select value={formData.reason} onValueChange={(value: string) => handleInputChange("reason", value)}>
                <SelectTrigger disabled={isLoading}>
                  <SelectValue placeholder="Select reason" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="defective">Defective Product</SelectItem>
                  <SelectItem value="wrong-item">Wrong Item Delivered</SelectItem>
                  <SelectItem value="damaged">Damaged in Transit</SelectItem>
                  <SelectItem value="not-needed">No Longer Needed</SelectItem>
                  <SelectItem value="other">Other</SelectItem>
                </SelectContent>
              </Select>
            </div>
            <div className="space-y-2">
              <Label htmlFor="condition">Item Condition</Label>
              <Select value={formData.condition} onValueChange={(value: string) => handleInputChange("condition", value)}>
                <SelectTrigger disabled={isLoading}>
                  <SelectValue placeholder="Select condition" />
                </SelectTrigger>
                <SelectContent>
                  <SelectItem value="new">Like New</SelectItem>
                  <SelectItem value="good">Good Condition</SelectItem>
                  <SelectItem value="fair">Fair Condition</SelectItem>
                  <SelectItem value="poor">Poor Condition</SelectItem>
                  <SelectItem value="damaged">Damaged</SelectItem>
                </SelectContent>
              </Select>
            </div>
          </div>

          <div className="space-y-2">
            <Label htmlFor="notes">Notes (Optional)</Label>
            <Textarea
              id="notes"
              placeholder="Additional details about the return"
              value={formData.notes}
              onChange={(e) => handleInputChange("notes", e.target.value)}
              rows={3}
              disabled={isLoading}
            />
          </div>

          <Button type="submit" className="w-full bg-accent hover:bg-accent/90" disabled={isLoading}>
            {isLoading ? "Processing..." : "Process Return"}
          </Button>
        </form>
      </CardContent>
    </Card>
  )
}