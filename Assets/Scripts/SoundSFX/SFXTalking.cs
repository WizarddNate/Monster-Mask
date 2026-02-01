using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SFXTalking : MonoBehaviour
{
    public DialoguePopup dPop;

    [SerializeField] private AudioClip[] phantomClips;
    [SerializeField] private AudioClip[] mummyClips;
    [SerializeField] private AudioClip[] vampireClips;
    [SerializeField] private AudioClip[] centaurClips;
    [SerializeField] private AudioClip[] werewolfClips;
    [SerializeField] private AudioClip[] alienClips;

    public string monster;

    void Update()
    {
        
        dPop = GetComponent<DialoguePopup>();

        if (dPop != null)
        {
            monster = dPop.MonsterName;
        }

    }

    public void MonTalk()
    {
        

        if (monster != null)
        {
            if (monster == "Werewolf")
            {
                WerewolfTalking();
            }
            else if (monster == "Vampire")
            {
                VampireTalking();
            }
            else if (monster == "ZebraClueTest")
            {
                CentaurTalking();
            }
            else if (monster == "Mummy")
            {
                MummyTalking();
            }
            else if (monster == "Alien")
            {
                AlienTalking();
            }
            else if (monster == "Phantom")
            {
                PhantomTalking();
            }
        }


        
    }


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
