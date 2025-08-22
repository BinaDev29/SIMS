"use client"

import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Button } from "@/components/ui/button"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import { Edit, Trash2, AlertTriangle } from "lucide-react"

const items = [
  {
    id: "ITM-001",
    name: "Product A",
    description: "High-quality electronics item",
    category: "Electronics",
    unitPrice: 125.0,
    currentStock: 45,
    minStockLevel: 10,
    unit: "pieces",
    status: "in-stock",
  },
  {
    id: "ITM-002",
    name: "Product B",
    description: "Premium furniture piece",
    category: "Furniture",
    unitPrice: 240.0,
    currentStock: 8,
    minStockLevel: 15,
    unit: "pieces",
    status: "low-stock",
  },
  {
    id: "ITM-003",
    name: "Product C",
    description: "Fashionable clothing item",
    category: "Clothing",
    unitPrice: 45.0,
    currentStock: 0,
    minStockLevel: 20,
    unit: "pieces",
    status: "out-of-stock",
  },
  {
    id: "ITM-004",
    name: "Product D",
    description: "Educational book collection",
    category: "Books",
    unitPrice: 25.0,
    currentStock: 120,
    minStockLevel: 30,
    unit: "pieces",
    status: "in-stock",
  },
  {
    id: "ITM-005",
    name: "Product E",
    description: "Professional tool set",
    category: "Tools",
    unitPrice: 85.0,
    currentStock: 5,
    minStockLevel: 10,
    unit: "sets",
    status: "low-stock",
  },
]

const getStatusColor = (status: string) => {
  switch (status) {
    case "in-stock":
      return "bg-green-100 text-green-800"
    case "low-stock":
      return "bg-yellow-100 text-yellow-800"
    case "out-of-stock":
      return "bg-red-100 text-red-800"
    default:
      return "bg-gray-100 text-gray-800"
  }
}

export function ItemsTable() {
  return (
    <Card>
      <CardHeader>
        <CardTitle className="font-[family-name:var(--font-space-grotesk)]">All Items</CardTitle>
        <CardDescription>Complete inventory item list with stock levels</CardDescription>
      </CardHeader>
      <CardContent>
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>Item ID</TableHead>
              <TableHead>Name</TableHead>
              <TableHead>Category</TableHead>
              <TableHead>Unit Price</TableHead>
              <TableHead>Current Stock</TableHead>
              <TableHead>Status</TableHead>
              <TableHead>Actions</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {items.map((item) => (
              <TableRow key={item.id}>
                <TableCell className="font-medium">{item.id}</TableCell>
                <TableCell>
                  <div>
                    <div className="font-medium">{item.name}</div>
                    <div className="text-sm text-muted-foreground">{item.description}</div>
                  </div>
                </TableCell>
                <TableCell>{item.category}</TableCell>
                <TableCell>${item.unitPrice.toFixed(2)}</TableCell>
                <TableCell>
                  <div className="flex items-center space-x-2">
                    <span>
                      {item.currentStock} {item.unit}
                    </span>
                    {item.currentStock <= item.minStockLevel && <AlertTriangle className="h-4 w-4 text-yellow-600" />}
                  </div>
                </TableCell>
                <TableCell>
                  <Badge className={getStatusColor(item.status)} variant="secondary">
                    {item.status.replace("-", " ")}
                  </Badge>
                </TableCell>
                <TableCell>
                  <div className="flex items-center space-x-2">
                    <Button variant="ghost" size="sm">
                      <Edit className="h-4 w-4" />
                    </Button>
                    <Button variant="ghost" size="sm">
                      <Trash2 className="h-4 w-4" />
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
