using UnityEngine;
using System.Collections;

namespace Gamify
{
	/// <summary>
	/// The purpose of this class is to delegate any form
	/// of events that occur to the GamePiece root when 
	/// interacting with the associated piece.
	/// </summary>
	public class PieceEventHandler : MonoBehaviour {
		
		/// <summary>
		/// A reference to the root game piece.
		/// </summary>
		public GamePiece PieceParent;
		
		void Start()
		{
			PieceParent = transform.GetComponentInParent<GamePiece>();
		}
		
		public void OnMouseDown()
		{
			if(PieceParent)
			{
				PieceParent.Piece.OnSelected(PieceParent);
			}
			else
			{
				Debug.LogWarning("GAMIFY - " + name + " could not find a GamePiece parent reference.");
			}
		}
		
		public void OnMouseOver()
		{
			if(PieceParent)
			{
                // Only highlight if the piece is not currently selected.
                if(!PieceParent.Piece.IsSelected)
                {
                    PieceParent.Piece.OnHighlight(PieceParent);
                }
			}
			else
			{
				Debug.LogWarning("GAMIFY - " + name + " could not find a GamePiece parent reference.");
			}
		}
		
		public void OnMouseExit()
		{
			if(PieceParent)
			{
				PieceParent.Piece.OnUnhighlight(PieceParent);
			}
			else
			{
				Debug.LogWarning("GAMIFY - " + name + " could not find a GamePiece parent reference.");
			}			
		}
	}
}
