using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Gamify
{
	public class MaterialHighlight : BaseHighlight {
		
        /// <summary>
        /// The highlight colour.
        /// </summary>
        public Color HighlightColour;

        /// <summary>
        /// The highlight step.
        /// </summary>
        public float HighlightStep = 0.1f;

        /// <summary>
        /// The highlight delay.
        /// </summary>
        public float HighlightDelay = 0.1f;

        /// <summary>
        /// Internal colour lerp direction control.
        /// </summary>
        private bool _lerpForward = true;

        /// <summary>
        /// The lerp delta.
        /// </summary>
        private float _lerpDelta = 0f;

        /// <summary>
        /// A list of all materials attached to this component.
        /// </summary>
        private List<Material[]> _componentMaterials = new List<Material[]>();

        /// <summary>
        /// A list of all colours for each material.
        /// </summary>
        private List<Color[]> _cachedColours = new List<Color[]>();

        /// <summary>
        /// Highlight effects will continue while this is true.
        /// </summary>
        private bool _highlighting = false;

        /// <summary>
        /// Is true while the highlight is in effect.
        /// </summary>
        private bool _currentlyHighlighted = false;

        protected override void Start()
        {
            base.Start();

            // Cache all material information needed to perform the highlight effect
            Renderer[] renderers = GetComponentsInChildren<Renderer>();

            for(int r = 0; r < renderers.Length; r++)
            {
                Material[] materials = renderers[r].sharedMaterials;
                Color[] colors = new Color[materials.Length];

                for(int m = 0; m < materials.Length; m++)
                {
                    colors[m] = materials[m].color;
                }

                _componentMaterials.Add(materials);
                _cachedColours.Add(colors);
            }
        }

		/// <summary>
		/// The effect that occurs when the object's OnHighlight event is called.
		/// </summary>
        public override void OnHighlight<T>(T component)
		{
            // If the received component is not our attached component, terminate execution
            if(!ValidateComponent(component))
            {
                return;
            }

            if(!_highlighting && _lerpDelta == 0f)
            {
                _highlighting = true;

                if(!_currentlyHighlighted)
                {
                    StartCoroutine("HighlightMaterials");
                }
            }
		}
		
		/// <summary>
		/// The effect that occurs when the object's OnUnhighlight event is called.
		/// </summary>
        public override void OnUnhighlight<T>(T component)
		{
            // If the received component is not our attached component, terminate execution
            if(!ValidateComponent(component))
            {
                return;
            }

            if(_highlighting)
            {
                _highlighting = false;
            }
        }

        protected virtual IEnumerator HighlightMaterials()
        {
            _currentlyHighlighted = true;

            bool alreadySelected = false;

            while(_highlighting || _lerpDelta > 0f)
            {
                if(_isPiece && _gamePiece.Piece.IsSelected)
                {
                    _lerpForward = false;

                    if(!alreadySelected)
                    {
                        for(int r = 0; r < _componentMaterials.Count; r++)
                        {
                            for(int m = 0; m < _componentMaterials[r].Length; m++)
                            {
                                (_componentMaterials[r])[m].color = HighlightColour;
                            }
                        }

                        alreadySelected = true;
                    }
                }
                else
                {
                    for(int r = 0; r < _componentMaterials.Count; r++)
                    {
                        for(int m = 0; m < _componentMaterials[r].Length; m++)
                        {
                            (_componentMaterials[r])[m].color = Color.Lerp((_cachedColours[r])[m], HighlightColour, _lerpDelta);
                        }
                    }

                    _lerpDelta = _lerpForward ? _lerpDelta + HighlightStep : _lerpDelta - HighlightStep;
                    _lerpForward = _lerpDelta <= 0f || _lerpDelta >= 1f ? !_lerpForward : _lerpForward;
                }

                yield return new WaitForSeconds(HighlightDelay);
            }

            // Make sure the original material colour is set
            for(int r = 0; r < _componentMaterials.Count; r++)
            {
                for(int m = 0; m < _componentMaterials[r].Length; m++)
                {
                    (_componentMaterials[r])[m].color = (_cachedColours[r])[m];
                }
            }

            _lerpDelta = 0f;
            _currentlyHighlighted = false;
        }
	}
}
