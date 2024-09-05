using System.Collections.Generic;
using UnityEngine;

namespace GameDevBuddies
{
    [ExecuteInEditMode]
    public class SnowControlSettings : MonoBehaviour
    {
        [Header("References: ")]
        [SerializeField] private List<Material> _materials = new List<Material>();

        [Header("Settings: ")]
        [SerializeField, Range(0f, 1f)] private float _globalWeatherInfluence = 1f;
        [SerializeField, Range(0f, 1f)] private float _wetness = 1f;
        [SerializeField, Range(0.01f, 40f)] private float _snowFalloff = 15f;

        private void Awake()
        {
            UpdateSnowSettings(_globalWeatherInfluence, _wetness, _snowFalloff);
        }

        private void OnEnable()
        {
            UpdateSnowSettings(_globalWeatherInfluence, _wetness, _snowFalloff);
        }

        private void OnValidate()
        {
            UpdateSnowSettings(_globalWeatherInfluence, _wetness, _snowFalloff);
        }

        public void UpdateSnowSettings(float globalWeatherInfluence, float wetness, float snowFalloff)
        {
            foreach(Material material in _materials)
            {
                if(material == null)
                {
                    continue;
                }

                material.SetFloat("_Global_Weather_Effect", globalWeatherInfluence);
                material.SetFloat("_Wetness", wetness);
                material.SetFloat("_Snow_Falloff", snowFalloff);
            }
        }
    }
}