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
			new PieceSettingsWrapper(Enums.PieceType.King, Enums.PieceColour.White, Enums.Files.A, Enums.Ranks._5)
		};
	}
}