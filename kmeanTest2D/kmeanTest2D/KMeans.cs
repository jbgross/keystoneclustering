using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.Psu.Ist.Keystone.Test2D
{
    class KMeans
    {
        private List<Point> points;
        private List<Centroid> centroids;
        private List<Centroid> lastCentroids;
        private int numberOfClusters;
        private int iterations = 0;

        public int Iterations
        {
            get { return iterations; }
        }

        public KMeans(List<Point> points, int numberOfClusters)
        {
            this.points = points;
            this.centroids = new List<Centroid>();
            this.numberOfClusters = numberOfClusters;
            for (int i = 0; i < numberOfClusters; i++)
            {
                this.centroids.Add(new Centroid());
            }
        }

        public List<Centroid> Centroids
        {
            get { return centroids; }
        }

        public void MakeClusters()
        {
            // debug
            this.iterations++;
            Console.WriteLine("Iteration " + this.iterations);

            foreach (Point p in this.points) 
            {
                Centroid closest = null;
                float closestDistance = float.MaxValue;
                foreach (Centroid c in centroids)
                {
                    float distance = c.GetDistance(p);
                    if (distance < closestDistance)
                    {
                        closest = c;
                        closestDistance = distance;
                    }
                }
                closest.AddPointToCluster(p);
            }
            this.lastCentroids = this.centroids;
            this.centroids = new List<Centroid>();
            bool unchanged = true;

            for (int i = 0; i < this.numberOfClusters; i++) 
            {
                Centroid c = this.lastCentroids[i];
                // debug
                // Console.WriteLine(c);
                Centroid newC = c.GetAveragedCentroid();
                if(unchanged && (c.X != newC.X || c.Y != newC.Y)) {
                    unchanged = false;
                }
                this.centroids.Add(newC);
            }

            if (!unchanged)
            {
                // recurse
                this.MakeClusters();
            }
            else
            {
                this.centroids = this.lastCentroids;
            }

            return;

        }


    }
}
