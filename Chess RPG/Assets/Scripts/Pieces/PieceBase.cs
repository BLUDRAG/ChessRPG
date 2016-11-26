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
        /// The max HP this piece possesses.
        /// </summary>
        public int MaxHP;

        /// <summary>
        /// The current HP for this piece.
        /// </summary>
        public int CurrentHP;

        /// <summary>
        /// Gets the position of this piece.
        /// </summary>
        public virtual Vector2 Position
        {
            get
            {
                return Utilities.CoordToPosition(File, Rank);
            }
        }

        /// <summary>
        /// The file this piece holds.
        /// </summary>
        public Enums.Files File;

        /// <summary>
        /// The rank this piece holds.
        /// </summary>
        public Enums.Ranks Rank;

        /// <summary>
        /// The piece's alignment, defined by the owned player.
        /// </summary>
        public Enums.Alignment Alignment;

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