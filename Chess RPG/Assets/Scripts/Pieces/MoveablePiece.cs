using UnityEngine;
using System.Collections;

namespace Gamify
{
    public class MoveablePiece : PieceBase {

        /// <summary>
        /// Handles events when this piece is highlighted.
        /// </summary>
    	public override void OnHighlight(GamePiece piece)
        {
            
        }

        /// <summary>
        /// Handles events when this piece is selected.
        /// </summary>
        public override void OnSelected(GamePiece piece)
        {
            InputManager.Instance.SelectPiece(piece);
        }
    }
}