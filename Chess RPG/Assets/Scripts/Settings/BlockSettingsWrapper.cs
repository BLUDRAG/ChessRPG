using System;

namespace Gamify
{
	/// <summary>
	/// The sole purpose of this class is to wrap all
	/// information needed to create an individual
	/// block setting inside a single container.
	/// </summary>
	[Serializable]
	public class BlockSettingsWrapper {
		
		public Enums.BlockColour Colour;
		
		public Enums.Files File;
		
		public Enums.Ranks Rank;
		
		public BlockSettingsWrapper(Enums.BlockColour Colour, Enums.Files File, Enums.Ranks Rank)
		{
			this.Colour = Colour;
			this.File = File;
			this.Rank = Rank;
		}
	}
}