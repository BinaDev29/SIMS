import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"

const recentReturns = [
  {
    id: "RET-001",
    date: "2024-01-15",
    item: "Product A",
    customer: "Customer ABC",
    quantity: 2,
    reason: "Defective",
    condition: "Poor",
    status: "processed",
  },
  {
    id: "RET-002",
    date: "2024-01-14",
    item: "Product B",
    customer: "DEF Enterprises",
    quantity: 1,
    reason: "Wrong Item",
    condition: "New",
    status: "pending",
  },
  {
    id: "RET-003",
    date: "2024-01-13",
    item: "Product C",
    customer: "GHI Solutions",
    quantity: 3,
    reason: "Damaged",
    condition: "Damaged",
    status: "processed",
  },
]

export function ReturnsTable() {
  return (
    <Card>
      <CardHeader>
        <CardTitle className="font-[family-name:var(--font-space-grotesk)]">Recent Returns</CardTitle>
        <CardDescription>Latest return transactions</CardDescription>
      </CardHeader>
      <CardContent>
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>ID</TableHead>
              <TableHead>Date</TableHead>
              <TableHead>Item</TableHead>
              <TableHead>Customer</TableHead>
              <TableHead>Qty</TableHead>
              <TableHead>Reason</TableHead>
              <TableHead>Status</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {recentReturns.map((returnItem) => (
              <TableRow key={returnItem.id}>
                <TableCell className="font-medium">{returnItem.id}</TableCell>
                <TableCell>{returnItem.date}</TableCell>
                <TableCell>{returnItem.item}</TableCell>
                <TableCell>{returnItem.customer}</TableCell>
                <TableCell>{returnItem.quantity}</TableCell>
                <TableCell>{returnItem.reason}</TableCell>
                <TableCell>
                  <Badge variant={returnItem.status === "processed" ? "default" : "secondary"}>
                    {returnItem.status}
                  </Badge>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </CardContent>
    </Card>
  )
}
