using UnityEngine;
using System.Collections;

namespace Gamify
{
	/// <summary>
	/// Represents a Block within the game space.
	/// Any game space specific functionality should be
	/// defined here. Block specific functionality
	/// should merely be referenced from the attached
	/// Block type.
	/// </summary>
	public class GameBlock : MonoBehaviour {
		
		/// <summary>
		/// The Block type attached to this instance.
		/// All Block functionality is contained within
		/// this reference.
		/// </summary>
		public BlockBase Block;
		
		void Start()
		{
			Block = new NormalBlock();
		}
		
		public void OnMouseUp()
		{
			if(Block != null)
			{
				Block.OnSelected(gameObject);
			}
		}
	}
}