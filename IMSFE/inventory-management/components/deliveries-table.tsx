"use client"

import { useState, useEffect } from "react"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Button } from "@/components/ui/button"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import { Alert, AlertDescription } from "@/components/ui/alert"
import { Edit, Trash2, AlertCircle } from "lucide-react"
import { AuthService } from "@/lib/auth"

interface OutwardTransaction {
  id: number
  itemId: number
  customerId: number
  godownId: number
  quantity: number
  transactionDate: string
  notes?: string
  // Populated fields for display
  itemName?: string
  customerName?: string
  godownName?: string
}

interface DeliveriesTableProps {
  refreshTrigger?: number
  onEditTransaction?: (transaction: OutwardTransaction) => void
}

export function DeliveriesTable({ refreshTrigger, onEditTransaction }: DeliveriesTableProps) {
  const [transactions, setTransactions] = useState<OutwardTransaction[]>([])
  const [isLoading, setIsLoading] = useState(true)
  const [error, setError] = useState("")

  const fetchTransactions = async () => {
    try {
      setIsLoading(true)
      const response = await fetch("/api/outward-transactions", {
        headers: {
          ...AuthService.getAuthHeaders(),
        },
      })

      const result = await response.json()

      if (result.success) {
        setTransactions(result.data || [])
      } else {
        setError(result.message || "Failed to fetch transactions")
      }
    } catch { // Corrected catch block
      setError("Network error occurred")
    } finally {
      setIsLoading(false)
    }
  }

  const handleDeleteTransaction = async (transactionId: number) => {
    if (!confirm("Are you sure you want to delete this transaction?")) {
      return
    }

    try {
      const response = await fetch(`/api/outward-transactions/${transactionId}`, {
        method: "DELETE",
        headers: {
          ...AuthService.getAuthHeaders(),
        },
      })

      const result = await response.json()

      if (result.success) {
        setTransactions(transactions.filter((t) => t.id !== transactionId))
      } else {
        setError(result.message || "Failed to delete transaction")
      }
    } catch { // Corrected catch block
      setError("Network error occurred")
    }
  }

  useEffect(() => {
    fetchTransactions()
  }, [refreshTrigger])

  if (isLoading) {
    return (
      <Card>
        <CardContent className="p-6">
          <div className="text-center">
            <div className="animate-spin rounded-full h-8 w-8 border-b-2 border-accent mx-auto mb-4"></div>
            <p className="text-muted-foreground">Loading transactions...</p>
          </div>
        </CardContent>
      </Card>
    )
  }

  return (
    <Card>
      <CardHeader>
        <CardTitle className="font-[family-name:var(--font-space-grotesk)]">Outward Transactions</CardTitle>
        <CardDescription>Recent delivery transactions ({transactions.length} records)</CardDescription>
      </CardHeader>
      <CardContent>
        {error && (
          <Alert variant="destructive" className="mb-4">
            <AlertCircle className="h-4 w-4" />
            <AlertDescription>{error}</AlertDescription>
          </Alert>
        )}

        {transactions.length === 0 ? (
          <div className="text-center py-8">
            <p className="text-muted-foreground">
              No transactions found. Record your first outward transaction to get started.
            </p>
          </div>
        ) : (
          <Table>
            <TableHeader>
              <TableRow>
                <TableHead>ID</TableHead>
                <TableHead>Date</TableHead>
                <TableHead>Item</TableHead>
                <TableHead>Customer</TableHead>
                <TableHead>Godown</TableHead>
                <TableHead>Quantity</TableHead>
                <TableHead>Actions</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {transactions.map((transaction) => (
                <TableRow key={transaction.id}>
                  <TableCell className="font-medium">#{transaction.id}</TableCell>
                  <TableCell>{new Date(transaction.transactionDate).toLocaleDateString()}</TableCell>
                  <TableCell>{transaction.itemName || `Item #${transaction.itemId}`}</TableCell>
                  <TableCell>{transaction.customerName || `Customer #${transaction.customerId}`}</TableCell>
                  <TableCell>{transaction.godownName || `Godown #${transaction.godownId}`}</TableCell>
                  <TableCell>
                    <Badge variant="outline">{transaction.quantity}</Badge>
                  </TableCell>
                  <TableCell>
                    <div className="flex items-center space-x-2">
                      <Button variant="ghost" size="sm" onClick={() => onEditTransaction?.(transaction)}>
                        <Edit className="h-4 w-4" />
                      </Button>
                      <Button variant="ghost" size="sm" onClick={() => handleDeleteTransaction(transaction.id)}>
                        <Trash2 className="h-4 w-4" />
                      </Button>
                    </div>
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        )}
      </CardContent>
    </Card>
  )
}