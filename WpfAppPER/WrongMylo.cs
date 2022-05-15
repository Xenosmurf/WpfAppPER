using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppPER
{
    class WrongMylo : Exception
    {
        public WrongMylo() { }
        public WrongMylo(string message) : base(message) {
           
        }
        public WrongMylo(string message, Exception inner) : base(message, inner) {
        }

    }
}
