using System;
using System.Collections.Generic;
using System.Text;
using kmeans_test_jbg.Data;

namespace kmeans_test_jbg.Dimensions
{
    class Cartesian2DPlane : DiscretePlane
    {
        public override DataElement GetRandomDataElement()
        {
            return new Point2D();
        }

        public override float GetDistance(Centroid centroid, DataElement el)
        {
            Point2D point = (Point2D) el;
            Point2D cent = (Point2D) centroid.GetFirstDataElement();
            float xDist = (float) Math.Abs(point.X - cent.X);
            float yDist = (float) Math.Abs(point.Y - cent.Y);
            return xDist * xDist + yDist * yDist;
        }
    }
}
