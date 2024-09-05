using UnityEngine;
using UnityEngine.Playables;

namespace GameDevBuddies
{
    public class SnowControlAsset : PlayableAsset
    {
        public SnowControlBehaviour template;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<SnowControlBehaviour>.Create(graph, template);
        }
    }
}