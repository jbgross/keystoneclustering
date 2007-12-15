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
        Cluster cluster;

        /// <summary>
        /// Constructor
        /// </summary>
        public Cluster Cluster
        {
            get { return cluster; }
            private set { cluster = value; }
        }


        public Centroid(int id)
        {
            this.id = id;
            this.Cluster = new Cluster(this);
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

        public Boolean ContainsElement(DataElement el)
        {
            return this.elements.Contains(el); 
        }

        /// <summary>
        /// Given the existing centroid and its cluster, 
        /// find the new centroid via averaging.
        /// </summary>
        /// <returns></returns>
        public Centroid Average()
        {
            //START WORKING HERE
            return null;
        }
    }
}
