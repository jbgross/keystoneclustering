using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.Psu.Ist.Keystone.Test2D
{
    class Centroid : Point
    {
        private List<Point> cluster = new List<Point>();

        public Centroid() : base()
        {
        }

        public Centroid(float x, float y) : base(x, y)
        {
        }

        public void AddPointToCluster(Point p)
        {
            this.cluster.Add(p);
        }

        public override string ToString()
        {
            return base.ToString() + " - Points: " + cluster.Count;
        }

        public string ToStringFull()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine();
            foreach (Point p in cluster)
            {
                sb.Append("\t");
                sb.Append(p);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public Centroid GetAveragedCentroid()
        {
            float totalX = 0;
            float totalY = 0;

            foreach(Point p in cluster) {
                totalX += p.X;
                totalY += p.Y;
            }

            return new Centroid(
                (float) Math.Round(totalX / cluster.Count, 2), 
                (float) Math.Round(totalY / cluster.Count, 2));
        }
    }
}