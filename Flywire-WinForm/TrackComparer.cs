using System;
using System.Collections.Generic;
#if !NOT_NET4
using System.Linq;
using System.Threading.Tasks;
#endif
using System.Text;

namespace Flywire_WinForm
{
    public class TrackComparer : IEqualityComparer<Track>
    {
        bool IEqualityComparer<Track>.Equals(Track t1, Track t2)
        {
            //Check whether the compared objects reference the same data. 
            if (Object.ReferenceEquals(t1, t2)) return true;

            //Check whether any of the compared objects is null. 
            if (Object.ReferenceEquals(t1, null) || Object.ReferenceEquals(t2, null))
                return false;

            //Check whether the Track' properties are equal. 
            return t1.Name == t2.Name && t1.Location == t2.Location;
        }

        int IEqualityComparer<Track>.GetHashCode(Track t)
        {
            //Check whether the object is null 
            if (Object.ReferenceEquals(t, null)) return 0;

            //Get hash code for the Name field if it is not null. 
            int hashTrackName = t.Name == null ? 0 : t.Name.GetHashCode();

            //Get hash code for the Code field. 
            int hashTrackLocation = t.Location.GetHashCode();

            //Calculate the hash code for the product. 
            return hashTrackName ^ hashTrackLocation;
        }
    }
}
