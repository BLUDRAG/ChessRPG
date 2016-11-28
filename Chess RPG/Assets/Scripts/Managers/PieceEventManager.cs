using UnityEngine;
using System.Collections;

namespace Gamify
{
    /// <summary>
    /// This class handles any events sent by game pieces.
    /// </summary>
	public class PieceEventManager : MonoBehaviour {
	
        void Awake()
        {
            EventManager<GamePiece>.SubscribeEvent(EventDefinitions.PieceSelected, OnPieceSelected);
            EventManager<GamePiece>.SubscribeEvent(EventDefinitions.PieceHighlighted, OnPieceHighlighted);
        }

        /// <summary>
        /// Performs any available action on the selected piece.
        /// </summary>
        /// <param name="piece">Piece.</param>
        private void OnPieceSelected(GamePiece piece)
        {
            // Temporary
            print(piece.Piece.PieceType);
            InputManager.Instance.SelectPiece(piece);
            // Temporary
        }

        /// <summary>
        /// Performs any available action on the highlighted piece.
        /// </summary>
        /// <param name="piece">Piece.</param>
        private void OnPieceHighlighted(GamePiece piece)
        {
            // Temporary
            print(piece.Piece.PieceType);
            // Temporary
        }
	}
}
