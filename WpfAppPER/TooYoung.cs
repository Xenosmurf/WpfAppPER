using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppPER
{
    class TooYoung : Exception
    {
        public TooYoung() { }
        public TooYoung(string message) : base(message)
        {
           
        }
        public TooYoung(string message, Exception inner) : base(message, inner) {

        }

    }
}
