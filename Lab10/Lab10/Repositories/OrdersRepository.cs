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
        Context _db;
        public OrdersRepository(Context db)
        {
            _db = db;
            _db.Orders.Load();
        }
        public BindingList<Order> GetAll()
        {
            _db.SaveChanges();
            return _db.Orders.Local.ToBindingList();
        }
        public Order Get(int id)
        {
            _db.SaveChanges();
            return _db.Orders.FirstOrDefault(o => o.ID == id);
        }
        public void Add(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
        }
        public void Update(Order order)
        {
            _db.Entry(order).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            _db.Orders.Remove(_db.Orders.Where(o => o.ID == id).Single());
            _db.SaveChanges();
        }
    }
}

