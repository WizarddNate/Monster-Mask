using UnityEngine;

public class Monster
{
    public string name;
    public string race;
    public string drink;
    public string food;
    public string smoker;
    public string relationship;
    public string hobby;
    public string pet;


    private int iterator = 1;

    
    public string nameOne;
    public string raceOne;
    public string drinkOne;
    public string foodOne;
    public string smokerOne;
    public string relationshipOne;
    public string hobbyOne;
    public string petOne;


    public string nameTwo;
    public string raceTwo;
    public string drinkTwo;
    public string foodTwo;
    public string smokerTwo;
    public string relationshipTwo;
    public string hobbyTwo;
    public string petTwo;


    public string nameThree;
    public string raceThree;
    public string drinkThree;
    public string foodThree;
    public string smokerThree;
    public string relationshipThree;
    public string hobbyThree;
    public string petThree;


    public string nameFour;
    public string raceFour;
    public string drinkFour;
    public string foodFour;
    public string smokerFour;
    public string relationshipFour;
    public string hobbyFour;
    public string petFour;


    public string nameFive;
    public string raceFive;
    public string drinkFive;
    public string foodFive;
    public string smokerFive;
    public string relationshipFive;
    public string hobbyFive;
    public string petFive;


    public string nameSix;
    public string raceSix;
    public string drinkSix;
    public string foodSix;
    public string smokerSix;
    public string relationshipSix;
    public string hobbySix;
    public string petSix;



    public void Intro()
    {
        Debug.Log(message:$"Name is {name}, Race is {race}, Drink is {drink}, Food is {food}, Smoke stats {smoker}, Hobby is {hobby}, Relationship is {relationship}, Pet is {pet}");


        if (iterator == 1)
        {
            nameOne = name;
            raceOne = race;
            drinkOne = drink;
            foodOne = food;
            smokerOne = smoker;
            hobbyOne = hobby;
            relationshipOne = relationship;
            petOne = pet;

            iterator++;
            Debug.Log("hah?");
        }
        else if (iterator == 2)
        {
            nameTwo = name;
            raceTwo = race;
            drinkTwo = drink;
            foodTwo = food;
            smokerTwo = smoker;
            hobbyTwo = hobby;
            relationshipTwo = relationship;
            petTwo = pet;

            iterator++;
            Debug.Log("hah?");
        }
        else if (iterator == 3)
        {
            nameThree = name;
            raceThree = race;
            drinkThree = drink;
            foodThree = food;
            smokerThree = smoker;
            hobbyThree = hobby;
            relationshipThree = relationship;
            petThree = pet;

            iterator++;
            Debug.Log("hah?");
        }
        else if (iterator == 4)
        {
            nameFour = name;
            raceFour = race;
            drinkFour = drink;
            foodFour = food;
            smokerFour = smoker;
            hobbyFour = hobby;
            relationshipFour = relationship;
            petFour = pet;

            iterator++;
        }
        else if (iterator == 5)
        {
            nameFive = name;
            raceFive = race;
            drinkFive = drink;
            foodFive = food;
            smokerFive = smoker;
            hobbyFive = hobby;
            relationshipFive = relationship;
            petFive = pet;

            iterator++;
        }
        else if (iterator == 6)
        {
            nameSix = name;
            raceSix = race;
            drinkSix = drink;
            foodSix = food;
            smokerSix = smoker;
            hobbySix = hobby;
            relationshipSix = relationship;
            petSix = pet;

            iterator++;
        }
        else
        {
            //Debug.Log("hah?");
        }
        
        if (iterator == 7)
        {
            Debug.Log($"{nameOne}, {raceOne}, {drinkOne}, {foodOne}, {smokerOne}, {relationshipOne}, {hobbyOne}, {petOne}, {nameTwo}");
        }
        
    }

}
