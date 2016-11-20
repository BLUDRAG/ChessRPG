using UnityEngine;
using System.Collections;

namespace Gamify
{
	/// <summary>
	/// Represents a Piece within the game space.
	/// Any game space specific functionality should be
	/// defined here. Piece specific functionality
	/// should merely be referenced from the attached
	/// Piece type.
	/// </summary>
	public class GamePiece : MonoBehaviour {
		
		/// <summary>
		/// The Piece type attached to this instance.
		/// All Piece functionality is contained within
		/// this reference.
		/// </summary>
		public PieceBase Piece;
		
		/// <summary>
		/// The model attached to this game piece.
		/// </summary>
		public GameObject Model;
		
		/// <summary>
		/// The shader applied to all materials attached to this piece.
		/// </summary>
		public string ActiveShader = "Standard";
		
		/// <summary>
		/// All materials attached to the piece model.
		/// </summary>
		private Material[] _materials;
		
		/// <summary>
		/// Sets up all in-game settings for this piece.
		/// </summary>
		public void PreparePiece()
		{
			UpdateModelColours();
			
		}
		
		/// <summary>
		/// Applies the active piece colour to the piece model.
		/// </summary>
		public void UpdateModelColours()
		{
			// Retrieve every mesh renderer within the model
			MeshRenderer[] meshes = Model.GetComponentsInChildren<MeshRenderer>();			
			
			// Prepare the material with the applied colour
			Material pieceMaterial = new Material(Shader.Find(ActiveShader));
            pieceMaterial.SetColor("_Color", Utilities.GetPieceColor(Piece.PieceColour));
			
			// And finally apply the material to each mesh renderer
			for(int i = 0; i < meshes.Length; i++)
			{
				meshes[i].sharedMaterial = pieceMaterial;
			}
		}
	}
}