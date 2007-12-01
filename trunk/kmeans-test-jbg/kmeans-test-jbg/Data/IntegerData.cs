using System;
using System.Collections.Generic;
using System.Text;

namespace kmeans_test_jbg.Data
{
    /// <summary>
    /// Stores integer data
    /// </summary>
    class IntegerData : DataElement
    {
        private int data;

        public int Data
        {
            get { return data; }
            private set { data = value; }
        }

        public IntegerData(int data)
        {
            Data = data;
        }

        /// <summary>
        /// Return the data element, in this case an integer
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
