import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Package, ArrowDownToLine, ArrowUpFromLine, TrendingUp } from "lucide-react"

const stats = [
  {
    title: "Total In-Stock Items",
    value: "2,847",
    change: "+12%",
    changeType: "positive" as const,
    icon: Package,
    description: "Items currently in inventory",
  },
  {
    title: "Today's Inwards",
    value: "156",
    change: "+8%",
    changeType: "positive" as const,
    icon: ArrowDownToLine,
    description: "Items received today",
  },
  {
    title: "Today's Deliveries",
    value: "89",
    change: "-3%",
    changeType: "negative" as const,
    icon: ArrowUpFromLine,
    description: "Items delivered today",
  },
  {
    title: "Stock Value",
    value: "$124,580",
    change: "+15%",
    changeType: "positive" as const,
    icon: TrendingUp,
    description: "Total inventory value",
  },
]

export function DashboardStats() {
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
              <span>from yesterday</span>
            </div>
            <p className="text-xs text-muted-foreground mt-1">{stat.description}</p>
          </CardContent>
        </Card>
      ))}
    </div>
  )
}
