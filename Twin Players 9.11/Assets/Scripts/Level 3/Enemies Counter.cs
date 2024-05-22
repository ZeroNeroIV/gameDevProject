using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Reference to the cage GameObject
    public CageController cageController;

    // Function to call when the zombie is killed
    public void Die()
    {
        // Call the ZombieKilled function on the cage controller
        cageController.ZombieKilled();

        // Other death logic goes here
        // For example, play death animation, sound, etc.
    }
}
