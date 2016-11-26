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
            // Temporary
            Debug.Log("GAMIFY : Piece highlighted > " + piece.name);
            // Temporary
        }

        /// <summary>
        /// Handles events when this piece is selected.
        /// </summary>
        public override void OnSelected(GamePiece piece)
        {
            // Temporary
            Debug.Log("GAMIFY : Piece selected > " + piece.name);
            // Temporary
        }
    }
}