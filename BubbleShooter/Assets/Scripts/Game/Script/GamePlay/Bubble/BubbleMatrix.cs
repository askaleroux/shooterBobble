using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanswu.bubble
{

    public class BubbleMatrixGeoInfo
    {
        /* Geometry */
        public float LeftBorder { get; private set; }
        public float RightBorder { get; private set; }
        public float TopBorder { get; private set; }
        public float Depth;
        // Dimensions
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public float BubbleRadius { get; private set; }

        public BubbleMatrixGeoInfo(float leftBorder, float rightBorder, float topBorder, int rows, int columns, float bubbleRadius)
        {
            LeftBorder = leftBorder;
            RightBorder = rightBorder;
            TopBorder = topBorder;
            Rows = rows;
            Columns = columns;
            BubbleRadius = bubbleRadius;
        }
    }

    public class BubbleMatrix : MonoBehaviour
    {

        private int _rows;
        private int _columns;
        private BubbleElement [,] _matrix;

        public BubbleMatrix(int rows,int columns)
        {
            _rows = rows;
            _columns = columns;
            _matrix = new BubbleElement[rows, columns];
        }

        public void AddBubble()
        {

        }

        public void RemoveBubble()
        {

        }

        
    }
}