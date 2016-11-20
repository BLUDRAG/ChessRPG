
namespace Gamify
{
	/// <summary>
	/// The purpose of this class is to act as a container
	/// for all globally used enums.
	/// </summary>
	public class Enums {
		
		/// <summary>
		/// Contains all the rank values on the board.
		/// </summary>
		public enum Ranks
		{
			_1 = 1,
			_2 = 2,
			_3 = 3,
			_4 = 4,
			_5 = 5,
			_6 = 6,
			_7 = 7,
			_8 = 8
		}
		
		/// <summary>
		/// Contains all the file values on the board.
		/// </summary>
		public enum Files
		{
			A = 1,
			B = 2,
			C = 3,
			D = 4,
			E = 5,
			F = 6,
			G = 7,
			H = 8
		}
		
		// Contains all types of pieces in the game.
		public enum PieceType
		{
			Empty,
			Pawn,
			Knight,
			Bishop,
			Rook,
			Queen,
			King
		}
		
		// Contains all possible piece colours.
		public enum PieceColour
		{
			White,
			Black,
            Red
		}
		
		// Contains all possible block colours.
		public enum BlockColour
		{
			White,
			Black,
            Red
		}

        // Represents the side the player is on.
        public enum Alignment
        {
            North,
            South
        }

        // Contains the default maximum HP all pieces possess.
        public enum PieceHP
        {
            Pawn = 100
        }
	}
}