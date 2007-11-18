using System;
using System.Collections.Generic;
using System.Text;
using ClusteringFramework.Data;

namespace ClusteringFramework.Dimensions
{
    public class Point
    {
        private DataElement element;
        private DataType type;

        public DataElement Element
        {
            get { return element; }
            private set { element = value; }
        }
        public DataType Type
        {
            get { return type; }
            private set { type = value; }
        }

        public Point(DataElement element, DataType type)
        {
            Element = element;
            Type = type;
        }
    }
}
