using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SFXTalking : MonoBehaviour
{
    [SerializeField] private AudioClip[] phantomClips;
    [SerializeField] private AudioClip[] mummyClips;
    [SerializeField] private AudioClip[] vampireClips;
    [SerializeField] private AudioClip[] centaurClips;
    [SerializeField] private AudioClip[] werewolfClips;
    [SerializeField] private AudioClip[] alienClips;


    public void PhantomTalking()
    {
        SoundFXManager.instance.PlayRandomSoundFXClip(phantomClips, transform, 1f);
    }


    public void MummyTalking()
    {
        SoundFXManager.instance.PlayRandomSoundFXClip(mummyClips, transform, 1f);
    }

    public void VampireTalking()
    {
        SoundFXManager.instance.PlayRandomSoundFXClip(vampireClips, transform, 1f);
    }

    public void CentaurTalking()
    {
        SoundFXManager.instance.PlayRandomSoundFXClip(centaurClips, transform, 1f);
    }

    public void WerewolfTalking()
    {
        SoundFXManager.instance.PlayRandomSoundFXClip(werewolfClips, transform, 1f);
    }

    public void AlienTalking()
    {
        SoundFXManager.instance.PlayRandomSoundFXClip(alienClips, transform, 1f);
    }
}
