using System;
using System.Collections.Generic;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Text;

namespace Flywire_WinForm
{
    public class LinkedListExt<T> : LinkedList<T>
    {
        public int IndexOf<U>(U item)
        {
            if (item == null) return -1;
            var count = 0;
            for (var node = this.First; node != null; node = node.Next, count++)
            {
                if (item.Equals(node.Value))
                    return count;
            }
            return -1;
        }
    }
}
