using System;
using System.Collections.Generic;
using System.Text;

namespace Edu.Psu.Ist.Keystone.Test2D
{
    class Point 
    {
        private float x, y;
        private static Random rand = new Random();


        protected static Random Rand
        {
            get { return rand; }
        }

        public float X
        {
            get { return x; }
            protected set { x = value; }
        }

        public float Y
        {
            get { return y; }
            protected set { y = value; }
        }

        public Point() 
        {
            X = (float) Math.Round(Rand.NextDouble() * 100, 2);
            Y = (float) Math.Round(Rand.NextDouble() * 100, 2);
        }

        /// <summary>
        /// For Centroid subclass
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        protected Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y;
        }

        public float GetDistance(Point p)
        {
            float a = Math.Abs(X - p.X);
            float b = Math.Abs(Y - p.Y);
            return (float) Math.Pow((a * a) + (b * b), 0.5);
        }


    }
}
