using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Edu.Psu.Ist.Keystone.Dimensions;

namespace Edu.Psu.Ist.Keystone.Data
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
                throw new VectorException("No data elements in this Centroid");
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
        /// Temporarily, this is going to be specific code 
        /// for email only
        /// </summary>
        /// <returns></returns>
        public Centroid GenerateAverageCentroid()
        {
            Hashtable guids = new Hashtable();
            
            DataElement [] addresses = this.Cluster.GetDataElements();
            foreach (DataElement d in addresses)
            {
                // convert the DE to a dimension (which it will be 
                // for facet - and the dimension an address)
                Vector address = (Vector)d;
                DataElement [] des = address.GetDataElements();
                // loop through each messageid
                foreach (DataElement messageid in des)
                {
                    // if this messageid isn't in the hashtable, add it
                    if (guids.ContainsKey(messageid) == false)
                    {
                         guids.Add(messageid, null);
                    }
                }

            }

            // create a new, empty centroid
            Centroid newCent = new Centroid(this.id);

            // loop through each messageid in hashtable and add t
            // new centroid
            foreach (DataElement guid in guids.Keys)
            {
                newCent.AddElement(guid);
            }

            return newCent;
        }
    }
}
