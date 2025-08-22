"use client"

import type React from "react"

import { useState } from "react"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Textarea } from "@/components/ui/textarea"
import { Package } from "lucide-react"

export function InwardsForm() {
  const [formData, setFormData] = useState({
    transactionDate: "",
    itemId: "",
    supplierId: "",
    godownId: "",
    quantity: "",
    unitPrice: "",
    notes: "",
  })

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    console.log("Inwards transaction:", formData)
    // TODO: Implement API call
  }

  const handleInputChange = (field: string, value: string) => {
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
            <Select value={formData.supplierId} onValueChange={(value) => handleInputChange("supplierId", value)}>
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
              <Select value={formData.godownId} onValueChange={(value) => handleInputChange("godownId", value)}>
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
            />
          </div>

          <Button type="submit" className="w-full bg-accent hover:bg-accent/90">
            Record Inward Transaction
          </Button>
        </form>
      </CardContent>
    </Card>
  )
}
