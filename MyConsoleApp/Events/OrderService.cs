using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Events
{
    public class OrderService
    {
        public event EventHandler orderPlaced;

        public void PlaceOrder()
        {
            Console.WriteLine("Order placed successfully.");
            OnOrderPlaced();
        }

        protected virtual void OnOrderPlaced()
        {
            orderPlaced?.Invoke(this, EventArgs.Empty);
        }
    }
}
