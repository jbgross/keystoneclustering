using System;
using System.Collections.Generic;
using System.Text;
using kmeans_test_jbg.Data;

namespace kmeans_test_jbg.Dimensions
{
    /// <summary>
    /// This is the base class for a dimension in the clustering space.
    /// In it, the valid data type is defined, as is the type of plane,
    /// which will lead to a particular distance calculation.
    /// </summary>
    public class Dimension
    {
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

        public void AddElement(DataElement el)
        {
            if(this.completed) {
                this.elements.Add(el);
            } else {
                throw new DimensionException("Dimension is closed");
            }
        }

        /// <summary>
        /// Called when all elements are inserted, to lock the 
        /// dimension (no more adds) and sort the dimension to 
        /// speed retrieval.
        /// </summary>
        /// <param name="?"></param>
        public void Complete()
        {
            this.completed = true;
            this.elements = this.elements.Sort();
        }

        public float[] GetDistances(Centroid centroid)
        {
            if(! completed) 
            {
                throw new DimensionException("Dimension is not completed; call Complete().");
            }

            float[] distances = new float[this.elements.Count];
            int count = 0;
            foreach (DataElement el in this.elements)
            {
                distances[count++] = this.Plane.GetDistance(centroid, el);
            }
            return distances;
        }


    }
}
