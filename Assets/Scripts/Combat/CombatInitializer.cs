using UnityEngine;

public class CombatInitializer : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"Combat Started! {MomentumManager.MomentumHolder} has the momentum advantage.");
        
        // Initialize combat system here based on MomentumManager.MomentumHolder
        // Example: Show UI for combat and set initial turn.
    }
}