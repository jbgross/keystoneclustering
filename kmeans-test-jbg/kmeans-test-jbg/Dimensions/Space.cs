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

        private bool centroidsComplete = false;

        public bool CentroidsComplete
        {
            get { return centroidsComplete; }
            private set { centroidsComplete = value; }
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

        /// <summary>
        /// Compare each centroid to each dimension,
        /// and assign each dimension to the closest centroid
        /// </summary>
        public void CompareCentroids()
        {
            // loop through each dimension
            foreach (Dimension dim in this.dimensions)
            {
                Centroid closest = null;
                float closestCount = 0;
                
                // loop through and compare to each centroid
                // find the closest
                foreach (Centroid cent in Centroids)
                {
                    // get the distances from this centroid to 
                    // each element in the dimension (will be 
                    // 0 (not contained) or 1 (contained)
                    float[] distances = dim.GetDistances(cent);

                    // sum the distances
                    float total = 0;
                    foreach (float d in distances)
                    {
                        total += d;
                    }

                    // if this is closer (higher number) than the 
                    // previous closest centroid, pick this centroid
                    if (total > closestCount)
                    {
                        closest = cent;
                        closestCount = total;
                    }
                }

                // assign this dimension to the closest centroid
                closest.Cluster.AddDataElement(dim, closestCount);
            }
        }

        private Centroid[] GetNewCentroids()
        {
            Centroid[] newCents = new Centroid[Clusters];
            for (int i = 0; i < newCents.Length; i++)
            {
                Centroid oldCentroid = Centroids[i];
                Centroid newCentroid = oldCentroid.Average();
                newCents[i] = newCentroid;
            }
            return newCents;
        }

    }
}