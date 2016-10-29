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
		
		/// Temporary?
		public Material BlockMaterial;
		/// Temporary?
		
		/// <summary>
		/// Sets up all in-game settings for this block
		/// </summary>
		public void PrepareBlock()
		{
			/// Temporary?
			Color blockColour = Color.white;
			
			switch(Block.Colour)
			{
			case Enums.BlockColour.Black:
				blockColour = Color.black;
				break;
			}
			
			BlockMaterial = GetComponent<MeshRenderer>().material;
			BlockMaterial.SetColor("_Color", blockColour);
			
			transform.localPosition = new Vector3(((int)Block.Rank - 1) * 2f, 0.5f, ((int)Block.File - 1) * 2f);
			/// Temporary?
		}
	}
}