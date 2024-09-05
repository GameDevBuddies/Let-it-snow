using UnityEngine.Playables;

namespace GameDevBuddies
{
    public class SnowControlMixer : PlayableBehaviour
    {
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            SnowControlSettings snowControlSettings = (SnowControlSettings)playerData;
            if (snowControlSettings == null)
            {
                return;
            }

            float globalWeatherInfluence = 0f;
            float globalWetness = 0f;
            float globalSnowFalloff = 0f;

            int numberOfClips = playable.GetInputCount();
            for (int i = 0; i < numberOfClips; i++)
            {
                float clipWeight = playable.GetInputWeight(i);
                if (clipWeight <= 0f)
                {
                    continue;
                }

                ScriptPlayable<SnowControlBehaviour> snowControlPlayable = (ScriptPlayable<SnowControlBehaviour>)playable.GetInput(i);
                SnowControlBehaviour snowControlBehaviour = snowControlPlayable.GetBehaviour();

                globalWeatherInfluence += clipWeight * snowControlBehaviour.GlobalWeatherInfluence;
                globalWetness += clipWeight * snowControlBehaviour.Wetness;
                globalSnowFalloff += clipWeight * snowControlBehaviour.SnowFalloff;
            }

            snowControlSettings.UpdateSnowSettings(globalWeatherInfluence, globalWetness, globalSnowFalloff);
        }
    }
}