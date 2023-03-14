using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planemetry
{
    public abstract class Figure
    {
        protected List<double> borders { get; set; }
        public abstract double Area();
    }
}
