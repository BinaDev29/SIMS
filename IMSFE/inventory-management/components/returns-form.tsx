"use client"

import type React from "react"

import { useState } from "react"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Textarea } from "@/components/ui/textarea"
import { RotateCcw } from "lucide-react"

export function ReturnsForm() {
  const [formData, setFormData] = useState({
    returnDate: "",
    itemId: "",
    customerId: "",
    quantity: "",
    reason: "",
    condition: "",
    notes: "",
  })

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    console.log("Return transaction:", formData)
    // TODO: Implement API call
  }

  const handleInputChange = (field: string, value: string) => {
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
              />
            </div>
          </div>

          <div className="space-y-2">
            <Label htmlFor="itemId">Item</Label>
            <Select value={formData.itemId} onValueChange={(value) => handleInputChange("itemId", value)}>
              <SelectTrigger>
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
            <Select value={formData.customerId} onValueChange={(value) => handleInputChange("customerId", value)}>
              <SelectTrigger>
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
              <Select value={formData.reason} onValueChange={(value) => handleInputChange("reason", value)}>
                <SelectTrigger>
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
              <Select value={formData.condition} onValueChange={(value) => handleInputChange("condition", value)}>
                <SelectTrigger>
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
            />
          </div>

          <Button type="submit" className="w-full bg-accent hover:bg-accent/90">
            Process Return
          </Button>
        </form>
      </CardContent>
    </Card>
  )
}
