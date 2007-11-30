using System;
using System.Collections.Generic;
using System.Text;
using ClusteringFramework.Data;

namespace ClusteringFramework.Dimensions
{
    public class Dimension
    {
        private DataType dataType;
        private PlaneType planeType;
        private List<DataElement> points;

        public DataType DimensionDataType
        {
            get { return dataType; }
            private set { dataType = value; }
        }
        public PlaneType DimensionPlaneType
        {
            get { return planeType; }
            private set { planeType = value; }
        }
        private List<DataElement> Points
        {
            get { return points; }
            set { points = value; }
        }

        public Dimension(PlaneType planeType, DataType dataType)
        {
            DimensionDataType = dataType;
            DimensionPlaneType = planeType;
            Points = new List<DataElement>();
        }

        public void AddPoint(DataElement point)
        {
            Points.Add(point);
        }
    }
}
