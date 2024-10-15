using UnityEngine;

[System.Serializable]
public class Character : MonoBehaviour
{
    public string name;
    public string gender;
    public int age;
    public int health;
    public int happiness;

    public Character(string name, string gender, int age){
        this.name = name;
        this.gender = gender;
        this.age = age;
        this.health = 100; //nilai default
        this.happiness = 100; //nilai default


    }
}
