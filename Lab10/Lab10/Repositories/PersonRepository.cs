using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class PersonRepository : IRepository<Person>
    {
        Context db = new Context();
        public PersonRepository()
        {
            db.People.Load();
        }
        public BindingList<Person> GetAll()
        {
            db.SaveChanges();
            return db.People.Local.ToBindingList();
        }
        public Person Get(int id)
        {
            db.SaveChanges();
            return db.People.Include(p => p.Orders).FirstOrDefault(p => p.ID == id);
        }
        public void Add(Person person)
        {
            db.People.Add(person);
            db.SaveChanges();
        }
        public void Update(Person person)
        {
            db.Entry(person).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var orders = db.Orders.Where(o => o.PersonId == id);
            foreach (var o in orders)
                db.Orders.Remove(o);
            db.People.Remove(db.People.Where(p => p.ID == id).Single());
            db.SaveChanges();
        }
    }
}
