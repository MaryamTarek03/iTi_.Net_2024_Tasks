using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTi_day_10_task
{
    internal class InterfaceChild : IInteract, ITalk
    {
        public void Interact() => Console.WriteLine("I interacted with something");
        public void Pick() => Console.WriteLine("I picked up something");

        public void SayBye() => Console.WriteLine("GoodBye!");
        public void SayHello() => Console.WriteLine("Hello there!");
    }
}
