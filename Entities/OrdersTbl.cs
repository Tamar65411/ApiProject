using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities;

public partial class OrdersTbl
{
    public int OrderId { get; set; }

    public string OrderDate { get; set; } = null!;

    public int OrderSum { get; set; }

    public int? UserId { get; set; }
    
    public virtual ICollection<OrderItemTbl> OrderItemTbls { get; set; } = new List<OrderItemTbl>();
    
    public virtual UsersTbl? User { get; set; }
}
