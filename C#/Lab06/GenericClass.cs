using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTi_day_10_task
{
    internal class GenericClass<Type>
    {
        Type x;

        public Type? Getter() => x;
        public void Setter(Type x) => this.x = x;
        public GenericClass(Type x) => this.x = x;
    }
}
