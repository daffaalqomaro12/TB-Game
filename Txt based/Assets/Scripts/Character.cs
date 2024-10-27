using UnityEngine;

[System.Serializable]
public class Character : MonoBehaviour
{
    public string name;
    public string gender;
    public int age;
    public int health = 100;
    private int strength;
    public int intelligence = 0;
    public int agility = 0;

    public Character(string name, string gender, int age){
        this.name = name;
        this.gender = gender;
        this.age = age;
        
    }

    public void StrTrain(int value)
    {
        strength += value;
    }

    public void INTTrain(int value)
    {
        intelligence += value;
    }

    public void AGITrain(int value)
    {
        agility += value;
    }

    public void IncreaseStats(int value)
    {
        strength += value;
        intelligence += value;
        agility += value;
    }

    

    public int GetStrength(){
        return strength;
    }
    public int GetIntelligence(){
        return intelligence;
    }
    public int GetAgility(){
        return agility;
    }
    public int GetHealth() => health;
}