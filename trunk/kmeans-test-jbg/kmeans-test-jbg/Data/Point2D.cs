using System;
using System.Collections.Generic;
using System.Text;

namespace kmeans_test_jbg.Data
{
    class Point2D : DataElement
    {
        decimal x, y;

        public Point2D()
        {
            Random r = new Random();
            X = (decimal) r.NextDouble();
            Y = (decimal)r.NextDouble();
        }

        public decimal Y
        {
            get { return y; }
            private set { y = value; }
        }

        public decimal X
        {
            get { return x; }
            private set { x = value; }
        }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y;
        }
    }
}
