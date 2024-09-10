using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace GameDevBuddies
{
    /// <summary>
    /// Script responsible for creating a track in the Timeline and for creation of the Mixer component on it.
    /// </summary>
    [TrackClipType(typeof(SnowControlAsset))]
    [TrackBindingType(typeof(SnowControlSettings))]
    public class SnowControlTrack : TrackAsset
    {
        /// <inheritdoc/>
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<SnowControlMixer>.Create(graph, inputCount);
        }
    }
}