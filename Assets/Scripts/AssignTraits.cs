using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AssignTraits : MonoBehaviour
{
    public string charaName;

    public List<string> partyMembers = new List<string>() { "Phantom", "Mummy", "Vampire", "Centaur", "Werewolf", "Alien" };
    public List<string> favDrink = new List<string>() { "Water", "Wine", "Cocktail", "Beer", "Margarita", "Vodka" };
    public List<string> favFood = new List<string>() { "Cucumber", "Bread", "Sausage Roll", "Finger Cheese", "Egg Bites", "Shrimp" };
    public List<string> favSmoke = new List<string>() { "Yes", "No", "Often", "Rarely", "At Partys", "Not Recently" };
    public List<string> favHobby = new List<string>() { "Philanthropy", "Painting", "Writing", "Equestrianism", "Croquet", "Gambling" };
    public List<string> favRelationship = new List<string>() { "Single", "Married", "Dating", "Cheating", "Its Complicated", "Divorced" };
    public List<string> favPet = new List<string>() { "Cat", "Dog", "Fish", "Horse", "Bird", "Lizard" };

    public string chosenChara;    
    public string chosenDrink;
    public string chosenFood;
    public string chosenSmoke;
    public string chosenHobby;
    public string chosenRelationship;
    public string chosenPet;

    public int charaSize;
    public int drinkSize;
    public int foodSize;
    public int smokeSize;
    public int hobbySize;
    public int relationshipSize;
    public int petSize;

    

    void Start()
    {
        Assign();
        Assign();
        Assign();
        Assign();
        Assign();
        Assign();
    }


    public void Assign()
    {
        charaSize = partyMembers.Count;
        int charaNumIndex = Random.Range(0, charaSize);
        chosenChara = partyMembers[charaNumIndex];
        partyMembers.RemoveAt(charaNumIndex);



        drinkSize = favDrink.Count;
        int drinkNumIndex = Random.Range(0, drinkSize);
        chosenDrink = favDrink[drinkNumIndex];
        favDrink.RemoveAt(drinkNumIndex);



        foodSize = favFood.Count;
        int foodNumIndex = Random.Range(0, foodSize);
        chosenFood = favFood[foodNumIndex];
        favFood.RemoveAt(foodNumIndex);



        smokeSize = favSmoke.Count;
        int smokeNumIndex = Random.Range(0, smokeSize);
        chosenSmoke = favSmoke[smokeNumIndex];
        favSmoke.RemoveAt(smokeNumIndex);



        hobbySize = favHobby.Count;
        int hobbyNumIndex = Random.Range(0, hobbySize);
        chosenHobby = favHobby[hobbyNumIndex];
        favHobby.RemoveAt(hobbyNumIndex);



        relationshipSize = favRelationship.Count;
        int relationshipNumIndex = Random.Range(0, relationshipSize);
        chosenRelationship = favRelationship[relationshipNumIndex];
        favRelationship.RemoveAt(relationshipNumIndex);



        petSize = favPet.Count;
        int petNumIndex = Random.Range(0, petSize);
        chosenPet = favPet[petNumIndex];
        favPet.RemoveAt(petNumIndex);



        if (chosenChara == "Phantom")
        {
            charaName = "Phan";
        }
        else if (chosenChara == "Mummy")
        {
            charaName = "Mum";
        }
        else if (chosenChara == "Vampire")
        {
            charaName = "Drac";
        }
        else if (chosenChara == "Centaur")
        {
            charaName = "Steve";
        }
        else if (chosenChara == "Werewolf")
        {
            charaName = "Wally";
        }
        else if (chosenChara == "Alien")
        {
            charaName = "Allen";
        }
        else
        {
            charaName = "What did you do?";
        }


        

        var monster = new Monster();

        monster.name = charaName;
        monster.race = chosenChara;
        monster.drink = chosenDrink;
        monster.food = chosenFood;
        monster.smoker = chosenSmoke;
        monster.hobby = chosenHobby;
        monster.relationship = chosenRelationship;
        monster.pet = chosenPet;
        
        monster.Intro();
    }


    void Update()
    {
        
    }
}
