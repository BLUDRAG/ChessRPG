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
        /// The game piece attached to this highlight effect.
        /// </summary>
        protected GamePiece _gamePiece;

        /// <summary>
        /// The game block attached to this highlight effect.
        /// </summary>
        protected GameBlock _gameBlock;

        /// <summary>
        /// Flag indicating whether this highlight effect is attached to a piece or a block.
        /// </summary>
        protected bool _isPiece = false;

        protected virtual void Start()
        {
            // Determine which highlight event to register to
            _gamePiece = GetComponentInParent<GamePiece>();
            _gameBlock = GetComponentInParent<GameBlock>();
            _isPiece = _gamePiece != null;

            // Register highlight events
            if(_isPiece)
            {
                EventManager<GamePiece>.SubscribeEvent(_isPiece ? EventDefinitions.PieceHighlighted : EventDefinitions.BlockHighlighted, OnHighlight);
                EventManager<GamePiece>.SubscribeEvent(_isPiece ? EventDefinitions.PieceUnhighlighted : EventDefinitions.BlockUnhighlighted, OnUnhighlight);
            }
            else
            {
                EventManager<GameBlock>.SubscribeEvent(_isPiece ? EventDefinitions.PieceHighlighted : EventDefinitions.BlockHighlighted, OnHighlight);
                EventManager<GameBlock>.SubscribeEvent(_isPiece ? EventDefinitions.PieceUnhighlighted : EventDefinitions.BlockUnhighlighted, OnUnhighlight);
            }
        }

        protected virtual void OnDestroy()
        {
            // Remove events
            if(_isPiece)
            {
                EventManager<GamePiece>.UnsubscribeEvent(_isPiece ? EventDefinitions.PieceHighlighted : EventDefinitions.BlockHighlighted, OnHighlight);
                EventManager<GamePiece>.UnsubscribeEvent(_isPiece ? EventDefinitions.PieceUnhighlighted : EventDefinitions.BlockUnhighlighted, OnUnhighlight);
            }
            else
            {
                EventManager<GameBlock>.UnsubscribeEvent(_isPiece ? EventDefinitions.PieceHighlighted : EventDefinitions.BlockHighlighted, OnHighlight);
                EventManager<GameBlock>.UnsubscribeEvent(_isPiece ? EventDefinitions.PieceUnhighlighted : EventDefinitions.BlockUnhighlighted, OnUnhighlight);
            }
        }
		
		/// <summary>
		/// The effect that occurs when the object's OnHighlight event is called.
		/// </summary>
		public abstract void OnHighlight<T>(T component);
		
		/// <summary>
		/// The effect that occurs when the object's OnUnhighlight event is called.
		/// </summary>
        public abstract void OnUnhighlight<T>(T component);

        /// <summary>
        /// Validates the component.
        /// </summary>
        /// <returns><c>true</c>, if component was validated, <c>false</c> otherwise.</returns>
        /// <param name="component">Component.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public bool ValidateComponent<T>(T component)
        {
            if(_isPiece)
            {
                if((component as GamePiece) != _gamePiece)
                {
                    return false;
                }
            }
            else
            {
                if((component as GameBlock) != _gameBlock)
                {
                    return false;
                }
            }

            return true;
        }
	}
}
