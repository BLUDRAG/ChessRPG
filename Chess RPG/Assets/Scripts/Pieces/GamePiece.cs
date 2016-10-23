using UnityEngine;
using System.Collections;

namespace Gamify
{
	/// <summary>
	/// Represents a Piece within the game space.
	/// Any game space specific functionality should be
	/// defined here. Piece specific functionality
	/// should merely be referenced from the attached
	/// Piece type.
	/// </summary>
	public class GamePiece : MonoBehaviour {
		
		/// <summary>
		/// The Piece type attached to this instance.
		/// All Piece functionality is contained within
		/// this reference.
		/// </summary>
		public PieceBase Piece;
	}
}