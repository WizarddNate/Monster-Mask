using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AssignTraits : MonoBehaviour
{
    public string charaName;

    public List<string> partyMembers = new List<string>() { "Phantom", "Mummy", "Vampire", "Centaur", "Werewolf", "Alien" };
    public List<string> favDrink = new List<string>() { "Water", "Wine", "Cocktail", "Beer", "Margarita", "Vodka" };
    public List<string> favFood = new List<string>() { "Cucumber", "Bread", "Sausage Roll", "Finger Cheese", "Egg Bites", "Shrimp" };
    public List<string> favSmoke = new List<string>() { "Yes", "Never", "Often", "Rarely", "At Partys", "Not Recently" };
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
    public int iterator = 1;

    

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
        int charaNumIndex = 0; // Random.Range(0, charaSize);
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
        monster.species = chosenChara;
        monster.drink = chosenDrink;
        monster.food = chosenFood;
        monster.smoker = chosenSmoke;
        monster.hobby = chosenHobby;
        monster.relationship = chosenRelationship;
        monster.pet = chosenPet;


        //monster.iterator = iterator;
        
        
        monster.Intro();

        if (iterator == 1)
        {
            nameOne =  charaName;
            speciesOne = chosenChara;
            drinkOne = chosenDrink;
            foodOne = chosenFood;
            smokerOne = chosenSmoke;
            hobbyOne = chosenHobby;
            relationshipOne = chosenRelationship;
            petOne = chosenPet;
        }
        else if (iterator == 2)
        {
            nameTwo =  charaName;
            speciesTwo = chosenChara;
            drinkTwo = chosenDrink;
            foodTwo = chosenFood;
            smokerTwo = chosenSmoke;
            hobbyTwo = chosenHobby;
            relationshipTwo = chosenRelationship;
            petTwo = chosenPet;
        }
        else if (iterator == 3)
        {
            nameThree =  charaName;
            speciesThree = chosenChara;
            drinkThree = chosenDrink;
            foodThree = chosenFood;
            smokerThree = chosenSmoke;
            hobbyThree = chosenHobby;
            relationshipThree = chosenRelationship;
            petThree = chosenPet;
        }
        else if (iterator == 4)
        {
            nameFour =  charaName;
            speciesFour = chosenChara;
            drinkFour = chosenDrink;
            foodFour = chosenFood;
            smokerFour = chosenSmoke;
            hobbyFour = chosenHobby;
            relationshipFour = chosenRelationship;
            petFour = chosenPet; 
        }
        else if (iterator == 5)
        {
            nameFive =  charaName;
            speciesFive = chosenChara;
            drinkFive = chosenDrink;
            foodFive = chosenFood;
            smokerFive = chosenSmoke;
            hobbyFive = chosenHobby;
            relationshipFive = chosenRelationship;
            petFive = chosenPet;   
        }
        else if (iterator == 6)
        {
            nameSix =  charaName;
            speciesSix = chosenChara;
            drinkSix = chosenDrink;
            foodSix = chosenFood;
            smokerSix = chosenSmoke;
            hobbySix = chosenHobby;
            relationshipSix = chosenRelationship;
            petSix = chosenPet; 
        }
        else
        {
            Debug.Log("hah?");
        }
        
        if (iterator == 6)
        {
            Debug.Log(message:$"{nameOne}, {speciesOne}, {drinkOne}, {foodOne}, {smokerOne}, {relationshipOne}, {hobbyOne}, {petOne}, {nameTwo}, {nameThree}, {nameFour}, {nameFive}, {nameSix}");
        }

        iterator++;
    }


    void Update()
    {
        
    }





    public string nameOne;
    public string speciesOne;
    public string drinkOne;
    public string foodOne;
    public string smokerOne;
    public string relationshipOne;
    public string hobbyOne;
    public string petOne;


    public string nameTwo;
    public string speciesTwo;
    public string drinkTwo;
    public string foodTwo;
    public string smokerTwo;
    public string relationshipTwo;
    public string hobbyTwo;
    public string petTwo;


    public string nameThree;
    public string speciesThree;
    public string drinkThree;
    public string foodThree;
    public string smokerThree;
    public string relationshipThree;
    public string hobbyThree;
    public string petThree;


    public string nameFour;
    public string speciesFour;
    public string drinkFour;
    public string foodFour;
    public string smokerFour;
    public string relationshipFour;
    public string hobbyFour;
    public string petFour;


    public string nameFive;
    public string speciesFive;
    public string drinkFive;
    public string foodFive;
    public string smokerFive;
    public string relationshipFive;
    public string hobbyFive;
    public string petFive;


    public string nameSix;
    public string speciesSix;
    public string drinkSix;
    public string foodSix;
    public string smokerSix;
    public string relationshipSix;
    public string hobbySix;
    public string petSix;


public List<SuspectTraits> GetAllChosenTraits()
{
    return new List<SuspectTraits>
    {
        new SuspectTraits(speciesOne, drinkOne, foodOne, smokerOne, hobbyOne, petOne, relationshipOne),
        new SuspectTraits(speciesTwo, drinkTwo, foodTwo, smokerTwo, hobbyTwo, petTwo, relationshipTwo),
        new SuspectTraits(speciesThree, drinkThree, foodThree, smokerThree, hobbyThree, petThree, relationshipThree),
        new SuspectTraits(speciesFour, drinkFour, foodFour, smokerFour, hobbyFour, petFour, relationshipFour),
        new SuspectTraits(speciesFive, drinkFive, foodFive, smokerFive, hobbyFive, petFive, relationshipFive),
        new SuspectTraits(speciesSix, drinkSix, foodSix, smokerSix, hobbySix, petSix, relationshipSix)
    };
}

public struct SuspectTraits
{
    public string species, drink, food, smoke, hobby, pet, relationship;
    public SuspectTraits(string species, string drink, string food, string smoke, string hobby, string pet, string relationship)
    {
        this.species = species;
        this.drink = drink;
        this.food = food;
        this.smoke = smoke;
        this.hobby = hobby;
        this.pet = pet;
        this.relationship = relationship;
    }
}


}
