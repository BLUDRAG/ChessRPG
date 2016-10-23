using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

namespace Gamify
{
	/// <summary>
	/// Makes editing piece settings a little nicer.
	/// </summary>
	[CustomEditor(typeof(PieceSettings))]
	public class PieceSettingsEditor : Editor {
		
		private PieceSettings _settings;
		
		public override void OnInspectorGUI()
		{
			_settings = (PieceSettings)target;
			
			DrawDefaultInspector();
			
			DrawPieceData();
		}
		
		private void DrawPieceData()
		{
			GUILayout.Space(10f);

            GUIStyle headerStyle = EditorStyles.largeLabel;
            headerStyle.fontStyle = FontStyle.Bold;
            headerStyle.alignment = TextAnchor.UpperCenter;

            foreach(Enums.PieceColour colour in Enum.GetValues(typeof(Enums.PieceColour)))
            {
                EditorGUILayout.LabelField(colour.ToString(), headerStyle);

                EditorGUILayout.BeginHorizontal();
            
                GUILayout.Label("Piece", EditorStyles.boldLabel);
                GUILayout.Label("Colour", EditorStyles.boldLabel);
                GUILayout.Label("File", EditorStyles.boldLabel);
                GUILayout.Label("Rank", EditorStyles.boldLabel);
            
                EditorGUILayout.EndHorizontal();

                foreach(PieceSettingsWrapper piece in _settings.Pieces.FindAll(piece => piece.Colour == colour))
                {
                    EditorGUI.BeginChangeCheck();

                    EditorGUILayout.BeginHorizontal();

                    Enums.PieceType newType = (Enums.PieceType)EditorGUILayout.EnumPopup(piece.Type);
                    Enums.PieceColour newColour = (Enums.PieceColour)EditorGUILayout.EnumPopup(piece.Colour);
                    Enums.Files newFile = (Enums.Files)EditorGUILayout.EnumPopup(piece.File);
                    Enums.Ranks newRank = (Enums.Ranks)EditorGUILayout.EnumPopup(piece.Rank);

                    if(GUILayout.Button("Remove"))
                    {
                        _settings.Pieces.Remove(piece);

                        EditorUtility.SetDirty(_settings);
                    }

                    EditorGUILayout.EndHorizontal();

                    if(EditorGUI.EndChangeCheck())
                    {
                        piece.Type = newType;
                        piece.Colour = newColour;
                        piece.File = newFile;
                        piece.Rank = newRank;
                    }

                    EditorUtility.SetDirty(_settings);
                }

                if(GUILayout.Button("Add " + colour.ToString() + " Piece"))
                {
                    _settings.Pieces.Add(new PieceSettingsWrapper(Enums.PieceType.Pawn, colour, Enums.Files.A, Enums.Ranks._1));

                    EditorUtility.SetDirty(_settings);
                }
            }
		}
	}
}