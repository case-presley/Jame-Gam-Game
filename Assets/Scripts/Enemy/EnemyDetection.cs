using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public PlayerStatsManager playerStats;
    public int enemyPerception = 2;
    public string combatTestScene = "CombatTestScene";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected, starting dice roll... ");
            StartCombat();
        }
    }

    void StartCombat()
    {
        int playerRoll = Random.Range(0, 20) + playerStats.GetAttribute("perception"); // d20 roll
        int npcRoll = Random.Range(0, 20) + enemyPerception;

        if (playerRoll > npcRoll)
        {
            MomentumManager.MomentumHolder = "Player";
            Debug.Log($"Player wins the roll ({playerRoll} vs {npcRoll}). Player goes first and has momentum. ");
        }
        else if (playerRoll < npcRoll)
        {
            MomentumManager.MomentumHolder = "Enemy";
            Debug.Log($"NPC wins roll ({npcRoll} vs {playerRoll}). Enemy goes first and has momentum. ");
        }
        else
        {
            MomentumManager.MomentumHolder = Random.value > 0.5 ? "Player" : "NPC";
            Debug.Log($"It's a tie ({playerRoll} vs {npcRoll}). Turn and momentum will be decided randomly. ");
        }
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(combatTestScene);
    }
}
