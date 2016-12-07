using UnityEngine;
using System.Collections;

namespace Gamify
{
	/// <summary>
	/// This class defines the functionality skeleton available
	/// to all highlight effects. Only method defined here should
	/// be used in other classes.
	/// </summary>
	public abstract class BaseHighlight : MonoBehaviour {

        /// <summary>
        /// Flag indicating whether this highlight effect is attached to a piece or a block.
        /// </summary>
        private bool _isPiece = false;

        protected virtual void Start()
        {
            // Determine which highlight event to register to
            _isPiece = GetComponentInParent<PieceBase>() != null;

            // Register highlight events
            EventManager<bool>.SubscribeEvent(_isPiece ? EventDefinitions.PieceHighlighted : EventDefinitions.BlockHighlighted, OnHighlight);
            EventManager<bool>.SubscribeEvent(_isPiece ? EventDefinitions.PieceUnhighlighted : EventDefinitions.BlockUnhighlighted, OnHighlight);
        }

        protected virtual void OnDestroy()
        {
            // Remove events
            EventManager<bool>.UnsubscribeEvent(_isPiece ? EventDefinitions.PieceHighlighted : EventDefinitions.BlockHighlighted, OnHighlight);
            EventManager<bool>.UnsubscribeEvent(_isPiece ? EventDefinitions.PieceUnhighlighted : EventDefinitions.BlockUnhighlighted, OnHighlight);
        }
		
		/// <summary>
		/// The effect that occurs when the object's OnHighlight event is called.
		/// </summary>
		public abstract void OnHighlight();
		
		/// <summary>
		/// The effect that occurs when the object's OnUnhighlight event is called.
		/// </summary>
		public abstract void OnUnhighlight();
	}
}
