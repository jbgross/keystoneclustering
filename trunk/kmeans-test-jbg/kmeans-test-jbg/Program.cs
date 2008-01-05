using System;
using System.Collections.Generic;
using System.Text;
using kmeans_test_jbg.Dimensions;
using kmeans_test_jbg.Data;

namespace kmeans_test_jbg
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<DataElement> names = new List<DataElement>();
            //Dimension d1 = new Dimension("message1", new DataType(), new InvertedBooleanPlane());
            ArtificialDimensions ad = new ArtificialDimensions();
            ad.Space.CreateRandomCentroids();
            while (ad.Space.CentroidsComplete == false)
            {
                // start by comparing centroids to dimensions
                ad.Space.CompareCentroids();

                // DEBUG - print out centroids
                Console.WriteLine();
                foreach (Centroid cent in ad.Space.Centroids)
                {
                    Cluster cluster = cent.Cluster;
                    Console.WriteLine(cluster.Count);
                }

                // now, get new centroids
                ad.Space.GenerateNewCentroids();

            }
            //DEBUG stop and allow me to read
            Console.ReadLine();
        }
    }
}
