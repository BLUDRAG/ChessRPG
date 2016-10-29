using UnityEngine;
using System.Collections;

namespace Gamify
{
	/// <summary>
	/// This class defines the basic pawn piece type.
	/// </summary>
	public class Pawn : PieceBase {
		
		/// <summary>
		/// Handles events when this piece is highlighted.
		/// </summary>
		public override void OnHighlight(GameObject piece)
		{
			// Temporary
			Debug.Log("GAMIFY : Piece highlighted > " + piece.name);
			// Temporary
		}
		
		/// <summary>
		/// Handles events when this piece is selected.
		/// </summary>
		public override void OnSelected(GameObject piece)
		{
			// Temporary
			Debug.Log("GAMIFY : Piece selected > " + piece.name);
			// Temporary
		}
	}
}