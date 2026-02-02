using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ZebraPuzzle : MonoBehaviour
{
    private AssignTraits asT;

    public string killerClue = "";

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

    [Header("Spawn Positions")]
        public Vector3 ctFoodPos;
        public Vector3 ctDrinkPos;
        public Vector3 ptDrinkPos;

        [Header("Drink Prefabs")]
        public GameObject Water;
        public GameObject Wine;
        public GameObject Cocktail;
        public GameObject Beer;
        public GameObject Margarita;
        public GameObject Vodka;

        [Header("Food Prefabs")]
        public GameObject Cucumber;
        public GameObject Bread;
        public GameObject Sausage;
        public GameObject Cheese;
        public GameObject Egg;
        public GameObject Shrimp;

        [Header("UI Prefabs")]
        public GameObject CorrectPanel;
        public GameObject WrongPanel;
        public GameObject accuseButton;
        public GameObject backButton;
        public GameObject accuseText;

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

        SpawnItemClues();
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
        int index = Random.Range(0, 4);
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
        Suspect ww = suspects[3];
        Suspect vp = suspects[1];
        Suspect ct = suspects[2];
        Suspect pt = suspects[0];



        clues.Add($"The {ct.species} eats {ct.food}."); //spawn food and drink on table in lounge
        clues.Add($"The phantom drinks {pt.drink}."); //drink spawn in bedroom
        clues.Add($"The centaur drinks {ct.drink}."); //spawn drink
        clues.Add($"The monster who has a {vp.Pet} also eats {vp.food}."); ///I have to keep reminding people about the no pets in the dining room policy. SOMEONE keeps sharing {food} with their {pet}.
        clues.Add($"The monster who eats {pt.food} is somewhere to the right of the monster who has a {ct.Pet}."); //  vampire's hint
        clues.Add($"The monster who drinks {ww.drink} is immediately to the left of the monster who eats {vp.food}."); //Centaur's hint
        clues.Add($"The {ww.species} likes {ww.Hobby}."); ///werewolf talks about hobby when asked 
        clues.Add($"The monster who has a {ct.Pet} is two rooms to the right of the monster who {vp.Hobby}."); //phantom hobby
        clues.Add($"The monster who likes {pt.Hobby} also has a {pt.Pet}."); //i heard a rumor that...

        
        if (ww.isKiller)
        {
            clues.Add($"The killer has a {ww.Pet}."); //some fur on the body. The killer must have a pet {}!
            killerClue = "wwPet";
        }
        else if (vp.isKiller)
        {
           clues.Add($"The killer drinks {vp.drink}."); //theres a spill on the floor. The killer was drinking {}! 
           killerClue = "vpDrink";
        }
        else if (ct.isKiller)
        {
            clues.Add($"The killer has a {ct.Pet}."); //some fur on the body. The killer must have a pet {}!
            killerClue = "ctPet";
        }
        else
        {
            clues.Add($"The killer likes {pt.Hobby}."); //tickets to a {} convention. These must have fallen out of the killer's pocket!
            killerClue = "ptHobby";
        }

        Debug.Log("Killer clue: " + killerClue + "!");
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
        if (suspects[3].isKiller)  
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
        if (suspects[1].isKiller)  
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
        if (suspects[2].isKiller)  
        {  
            
            CorrectPanel.SetActive(true);
        }  
        else
        WrongPanel.SetActive(true);
    }

    void SpawnItemClues()
    {
        Suspect ct = suspects[2];
        Suspect pt = suspects[0];

        switch (ct.food)
        {
            case "Cucumber":
                Instantiate(Cucumber, ctFoodPos, Quaternion.identity);
                break;
            case "Bread":
                Instantiate(Bread, ctFoodPos, Quaternion.identity);
                break;
            case "Sausage Roll":
                Instantiate(Sausage, ctFoodPos, Quaternion.identity);
                break;
            case "Finger Cheese":
                Instantiate(Cheese, ctFoodPos, Quaternion.identity);
                break;
            case "Egg Bites":
                Instantiate(Egg, ctFoodPos, Quaternion.identity);
                break;
            case "Shrimp":
                Instantiate(Shrimp, ctFoodPos, Quaternion.identity);
                break;
        }

        switch (ct.drink)
        {
            case "Water":
                Instantiate(Water, ctDrinkPos, Quaternion.identity);
                break;
            case "Wine":
                Instantiate(Wine, ctDrinkPos, Quaternion.identity);
                break;
            case "Cocktail":
                Instantiate(Cocktail, ctDrinkPos, Quaternion.identity);
                break;
            case "Beer":
                Instantiate(Beer, ctDrinkPos, Quaternion.identity);
                break;
            case "Margarita":
                Instantiate(Margarita, ctDrinkPos, Quaternion.identity);
                break;
            case "Vodka":
                Instantiate(Vodka, ctDrinkPos, Quaternion.identity);
                break;
        }

        switch (pt.drink)
        {
            case "Water":
                Instantiate(Water, ptDrinkPos, Quaternion.identity);
                break;
            case "Wine":
                Instantiate(Wine, ptDrinkPos, Quaternion.identity);
                break;
            case "Cocktail":
                Instantiate(Cocktail, ptDrinkPos, Quaternion.identity);
                break;
            case "Beer":
                Instantiate(Beer, ptDrinkPos, Quaternion.identity);
                break;
            case "Margarita":
                Instantiate(Margarita, ptDrinkPos, Quaternion.identity);
                break;
            case "Vodka":
                Instantiate(Vodka, ptDrinkPos, Quaternion.identity);
                break;
        }
    }
}
