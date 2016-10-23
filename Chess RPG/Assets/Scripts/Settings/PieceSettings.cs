using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Gamify
{
	/// <summary>
	/// This class defines the basic pieces settings template.
	/// Instances of this class should contain all the different
	/// available pieces settings.
	/// </summary>
	[CreateAssetMenu]
	public class PieceSettings : ScriptableObject {
		
		/// <summary>
		/// A list of all pieces defined for this setting.
		/// </summary>
		public List<PieceSettingsWrapper> Pieces = new List<PieceSettingsWrapper>()
		{
			new PieceSettingsWrapper(Enums.PieceType.King, Enums.PieceColour.White, Enums.Files.A, Enums.Ranks._5),
			new PieceSettingsWrapper(Enums.PieceType.Queen, Enums.PieceColour.White, Enums.Files.A, Enums.Ranks._4),
			new PieceSettingsWrapper(Enums.PieceType.Bishop, Enums.PieceColour.White, Enums.Files.A, Enums.Ranks._3),
			new PieceSettingsWrapper(Enums.PieceType.Bishop, Enums.PieceColour.White, Enums.Files.A, Enums.Ranks._6),
			new PieceSettingsWrapper(Enums.PieceType.Knight, Enums.PieceColour.White, Enums.Files.A, Enums.Ranks._2),
			new PieceSettingsWrapper(Enums.PieceType.Knight, Enums.PieceColour.White, Enums.Files.A, Enums.Ranks._7),
			new PieceSettingsWrapper(Enums.PieceType.Rook, Enums.PieceColour.White, Enums.Files.A, Enums.Ranks._1),
			new PieceSettingsWrapper(Enums.PieceType.Rook, Enums.PieceColour.White, Enums.Files.A, Enums.Ranks._8),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.White, Enums.Files.B, Enums.Ranks._1),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.White, Enums.Files.B, Enums.Ranks._2),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.White, Enums.Files.B, Enums.Ranks._3),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.White, Enums.Files.B, Enums.Ranks._4),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.White, Enums.Files.B, Enums.Ranks._5),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.White, Enums.Files.B, Enums.Ranks._6),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.White, Enums.Files.B, Enums.Ranks._7),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.White, Enums.Files.B, Enums.Ranks._8),
			new PieceSettingsWrapper(Enums.PieceType.King, Enums.PieceColour.Black, Enums.Files.H, Enums.Ranks._5),
			new PieceSettingsWrapper(Enums.PieceType.Queen, Enums.PieceColour.Black, Enums.Files.H, Enums.Ranks._4),
			new PieceSettingsWrapper(Enums.PieceType.Bishop, Enums.PieceColour.Black, Enums.Files.H, Enums.Ranks._3),
			new PieceSettingsWrapper(Enums.PieceType.Bishop, Enums.PieceColour.Black, Enums.Files.H, Enums.Ranks._6),
			new PieceSettingsWrapper(Enums.PieceType.Knight, Enums.PieceColour.Black, Enums.Files.H, Enums.Ranks._2),
			new PieceSettingsWrapper(Enums.PieceType.Knight, Enums.PieceColour.Black, Enums.Files.H, Enums.Ranks._7),
			new PieceSettingsWrapper(Enums.PieceType.Rook, Enums.PieceColour.Black, Enums.Files.H, Enums.Ranks._1),
			new PieceSettingsWrapper(Enums.PieceType.Rook, Enums.PieceColour.Black, Enums.Files.H, Enums.Ranks._8),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.Black, Enums.Files.G, Enums.Ranks._1),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.Black, Enums.Files.G, Enums.Ranks._2),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.Black, Enums.Files.G, Enums.Ranks._3),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.Black, Enums.Files.G, Enums.Ranks._4),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.Black, Enums.Files.G, Enums.Ranks._5),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.Black, Enums.Files.G, Enums.Ranks._6),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.Black, Enums.Files.G, Enums.Ranks._7),
			new PieceSettingsWrapper(Enums.PieceType.Pawn, Enums.PieceColour.Black, Enums.Files.G, Enums.Ranks._8)
		};
	}
}