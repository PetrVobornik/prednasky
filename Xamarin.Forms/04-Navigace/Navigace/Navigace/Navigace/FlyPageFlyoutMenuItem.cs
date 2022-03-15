using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigace
{
    public class FlyPageFlyoutMenuItem
    {
        public FlyPageFlyoutMenuItem()
        {
            TargetType = typeof(FlyPageDetail); // FlyPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}