using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.Psu.Ist.Keystone.Test2D
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of points: ");
            String sp = Console.ReadLine();
            int pCount = Convert.ToInt32(sp);

            List<Point> allPoints = new List<Point>();
            for (int i = 0; i < pCount; i++)
            {
                Point p = new Point();
                // debug
                // Console.WriteLine((i+1) + ": " + p);
                allPoints.Add(p);
            }

            Console.Write("Enter number of clusters: ");
            String kp = Console.ReadLine();
            int kCount = Convert.ToInt32(kp);

            KMeans k = new KMeans(allPoints, kCount);
            
            //debug
            DateTime start = DateTime.Now;
 
            k.MakeClusters();
            //debug
            DateTime stop = DateTime.Now;
            Console.Write("Elapsed Time: ");
            Console.WriteLine(stop - start);

            List<Centroid> centroids = k.Centroids;
            foreach (Centroid c in centroids)
            {
                Console.WriteLine(c);
            }

            Console.WriteLine("Number of Iterations: " + k.Iterations);
            // keep window open
            Console.ReadLine();
        }
    }
}
