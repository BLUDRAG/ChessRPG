using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Gamify
{
	/// <summary>
	/// This class defines the basic board settings template.
	/// Instances of this class should contain all the different
	/// available board settings.
	/// </summary>
	[CreateAssetMenu]
	public class BoardSettings : ScriptableObject {
	
		/// <summary>
		/// A list of all blocks defined for this setting.
		/// </summary>
		[HideInInspector]
		public List<BlockSettingsWrapper> Blocks = new List<BlockSettingsWrapper>()
		{
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.A, Enums.Ranks._1),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.A, Enums.Ranks._2),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.A, Enums.Ranks._3),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.A, Enums.Ranks._4),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.A, Enums.Ranks._5),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.A, Enums.Ranks._6),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.A, Enums.Ranks._7),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.A, Enums.Ranks._8),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.B, Enums.Ranks._1),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.B, Enums.Ranks._2),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.B, Enums.Ranks._3),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.B, Enums.Ranks._4),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.B, Enums.Ranks._5),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.B, Enums.Ranks._6),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.B, Enums.Ranks._7),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.B, Enums.Ranks._8),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.C, Enums.Ranks._1),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.C, Enums.Ranks._2),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.C, Enums.Ranks._3),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.C, Enums.Ranks._4),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.C, Enums.Ranks._5),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.C, Enums.Ranks._6),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.C, Enums.Ranks._7),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.C, Enums.Ranks._8),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.D, Enums.Ranks._1),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.D, Enums.Ranks._2),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.D, Enums.Ranks._3),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.D, Enums.Ranks._4),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.D, Enums.Ranks._5),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.D, Enums.Ranks._6),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.D, Enums.Ranks._7),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.D, Enums.Ranks._8),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.E, Enums.Ranks._1),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.E, Enums.Ranks._2),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.E, Enums.Ranks._3),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.E, Enums.Ranks._4),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.E, Enums.Ranks._5),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.E, Enums.Ranks._6),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.E, Enums.Ranks._7),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.E, Enums.Ranks._8),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.F, Enums.Ranks._1),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.F, Enums.Ranks._2),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.F, Enums.Ranks._3),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.F, Enums.Ranks._4),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.F, Enums.Ranks._5),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.F, Enums.Ranks._6),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.F, Enums.Ranks._7),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.F, Enums.Ranks._8),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.G, Enums.Ranks._1),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.G, Enums.Ranks._2),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.G, Enums.Ranks._3),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.G, Enums.Ranks._4),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.G, Enums.Ranks._5),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.G, Enums.Ranks._6),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.G, Enums.Ranks._7),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.G, Enums.Ranks._8),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.H, Enums.Ranks._1),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.H, Enums.Ranks._2),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.H, Enums.Ranks._3),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.H, Enums.Ranks._4),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.H, Enums.Ranks._5),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.H, Enums.Ranks._6),
			new BlockSettingsWrapper(Enums.BlockColour.White, Enums.Files.H, Enums.Ranks._7),
			new BlockSettingsWrapper(Enums.BlockColour.Black, Enums.Files.H, Enums.Ranks._8)
		};
	}
}