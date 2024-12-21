using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    public PlayerAttributes Attributes;

    public int Level = 1;       // Player's level
    public int Experience = 0; // Current experience points
    public int NextLevelXP = 100; // Experience needed for the next level

    void Start()
    {
        // Initialize player attributes with default values
        Attributes = new PlayerAttributes();
    }

    public void GainExperience(int xp)
    {
        Experience += xp;

        if (Experience >= NextLevelXP)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        Level++;
        Experience = Experience - NextLevelXP;
        NextLevelXP = Mathf.CeilToInt(NextLevelXP * 1.5f); // Increase XP requirement for next level

        // Example level-up logic (distribute stat points)
        Attributes.Strength += 1;
        Attributes.Constitution += 1;
        Attributes.Intelligence += 1;
        Attributes.Charisma += 1;
        Attributes.Luck += 1;
        Attributes.Perception += 1;

        Debug.Log("Level Up! Current Level: " + Level);
    }

    public int GetAttribute(string attributeName)
    {
        switch (attributeName.ToLower())
        {
            case "strength": return Attributes.Strength;
            case "constitution": return Attributes.Constitution;
            case "intelligence": return Attributes.Intelligence;
            case "charisma": return Attributes.Charisma;
            case "luck": return Attributes.Luck;
            case "perception": return Attributes.Perception;
            default: return 0;
        }
    }
}