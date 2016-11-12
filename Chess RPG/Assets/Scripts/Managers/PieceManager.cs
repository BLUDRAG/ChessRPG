using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Gamify
{
	/// <summary>
	/// This class is responsible for all internal piece
	/// creation and destruction within the game.
	/// </summary>
	public class PieceManager : MonoBehaviour {
		
		/// <summary>
		/// The current piece settings used by the PieceManager.
		/// </summary>
		public PieceSettings ActiveSettings;
		
		/// <summary>
		/// The piece prefab.
		/// </summary>
		public GamePiece PiecePrefab;
		
		/// <summary>
		/// A list of all pieces within the current game.
		/// </summary>
		public List<GamePiece> ActivePieces;
		
		/// <summary>
		/// The piece container object.
		/// </summary>
		public Transform PieceContainer;
		
		void Start()
		{
			// Temporary
			GeneratePieces();
			// Temporary
		}
		
		/// <summary>
		/// Creates all pieces contained within the current
		/// piece settings.
		/// </summary>
		public void GeneratePieces()
		{
			// Temporary
			foreach(PieceSettingsWrapper piece in ActiveSettings.Pieces)
			{
				GamePiece newPiece = (GamePiece)Instantiate(PiecePrefab, Vector3.zero, Quaternion.identity);
				newPiece.transform.SetParent(PieceContainer, false);
				
				// TODO We'll need a way to select a piece type for each setting
				newPiece.gameObject.name = piece.Colour.ToString() + " " + piece.Type.ToString() + " " + piece.File.ToString() + piece.Rank.ToString();
				newPiece.Title.text = piece.Type.ToString();
				newPiece.transform.localPosition = new Vector3(((int)piece.Rank - 1) * 2f, 0.6f, ((int)piece.File - 1) * 2f);
				//newPiece.PreparePiece();
				
				ActivePieces.Add(newPiece);
				
			}
			// Temporary
		}
		
		/// <summary>
		/// Deletes all active pieces within the current game.
		/// </summary>
		public void ClearPieces()
		{
			foreach(GamePiece piece in ActivePieces)
			{
				DestroyImmediate(piece.gameObject);
			}
			
			ActivePieces.Clear();
		}
	}
}