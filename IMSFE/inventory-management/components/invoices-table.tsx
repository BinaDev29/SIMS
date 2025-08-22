"use client"

import Link from "next/link"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Button } from "@/components/ui/button"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import { Eye, Download } from "lucide-react"

const invoices = [
  {
    id: "INV-2024-001",
    date: "2024-01-15",
    customer: "Customer ABC Corp.",
    totalAmount: 2450.0,
    status: "paid",
    dueDate: "2024-02-15",
  },
  {
    id: "INV-2024-002",
    date: "2024-01-14",
    customer: "DEF Enterprises",
    totalAmount: 1875.0,
    status: "pending",
    dueDate: "2024-02-14",
  },
  {
    id: "INV-2024-003",
    date: "2024-01-13",
    customer: "GHI Solutions Ltd.",
    totalAmount: 3200.0,
    status: "paid",
    dueDate: "2024-02-13",
  },
  {
    id: "INV-2024-004",
    date: "2024-01-12",
    customer: "JKL Manufacturing",
    totalAmount: 1650.0,
    status: "overdue",
    dueDate: "2024-01-12",
  },
  {
    id: "INV-2024-005",
    date: "2024-01-11",
    customer: "MNO Trading Co.",
    totalAmount: 2890.0,
    status: "pending",
    dueDate: "2024-02-11",
  },
]

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

export function InvoicesTable() {
  return (
    <Card>
      <CardHeader>
        <CardTitle className="font-[family-name:var(--font-space-grotesk)]">All Invoices</CardTitle>
        <CardDescription>Complete list of system invoices</CardDescription>
      </CardHeader>
      <CardContent>
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>Invoice ID</TableHead>
              <TableHead>Date</TableHead>
              <TableHead>Customer</TableHead>
              <TableHead>Total Amount</TableHead>
              <TableHead>Due Date</TableHead>
              <TableHead>Status</TableHead>
              <TableHead>Actions</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {invoices.map((invoice) => (
              <TableRow key={invoice.id}>
                <TableCell className="font-medium">{invoice.id}</TableCell>
                <TableCell>{invoice.date}</TableCell>
                <TableCell>{invoice.customer}</TableCell>
                <TableCell>${invoice.totalAmount.toFixed(2)}</TableCell>
                <TableCell>{invoice.dueDate}</TableCell>
                <TableCell>
                  <Badge className={getStatusColor(invoice.status)} variant="secondary">
                    {invoice.status}
                  </Badge>
                </TableCell>
                <TableCell>
                  <div className="flex items-center space-x-2">
                    <Link href={`/dashboard/invoices/${invoice.id}`}>
                      <Button variant="ghost" size="sm">
                        <Eye className="h-4 w-4" />
                      </Button>
                    </Link>
                    <Button variant="ghost" size="sm">
                      <Download className="h-4 w-4" />
                    </Button>
                  </div>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </CardContent>
    </Card>
  )
}
