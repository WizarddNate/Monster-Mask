using UnityEngine;
using Yarn.Unity;

public class DialogueCommands : MonoBehaviour
{

    private void OnStart()
    {
        Debug.Log("DialogueCommands script has started.");
    }

    public void StartDialogue()
    {
        Yarn.Unity.DialogueRunner dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();

        if (dialogueRunner != null)
        {
            dialogueRunner.StartDialogue("Intro"); //must be desired node name
        }
        else
        {
            Debug.LogError("DialogueRunner not found in the scene.");
        }
    }
}