using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using kmeans_test_jbg.Data;

namespace kmeans_test_jbg.Dimensions
{
    /// <summary>
    /// This is the base class for a dimension in the clustering space.
    /// In it, the valid data type is defined, as is the type of plane,
    /// which will lead to a particular distance calculation.
    /// </summary>
    public class Dimension : DataElement
    {

        /// <summary>
        /// Need all of the data to create centroids
        /// </summary>
        private static Hashtable allData = new Hashtable();
        public static DataElement [] GetUniqueDataElements()
        {
            DataElement [] de = new DataElement[Dimension.allData.Keys.Count];
            Dimension.allData.Keys.CopyTo(de, 0);
            return de;
        }


        public Dimension(String name, DataType data, PlaneType plane)
        {
            Name = name;
            Data = data;
            Plane = plane;
        }

        private String name;

        public String Name
        {
            get { return name; }
            private set { name = value; }
        }

        private DataType data;
        private bool completed = false;

        /// <summary>
        /// The type of data that this dimension can store
        /// </summary>
        public DataType Data
        {
            get { return data; }
            private set { data = value; }
        }

        private PlaneType plane;

        /// <summary>
        /// The type of plane that this dimension will use
        /// </summary>
        public PlaneType Plane
        {
            get { return plane; }
            private set { plane = value; }
        }
        /// <summary>
        /// All of the data elements - note lack of order
        /// This may need to 
        /// </summary>
        private List<DataElement> elements = new List<DataElement>();

        public List<DataElement> Elements
        {
            get { return elements; }
            set { elements = value; }
        }

        public void AddElement(DataElement el)
        {
            if(this.completed) 
            {
                throw new DimensionException("Dimension is closed");
            }
            else
            {
                this.Elements.Add(el);
                if (Dimension.allData.ContainsKey(el) == false)
                {
                    Dimension.allData.Add(el, null);
                }
            }
        }

        /// <summary>
        /// Called when all elements are inserted, to lock the 
        /// dimension (no more adds) and sort the dimension to 
        /// speed retrieval.
        /// </summary>
        public void Complete()
        {
            this.completed = true;
            this.Elements.Sort();
        }

        public float[] GetDistances(Centroid centroid)
        {
            if(! completed) 
            {
                throw new DimensionException("Dimension is not completed; call Complete().");
            }

            float[] distances = new float[this.Elements.Count];
            int count = 0;
            foreach (DataElement el in this.Elements)
            {
                distances[count++] = this.Plane.GetDistance(centroid, el);
            }
            return distances;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name).Append(": ");
            sb.Append(this.Elements.Count);
            //foreach (DataElement el in this.elements)
            //{
            //    sb.Append("\t").Append(el).AppendLine();
            //}
            return sb.ToString();
        }

        public override int CompareTo(object o)
        {
            throw new DimensionException("Cannot sort a dimension. Bad programmer.");
        }

    }
}
