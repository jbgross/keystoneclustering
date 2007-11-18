using System;
using System.Collections.Generic;
using System.Text;
using kmeans_test_jbg.Dimensions;
using kmeans_test_jbg.Data;

namespace kmeans_test_jbg
{
    class Program
    {
        static void Main(string[] args)
        {
            Dimension d1 = new Dimension("message1", new DataType(), new InvertedBooleanPlane());
            d1.AddElement(new StringData("jbg172"));
        }
    }
}
