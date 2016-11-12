using UnityEngine;
using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Gamify
{
	/// <summary>
	/// This class defines a list of pieces available for
	/// use within the game. Each container can have a set
	/// of pieces specializing in certain areas, or can
	/// simply be duplicates of other containers, with simple
	/// mesh changes.
	/// </summary>
	public class ModelPieceContainer : ScriptableObject {
		
		#if UNITY_EDITOR
		[MenuItem("Assets/Gamify/Models/Pieces/Model Piece Container")]
		public static ModelPieceContainer CreateSettings()
		{
			return EditorUtil.CreateAsset<ModelPieceContainer>();
		}
        #endif
		
		/// <summary>
		/// A list of all pieces models defined for this container.
		/// </summary>
		public List<GameObject> PieceModels;
	}
}