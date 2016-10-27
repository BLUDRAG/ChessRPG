using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

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
			
			EditorGUILayout.LabelField("Board Layout", headerStyle);
			
			Dictionary<Enums.Files, List<BlockSettingsWrapper>> orderedBoardArrangement = new Dictionary<Gamify.Enums.Files, List<Gamify.BlockSettingsWrapper>>();
			Array fileTypes = Enum.GetValues(typeof(Enums.Files));
			
			foreach(Enums.Files file in fileTypes)
			{ 
				orderedBoardArrangement[file] = new List<Gamify.BlockSettingsWrapper>();
				orderedBoardArrangement[file].AddRange(_settings.Blocks.FindAll(block => block.File == file));
			}
			
			for(int i = fileTypes.Length - 1; i >= 0; i--)
			{
				Enums.Files currentType = (Enums.Files)fileTypes.GetValue(i);
				
				List<BlockSettingsWrapper> filteredFile = GetDefaultFile(currentType);
				orderedBoardArrangement[currentType].ForEach(wrapper => filteredFile[((int)wrapper.Rank) - 1] = wrapper);
				
				EditorGUILayout.BeginHorizontal();
				
				GUILayout.Label(currentType.ToString());
				
				foreach(BlockSettingsWrapper block in filteredFile)
				{
					EditorGUI.BeginChangeCheck();
					
					
					
					GUIStyle blockStyle = new GUIStyle(GUI.skin.button);
					
					switch(block.Colour)
					{
					case Enums.BlockColour.Black:
						GUI.backgroundColor = Color.black;
						break;
					case Enums.BlockColour.White:
						GUI.backgroundColor = Color.white;
						break;
					}										
					
					if(GUILayout.Button("", blockStyle))
					{
						string[] options = new string[]{"A", "B"};
						
						EditorGUILayout.Popup(0, options);
					}
					
					if(EditorGUI.EndChangeCheck())
					{
						
					}
				}
				
				EditorGUILayout.EndHorizontal();
			}
			
			//foreach(BlockSettingsWrapper block in _settings.Blocks.FindAll(block => block.File == file))
			//{										
			//	EditorGUI.BeginChangeCheck();
				
			//	EditorGUILayout.BeginHorizontal();
				
			//	Enums.BlockColour newColour = (Enums.BlockColour)EditorGUILayout.EnumPopup(block.Colour);
			//	Enums.Files newFile = (Enums.Files)EditorGUILayout.EnumPopup(block.File);
			//	Enums.Ranks newRank = (Enums.Ranks)EditorGUILayout.EnumPopup(block.Rank);
				
			//	if(GUILayout.Button("Remove"))
			//	{
			//		_settings.Blocks.Remove(block);
					
			//		EditorUtility.SetDirty(_settings);
			//	}
				
			//	EditorGUILayout.EndHorizontal();
				
			//	if(EditorGUI.EndChangeCheck())
			//	{
			//		block.Colour = newColour;
			//		block.File = newFile;
			//		block.Rank = newRank;
			//	}
				
			//	EditorUtility.SetDirty(_settings);
			//}
			
			//if(GUILayout.Button("Add Block To " + file.ToString() + " File"))
			//{
			//	_settings.Blocks.Add(new BlockSettingsWrapper(Enums.BlockColour.White, file, Enums.Ranks._1));
				
			//	EditorUtility.SetDirty(_settings);
			//}
		}
		
		public List<BlockSettingsWrapper> GetDefaultFile(Enums.Files file)
		{
			List<BlockSettingsWrapper> defaultFile = new List<Gamify.BlockSettingsWrapper>();
			
			for(int i = 0; i < Enum.GetValues(typeof(Enums.Files)).Length; i++)
			{
				defaultFile.Add(new BlockSettingsWrapper(Enums.BlockColour.White, file, (Enums.Ranks)(i + 1)));
			}
			
			return defaultFile;
		}
	}
}