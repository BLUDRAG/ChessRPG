﻿using UnityEngine;
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
		/// A list of all piece models in the project.
		/// </summary>
		public GameObject[] PieceModels;
		
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
				newPiece.transform.localScale = Vector3.one;
				newPiece.transform.SetParent(PieceContainer, false);
				
				switch(piece.Type)
				{
				case Enums.PieceType.Pawn:
					newPiece.Piece = new Pawn();
					break;
				default:
					newPiece.Piece = new Pawn();
					break;
				}
				
				newPiece.Model = (GameObject)Instantiate(PieceModels[((int)piece.Type)], Vector3.zero, Quaternion.identity);
				newPiece.Model.transform.localScale = Vector3.one;
				newPiece.Model.transform.SetParent(newPiece.transform, false);
				
				newPiece.gameObject.name = piece.Colour.ToString() + " " + piece.Type.ToString() + " " + piece.File.ToString() + piece.Rank.ToString();
				newPiece.transform.localPosition = new Vector3(((int)piece.Rank - 1) * 2f, 0.6f, ((int)piece.File - 1) * 2f);
				newPiece.Piece.PieceColour = piece.Colour;
				newPiece.PreparePiece();
				
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