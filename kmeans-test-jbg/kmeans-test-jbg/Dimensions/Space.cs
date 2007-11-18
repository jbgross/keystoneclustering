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
        public Space(int clusters)
        {
            Clusters = clusters;
        }
        
        int clusters;

        public int Clusters
        {
            get { return clusters; }
            private set { clusters = value; }
        }

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
        public Centroid [] GetRandomCentroids()
        {
            Centroid[] centroids = new Centroid[this.clusters];
            int count = 0;
            for (int cents = 0; cents < this.clusters; cents++)
            {
                Centroid c = new Centroid();
                foreach (Dimension dim in this.dimensions)
                {
                    c.AddElement(dim, dim.Plane.GetRandomDataElement());
                }
                centroids[count++] = c;
            }
            return centroids;
        }
    }
}