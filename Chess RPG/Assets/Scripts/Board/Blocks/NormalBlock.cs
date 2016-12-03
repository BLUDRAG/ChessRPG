using UnityEngine;
using System.Collections;

namespace Gamify
{
	/// <summary>
	/// This class defines a normal Block with
	/// typical behaviour expected from most
	/// Block types.
	/// </summary>
	public class NormalBlock : BlockBase {
		
		/// <summary>
		/// Handles events when this block is highlighted.
		/// </summary>
		public override void OnHighlight(GameBlock block)
		{
			EventManager<GameBlock>.Invoke(EventDefinitions.BlockHighlighted, block);
        }
        
        /// <summary>
        /// Handles events when this block is selected.
        /// </summary>
        public override void OnSelected(GameBlock block)
        {
            EventManager<GameBlock>.Invoke(EventDefinitions.BlockSelected, block);
        }
		
		/// <summary>
		/// Handles events when this block is unhighlighted.
		/// </summary>
		public override void OnUnhighlight(GameBlock block)
		{
			EventManager<GameBlock>.Invoke(EventDefinitions.BlockUnhighlighted, block);
		}
	}
}