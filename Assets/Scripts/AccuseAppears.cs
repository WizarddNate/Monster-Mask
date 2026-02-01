using Unity.VisualScripting;
using UnityEngine;

public class AccuseAppears : MonoBehaviour
{
    public GameObject popup;
    public GameObject AccusePanel;
    Collider charCol;
    
    bool isInRange;
    bool isSpeaking;

    public AudioSource investigation;
    public AudioSource accuse;

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
        AccusePanel.SetActive(true);
        investigation.mute = !investigation.mute;
        accuse.mute = !accuse.mute;
    }
}
