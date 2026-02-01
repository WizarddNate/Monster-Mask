using Unity.VisualScripting;
using UnityEngine;

public class DialoguePopup : MonoBehaviour
{
    public GameObject popup;
    public string MonsterName;
    Collider charCol;
    
    bool isInRange;
    bool isSpeaking;

    [SerializeField] private AudioClip[] phantomClips;
    [SerializeField] private AudioClip[] mummyClips;
    [SerializeField] private AudioClip[] vampireClips;
    [SerializeField] private AudioClip[] centaurClips;
    [SerializeField] private AudioClip[] werewolfClips;
    [SerializeField] private AudioClip[] alienClips;

    void Start()
    {
        if (charCol == null)
        {
            charCol = gameObject.GetComponent<Collider>();
        }

        if (popup != null)
        {
            popup.SetActive(false);
        }

        isInRange = false;

        if (MonsterName == null || MonsterName == "")
        {
            Debug.LogError("Dialogue Node not selected for " + gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange == true)
        {
            StartDialogue();
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has entered");
            popup.SetActive(true);
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has exited");
            popup.SetActive(false);
            isInRange = false;
        }
    }

    public void StartDialogue()
    {
        Yarn.Unity.DialogueRunner dialogueRunner = FindFirstObjectByType<Yarn.Unity.DialogueRunner>();

        if (dialogueRunner != null)
        {
            dialogueRunner.StartDialogue(MonsterName); //must be desired node name
            MonTalk();
        }
        else
        {
            Debug.LogError("DialogueRunner not found in the scene.");
        }
    }

        public void MonTalk()
    {
        if (MonsterName != null)
        {
            if (MonsterName == "Werewolf")
            {
                // Debug.Log("wolf");
                WerewolfTalking();
            }
            else if (MonsterName == "Vampire")
            {
                VampireTalking();
            }
            else if (MonsterName == "Centaur")
            {
                CentaurTalking();
            }
            else if (MonsterName == "Mummy")
            {
                MummyTalking();
            }
            else if (MonsterName == "Alien")
            {
                AlienTalking();
            }
            else if (MonsterName == "Phantom")
            {
                PhantomTalking();
            }
            else if (MonsterName == "")
            {
                Debug.Log("noName");
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
