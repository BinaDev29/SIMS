import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"

const recentInwards = [
  {
    id: "INW-001",
    date: "2024-01-15",
    item: "Product A",
    supplier: "Supplier XYZ",
    quantity: 50,
    unitPrice: 25.0,
    total: 1250.0,
    status: "completed",
  },
  {
    id: "INW-002",
    date: "2024-01-14",
    item: "Product B",
    supplier: "ABC Manufacturing",
    quantity: 30,
    unitPrice: 45.0,
    total: 1350.0,
    status: "completed",
  },
  {
    id: "INW-003",
    date: "2024-01-14",
    item: "Product C",
    supplier: "Global Supplies",
    quantity: 75,
    unitPrice: 15.0,
    total: 1125.0,
    status: "pending",
  },
]

export function InwardsTable() {
  return (
    <Card>
      <CardHeader>
        <CardTitle className="font-[family-name:var(--font-space-grotesk)]">Recent Inwards</CardTitle>
        <CardDescription>Latest inward transactions</CardDescription>
      </CardHeader>
      <CardContent>
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>ID</TableHead>
              <TableHead>Date</TableHead>
              <TableHead>Item</TableHead>
              <TableHead>Supplier</TableHead>
              <TableHead>Qty</TableHead>
              <TableHead>Total</TableHead>
              <TableHead>Status</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {recentInwards.map((inward) => (
              <TableRow key={inward.id}>
                <TableCell className="font-medium">{inward.id}</TableCell>
                <TableCell>{inward.date}</TableCell>
                <TableCell>{inward.item}</TableCell>
                <TableCell>{inward.supplier}</TableCell>
                <TableCell>{inward.quantity}</TableCell>
                <TableCell>${inward.total.toFixed(2)}</TableCell>
                <TableCell>
                  <Badge variant={inward.status === "completed" ? "default" : "secondary"}>{inward.status}</Badge>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </CardContent>
    </Card>
  )
}
