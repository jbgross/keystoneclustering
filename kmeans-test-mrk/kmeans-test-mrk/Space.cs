using System;
using System.Collections.Generic;
using System.Text;

namespace ClusteringFramework.Dimensions
{
    public class Space
    {
        private List<Dimension> dimensions;

        private List<Dimension> Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }

        public Space()
        {
            dimensions = new List<Dimension>();
        }

        public void AddDimension(Dimension dimension)
        {
            Dimensions.Add(dimension);
        }
    }
}
