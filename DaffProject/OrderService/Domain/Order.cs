using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;

namespace OrderService.Domain
{
    public class Order
    {
        [Key]
        [Display(Name = "OrderId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderId { get; set; }


        public long OrderStatus { get; set; }

        //public long UserId { get; set; }

        ////[ForeignKey("UserId")]
        ////[DeleteBehavior(DeleteBehavior.NoAction)]
        public long User { get; set; }

        //public long ProductId { get; set; }

        //[ForeignKey("ProductId")]
        public long Product { get; set; }

        public long? ParentOrderId { get; set; }

        //public long Paymentd { get; set; }

        //[ForeignKey("PaymentId")]
        //[DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual long Payment { get; set; }

        public short OrderQuantity { get; set; }

        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }



    }
}
