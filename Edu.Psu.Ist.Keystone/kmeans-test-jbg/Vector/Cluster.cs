using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Edu.Psu.Ist.Keystone.Data;

namespace Edu.Psu.Ist.Keystone.Dimensions
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
        private Hashtable elements = new Hashtable();
        


        public Cluster(Centroid centroid)
        {
            this.Centroid = centroid;
        }

        public void AddDataElement(DataElement el, float distance)
        {
            this.elements[el] = distance;
        }

        /// <summary>
        /// Get all the data elements
        /// </summary>
        /// <returns></returns>
        public DataElement[] GetDataElements()
        {
            DataElement [] des = new DataElement[elements.Count];
            int count = 0;
            foreach (DataElement d in elements.Keys) 
            {
                des[count++] = d;
            }
            return des;
        }
        
        public int Count {
            get { return elements.Count; }
        }

    }
}
