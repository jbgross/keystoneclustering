using System;
using System.Collections.Generic;
using System.Text;
using kmeans_test_jbg.Data;

namespace kmeans_test_jbg.Dimensions
{
    /// <summary>
    /// This class identifies the type of dimension,
    /// and by extension, the distance computation.
    /// </summary>
    public abstract class PlaneType
    {
        protected static Random rand = new Random();

        /// <summary>
        /// This 
        /// </summary>
        /// <param name="centroid">The centroid to compare to </param>
        /// <param name="el"></param>
        /// <returns>The square of the Euclidean distance, 0-1, from centroid to element</returns>
        public abstract float GetDistance(Centroid centroid, DataElement el);

        public abstract DataElement GetRandomDataElement();
    }
}
