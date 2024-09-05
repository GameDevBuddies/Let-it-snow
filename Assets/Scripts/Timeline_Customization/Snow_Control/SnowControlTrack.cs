using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace GameDevBuddies
{
    [TrackClipType(typeof(SnowControlAsset))]
    [TrackBindingType(typeof(SnowControlSettings))]
    public class SnowControlTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<SnowControlMixer>.Create(graph, inputCount);
        }
    }
}