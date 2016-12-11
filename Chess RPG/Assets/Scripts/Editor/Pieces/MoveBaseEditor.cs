using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Gamify
{
    [CustomEditor(typeof(MoveBase))]
    public class MoveBaseEditor : Editor {

        private MoveBase _moveBase;
        private const int blockLength = 17;
        private Color[,] blocks = new Color[blockLength,blockLength];

        public override void OnInspectorGUI()
        {
            _moveBase = (MoveBase)target;

            DrawDefaultInspector();

            DrawCustomOptions();
        }

        private void DrawCustomOptions()
        {
            EditorGUI.BeginChangeCheck();

            bool newDiagonal = EditorGUILayout.Toggle("Include Diagonals", _moveBase.IncludeDiagonal);
            bool newLinear = EditorGUILayout.Toggle("Exclude Linear", _moveBase.ExcludeLinear);

            if(EditorGUI.EndChangeCheck())
            {
                _moveBase.IncludeDiagonal = newDiagonal;
                _moveBase.ExcludeLinear = newLinear;
            }

            EditorUtility.SetDirty(_moveBase);

            if(_moveBase.MoveType == Enums.MoveType.Custom)
            {
                EditorGUI.BeginChangeCheck();

                GUILayout.Space(12);

                EditorGUILayout.BeginHorizontal();
                int newForward = Mathf.Clamp(EditorGUILayout.IntField("Forward", _moveBase.CustomForward), 0, 8);
                int newBackward = Mathf.Clamp(EditorGUILayout.IntField("Backward", _moveBase.CustomBackward), 0, 8);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                int newLeft = Mathf.Clamp(EditorGUILayout.IntField("Left", _moveBase.CustomLeft), 0, 8);
                int newRight = Mathf.Clamp(EditorGUILayout.IntField("Right", _moveBase.CustomRight), 0, 8);
                EditorGUILayout.EndHorizontal();

                GUILayout.Space(12);

                EditorGUILayout.BeginHorizontal();
                int newForwardOffset = Mathf.Clamp(EditorGUILayout.IntField("Forward Offset", _moveBase.CustomForwardOffset), 0, 7);
                int newBackwardOffset = Mathf.Clamp(EditorGUILayout.IntField("Backward Offset", _moveBase.CustomBackwardOffset), 0, 7);
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                int newLeftOffset = Mathf.Clamp(EditorGUILayout.IntField("Left Offset", _moveBase.CustomLeftOffset), 0, 7);
                int newRightOffset = Mathf.Clamp(EditorGUILayout.IntField("Right Offset", _moveBase.CustomRightOffset), 0, 7);
                EditorGUILayout.EndHorizontal();

                if(EditorGUI.EndChangeCheck())
                {
                    _moveBase.CustomForward = newForward;
                    _moveBase.CustomBackward = newBackward;
                    _moveBase.CustomLeft = newLeft;
                    _moveBase.CustomRight = newRight;

                    _moveBase.CustomForwardOffset = newForwardOffset;
                    _moveBase.CustomBackwardOffset = newBackwardOffset;
                    _moveBase.CustomLeftOffset = newLeftOffset;
                    _moveBase.CustomRightOffset = newRightOffset;
                }

                EditorUtility.SetDirty(_moveBase);

                GUILayout.Space(12);

                Vector2 origin = new Vector2(8, 8);

                for(int x = 0; x < blockLength; x++)
                {
                    for(int y = 0; y < blockLength; y++)
                    {
                        blocks[x, y] = Color.white;
                    }
                }

                int cachedLeft = newLeft;
                int cachedRight = newRight;
                int cachedForward = newForward;
                int cachedBackward = newBackward;

                if(_moveBase.IncludeDiagonal)
                {
                    while(newLeft - newLeftOffset > 0 || newRight - newRightOffset > 0 || newForward - newForwardOffset > 0 || newBackward - newBackwardOffset > 0)
                    {
                        int left = (int)origin.x;
                        int right = (int)origin.x;
                        int forward = (int)origin.y;
                        int backward = (int)origin.y;

                        if(newLeft - newLeftOffset > 0)
                        {
                            left = (int)origin.x - newLeft;
                        }

                        if(newRight - newRightOffset > 0)
                        {
                            right = (int)origin.x + newRight;
                        }

                        if(newForward - newForwardOffset > 0)
                        {
                            forward = (int)origin.y - newForward;
                        }

                        if(newBackward - newBackwardOffset > 0)
                        {
                            backward = (int)origin.y + newBackward;
                        }

                        blocks[left, forward] = Color.cyan;
                        blocks[left, backward] = Color.cyan;
                        blocks[right, forward] = Color.cyan;
                        blocks[right, backward] = Color.cyan;

                        newLeft = Mathf.Clamp(--newLeft, 0, 8);
                        newRight = Mathf.Clamp(--newRight, 0, 8);
                        newForward = Mathf.Clamp(--newForward, 0, 8);
                        newBackward = Mathf.Clamp(--newBackward, 0, 8);

                        if(_moveBase.DestinationOnly)
                        {
                            break;
                        }
                    }
                }

                newLeft = cachedLeft;
                newRight = cachedRight;
                newForward = cachedForward;
                newBackward = cachedBackward;

                if(!_moveBase.ExcludeLinear)
                {
                    while(newLeft - newLeftOffset > 0)
                    {
                        int x = (int)origin.x - newLeft;
                        blocks[x, (int)origin.y] = Color.cyan;

                        if(_moveBase.DestinationOnly)
                        {
                            break;
                        }

                        newLeft--;
                    }

                    while(newRight - newRightOffset > 0)
                    {
                        int x = (int)origin.x + newRight;
                        blocks[x, (int)origin.y] = Color.cyan;

                        if(_moveBase.DestinationOnly)
                        {
                            break;
                        }

                        newRight--;
                    }

                    while(newForward - newForwardOffset > 0)
                    {
                        int y = (int)origin.y - newForward;
                        blocks[(int)origin.x, y] = Color.cyan;

                        if(_moveBase.DestinationOnly)
                        {
                            break;
                        }

                        newForward--;
                    }

                    while(newBackward - newBackwardOffset > 0)
                    {
                        int y = (int)origin.y + newBackward;
                        blocks[(int)origin.x, y] = Color.cyan;

                        if(_moveBase.DestinationOnly)
                        {
                            break;
                        }

                        newBackward--;
                    }
                }

                blocks[(int)origin.x, (int)origin.y] = Color.magenta;


                for(int y = 0; y < blockLength; y++)
                {
                    EditorGUILayout.BeginHorizontal();

                    for(int x = 0; x < blockLength; x++)
                    {
                        GUIStyle style = EditorStyles.toggle;
                        GUI.backgroundColor = blocks[x, y];
                        GUILayout.Label("", style);
                    }

                    EditorGUILayout.EndHorizontal();
                }
            }
        }
    }
}
