using System;
using System.Collections.Generic;
using System.Text;
using kmeans_test_jbg.Data;

namespace kmeans_test_jbg.Dimensions
{
    /// <summary>
    /// The actual class to store a cluster, which is 
    /// a set of (DataElement, distance)
    /// </summary>
    public class Cluster
    {
        private Centroid centroid;

        public Centroid Centroid
        {
            get { return centroid; }
            private set { centroid = value; }
        }
        private Hashtable<DataElement, float> elements = new Hashtable<DataElement, float>();

        public Cluster()
        {
            this.Centroid = centroid;
        }

        public void AddDataElement(DataElement el, float distance)
        {
            this.elements[el] = distance;
        }
    }
}