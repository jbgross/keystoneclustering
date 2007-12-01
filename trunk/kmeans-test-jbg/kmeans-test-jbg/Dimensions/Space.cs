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
        private Centroid [] centroids;

        public Centroid[] Centroids
        {
          get { return centroids; }
          private set { centroids = value; }
        }

        public Space(int clusters)
        {
            Clusters = clusters;
            Centroids = new Centroid[clusters];
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
        public void CreateRandomCentroids()
        {
            // create the empty centroids
            for (int cents = 0; cents < this.clusters; cents++)
            {
                Centroids[cents] = new Centroid(cents);
            }

            // list of unique data points
            DataElement [] dataPoints = Dimension.GetUniqueDataElements();
            Random rand = new Random();

            // assign points to randomly selected centroids
            foreach (DataElement de in dataPoints)
            {
                Centroids[rand.Next(0, this.clusters)].AddElement(de);
            }

            foreach (Centroid c in Centroids)
            {
                Console.WriteLine(c);
            }
        }

        public void CompareCentroids()
        {
        }

    }
}