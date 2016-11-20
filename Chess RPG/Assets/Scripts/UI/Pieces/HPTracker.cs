using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Gamify
{
    /// <summary>
    /// Tracks the HP of the associated game piece.
    /// </summary>
	public class HPTracker : MonoBehaviour {
	
        /// <summary>
        /// The attached game piece.
        /// </summary>
        public GamePiece GamePiece;

        /// <summary>
        /// The HP Bar.
        /// </summary>
        public Image HPBar;

        /// <summary>
        /// Keeps track of the previous HP value. Used to optimise HP update operations.
        /// </summary>
        private int _previousHP;

        void Update()
        {
            // Update the displayed HP only if a change has been made to the current HP of the associated piece.
            if(GamePiece.Piece != null)
            {
                if (GamePiece.Piece.CurrentHP != _previousHP)
                {
                    _previousHP = GamePiece.Piece.CurrentHP;

                    HPBar.fillAmount = Utilities.GetValuePercentage(0f, GamePiece.Piece.MaxHP, _previousHP);
                }
            }
        }
	}
}
