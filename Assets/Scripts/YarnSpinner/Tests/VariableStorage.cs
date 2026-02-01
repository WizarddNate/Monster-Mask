using UnityEngine;
using Yarn.Unity;

public class VariableStorage : MonoBehaviour
{
    private DialogueRunner runner;

    private ZebraPuzzle zPR;
    private AssignTraits asT;

    private static string playerName = "Cleven";

    void Start()
    {
        asT = GameObject.FindFirstObjectByType<AssignTraits>();
        zPR = GameObject.FindFirstObjectByType<ZebraPuzzle>();
        
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

        //runner.VariableStorage.SetValue("$player_coins", 10);
        runner.VariableStorage.SetValue("$monster1", "Vampire"); //asT.speciesOne

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
