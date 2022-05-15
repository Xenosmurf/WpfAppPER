using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppPER
{
    class TooOld : Exception
    {
        public TooOld() { }
        public TooOld(string message) : base(message)
        {
            MessageBox.Show("Wrong date of birth");
        }
        public TooOld(string message, Exception inner) : base(message, inner) {
            message = "Wrong date of birth";
        }

    }
}
