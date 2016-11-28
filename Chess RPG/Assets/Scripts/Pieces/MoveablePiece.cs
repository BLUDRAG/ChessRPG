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
            EventManager<GamePiece>.Invoke(EventDefinitions.PieceHighlighted, piece);
        }

        /// <summary>
        /// Handles events when this piece is selected.
        /// </summary>
        public override void OnSelected(GamePiece piece)
        {
            EventManager<GamePiece>.Invoke(EventDefinitions.PieceSelected, piece);
        }
    }
}