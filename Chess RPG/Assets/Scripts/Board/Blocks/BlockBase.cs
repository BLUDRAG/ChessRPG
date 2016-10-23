using UnityEngine;
using System.Collections;

namespace Gamify
{
	/// <summary>
	/// The BlockBase defines skeleton methods available to
	/// all derived Block types. Only methods defined here
	/// should be used in other classes not derived from
	/// BlockBase. 
	/// </summary>
	public abstract class BlockBase {
		
		/// <summary>
		/// The file this Block occupies.
		/// </summary>
		public Enums.Files File;
		
		/// <summary>
		/// The rank this Block occupies.
		/// </summary>
		public Enums.Ranks Rank;
		
		/// <summary>
		/// Handles events when this block is highlighted.
		/// </summary>
		public abstract void OnHighlight(GameObject block);
		
		/// <summary>
		/// Handles events when this block is selected.
		/// </summary>
		public abstract void OnSelected(GameObject block);
	}
}