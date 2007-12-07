using System;
using System.Collections.Generic;
using System.Text;

namespace kmeans_test_jbg.Data
{
    public abstract class DataElement : IComparable
    {
        public abstract override String ToString();
        public abstract int CompareTo(Object o);
    }
}
