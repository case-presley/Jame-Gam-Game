using UnityEngine;

public class AreaTransition : MonoBehaviour
{
    public string sceneToLoad; // The scene to load when the player enters the trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the player enters the trigger
        {
            SceneController.Instance.LoadScene(sceneToLoad); // Load the scene
        }
    }
}