using Unity.VisualScripting;
using UnityEngine;

public class AccuseAppears : MonoBehaviour
{
    public GameObject popup;
    public GameObject Buttons;
    public string MonsterName;
    Collider charCol;
    
    bool isInRange;
    bool isSpeaking;

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
        Buttons.SetActive(true);
    }
}
