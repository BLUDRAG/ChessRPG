using UnityEngine;
using System.Collections;

namespace Gamify
{
    /// <summary>
    /// This class handles any events sent by game blocks.
    /// </summary>
    public class BlockEventManager : MonoBehaviour {

        void Awake()
        {
            EventManager<GameBlock>.SubscribeEvent(EventDefinitions.BlockSelected, OnBlockSelected);
            EventManager<GameBlock>.SubscribeEvent(EventDefinitions.BlockHighlighted, OnBlockHighlighted);
        }

        /// <summary>
        /// Performs any available action on the selected block.
        /// </summary>
        /// <param name="block">Block.</param>
        private void OnBlockSelected(GameBlock block)
        {
            // Temporary
            print(block.Block.Colour);
            InputManager.Instance.SelectBlock(block);
            // Temporary
        }

        /// <summary>
        /// Performs any available action on the highlighted block.
        /// </summary>
        /// <param name="block">Block.</param>
        private void OnBlockHighlighted(GameBlock block)
        {
            // Temporary
            print(block.Block.Colour);
            // Temporary
        }
    }
}
