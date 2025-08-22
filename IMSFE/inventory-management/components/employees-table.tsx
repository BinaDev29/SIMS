"use client"

import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Button } from "@/components/ui/button"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import { Edit, Trash2, Mail, Phone } from "lucide-react"

const employees = [
  {
    id: "EMP-001",
    firstName: "John",
    lastName: "Smith",
    email: "john.smith@company.com",
    phone: "+1 (555) 123-4567",
    position: "Manager",
    department: "Warehouse",
    hireDate: "2022-03-15",
    salary: 65000,
    status: "active",
  },
  {
    id: "EMP-002",
    firstName: "Sarah",
    lastName: "Johnson",
    email: "sarah.johnson@company.com",
    phone: "+1 (555) 234-5678",
    position: "Supervisor",
    department: "Logistics",
    hireDate: "2021-08-22",
    salary: 55000,
    status: "active",
  },
  {
    id: "EMP-003",
    firstName: "Mike",
    lastName: "Wilson",
    email: "mike.wilson@company.com",
    phone: "+1 (555) 345-6789",
    position: "Warehouse Worker",
    department: "Warehouse",
    hireDate: "2023-01-10",
    salary: 42000,
    status: "on-leave",
  },
  {
    id: "EMP-004",
    firstName: "Lisa",
    lastName: "Brown",
    email: "lisa.brown@company.com",
    phone: "+1 (555) 456-7890",
    position: "Accountant",
    department: "Finance",
    hireDate: "2020-11-05",
    salary: 58000,
    status: "active",
  },
  {
    id: "EMP-005",
    firstName: "David",
    lastName: "Chen",
    email: "david.chen@company.com",
    phone: "+1 (555) 567-8901",
    position: "Driver",
    department: "Logistics",
    hireDate: "2022-07-18",
    salary: 45000,
    status: "active",
  },
]

const getStatusColor = (status: string) => {
  switch (status) {
    case "active":
      return "bg-green-100 text-green-800"
    case "on-leave":
      return "bg-yellow-100 text-yellow-800"
    case "inactive":
      return "bg-red-100 text-red-800"
    default:
      return "bg-gray-100 text-gray-800"
  }
}

const getDepartmentColor = (department: string) => {
  switch (department) {
    case "Warehouse":
      return "bg-blue-100 text-blue-800"
    case "Logistics":
      return "bg-purple-100 text-purple-800"
    case "Finance":
      return "bg-green-100 text-green-800"
    case "Administration":
      return "bg-orange-100 text-orange-800"
    case "Sales":
      return "bg-pink-100 text-pink-800"
    case "HR":
      return "bg-indigo-100 text-indigo-800"
    default:
      return "bg-gray-100 text-gray-800"
  }
}

export function EmployeesTable() {
  return (
    <Card>
      <CardHeader>
        <CardTitle className="font-[family-name:var(--font-space-grotesk)]">All Employees</CardTitle>
        <CardDescription>Complete employee database</CardDescription>
      </CardHeader>
      <CardContent>
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>Employee ID</TableHead>
              <TableHead>Name</TableHead>
              <TableHead>Contact</TableHead>
              <TableHead>Position</TableHead>
              <TableHead>Department</TableHead>
              <TableHead>Hire Date</TableHead>
              <TableHead>Status</TableHead>
              <TableHead>Actions</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {employees.map((employee) => (
              <TableRow key={employee.id}>
                <TableCell className="font-medium">{employee.id}</TableCell>
                <TableCell>
                  <div>
                    <div className="font-medium">
                      {employee.firstName} {employee.lastName}
                    </div>
                    <div className="text-sm text-muted-foreground">${employee.salary.toLocaleString()}/year</div>
                  </div>
                </TableCell>
                <TableCell>
                  <div>
                    <div className="text-sm text-muted-foreground flex items-center space-x-2">
                      <Mail className="h-3 w-3" />
                      <span>{employee.email}</span>
                    </div>
                    <div className="text-sm text-muted-foreground flex items-center space-x-2">
                      <Phone className="h-3 w-3" />
                      <span>{employee.phone}</span>
                    </div>
                  </div>
                </TableCell>
                <TableCell>{employee.position}</TableCell>
                <TableCell>
                  <Badge className={getDepartmentColor(employee.department)} variant="secondary">
                    {employee.department}
                  </Badge>
                </TableCell>
                <TableCell>{employee.hireDate}</TableCell>
                <TableCell>
                  <Badge className={getStatusColor(employee.status)} variant="secondary">
                    {employee.status.replace("-", " ")}
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
