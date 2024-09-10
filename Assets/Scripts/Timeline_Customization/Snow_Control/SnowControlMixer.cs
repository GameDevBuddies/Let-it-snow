using UnityEngine.Playables;

namespace GameDevBuddies
{
    /// <summary>
    /// Class responsible for mixing the snow influences of multiple <see cref="SnowControlBehaviour"/> clips on the
    /// track in order to calculate the final snow influence in the current frame of the cutscene.
    /// </summary>
    public class SnowControlMixer : PlayableBehaviour
    {
        /// <inheritdoc/>
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            // Check if the reference is set on the track.
            SnowControlSettings snowControlSettings = (SnowControlSettings)playerData;
            if (snowControlSettings == null)
            {
                return;
            }

            // Helper variables.
            float globalWeatherInfluence = 0f;
            float globalSnowFalloff = 0f;

            // Go over all clips on the track and calculate the final influence of the snow effect.
            int numberOfClips = playable.GetInputCount();
            for (int i = 0; i < numberOfClips; i++)
            {
                // Check if the current clip has any influence to the final calculation.
                float clipWeight = playable.GetInputWeight(i);
                if (clipWeight <= 0f)
                {
                    continue;
                }

                /// Fetch the <see cref="SnowControlBehaviour"/> component from the clip.
                ScriptPlayable<SnowControlBehaviour> snowControlPlayable = (ScriptPlayable<SnowControlBehaviour>)playable.GetInput(i);
                SnowControlBehaviour snowControlBehaviour = snowControlPlayable.GetBehaviour();

                // Accumulate the influence of this clip to the final snow influence.
                globalWeatherInfluence += clipWeight * snowControlBehaviour.GlobalWeatherInfluence;
                globalSnowFalloff += clipWeight * snowControlBehaviour.SnowFalloff;
            }

            // Apply the current snow and global weather influence to the scene.
            snowControlSettings.UpdateSnowSettings(globalWeatherInfluence, globalSnowFalloff);
        }
    }
}