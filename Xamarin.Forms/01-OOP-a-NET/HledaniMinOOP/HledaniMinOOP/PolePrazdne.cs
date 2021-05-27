using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HledaniMinOOP
{
    public class PolePrazdne : Pole
    {
        public PolePrazdne(int poziceY, int poziceX) : base(poziceY, poziceX) { }

        protected override Color BarvaPozadi => Colors.LightYellow;
    }
}
