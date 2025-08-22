"use client"

import Link from "next/link"
import { Button } from "@/components/ui/button"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import { Separator } from "@/components/ui/separator"
import { ArrowLeft, Download, Mail, Printer } from "lucide-react"

interface InvoiceDetailProps {
  invoiceId: string
}

// Mock data - in real app this would come from API
const invoiceData = {
  id: "INV-2024-001",
  date: "2024-01-15",
  dueDate: "2024-02-15",
  status: "paid",
  customer: {
    name: "Customer ABC Corp.",
    address: "123 Business Street\nCity, State 12345\nCountry",
    email: "billing@abc-corp.com",
    phone: "+1 (555) 123-4567",
  },
  items: [
    {
      id: 1,
      description: "Product A - Electronics",
      quantity: 10,
      unitPrice: 125.0,
      total: 1250.0,
    },
    {
      id: 2,
      description: "Product B - Furniture",
      quantity: 5,
      unitPrice: 240.0,
      total: 1200.0,
    },
  ],
  subtotal: 2450.0,
  tax: 0.0,
  total: 2450.0,
  notes: "Thank you for your business!",
}

export function InvoiceDetail({ invoiceId }: InvoiceDetailProps) {
  const getStatusColor = (status: string) => {
    switch (status) {
      case "paid":
        return "bg-green-100 text-green-800"
      case "pending":
        return "bg-yellow-100 text-yellow-800"
      case "overdue":
        return "bg-red-100 text-red-800"
      default:
        return "bg-gray-100 text-gray-800"
    }
  }

  return (
    <div className="space-y-6">
      {/* Header */}
      <div className="flex items-center justify-between">
        <div className="flex items-center space-x-4">
          <Link href="/dashboard/invoices">
            <Button variant="ghost" size="sm">
              <ArrowLeft className="mr-2 h-4 w-4" />
              Back to Invoices
            </Button>
          </Link>
          <div>
            <h1 className="text-3xl font-bold text-foreground font-[family-name:var(--font-space-grotesk)]">
              {invoiceData.id}
            </h1>
            <p className="text-muted-foreground">Invoice details and line items</p>
          </div>
        </div>
        <div className="flex items-center space-x-2">
          <Button variant="outline" size="sm">
            <Mail className="mr-2 h-4 w-4" />
            Send
          </Button>
          <Button variant="outline" size="sm">
            <Printer className="mr-2 h-4 w-4" />
            Print
          </Button>
          <Button variant="outline" size="sm">
            <Download className="mr-2 h-4 w-4" />
            Download
          </Button>
        </div>
      </div>

      {/* Invoice Overview */}
      <div className="grid gap-6 md:grid-cols-2">
        <Card>
          <CardHeader>
            <CardTitle className="font-[family-name:var(--font-space-grotesk)]">Invoice Information</CardTitle>
          </CardHeader>
          <CardContent className="space-y-4">
            <div className="flex justify-between">
              <span className="text-muted-foreground">Invoice ID:</span>
              <span className="font-medium">{invoiceData.id}</span>
            </div>
            <div className="flex justify-between">
              <span className="text-muted-foreground">Invoice Date:</span>
              <span className="font-medium">{invoiceData.date}</span>
            </div>
            <div className="flex justify-between">
              <span className="text-muted-foreground">Due Date:</span>
              <span className="font-medium">{invoiceData.dueDate}</span>
            </div>
            <div className="flex justify-between">
              <span className="text-muted-foreground">Status:</span>
              <Badge className={getStatusColor(invoiceData.status)} variant="secondary">
                {invoiceData.status}
              </Badge>
            </div>
            <div className="flex justify-between">
              <span className="text-muted-foreground">Total Amount:</span>
              <span className="font-bold text-lg">${invoiceData.total.toFixed(2)}</span>
            </div>
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle className="font-[family-name:var(--font-space-grotesk)]">Customer Information</CardTitle>
          </CardHeader>
          <CardContent className="space-y-4">
            <div>
              <span className="text-muted-foreground">Name:</span>
              <p className="font-medium">{invoiceData.customer.name}</p>
            </div>
            <div>
              <span className="text-muted-foreground">Address:</span>
              <p className="font-medium whitespace-pre-line">{invoiceData.customer.address}</p>
            </div>
            <div>
              <span className="text-muted-foreground">Email:</span>
              <p className="font-medium">{invoiceData.customer.email}</p>
            </div>
            <div>
              <span className="text-muted-foreground">Phone:</span>
              <p className="font-medium">{invoiceData.customer.phone}</p>
            </div>
          </CardContent>
        </Card>
      </div>

      {/* Invoice Items */}
      <Card>
        <CardHeader>
          <CardTitle className="font-[family-name:var(--font-space-grotesk)]">Invoice Items</CardTitle>
          <CardDescription>Detailed breakdown of items and charges</CardDescription>
        </CardHeader>
        <CardContent>
          <Table>
            <TableHeader>
              <TableRow>
                <TableHead>Description</TableHead>
                <TableHead>Quantity</TableHead>
                <TableHead>Unit Price</TableHead>
                <TableHead className="text-right">Total</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {invoiceData.items.map((item) => (
                <TableRow key={item.id}>
                  <TableCell className="font-medium">{item.description}</TableCell>
                  <TableCell>{item.quantity}</TableCell>
                  <TableCell>${item.unitPrice.toFixed(2)}</TableCell>
                  <TableCell className="text-right">${item.total.toFixed(2)}</TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>

          <Separator className="my-4" />

          <div className="space-y-2">
            <div className="flex justify-between">
              <span className="text-muted-foreground">Subtotal:</span>
              <span>${invoiceData.subtotal.toFixed(2)}</span>
            </div>
            <div className="flex justify-between">
              <span className="text-muted-foreground">Tax:</span>
              <span>${invoiceData.tax.toFixed(2)}</span>
            </div>
            <Separator />
            <div className="flex justify-between text-lg font-bold">
              <span>Total:</span>
              <span>${invoiceData.total.toFixed(2)}</span>
            </div>
          </div>

          {invoiceData.notes && (
            <div className="mt-6 p-4 bg-muted rounded-lg">
              <h4 className="font-medium mb-2">Notes:</h4>
              <p className="text-muted-foreground">{invoiceData.notes}</p>
            </div>
          )}
        </CardContent>
      </Card>
    </div>
  )
}
