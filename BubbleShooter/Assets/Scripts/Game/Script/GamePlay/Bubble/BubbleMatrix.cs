using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanswu.bubble
{
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