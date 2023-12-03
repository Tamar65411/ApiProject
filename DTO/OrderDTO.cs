using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        public string OrderDate { get; set; } = null!;

        public int OrderSum { get; set; }

        public int? UserId { get; set; }


        public virtual ICollection<OrderItemDTO> OrderItemTbls { get; set; } = new List<OrderItemDTO>();





    }

   
        



}

