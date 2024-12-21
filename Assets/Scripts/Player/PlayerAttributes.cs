using UnityEngine;

[System.Serializable]
public class PlayerAttributes
{
    public int Strength;     // STR
    public int Constitution; // CON
    public int Intelligence; // INT
    public int Charisma;     // CHA
    public int Luck;         // LCK
    public int Perception;   // PER

    public PlayerAttributes(int strength = 0,
        int constitution = 0,
        int intelligence = 0,
        int charisma = 0,
        int luck = 0,
        int perception = 0)
    {
        Strength = strength;
        Constitution = constitution;
        Intelligence = intelligence;
        Charisma = charisma;
        Luck = luck;
        Perception = perception;
    }
}
