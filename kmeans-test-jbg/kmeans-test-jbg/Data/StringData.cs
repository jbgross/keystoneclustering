using System;
using System.Collections.Generic;
using System.Text;

namespace kmeans_test_jbg.Data
{
    /// <summary>
    /// Store a DataElement of String type
    /// </summary>
    public class StringData : DataElement
    {
        /// <summary>
        /// Constructor, takes a String
        /// </summary>
        /// <param name="data"></param>
        public StringData(String data)
        {
            Data = data;
        }

        private String data;

        public String Data
        {
            get { return data; }
            private set { data = value; }
        }

        /// <summary>
        /// Return the data element, in this case a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Data;
        }

    }
}
