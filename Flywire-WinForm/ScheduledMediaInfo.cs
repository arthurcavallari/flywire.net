using System;
using System.Collections.Generic;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Text;

namespace Flywire_WinForm
{
    public class ScheduledMediaInfo
    {
        public string Name { get; set; }
        public DateTime ScheduledDateTime { get; set; }
    }
}
