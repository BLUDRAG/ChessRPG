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
			
			EditorGUILayout.BeginHorizontal();
			
			GUILayout.Label("");
			
			foreach(Enums.Ranks rank in Enum.GetValues(typeof(Enums.Ranks)))
			{ 
				GUILayout.Label(((int)rank).ToString(), EditorStyles.centeredGreyMiniLabel);
			}
			
			EditorGUILayout.EndHorizontal();
			
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
				
				GUILayout.Label(currentType.ToString(), EditorStyles.centeredGreyMiniLabel);
				
				foreach(BlockSettingsWrapper block in filteredFile)
				{
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
						GenericMenu menu = new GenericMenu();
						
						Hashtable selectWhite = new Hashtable();
						selectWhite["Colour"] = Enums.BlockColour.White;
						selectWhite["Block"] = block;
						
						menu.AddItem(new GUIContent("Colour/White"), false, SetColourCallback, selectWhite);
						
						Hashtable selectBlack = new Hashtable();
						selectBlack["Colour"] = Enums.BlockColour.Black;
						selectBlack["Block"] = block;
						
						menu.AddItem(new GUIContent("Colour/Black"), false, SetColourCallback, selectBlack);
						
						menu.ShowAsContext();
					}
				}
				
				EditorGUILayout.EndHorizontal();
			}						
		}
		
		public void SetColourCallback(object data)
		{
			Hashtable selectedColour = (Hashtable)data;
			
			((BlockSettingsWrapper)selectedColour["Block"]).Colour = ((Enums.BlockColour)selectedColour["Colour"]);
			
			EditorUtility.SetDirty(_settings);
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