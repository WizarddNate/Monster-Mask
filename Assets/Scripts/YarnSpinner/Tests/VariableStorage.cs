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

        /// VARIABLES ///

        runner.VariableStorage.SetValue("$nameOne", asT.nameOne); //asT.speciesOne
        runner.VariableStorage.SetValue("$foodOne", asT.foodOne);
        runner.VariableStorage.SetValue("$drinkOne", asT.drinkOne);
        runner.VariableStorage.SetValue("$hobbyOne", asT.hobbyOne);
        runner.VariableStorage.SetValue("$petOne", asT.petOne);

        runner.VariableStorage.SetValue("$nameTwo", asT.nameTwo); //asT.speciesTwo
        runner.VariableStorage.SetValue("$foodTwo", asT.foodTwo);
        runner.VariableStorage.SetValue("$drinkTwo", asT.drinkTwo);
        runner.VariableStorage.SetValue("$hobbyTwo", asT.hobbyTwo);
        runner.VariableStorage.SetValue("$petTwo", asT.petTwo);

        runner.VariableStorage.SetValue("$nameThree", asT.nameThree); //asT.speciesThree
        runner.VariableStorage.SetValue("$foodThree", asT.foodThree);
        runner.VariableStorage.SetValue("$drinkThree", asT.drinkThree);
        runner.VariableStorage.SetValue("$hobbyThree", asT.hobbyThree);
        runner.VariableStorage.SetValue("$petThree", asT.petThree);

        runner.VariableStorage.SetValue("$nameFour", asT.nameFour); //asT.speciesFour
        runner.VariableStorage.SetValue("$foodFour", asT.foodFour);
        runner.VariableStorage.SetValue("$drinkFour", asT.drinkFour);
        runner.VariableStorage.SetValue("$hobbyFour", asT.hobbyFour);
        runner.VariableStorage.SetValue("$petFour", asT.petFour);

        runner.VariableStorage.SetValue("$nameFive", asT.nameFive); //asT.speciesFive
        runner.VariableStorage.SetValue("$foodFive", asT.foodFive);
        runner.VariableStorage.SetValue("$drinkFive", asT.drinkFive);
        runner.VariableStorage.SetValue("$hobbyFive", asT.hobbyFive);
        runner.VariableStorage.SetValue("$petFive", asT.petFive);

        runner.VariableStorage.SetValue("$nameSix", asT.nameSix); //asT.speciesSix
        runner.VariableStorage.SetValue("$foodSix", asT.foodSix);
        runner.VariableStorage.SetValue("$drinkSix", asT.drinkSix);
        runner.VariableStorage.SetValue("$hobbySix", asT.hobbySix);
        runner.VariableStorage.SetValue("$petSix", asT.petSix);

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
