using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using kmeans_test_jbg.Data;

namespace kmeans_test_jbg.Dimensions
{
    /// <summary>
    /// Contains a set of dimensions and generates initial random
    /// centroids.
    /// </summary>
    public class Space
    {
        private List<Dimension> dimensions = new List<Dimension>();


        public void AddDimension(Dimension dim)
        {
            this.dimensions.Add(dim);
        }

        /// <summary>
        /// Get a Hashtable of DataElements which point to random values for
        /// each dimension to create a random Centroid
        /// </summary>
        /// <returns></returns>
        public Hashtable<Dimension, DataElement> GetRandomCentroids()
        {
            Hashtable<Dimension, DataElement> dim_els = new Hashtable<Dimension, DataElement>();
            foreach (Dimension dim in this.dimensions)
            {
                dim_els[dim] = dim.Plane.GetRandomDataElement();
            }
        }
    }
}