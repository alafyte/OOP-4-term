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
        Context _db;
        public PersonRepository(Context db)
        {
            _db = db;
            _db.People.Load();
        }
        public BindingList<Person> GetAll()
        {
            _db.SaveChanges();
            return _db.People.Local.ToBindingList();
        }
        public Person Get(int id)
        {
            _db.SaveChanges();
            return _db.People.Include(p => p.Orders).FirstOrDefault(p => p.ID == id);
        }
        public void Add(Person person)
        {
            _db.People.Add(person);
            _db.SaveChanges();
        }
        public void Update(Person person)
        {
            _db.Entry(person).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            var orders = _db.Orders.Where(o => o.PersonId == id);
            foreach (var o in orders)
                _db.Orders.Remove(o);
            _db.People.Remove(_db.People.Where(p => p.ID == id).Single());
            _db.SaveChanges();
        }
    }
}
