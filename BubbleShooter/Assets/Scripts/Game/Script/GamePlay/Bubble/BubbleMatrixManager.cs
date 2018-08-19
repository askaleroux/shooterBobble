using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hanswu.bubble
{
    public class BubbleMatrixManager : MonoBehaviour
    {
        private static BubbleMatrixManager _instance;
        private BubbleMatrixGeoInfo _geoInfo;
        private Difficulty _diffculty;

        public static BubbleMatrixManager GetInstance(BubbleMatrixGeoInfo geoInfo,Difficulty difficulty)
        {
            if (_instance == null)
            {
                _instance = new BubbleMatrixManager(geoInfo, difficulty);
            }
            return _instance;  
        }

        private BubbleMatrixManager(BubbleMatrixGeoInfo geoInfo,Difficulty difficulty)
        {
            _geoInfo = geoInfo;
            _diffculty = difficulty;
        }

        public BubbleMatrixGeoInfo GetBubbleMatrixGeoInfo()
        {
            return _geoInfo;
        }

        public static bool CanBubbleMoveToPosition(Vector3 position)
        {
            return true;
        }

        public Vector3 GetPositionFromCellCoord(Vector2 cell)
        {
            bool rowIsEven = cell.x % 2 == 0;
			float y = _geoInfo.Rows - cell.x - _geoInfo.BubbleRadius;
			float x;
			if (_matrix.IsTopRowAlignedToLeft)
            {
				if (rowIsEven)
                {
					x = cell.y + _geoInfo.BubbleRadius;
				}
                else
                {
					x = cell.y +  2 * _geoInfo.BubbleRadius;
				}
			}
            else
            {
				if (rowIsEven)
                {
					x = cell.y +  2 * _geoInfo.BubbleRadius;
				}
                else
                {
					x = cell.y + _geoInfo.BubbleRadius;
				}
			}
			return new Vector3(x, y, _geoInfo.Depth);
        }

        public Vector2 GetCellCoordFromPosition(Vector3 position)
        {
            int row = _geoInfo.Rows - Mathf.FloorToInt(position.y) - 1;
			int column;
			bool rowIsEven = row% 2 == 0;
			if ((rowIsEven && _matrix.IsTopRowAlignedToLeft) || (!rowIsEven  && !_matrix.IsTopRowAlignedToLeft))
            {
				column = Mathf.FloorToInt(position.x);
			}
            else
            {
				column = Mathf.FloorToInt(position.x - _geoInfo.BubbleRadius);
			}
			Vector2 result =  new Vector2(row, Mathf.Clamp(column, 0, _geoInfo.Columns -1));
			return result;
        }

        public void HandleBubbleCollision()
        {
            //// If the ball falls under the amoun of rows, the game is over
            //Vector2 bubblePos = BubbleMatrixControllerHelper.CellForPosition(bubble.transform.position, this.geometry, this._matrix.isBaselineAlignedLeft);
            //if ((int)bubblePos.x >= this.geometry.rows)
            //{
            //    this.FinishGame(GameState.Loose);
            //    return;
            //}

            //// Create the new bubble
            //BubbleController bubbleController = bubble.GetComponent<BubbleController>();
            //Vector2 matrixPosition = BubbleMatrixControllerHelper.CellForPosition(bubble.transform.position, this.geometry, this._matrix.isBaselineAlignedLeft);

            //// Update the model
            //this._matrix.insert(bubbleController.bubble, (int)matrixPosition.x, (int)matrixPosition.y);

            //// if we don't have to add a new row (because of the timer), move the bubble smoothly to its snapping point			
            //if (!this._pendingToAddRow)
            //{
            //    bubbleController.moveTo(BubbleMatrixControllerHelper.PositionForCell(matrixPosition, geometry, this._matrix.isBaselineAlignedLeft), 0.1f);
            //}
            //else
            //{
            //    // otherwise move it rapidly
            //    bubbleController.transform.position = BubbleMatrixControllerHelper.PositionForCell(matrixPosition, geometry, this._matrix.isBaselineAlignedLeft);
            //}

            //// Explode the bubbles that need to explode
            //// The the cluster of bubbles with a similar color as the colliding one
            //ArrayList cluster = this._matrix.colorCluster(bubbleController.bubble);

            //if (cluster.Count > 2)
            //{
            //    // Explode the cluster
            //    bubbleController.transform.position = BubbleMatrixControllerHelper.PositionForCell(matrixPosition, geometry, this._matrix.isBaselineAlignedLeft);
            //    this.destroyCluster(cluster, true);
            //    // Notify that bubbles have been removed
            //    GameEvents.BubblesRemoved(cluster.Count, true);
            //}

            //// Drop the bubbles that fall
            //cluster = this._matrix.looseBubbles();
            //this.destroyCluster(cluster, false);
            //if (cluster.Count > 0)
            //    GameEvents.BubblesRemoved(cluster.Count, false);

            //// Add a new Row of random bubbles if required
            //if (_pendingToAddRow)
            //{
            //    this.addRow();
            //    StartCoroutine("addRowScheduler");
            //}

            //// If there are no bubble lefts, win the game
            //if (this._matrix.bubbles.Count == 0)
            //{
            //    this.FinishGame(GameState.Win);
            //    return;
            //}

            //// Prepare the new bubble to shoot it
            //this._currentBubble = this.createBubble();
        }
    }
}