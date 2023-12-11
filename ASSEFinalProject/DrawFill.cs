using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASSEFinalProject
{
    class DrawFill
    {
        private bool fill;

        public DrawFill () { fill = false; }

        public bool Fill
        {
            get { return fill; }
            set { fill = value; }
        }
    }
}
