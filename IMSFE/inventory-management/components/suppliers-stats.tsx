import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Truck, UserPlus, Star, TrendingUp } from "lucide-react"

const stats = [
  {
    title: "Total Suppliers",
    value: "247",
    change: "+8%",
    changeType: "positive" as const,
    icon: Truck,
    description: "Active suppliers",
  },
  {
    title: "New This Month",
    value: "12",
    change: "+25%",
    changeType: "positive" as const,
    icon: UserPlus,
    description: "New partnerships",
  },
  {
    title: "Preferred Suppliers",
    value: "45",
    change: "+12%",
    changeType: "positive" as const,
    icon: Star,
    description: "Top-rated suppliers",
  },
  {
    title: "Supplier Growth",
    value: "8.5%",
    change: "+1.2%",
    changeType: "positive" as const,
    icon: TrendingUp,
    description: "Monthly growth rate",
  },
]

export function SuppliersStats() {
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
