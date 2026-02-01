using UnityEngine;

public class AccuseAudioSwitch : MonoBehaviour
{
    public AudioSource investigation;
    public AudioSource accuse;
    public void AudioBack()
    {
        investigation.mute = !investigation.mute;
        accuse.mute = !accuse.mute;
    }
}
