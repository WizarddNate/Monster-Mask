using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ZebraPuzzle : MonoBehaviour
{
    private AssignTraits asT;

    public class Suspect
    {
        public string species;
        public string drink;
        public string food;
        public string smoke;
        public string Hobby;
        public string Pet;
        public string MaritalStatus;
        public int Room;
        public bool isKiller;
    }

    public List<Suspect> suspects = new List<Suspect>();
    public List<string> clues = new List<string>();

    void Awake()
    {
        asT = GetComponent<AssignTraits>();
        if (asT == null)
            Debug.LogError("AssignTraits component not found!");
    }

    void Start()
    {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(0.1f); // wait 2 seconds

        CreateSuspects();
        AssignAttributesFromAssignTraits();
        ChooseKiller();

        suspects.Sort((a, b) => a.Room.CompareTo(b.Room));

        GenerateRoomClues();
        PrintMysteryToConsole();
    }


    void CreateSuspects()
    {
        suspects.Clear();

        suspects.Add(new Suspect { species = asT.speciesOne });
        suspects.Add(new Suspect { species = asT.speciesTwo });
        suspects.Add(new Suspect { species = asT.speciesThree });
        suspects.Add(new Suspect { species = asT.speciesFour });
        suspects.Add(new Suspect { species = asT.speciesFive });
        suspects.Add(new Suspect { species = asT.speciesSix });
    }

    void AssignAttributesFromAssignTraits()
    {
        var traitsList = asT.GetAllChosenTraits();

        suspects.Clear();
        for (int i = 0; i < traitsList.Count; i++)
        {
            var t = traitsList[i];
            suspects.Add(new Suspect
            {
                species = t.species,
                drink = t.drink,
                food = t.food,
                smoke = t.smoke,
                Hobby = t.hobby,
                Pet = t.pet,
                MaritalStatus = t.relationship,
                Room = i + 1
            });
        }
    }

    void ChooseKiller()
    {
        int index = Random.Range(0, suspects.Count);
        for (int i = 0; i < suspects.Count; i++)
            suspects[i].isKiller = (i == index);
    }

    struct AttributePick
    {
        public System.Func<Suspect, string> getter;
        public System.Func<string, string> describe;
    }

    AttributePick PickAndRemoveAttribute(List<AttributePick> list)
    {
        int idx = Random.Range(0, list.Count);
        AttributePick val = list[idx];
        list.RemoveAt(idx);
        return val;
    }

    void GenerateRoomClues()
    {
        Suspect ww = suspects[4];
        Suspect vp = suspects[2];
        Suspect ct = suspects[3];
        Suspect pt = suspects[0];



        clues.Add($"The centaur eats {ct.food}.");
        clues.Add($"The phantom drinks {pt.drink}.");
        clues.Add($"The centaur drinks {ct.drink}.");
        clues.Add($"The monster who has a {vp.Pet} also eats {vp.food}.");
        clues.Add($"The monster who eats {pt.food} is somewhere to the right of the monster who has a {ct.Pet}.");
        clues.Add($"The monster who drinks {ww.drink} is immediately to the left of the monster who eats {vp.food}.");
        clues.Add($"The {ww.species} likes {ww.Hobby}.");
        clues.Add($"The monster who has a {ct.Pet} is immediately to the right of the monster who {vp.Hobby}.");
        clues.Add($"The monster who likes {pt.Hobby} also has a {pt.Pet}.");

        
        if (ww.isKiller)
            clues.Add($"The killer has a {ww.Pet}.");

        else if (vp.isKiller)
            clues.Add($"The killer drinks {vp.drink}.");
        else if (ct.isKiller)
            clues.Add($"The killer has a {ct.Pet}.");
        else
            clues.Add($"The killer likes {pt.Hobby}.");
    }

    void PrintMysteryToConsole()
    {
        Debug.Log("=== SUSPECTS ===");
        foreach (Suspect s in suspects)
            Debug.Log($"{s.Room}: {s.species} | {s.drink} | {s.food} | {s.smoke} | {s.Pet} | {s.Hobby} | {s.MaritalStatus}");

        Debug.Log("=== CLUES ===");
        foreach (string c in clues)
            Debug.Log(c);

        Debug.Log("KILLER (debug): " + suspects.Find(s => s.isKiller).species);
    }

    public GameObject CorrectPanel;
    public GameObject WrongPanel;
    public GameObject accuseButton;
    public GameObject backButton;
    public GameObject accuseText;
    public void AccuseMummy()      
    {      
        accuseButton.SetActive(false);
        backButton.SetActive(false);
        accuseText.SetActive(false);
        WrongPanel.SetActive(true);
    }
    public void AccuseAlien()      
    {      
        accuseButton.SetActive(false);
        backButton.SetActive(false);
        accuseText.SetActive(false);
        WrongPanel.SetActive(true);
    }
    public void AccuseWerewolf()      
    {      
        accuseButton.SetActive(false);
        backButton.SetActive(false);
        accuseText.SetActive(false);
        if (suspects[4].isKiller)  
        {  
            CorrectPanel.SetActive(true);  
        }  
        else
        WrongPanel.SetActive(true);
    }
    
        public void AccusePhantom()      
    {      
        accuseButton.SetActive(false);
        backButton.SetActive(false);
        accuseText.SetActive(false);
        if (suspects[0].isKiller)  
        {  
            CorrectPanel.SetActive(true);  
        }  
        else
        WrongPanel.SetActive(true);
    }
    public void AccuseVampire()      
    {      
        accuseButton.SetActive(false);
        backButton.SetActive(false);
        accuseText.SetActive(false);
        if (suspects[2].isKiller)  
        {  
            CorrectPanel.SetActive(true);  
        }  
        else
        WrongPanel.SetActive(true);
    }
    public void AccuseCentaur()      
    {      
        accuseButton.SetActive(false);
        backButton.SetActive(false);
        accuseText.SetActive(false);
        if (suspects[3].isKiller)  
        {  
            
            CorrectPanel.SetActive(true);
        }  
        else
        WrongPanel.SetActive(true);
    }
}
