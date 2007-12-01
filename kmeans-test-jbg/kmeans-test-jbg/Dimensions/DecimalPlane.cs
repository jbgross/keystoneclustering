using System;
using System.Collections.Generic;
using System.Text;
using kmeans_test_jbg.Data;


namespace kmeans_test_jbg.Dimensions
{
    /// <summary>
    /// This is soooo not done. Use Cartesian2DPlane. JBG 2007-11-30
    /// </summary>
    class DecimalPlane : DiscretePlane
    {
        public override DataElement GetRandomDataElement()
        {
            return new Point2D();
        }

        public override float GetDistance(Centroid centroid, DataElement el)
        {
            return 0;
        }
    }

    
}
