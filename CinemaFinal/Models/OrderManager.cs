using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CinemaFinal.Models
{
    public class OrderManager
    {
        private CinemaFinalDBContext DB = new CinemaFinalDBContext();

        public List<Order> GetAllOrders()
        {
            return DB.Orders.ToList();
        }

        public List<Order> GetOrdersByUser(int userId)
        {
            var query = from p in DB.Orders
                        where p.UserId == userId
                        select new
                        {
                            p.OrderDate,
                            p.NumOfTickets,
                            p.BookedSeats,
                        };
            List<Order> orders = new List<Order>();
            foreach (var p in query.ToList())
            {
                Order mo = new Order
                {
                    OrderDate = p.OrderDate,
                    NumOfTickets = p.NumOfTickets,
                    BookedSeats = p.BookedSeats
                };
                orders.Add(mo);
            }

            return orders;
        }
        public void AddOrder(Order o)
        {
            DB.Orders.Add(o);
            DB.SaveChanges();
        }
        public void EditOrder(Order o)
        {
            DB.Entry(o).State = EntityState.Modified;
            DB.SaveChanges();
        }
        
        public void OrderDetails(Order o)
        {
            DB.Entry(o).State = EntityState.Modified;
            DB.SaveChanges();
        }
        public Order GetOrderById(int id)
        {
            Order o = DB.Orders.Find(id);
            return o;
        }
        public void RemoveOrder(Order o)
        {
            DB.Orders.Remove(o);
            DB.SaveChanges();
        }

    }
    
}

    