using UnityEngine;
using System.Collections;

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
			float x = -7f;
			foreach(PieceSettingsWrapper piece in ActiveSettings.Pieces)
			{
				GamePiece newPiece = (GamePiece)Instantiate(PiecePrefab, new Vector3(x, 1.01f, -7f), Quaternion.identity);
				newPiece.Title.text = piece.Type.ToString();
				
				x += 2f;
			}
			// Temporary
		}
	}
}