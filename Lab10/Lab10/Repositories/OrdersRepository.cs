using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class OrdersRepository : IRepository<Order>
    {
        Context db = new Context();
        public OrdersRepository()
        {
            db.Orders.Load();
        }
        public BindingList<Order> GetAll()
        {
            db.SaveChanges();
            return db.Orders.Local.ToBindingList();
        }
        public Order Get(int id)
        {
            db.SaveChanges();
            return db.Orders.FirstOrDefault(o => o.ID == id);
        }
        public void Add(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }
        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            db.Orders.Remove(db.Orders.Where(o => o.ID == id).Single());
            db.SaveChanges();
        }
    }
}

