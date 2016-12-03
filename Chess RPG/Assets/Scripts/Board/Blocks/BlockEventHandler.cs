using UnityEngine;
using System.Collections;

namespace Gamify
{
    /// <summary>
    /// The purpose of this class is to delegate any form
    /// of events that occur to the GameBlock root when 
    /// interacting with the associated block.
    /// </summary>
    public class BlockEventHandler : MonoBehaviour {

        /// <summary>
        /// A reference to the root game block.
        /// </summary>
        public GameBlock BlockParent;

        void Start()
        {
            BlockParent = transform.GetComponentInParent<GameBlock>();
        }

        public void OnMouseDown()
        {
            if(BlockParent)
            {
                BlockParent.Block.OnSelected(BlockParent);
            }
            else
            {
                Debug.LogWarning("GAMIFY - " + name + " could not find a GamePiece parent reference.");
            }
        }

        public void OnMouseOver()
        {
            if(BlockParent)
            {
                BlockParent.Block.OnHighlight(BlockParent);
            }
            else
            {
                Debug.LogWarning("GAMIFY - " + name + " could not find a GamePiece parent reference.");
            }
        }
	    
	    public void OnMouseExit()
	    {
		    if(BlockParent)
		    {
			    BlockParent.Block.OnUnhighlight(BlockParent);
		    }
		    else
		    {
			    Debug.LogWarning("GAMIFY - " + name + " could not find a GamePiece parent reference.");
		    }
	    }
    }
}
