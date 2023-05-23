using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class DatabaseUnit
    {
        private Context db = new Context();
        private PersonRepository peopleRepository;
        private OrdersRepository ordersRepository;
       
        public Database Database
        {
            get
            {
                return db.Database;
            }
        }
        public PersonRepository People
        {
 
            get
            {
                if (peopleRepository == null)
                {
                    peopleRepository = new PersonRepository(db);
                }
                return peopleRepository;
            }
        }
        public OrdersRepository Orders
        {
            get
            {
                if (ordersRepository == null)
                {
                    ordersRepository = new OrdersRepository(db);
                }
                return ordersRepository;
            }
        }
        public void Save()
        { 
            db.SaveChanges(); 
        }
        public Task<int> SaveAsync()
        {
            return db.SaveChangesAsync();
        }

    }
}
