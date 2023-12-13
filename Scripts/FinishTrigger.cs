using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    // This method is called when something enters the trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Load the scene with index 2
            SceneManager.LoadScene(2);
        }
    }
}
