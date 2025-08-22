"use client"

import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Button } from "@/components/ui/button"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import { Edit, Trash2, Mail, Phone } from "lucide-react"

const suppliers = [
  {
    id: "SUPP-001",
    companyName: "Supplier XYZ Ltd.",
    contactPerson: "David Chen",
    email: "david@xyz-ltd.com",
    phone: "+1 (555) 987-6543",
    address: "789 Supply Chain Ave, Industrial City",
    supplierType: "manufacturer",
    paymentTerms: "net-30",
    totalOrders: 78,
    rating: 4.8,
  },
  {
    id: "SUPP-002",
    companyName: "ABC Manufacturing",
    contactPerson: "Maria Garcia",
    email: "maria@abc-mfg.com",
    phone: "+1 (555) 876-5432",
    address: "456 Factory Rd, Manufacturing Hub",
    supplierType: "manufacturer",
    paymentTerms: "net-60",
    totalOrders: 92,
    rating: 4.6,
  },
  {
    id: "SUPP-003",
    companyName: "Global Supplies Inc.",
    contactPerson: "Robert Taylor",
    email: "robert@global-sup.com",
    phone: "+1 (555) 765-4321",
    address: "123 Distribution Blvd, Logistics Center",
    supplierType: "distributor",
    paymentTerms: "net-30",
    totalOrders: 156,
    rating: 4.9,
  },
  {
    id: "SUPP-004",
    companyName: "Premium Wholesale Co.",
    contactPerson: "Jennifer Lee",
    email: "jennifer@premium-wh.com",
    phone: "+1 (555) 654-3210",
    address: "321 Wholesale St, Commerce District",
    supplierType: "wholesaler",
    paymentTerms: "cod",
    totalOrders: 43,
    rating: 4.3,
  },
]

const getSupplierTypeColor = (type: string) => {
  switch (type) {
    case "manufacturer":
      return "bg-blue-100 text-blue-800"
    case "distributor":
      return "bg-green-100 text-green-800"
    case "wholesaler":
      return "bg-purple-100 text-purple-800"
    case "service":
      return "bg-orange-100 text-orange-800"
    default:
      return "bg-gray-100 text-gray-800"
  }
}

export function SuppliersTable() {
  return (
    <Card>
      <CardHeader>
        <CardTitle className="font-[family-name:var(--font-space-grotesk)]">All Suppliers</CardTitle>
        <CardDescription>Complete supplier database</CardDescription>
      </CardHeader>
      <CardContent>
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>Supplier ID</TableHead>
              <TableHead>Company</TableHead>
              <TableHead>Contact</TableHead>
              <TableHead>Type</TableHead>
              <TableHead>Payment Terms</TableHead>
              <TableHead>Orders</TableHead>
              <TableHead>Rating</TableHead>
              <TableHead>Actions</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {suppliers.map((supplier) => (
              <TableRow key={supplier.id}>
                <TableCell className="font-medium">{supplier.id}</TableCell>
                <TableCell>
                  <div>
                    <div className="font-medium">{supplier.companyName}</div>
                    <div className="text-sm text-muted-foreground">{supplier.address}</div>
                  </div>
                </TableCell>
                <TableCell>
                  <div>
                    <div className="font-medium">{supplier.contactPerson}</div>
                    <div className="text-sm text-muted-foreground flex items-center space-x-2">
                      <Mail className="h-3 w-3" />
                      <span>{supplier.email}</span>
                    </div>
                    <div className="text-sm text-muted-foreground flex items-center space-x-2">
                      <Phone className="h-3 w-3" />
                      <span>{supplier.phone}</span>
                    </div>
                  </div>
                </TableCell>
                <TableCell>
                  <Badge className={getSupplierTypeColor(supplier.supplierType)} variant="secondary">
                    {supplier.supplierType.toUpperCase()}
                  </Badge>
                </TableCell>
                <TableCell>{supplier.paymentTerms.toUpperCase()}</TableCell>
                <TableCell>{supplier.totalOrders}</TableCell>
                <TableCell>
                  <div className="flex items-center space-x-1">
                    <span className="font-medium">{supplier.rating}</span>
                    <span className="text-yellow-500">★</span>
                  </div>
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
