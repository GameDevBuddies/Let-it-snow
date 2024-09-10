using System.Collections.Generic;
using UnityEngine;

namespace GameDevBuddies
{
    /// <summary>
    /// Script holding the reference to all materials that need to update when the global snow settings change.
    /// It updates the look of all referenced materials whenever a certain parameter change (both in Scene and in Play Mode).
    /// </summary>
    [ExecuteInEditMode]
    public class SnowControlSettings : MonoBehaviour
    {
        [Header("References: ")]
        [SerializeField] private List<Material> _materials = new List<Material>();

        [Header("Settings: ")]
        [SerializeField, Range(0f, 1f)] private float _globalWeatherInfluence = 1f;
        [SerializeField, Range(0.01f, 40f)] private float _snowFalloff = 15f;

        private void Awake()
        {
            UpdateSnowSettings(_globalWeatherInfluence, _snowFalloff);
        }

        private void OnEnable()
        {
            UpdateSnowSettings(_globalWeatherInfluence, _snowFalloff);
        }

        private void OnValidate()
        {
            UpdateSnowSettings(_globalWeatherInfluence, _snowFalloff);
        }

        /// <summary>
        /// Function that applies the global weather influence and the current snow amount to all referenced materials.
        /// </summary>
        /// <param name="globalWeatherInfluence">Global influence of the weather effects on the materials. When 0, no 
        /// weather effects will be applied to the materials.</param>
        /// <param name="snowFalloff">Amount of area covered by snow on the objects.</param>
        public void UpdateSnowSettings(float globalWeatherInfluence, float snowFalloff)
        {
            foreach(Material material in _materials)
            {
                if(material == null)
                {
                    continue;
                }

                material.SetFloat("_Global_Weather_Effect", globalWeatherInfluence);
                material.SetFloat("_Snow_Falloff", snowFalloff);
            }
        }
    }
}