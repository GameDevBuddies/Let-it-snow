using UnityEngine;
using UnityEngine.Playables;

namespace GameDevBuddies
{
    /// <summary>
    /// Script that spawns the <see cref="SnowControlBehaviour"/> as a clip on a Timeline track.
    /// </summary>
    public class SnowControlAsset : PlayableAsset
    {
        /// <summary>
        /// An instance of the <see cref="SnowControlBehaviour"/> that serves as a template for creating the clip on the track.
        /// </summary>
        public SnowControlBehaviour template;

        /// <inheritdoc/>
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<SnowControlBehaviour>.Create(graph, template);
        }
    }
}