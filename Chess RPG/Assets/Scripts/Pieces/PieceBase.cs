using UnityEngine;
using System.Collections;

namespace Gamify
{
	/// <summary>
	/// The PieceBase defines skeleton methods available to
	/// all derived Piece types. Only methods defined here
	/// should be used in other classes not derived from
	/// PieceBase. 
	/// </summary>
	public abstract class PieceBase {
		
		/// <summary>
		/// The base type of this piece.
		/// </summary>
		public Enums.PieceType PieceType;
		
		/// <summary>
		/// The colour this piece possesses.
		/// </summary>
		public Enums.PieceColour PieceColour;
		
		/// <summary>
		/// Handles events when this piece is highlighted.
		/// </summary>
		public abstract void OnHighlight(GamePiece piece);
		
		/// <summary>
		/// Handles events when this piece is selected.
		/// </summary>
		public abstract void OnSelected(GamePiece piece);
	}
}