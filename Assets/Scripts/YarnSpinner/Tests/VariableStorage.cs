using UnityEngine;
using Yarn.Unity;

public class VariableStorage : MonoBehaviour
{
    private DialogueRunner runner;

    private ZebraPuzzleRooms zPR;

    private static string playerName = "Cleven";

    void Start()
    {
        zPR = GameObject.FindFirstObjectByType<ZebraPuzzleRooms>();
        
        /*
        if (zPR.clues == null)
        {
            Debug.Log("Clues list null");
        }
        else
        {
            string clue1 = zPR.clues[0];
            Debug.Log("CLUE 1: " + clue1);
        }
        */
        

        runner = GameObject.FindFirstObjectByType<DialogueRunner>();
        runner.AddFunction<string>("get_player_name", GetPlayerName);
        runner.AddFunction<string>("get_clue_one", GetClueOne);
    }

    private static string GetPlayerName()
    {
        return playerName;
    }

    private static string GetClueOne()
    {
        
        return null;
    }
}
