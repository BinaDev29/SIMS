"use client"

import type React from "react"
import { useState, useEffect } from "react"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Textarea } from "@/components/ui/textarea"
import { Alert, AlertDescription } from "@/components/ui/alert"
import { Truck, AlertCircle } from "lucide-react"
import { AuthService } from "@/lib/auth"

interface OutwardTransactionFormData {
  itemId: number
  customerId: number
  godownId: number
  quantity: number
  transactionDate: string
  notes?: string
}

// Define specific interfaces for the API data
interface OutwardTransaction extends OutwardTransactionFormData {
  id: number
}

interface Customer {
  id: number
  name: string
  // ... other customer properties
}

interface Godown {
  id: number
  name: string
  // ... other godown properties
}

interface DeliveriesFormProps {
  onTransactionAdded?: () => void
  editingTransaction?: OutwardTransaction // Corrected type
  onCancelEdit?: () => void
}

export function DeliveriesForm({ onTransactionAdded, editingTransaction, onCancelEdit }: DeliveriesFormProps) {
  const [formData, setFormData] = useState<OutwardTransactionFormData>({
    itemId: editingTransaction?.itemId || 0,
    customerId: editingTransaction?.customerId || 0,
    godownId: editingTransaction?.godownId || 0,
    quantity: editingTransaction?.quantity || 0,
    transactionDate: editingTransaction?.transactionDate?.split("T")[0] || new Date().toISOString().split("T")[0],
    notes: editingTransaction?.notes || "",
  })
  const [isLoading, setIsLoading] = useState(false)
  const [error, setError] = useState("")
  const [success, setSuccess] = useState("")
  const [customers, setCustomers] = useState<Customer[]>([]) // Corrected type
  const [godowns, setGodowns] = useState<Godown[]>([]) // Corrected type

  useEffect(() => {
    const loadData = async () => {
      try {
        const [customersRes, godownsRes] = await Promise.all([
          fetch("/api/customers", { headers: AuthService.getAuthHeaders() }),
          fetch("/api/godowns", { headers: AuthService.getAuthHeaders() }),
        ])

        const customersData = await customersRes.json()
        const godownsData = await godownsRes.json()

        if (customersData.success) setCustomers(customersData.data || [])
        if (godownsData.success) setGodowns(godownsData.data || [])
      } catch { // Corrected catch block
        console.error("Failed to load dropdown data:")
      }
    }

    loadData()
  }, [])

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setIsLoading(true)
    setError("")
    setSuccess("")

    try {
      const url = editingTransaction
        ? `/api/outward-transactions/${editingTransaction.id}`
        : "/api/outward-transactions"
      const method = editingTransaction ? "PUT" : "POST"

      const payload = editingTransaction ? { id: editingTransaction.id, ...formData } : formData

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
        if (!editingTransaction) {
          setFormData({
            itemId: 0,
            customerId: 0,
            godownId: 0,
            quantity: 0,
            transactionDate: new Date().toISOString().split("T")[0],
            notes: "",
          })
        }
        onTransactionAdded?.()
        if (editingTransaction && onCancelEdit) {
          setTimeout(() => onCancelEdit(), 1000)
        }
      } else {
        setError(result.message || "Operation failed")
      }
    } catch { // Corrected catch block
      setError("Network error occurred")
    } finally {
      setIsLoading(false)
    }
  }

  const handleInputChange = (field: keyof OutwardTransactionFormData, value: string | number) => {
    setFormData((prev) => ({ ...prev, [field]: value }))
  }

  return (
    <Card>
      <CardHeader>
        <div className="flex items-center space-x-2">
          <Truck className="h-5 w-5 text-accent" />
          <CardTitle className="font-[family-name:var(--font-space-grotesk)]">
            {editingTransaction ? "Edit Outward Transaction" : "New Outward Transaction"}
          </CardTitle>
        </div>
        <CardDescription>
          {editingTransaction ? "Update outward transaction details" : "Record items delivered to customers"}
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
          <div className="grid gap-4 md:grid-cols-2">
            <div className="space-y-2">
              <Label htmlFor="transactionDate">Transaction Date *</Label>
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
              <Label htmlFor="quantity">Quantity *</Label>
              <Input
                id="quantity"
                type="number"
                placeholder="Enter quantity"
                value={formData.quantity || ""}
                onChange={(e) => handleInputChange("quantity", Number.parseInt(e.target.value) || 0)}
                required
                disabled={isLoading}
                min="1"
              />
            </div>
          </div>

          <div className="space-y-2">
            <Label htmlFor="itemId">Item *</Label>
            <Select
              value={formData.itemId.toString()}
              onValueChange={(value: string) => handleInputChange("itemId", Number.parseInt(value))} // Corrected type
              disabled={isLoading}
            >
              <SelectTrigger>
                <SelectValue placeholder="Select an item" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="1">Product A - Electronics</SelectItem>
                <SelectItem value="2">Product B - Furniture</SelectItem>
                <SelectItem value="3">Product C - Clothing</SelectItem>
                <SelectItem value="4">Product D - Books</SelectItem>
              </SelectContent>
            </Select>
          </div>

          <div className="space-y-2">
            <Label htmlFor="customerId">Customer *</Label>
            <Select
              value={formData.customerId.toString()}
              onValueChange={(value: string) => handleInputChange("customerId", Number.parseInt(value))} // Corrected type
              disabled={isLoading}
            >
              <SelectTrigger>
                <SelectValue placeholder="Select a customer" />
              </SelectTrigger>
              <SelectContent>
                {customers.map((customer) => (
                  <SelectItem key={customer.id} value={customer.id.toString()}>
                    {customer.name}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>
          </div>

          <div className="space-y-2">
            <Label htmlFor="godownId">Source Godown *</Label>
            <Select
              value={formData.godownId.toString()}
              onValueChange={(value: string) => handleInputChange("godownId", Number.parseInt(value))} // Corrected type
              disabled={isLoading}
            >
              <SelectTrigger>
                <SelectValue placeholder="Select source godown" />
              </SelectTrigger>
              <SelectContent>
                {godowns.map((godown) => (
                  <SelectItem key={godown.id} value={godown.id.toString()}>
                    {godown.name}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>
          </div>

          <div className="space-y-2">
            <Label htmlFor="notes">Notes</Label>
            <Textarea
              id="notes"
              placeholder="Additional notes about this transaction"
              value={formData.notes}
              onChange={(e) => handleInputChange("notes", e.target.value)}
              rows={3}
              disabled={isLoading}
            />
          </div>

          <div className="flex gap-2">
            <Button type="submit" className="flex-1 bg-accent hover:bg-accent/90" disabled={isLoading}>
              {isLoading ? "Processing..." : editingTransaction ? "Update Transaction" : "Record Transaction"}
            </Button>
            {editingTransaction && onCancelEdit && (
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