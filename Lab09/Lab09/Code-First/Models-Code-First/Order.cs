using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab09
{
    public class Order
    {
        [Column("ID")]
        [Key]
        public int ID { get; set; }

        [Column("Order_price")]
        public int Order_price { get; set; }

        [Column("Date_of_order")]
        public DateTime Date_of_order { get; set; }
        [Column("PersonId")]
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        public override string ToString()
        {
            return $"Заказ \n{{ ID = {ID}, сумма заказа = {Order_price}, дата оформления = {Date_of_order}, ID Заказчика = {PersonId} }}";
        }

    }
}
