using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Gamify
{
	public class Board : MonoBehaviour {
		
		/// <summary>
		/// A list of all the blocks currently in the level.
		/// </summary>
		public List<BlockBase> LevelBlocks = new List<BlockBase>();
		
		/// <summary>
		/// TODO: This method should set up the blocks on the board
		///       and do any pre-game board initialization.
		/// </summary>
		public void InitializeBoard(List<BlockBase> blocks)
		{
			
		}
	}
}