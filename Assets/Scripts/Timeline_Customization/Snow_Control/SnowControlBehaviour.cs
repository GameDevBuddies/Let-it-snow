using System;
using UnityEngine;
using UnityEngine.Playables;

namespace GameDevBuddies
{
    /// <summary>
    /// Script that represents the clip on the Timeline for controlling the global behaviour of the snow.
    /// </summary>
    [Serializable]
    public class SnowControlBehaviour : PlayableBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float _globalWeatherInfluence = 1f;
        [SerializeField, Range(0.01f, 40f)] private float _snowFalloff = 15f;

        /// <summary>
        /// Property providing the value of the global weather influence. If the influence is 0, no snow will be visible.
        /// </summary>
        public float GlobalWeatherInfluence { get { return _globalWeatherInfluence; } }

        /// <summary>
        /// Property providing the value of the snow falloff shader property. It represents the spread of snow over the surface.
        /// </summary>
        public float SnowFalloff { get { return _snowFalloff; } }
    }
}