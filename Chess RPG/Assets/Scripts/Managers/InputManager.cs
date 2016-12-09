using UnityEngine;
using System.Collections;

namespace Gamify
{
    /// <summary>
    /// The Input Manager is responsible for managing any 
    /// form of input within the board. It delegates input 
    /// events to any interested parties. It does not contain
    /// any implementation for event handling.
    /// </summary>
    public class InputManager : MonoBehaviour {

        /// <summary>
        /// The currently selected game piece.
        /// </summary>
        public GamePiece SelectedPiece;

        /// <summary>
        /// The currently selected game block.
        /// </summary>
        public GameBlock SelectedBlock;

        /// <summary>
        /// The InputManager instance reference.
        /// </summary>
        public static InputManager Instance
        {
            get
            {
                if (!_instance)
                {
                    _instance = GameObject.FindObjectOfType<InputManager>();
                }

                return _instance;
            }
        }

        private static InputManager _instance;

        /// <summary>
        /// Selects the given game piece.
        /// </summary>
        /// <param name="piece">Piece.</param>
        public void SelectPiece(GamePiece piece)
        {
            // TODO If a piece has already been selected, send any necessary events to interested parties

            if(SelectedPiece != piece)
            {
                // Deselect the previous piece first.
                if(SelectedPiece != null)
                {
                    SelectedPiece.Piece.IsSelected = false;
                }

                SelectedPiece = piece;
                SelectedPiece.Piece.IsSelected = true;
            }

            // Deselect a previously selected piece.
            if(SelectedBlock != null)
            {
                SelectedBlock.Block.IsSelected = false;
                SelectedBlock = null;
            }
        }

        /// <summary>
        /// Selects the given game block.
        /// </summary>
        /// <param name="block">Block.</param>
        public void SelectBlock(GameBlock block)
        {
            // TODO If a block has already been selected, send any necessary events to interested parties

            if(SelectedBlock != block)
            {
                // Deselect the previous piece first.
                if(SelectedBlock != null)
                {
                    SelectedBlock.Block.IsSelected = false;
                }

                SelectedBlock = block;
                SelectedBlock.Block.IsSelected = true;
            }

            // Deselect a previously selected piece.
            if(SelectedPiece != null)
            {
                SelectedPiece.Piece.IsSelected = false;
                SelectedPiece = null;
            }
        }
    }
}