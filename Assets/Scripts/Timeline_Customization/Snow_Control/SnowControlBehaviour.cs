using System;
using UnityEngine;
using UnityEngine.Playables;

namespace GameDevBuddies
{
    [Serializable]
    public class SnowControlBehaviour : PlayableBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float _globalWeatherInfluence = 1f;
        [SerializeField, Range(0f, 1f)] private float _wetness = 1f;
        [SerializeField, Range(0.01f, 40f)] private float _snowFalloff = 15f;

        public float GlobalWeatherInfluence { get { return _globalWeatherInfluence; } }
        public float Wetness { get { return _wetness; } }
        public float SnowFalloff { get { return _snowFalloff; } }
    }
}