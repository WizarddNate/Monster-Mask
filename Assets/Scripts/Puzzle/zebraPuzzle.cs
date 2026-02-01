using System.Collections.Generic;
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

        List<AttributePick> attrs = new List<AttributePick>
        {
            new AttributePick { getter = x => x.drink, describe = v => $"drinks {v}" },
            new AttributePick { getter = x => x.food, describe = v => $"eats {v}" },
            new AttributePick { getter = x => x.Pet, describe = v => $"has a {v}" },
            new AttributePick { getter = x => x.Hobby, describe = v => $"likes {v}" },
            new AttributePick { getter = x => x.smoke, describe = v => $"smokes {v}" },
            new AttributePick { getter = x => x.MaritalStatus, describe = v => $"has a relationship status of {v}" }
        };

        var clue1 = PickAndRemoveAttribute(attrs);
        var clue2 = PickAndRemoveAttribute(attrs);
        var clue3 = PickAndRemoveAttribute(attrs);
        var clue4 = PickAndRemoveAttribute(attrs);
        var clue5 = PickAndRemoveAttribute(attrs);
        var clue6 = PickAndRemoveAttribute(attrs);

        clues.Add($"The {s3.species} {clue1.describe(clue1.getter(s3))}.");
        clues.Add($"The {s4.species} {clue2.describe(clue2.getter(s4))}.");
        clues.Add($"The {s3.species} {clue2.describe(clue2.getter(s3))}.");
        clues.Add($"The monster who {clue3.describe(clue3.getter(s2))} also {clue1.describe(clue1.getter(s2))}.");
        clues.Add($"The monster who {clue1.describe(clue1.getter(s4))} is somewhere to the right of the monster who {clue3.describe(clue3.getter(s3))}.");
        clues.Add($"The monster who {clue2.describe(clue2.getter(s1))} is immediately to the left of the monster who {clue1.describe(clue1.getter(s2))}.");
        clues.Add($"The {s1.species} {clue4.describe(clue4.getter(s1))}.");
        clues.Add($"The monster who {clue3.describe(clue3.getter(s3))} is immediately to the right of the monster who {clue4.describe(clue4.getter(s2))}.");
        clues.Add($"The monster who {clue4.describe(clue4.getter(s4))} also {clue3.describe(clue3.getter(s4))}.");

        if (s1.isKiller)
            clues.Add($"The killer {clue3.describe(clue3.getter(s1))}.");
        else if (s2.isKiller)
            clues.Add($"The killer {clue2.describe(clue2.getter(s2))}.");
        else if (s3.isKiller)
            clues.Add($"The killer {clue3.describe(clue3.getter(s3))}.");
        else
            clues.Add($"The killer {clue4.describe(clue4.getter(s4))}.");
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
