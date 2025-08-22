import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Warehouse, Package, AlertTriangle, TrendingUp } from "lucide-react"

const stats = [
  {
    title: "Total Godowns",
    value: "12",
    change: "+2",
    changeType: "positive" as const,
    icon: Warehouse,
    description: "Active warehouses",
  },
  {
    title: "Storage Capacity",
    value: "85,000",
    change: "+15%",
    changeType: "positive" as const,
    icon: Package,
    description: "Total cubic meters",
  },
  {
    title: "Capacity Used",
    value: "68%",
    change: "+5%",
    changeType: "positive" as const,
    icon: TrendingUp,
    description: "Current utilization",
  },
  {
    title: "Maintenance Due",
    value: "3",
    change: "-1",
    changeType: "positive" as const,
    icon: AlertTriangle,
    description: "Godowns needing service",
  },
]

export function GodownsStats() {
  return (
    <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
      {stats.map((stat) => (
        <Card key={stat.title}>
          <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
            <CardTitle className="text-sm font-medium text-muted-foreground">{stat.title}</CardTitle>
            <stat.icon className="h-4 w-4 text-muted-foreground" />
          </CardHeader>
          <CardContent>
            <div className="text-2xl font-bold font-[family-name:var(--font-space-grotesk)]">{stat.value}</div>
            <div className="flex items-center space-x-2 text-xs text-muted-foreground">
              <span className={`font-medium ${stat.changeType === "positive" ? "text-green-600" : "text-red-600"}`}>
                {stat.change}
              </span>
              <span>from last month</span>
            </div>
            <p className="text-xs text-muted-foreground mt-1">{stat.description}</p>
          </CardContent>
        </Card>
      ))}
    </div>
  )
}
