using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanswu.bubble
{
   public class BubbleMatrixGeoInfo
    {
        public float LeftBorder { get; private set; }
        public float RightBorder { get; private set; }
        public float TopBorder { get; private set; }
        public float Depth;

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
        public bool IsTopRowAlignedToLeft
        {
            get
            {
                return _isTopRowAlignedToLeft;    
            }
            private set
            {
                _isTopRowAlignedToLeft = value;
            }

        }

        private int _rows;
        private int _columns;
        private BubbleElement [,] _matrix;
        private bool _isTopRowAlignedToLeft = false;

        public BubbleMatrix(int rows,int columns)
        {
            _rows = rows;
            _columns = columns;
            _matrix = new BubbleElement[rows, columns];
        }
        public void AddBubble(BubbleElement bubble,int x,int y)
        {   
            if (x < 0 || x > this._rows -1 || y < 0 || y > this._columns -1)
				throw new System.ArgumentException("Adding Bubble to wrong coordinates");
			
			_matrix[x,y] = bubble;
        }

        public void RemoveBubble(BubbleElement bubble,int x,int y)
        {
            if (x < 0 || x > this._rows -1 || y < 0 || y > this._columns -1)
                    throw new System.ArgumentException("Removing Bubble from wrong coordinates");	

			_matrix[x,y] = null;
        }          

        public void SetTopRowAligned(bool isAligned)
        {
            _isTopRowAlignedToLeft = isAligned;
        }      
    }
}