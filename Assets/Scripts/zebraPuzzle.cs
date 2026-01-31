using System.Collections.Generic;
using UnityEngine;

/// Fully solvable Zebra Puzzle with Rooms
public class ZebraPuzzleRooms : MonoBehaviour
{
    [System.Serializable]
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

    private List<string> suspectspecies = new List<string>
        { "Phantom","Vampire","Werewolf","Alien","Mummy","Centaur" };

    private List<string> drinks = new List<string>
        { "water","mysterious red liquids","bloody mary","poison","mystery potion","juice" };

    private List<string> foods = new List<string>
        { "raw meat","dirt","ghost sandwich","worms","insects","ancient grains" };

    private List<string> smokes = new List<string>
        { "cursed cigar","enchanted pipe","death cigarette","ghost weed","nothing","bubble pipe" };

    private List<string> Hobby = new List<string>
        { "painting","sculpting","dancing","singing","reading","rotting away in a crypt" };

    private List<string> Pets = new List<string>
        { "black cat","owl","bat","spider","rat","snake" };

    private List<string> MaritalStatus = new List<string>
        { "Single","Married","Divorced","non-married partners","It's complicated","Cheating" };

    void Start()
    {
        CreateSuspects();
        AssignAttributesAndRooms();
        ChooseKiller();

        suspects.Sort((a, b) => a.Room.CompareTo(b.Room));

        GenerateRoomClues();
        PrintMysteryToConsole();
    }

    void CreateSuspects()
    {
        //suspects.Clear();
        foreach (string s in suspectspecies)
            suspects.Add(new Suspect { species = s });
    }

    void AssignAttributesAndRooms()
    {
        List<string> d = new List<string>(drinks);
        List<string> f = new List<string>(foods);
        List<string> s = new List<string>(smokes);
        List<string> h = new List<string>(Hobby);
        List<string> p = new List<string>(Pets);
        List<string> m = new List<string>(MaritalStatus);
        List<int> rooms = new List<int> { 1, 2, 3, 4, 5, 6 };

        foreach (Suspect suspect in suspects)
        {
            suspect.drink = PickAndRemove(d);
            suspect.food = PickAndRemove(f);
            suspect.smoke = PickAndRemove(s);
            suspect.Hobby = PickAndRemove(h);
            suspect.Pet = PickAndRemove(p);
            suspect.MaritalStatus = PickAndRemove(m);
            suspect.Room = PickAndRemove(rooms);
        }
    }

    string PickAndRemove(List<string> list)
    {
        int idx = Random.Range(0, list.Count);
        string val = list[idx];
        list.RemoveAt(idx);
        return val;
    }

    int PickAndRemove(List<int> list)
    {
        int idx = Random.Range(0, list.Count);
        int val = list[idx];
        list.RemoveAt(idx);
        return val;
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
        //clues.Clear();

        Suspect s1 = suspects[0];
        Suspect s2 = suspects[1];
        Suspect s3 = suspects[2];
        Suspect s4 = suspects[3];

        List<AttributePick> attrs = new List<AttributePick>
        {
            new AttributePick { getter = x => x.drink, describe = v => $"drinks {v}" },
            new AttributePick { getter = x => x.food, describe = v => $"eats {v}" },
            new AttributePick { getter = x => x.Pet, describe = v => $"keeps a {v}" },
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
        clues.Add($"The monster who {clue1.describe(clue1.getter(s4))} is somewhere to the right of the monster who {clue2.describe(clue2.getter(s3))}.");
        clues.Add($"The monster who {clue3.describe(clue3.getter(s1))} is immediately to the left of the monster who {clue1.describe(clue1.getter(s2))}.");
        clues.Add($"The {s1.species} {clue4.describe(clue4.getter(s1))}.");
        clues.Add($"The monster who {clue3.describe(clue3.getter(s3))} is immediately to the right of the monster who {clue4.describe(clue4.getter(s2))}.");
        clues.Add($"The monster who {clue4.describe(clue4.getter(s4))} also {clue3.describe(clue3.getter(s4))}.");

        if (s1.isKiller)
            clues.Add($"The killer drinks {clue3.describe(clue3.getter(s1))}.");
        else if (s2.isKiller)
            clues.Add($"The killer eats {clue2.describe(clue2.getter(s2))}.");
        else if (s3.isKiller)
            clues.Add($"The killer drinks {clue3.describe(clue3.getter(s3))}.");
        else
            clues.Add($"The killer likes {clue4.describe(clue4.getter(s4))}.");
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

    public void Accuse(string species)
    {
        Suspect s = suspects.Find(x => x.species == species);
        if (s == null)
            Debug.Log("No such suspect!");
        else
            Debug.Log(s.isKiller
                ? "Correct! You solved the mystery!"
                : "Wrong accusation. Keep thinking!");
    }
}
