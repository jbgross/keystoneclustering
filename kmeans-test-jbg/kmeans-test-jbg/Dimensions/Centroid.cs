using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using kmeans_test_jbg.Dimensions;

namespace kmeans_test_jbg.Data
{
    public class Centroid
    {
        private List<DataElement> elements = new List<DataElement>();
        int id;
        public Centroid(int id)
        {
            this.id = id;
        }

        public void AddElement(DataElement de)
        {
            this.elements.Add(de);
        }

        public override string ToString()
        {
            return this.id + ": " + this.elements.Count;
        }

        public DataElement GetFirstDataElement()
        {
            if (this.elements.Count < 1)
            {
                throw new DimensionException("No data elements in this Centroid");
            }
            return this.elements[0];
        }
    }
}
