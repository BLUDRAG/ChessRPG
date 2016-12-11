using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Gamify
{
    /// <summary>
    /// This class defines basic move instructions 
    /// available to all move types. Only methods
    /// defined in this class should be used in
    /// other classes.
    /// </summary>
    public class MoveBase : ScriptableObject{

        /// <summary>
        /// The move definition of this move type.
        /// </summary>
        public Enums.MoveType MoveType;

        /// <summary>
        /// If true, only the destination block will be selectable.
        /// </summary>
        public bool DestinationOnly;

        /// <summary>
        /// If true, obstacles will not affect the destination point.
        /// </summary>
        public bool IgnoreObstacles;

        /// <summary>
        /// If true, both the x and y axis will be combined to get the destination point.
        /// </summary>
        [HideInInspector]
        public bool IncludeDiagonal;

        /// <summary>
        /// If true, the x and y axis will not be included to determine the destination point.
        /// </summary>
        [HideInInspector]
        public bool ExcludeLinear;

        /// <summary>
        /// If MoveType is Custom, this forward distance will be used.
        /// </summary>
        [HideInInspector]
        public int CustomForward;

        /// <summary>
        /// If MoveType is Custom, this backward distance will be used.
        /// </summary>
        [HideInInspector]
        public int CustomBackward;

        /// <summary>
        /// If MoveType is Custom, this left distance will be used.
        /// </summary>
        [HideInInspector]
        public int CustomLeft;

        /// <summary>
        /// If MoveType is Custom, this right distance will be used.
        /// </summary>
        [HideInInspector]
        public int CustomRight;

        /// <summary>
        /// If MoveType is Custom, this forward distance offset will be used.
        /// </summary>
        [HideInInspector]
        public int CustomForwardOffset;

        /// <summary>
        /// If MoveType is Custom, this backward distance offset will be used.
        /// </summary>
        [HideInInspector]
        public int CustomBackwardOffset;

        /// <summary>
        /// If MoveType is Custom, this left distance offset will be used.
        /// </summary>
        [HideInInspector]
        public int CustomLeftOffset;

        /// <summary>
        /// If MoveType is Custom, this right distance offset will be used.
        /// </summary>
        [HideInInspector]
        public int CustomRightOffset;

        #if UNITY_EDITOR
        [MenuItem("Assets/Gamify/Movement/Move Base")]
        public static MoveBase CreateSettings()
        {
            return EditorUtil.CreateAsset<MoveBase>();
        }
        #endif

        /// <summary>
        /// Determines whether this piece can move from the specified position.
        /// </summary>
        /// <returns><c>true</c> if this piece can move from the specified position; otherwise, <c>false</c>.</returns>
        /// <param name="position">Position.</param>
        public virtual bool CanMove(Vector2 position)
        {
            return false;
        }
    }
}
