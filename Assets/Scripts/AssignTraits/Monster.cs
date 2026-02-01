using UnityEngine;

public class Monster
{
    public string name;
    public string species;
    public string drink;
    public string food;
    public string smoker;
    public string relationship;
    public string hobby;
    public string pet;

    public void Intro()
    {
        Debug.Log(message:$"Name is {name}, Species is {species}, Drink is {drink}, Food is {food}, Smoke stats {smoker}, Hobby is {hobby}, Relationship is {relationship}, Pet is {pet}");
    }
}
