using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Gamify
{
	public class Board : MonoBehaviour {
		
		/// <summary>
		/// The current board settings.
		/// </summary>
		public BoardSettings ActiveSettings;
		
		/// <summary>
		/// A list of all the blocks currently in the level.
		/// </summary>
		public List<GameBlock> LevelBlocks = new List<GameBlock>();
		
		/// <summary>
		/// The block prefab.
		/// </summary>
		public GameBlock BlockPrefab;
		
		/// <summary>
		/// The block container object.
		/// </summary>
		public Transform BlockContainer;
		
		void Start()
		{
			InitializeBoard();
		}
		
		/// <summary>
		/// TODO: This method should set up the blocks on the board
		///       and do any pre-game board initialization.
		/// </summary>
		public void InitializeBoard()
		{
			GenerateBlocks();
		}
		
		/// <summary>
		/// Creates all blocks contained within the current
		/// board settings.
		/// </summary>
		public void GenerateBlocks()
		{
			foreach(BlockSettingsWrapper block in ActiveSettings.Blocks)
			{
				GameBlock newBlock = (GameBlock)Instantiate(BlockPrefab, Vector3.zero, Quaternion.identity);
				newBlock.transform.SetParent(BlockContainer, false);
				
				// TODO We'll need a way to select a block type for each setting.
				NormalBlock normalBlock = new NormalBlock();
				normalBlock.Colour = block.Colour;
				normalBlock.File = block.File;
				normalBlock.Rank = block.Rank;
				
				newBlock.Block = normalBlock;
				newBlock.gameObject.name = "Block " + newBlock.Block.File.ToString() + ((int)newBlock.Block.Rank).ToString();
				newBlock.PrepareBlock();
				
				LevelBlocks.Add(newBlock);
			}
		}
		
		/// <summary>
		/// Removes all blocks within the current game.
		/// </summary>
		public void ClearBlocks()
		{
			foreach(GameBlock block in LevelBlocks)
			{
				DestroyImmediate(block.gameObject);
			}
			
			LevelBlocks.Clear();
		}
	}
}