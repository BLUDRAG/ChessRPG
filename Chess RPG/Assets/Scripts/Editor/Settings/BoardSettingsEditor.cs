using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

namespace Gamify
{
	/// <summary>
	/// Makes editing board settings a little nicer.
	/// </summary>
	[CustomEditor(typeof(BoardSettings))]
	public class BoardSettingsEditor : Editor {
		
		/// TODO : Make this a lot nicer
		
		private BoardSettings _settings;
		
		public override void OnInspectorGUI()
		{
			_settings = (BoardSettings)target;
			
			DrawDefaultInspector();
			
			DrawBlockData();
		}
		
		private void DrawBlockData()
		{
			GUILayout.Space(10f);
			
			GUIStyle headerStyle = EditorStyles.largeLabel;
			headerStyle.fontStyle = FontStyle.Bold;
			headerStyle.alignment = TextAnchor.UpperCenter;
			
			foreach(Enums.Files file in Enum.GetValues(typeof(Enums.Files)))
			{
				EditorGUILayout.LabelField(file.ToString() + " File", headerStyle);
				
				EditorGUILayout.BeginHorizontal();
				
				GUILayout.Label("Colour", EditorStyles.boldLabel);
				GUILayout.Label("File", EditorStyles.boldLabel);
				GUILayout.Label("Rank", EditorStyles.boldLabel);
				
				EditorGUILayout.EndHorizontal();
				
				foreach(BlockSettingsWrapper block in _settings.Blocks.FindAll(block => block.File == file))
				{
					EditorGUI.BeginChangeCheck();
					
					EditorGUILayout.BeginHorizontal();
					
					Enums.BlockColour newColour = (Enums.BlockColour)EditorGUILayout.EnumPopup(block.Colour);
					Enums.Files newFile = (Enums.Files)EditorGUILayout.EnumPopup(block.File);
					Enums.Ranks newRank = (Enums.Ranks)EditorGUILayout.EnumPopup(block.Rank);
					
					if(GUILayout.Button("Remove"))
					{
						_settings.Blocks.Remove(block);
						
						EditorUtility.SetDirty(_settings);
					}
					
					EditorGUILayout.EndHorizontal();
					
					if(EditorGUI.EndChangeCheck())
					{
						block.Colour = newColour;
						block.File = newFile;
						block.Rank = newRank;
					}
					
					EditorUtility.SetDirty(_settings);
				}
				
				if(GUILayout.Button("Add Block To " + file.ToString() + " File"))
				{
					_settings.Blocks.Add(new BlockSettingsWrapper(Enums.BlockColour.White, file, Enums.Ranks._1));
					
					EditorUtility.SetDirty(_settings);
				}
			}
		}
	}
}