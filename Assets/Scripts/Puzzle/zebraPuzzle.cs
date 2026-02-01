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
        Suspect s1 = suspects[0];
        Suspect s2 = suspects[1];
        Suspect s3 = suspects[2];
        Suspect s4 = suspects[3];



        clues.Add($"The {s3.species} eats {s3.food}.");
        clues.Add($"The {s4.species} drinks {s4.drink}.");
        clues.Add($"The {s3.species} drinks {s3.drink}.");
        clues.Add($"The monster who has a {s2.Pet} also eats {s2.food}.");
        clues.Add($"The monster who eats {s4.food} is somewhere to the right of the monster who has a {s3.Pet}.");
        clues.Add($"The monster who drinks {s1.drink} is immediately to the left of the monster who eats {s2.food}.");
        clues.Add($"The {s1.species} likes {s1.Hobby}.");
        clues.Add($"The monster who has a {s3.Pet} is immediately to the right of the monster who {s2.Hobby}.");
        clues.Add($"The monster who likes {s4.Hobby} also has a {s4.Pet}.");
        if (s1.isKiller)
            clues.Add($"The killer has a {s1.Pet}.");
        else if (s2.isKiller)
            clues.Add($"The killer drinks {s2.drink}.");
        else if (s3.isKiller)
            clues.Add($"The killer has a {s3.Pet}.");
        else
            clues.Add($"The killer likes {s4.Hobby}.");
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
}
