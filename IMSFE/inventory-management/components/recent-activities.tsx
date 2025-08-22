import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { ArrowDownToLine, ArrowUpFromLine, RotateCcw, FileText } from "lucide-react"

const activities = [
  {
    id: 1,
    type: "inward",
    description: "Received 50 units of Product A from Supplier XYZ",
    time: "2 hours ago",
    status: "completed",
    icon: ArrowDownToLine,
  },
  {
    id: 2,
    type: "delivery",
    description: "Delivered 25 units of Product B to Customer ABC",
    time: "4 hours ago",
    status: "completed",
    icon: ArrowUpFromLine,
  },
  {
    id: 3,
    type: "return",
    description: "Return processed for 5 units of Product C",
    time: "6 hours ago",
    status: "pending",
    icon: RotateCcw,
  },
  {
    id: 4,
    type: "invoice",
    description: "Invoice #INV-2024-001 generated for Customer DEF",
    time: "8 hours ago",
    status: "completed",
    icon: FileText,
  },
  {
    id: 5,
    type: "inward",
    description: "Received 100 units of Product D from Supplier PQR",
    time: "1 day ago",
    status: "completed",
    icon: ArrowDownToLine,
  },
]

const getStatusColor = (status: string) => {
  switch (status) {
    case "completed":
      return "bg-green-100 text-green-800"
    case "pending":
      return "bg-yellow-100 text-yellow-800"
    case "failed":
      return "bg-red-100 text-red-800"
    default:
      return "bg-gray-100 text-gray-800"
  }
}

export function RecentActivities() {
  return (
    <Card>
      <CardHeader>
        <CardTitle className="font-[family-name:var(--font-space-grotesk)]">Recent Activities</CardTitle>
        <CardDescription>Latest transactions and system activities</CardDescription>
      </CardHeader>
      <CardContent>
        <div className="space-y-4">
          {activities.map((activity) => (
            <div key={activity.id} className="flex items-start space-x-4 p-3 rounded-lg hover:bg-muted/50">
              <div className="p-2 bg-accent/10 rounded-full">
                <activity.icon className="h-4 w-4 text-accent" />
              </div>
              <div className="flex-1 min-w-0">
                <p className="text-sm font-medium text-foreground">{activity.description}</p>
                <p className="text-xs text-muted-foreground">{activity.time}</p>
              </div>
              <Badge className={getStatusColor(activity.status)} variant="secondary">
                {activity.status}
              </Badge>
            </div>
          ))}
        </div>
      </CardContent>
    </Card>
  )
}
