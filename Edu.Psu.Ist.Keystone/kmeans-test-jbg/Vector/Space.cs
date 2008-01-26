using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Edu.Psu.Ist.Keystone.Data;

namespace Edu.Psu.Ist.Keystone.Dimensions
{
    /// <summary>
    /// Contains a set of dimensions and generates initial random
    /// centroids.
    /// </summary>
    public class Space
    {
        private Centroid [] centroids;
        private Centroid [] oldCentroids;

        //debug
        int iterations = 0;

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

        private List<Vector> dimensions = new List<Vector>();

        public void AddDimension(Vector dim)
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
            DataElement [] dataPoints = Vector.GetUniqueDataElements();
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
            foreach (Vector dim in this.dimensions)
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

        /// <summary>
        /// Generate new centroids from averaging prior centroids
        /// </summary>
        /// <returns></returns>
        public void GenerateNewCentroids()
        {
            // stop if old centroids and new centroids are the same
            if (this.isFinished())
            {
                CentroidsComplete = true;
                return;
            }

            Centroid[] newCents = new Centroid[Clusters];
            for (int i = 0; i < newCents.Length; i++)
            {
                Centroid oldCentroid = Centroids[i];
                Centroid newCentroid = oldCentroid.GenerateAverageCentroid();
                newCents[i] = newCentroid;
            }
            this.oldCentroids = this.Centroids;
            this.centroids = newCents;
        }

        /// <summary>
        /// Check to see if the clusters in the centroids are identical
        /// If so, return true, else return false
        /// </summary>
        /// <returns></returns>
        private bool isFinished()
        {
            // first time through, we won't have old centroids,
            // so we won't have to check
            if (this.oldCentroids == null)
            {
                return false;
            }

            for (int i = 0; i < this.centroids.Length; i++)
            {
                DataElement [] newMembers = this.centroids[i].Cluster.GetDataElements();
                DataElement [] oldMembers = this.centroids[i].Cluster.GetDataElements();
                
                // if clusters are of different lengths, we
                // know they must be different, so return false
                if(newMembers.Length != oldMembers.Length) 
                {
                    return false;
                }

                // loop through and compare each member
                // may need to worry about sorting at some point
                // but not now, since the order of the dimension
                // list won't change
                for (int j = 0; j < oldMembers.Length; j++)
                {
                    DataElement o = oldMembers[j];
                    DataElement n = newMembers[j];
                    if (o.ToString().Equals(n.ToString()) == false)
                    {
                        return false;
                    }
                }

            }

            // if nothing has caused a false so far, then return true
            return true;
        }

    }
}