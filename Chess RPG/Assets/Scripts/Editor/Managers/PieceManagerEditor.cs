using UnityEngine;
using UnityEditor;
using System.Collections;

namespace Gamify
{
	[CustomEditor(typeof(PieceManager))]
	public class PieceManagerEditor : Editor {
	
		private PieceManager _manager;
		
		public override void OnInspectorGUI()
		{
			_manager = (PieceManager)target;
			
			DrawDefaultInspector();
			
			DrawPieceGenerationData();
			
			DrawPieceRemovalData();
		}
		
		private void DrawPieceGenerationData()
		{
			GUILayout.Space(10f);
			
			if(GUILayout.Button("Generate Pieces", EditorStyles.miniButton))
			{
				_manager.GeneratePieces();
			}
		}
		
		private void DrawPieceRemovalData()
		{
			GUILayout.Space(5f);
			
			if(GUILayout.Button("Clear Pieces", EditorStyles.miniButton))
			{
				_manager.ClearPieces();
			}
		}
	}
}
