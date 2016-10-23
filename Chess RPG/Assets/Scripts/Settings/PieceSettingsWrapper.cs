using System;

namespace Gamify
{
	/// <summary>
	/// The sole purpose of this class is to wrap all
	/// information needed to create an individual
	/// piece setting inside a single container.
	/// </summary>
	[Serializable]
	public class PieceSettingsWrapper {
	
		public Enums.PieceType Type;
		
		public Enums.PieceColour Colour;
		
		public Enums.Files File;
		
		public Enums.Ranks Rank;
		
		public PieceSettingsWrapper(Enums.PieceType Type, Enums.PieceColour Colour, Enums.Files File, Enums.Ranks Rank)
		{
			this.Type = Type;
			this.Colour = Colour;
			this.File = File;
			this.Rank = Rank;
		}
	}
}