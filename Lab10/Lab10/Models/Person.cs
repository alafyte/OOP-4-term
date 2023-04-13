using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Person
    {
        public Person()
        {
            Orders = new HashSet<Order>();
        }
        [Column("ID")]
        [Key]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Phone")]
        [Phone]
        public string Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


        public override string ToString()
        {
            return $"Клиент \n{{ ID = {ID}, ФИО = {Name}, Ттелефон = {Phone} }}";
        }
    }
}
