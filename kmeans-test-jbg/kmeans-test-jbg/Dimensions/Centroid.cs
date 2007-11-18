using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using kmeans_test_jbg.Dimensions;

namespace kmeans_test_jbg.Data
{
    public class Centroid
    {
        private Hashtable dim_value = new Hashtable();
        public Centroid()
        {
        }

        public void AddElement(Dimension dim, DataElement value)
        {
            this.dim_value[dim] = value;
        }
    }
}
