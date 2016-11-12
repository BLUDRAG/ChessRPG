using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Gamify
{
	[CustomEditor(typeof(Board))]
	public class BoardEditor : Editor {
		
		private Board _board;
		
		public override void OnInspectorGUI()
		{
			_board = (Board)target;
			
			DrawDefaultInspector();
			
			DrawBlockGenerationData();
			
			DrawBlockRemovalData();
		}
		
		private void DrawBlockGenerationData()
		{
			GUILayout.Space(10f);
			
			if(GUILayout.Button("Generate Blocks", EditorStyles.miniButton))
			{
				_board.GenerateBlocks();
			}
		}
		
		private void DrawBlockRemovalData()
		{
			GUILayout.Space(5f);
			
			if(GUILayout.Button("Clear Blocks", EditorStyles.miniButton))
			{
				_board.ClearBlocks();
			}
		}
	}
}
