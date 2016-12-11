using UnityEngine;
using System.Collections;

namespace Gamify
{
	/// <summary>
	/// This class defines the basic pawn piece type.
	/// </summary>
    public class Pawn : MoveablePiece {

		public Pawn()
		{
			PieceType = Enums.PieceType.Pawn;
            MaxHP = (int)Enums.PieceHP.Pawn;
            CurrentHP = MaxHP;
		}
	}
}