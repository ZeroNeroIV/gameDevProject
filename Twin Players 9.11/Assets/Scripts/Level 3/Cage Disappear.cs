using UnityEngine;

public class CageController : MonoBehaviour
{
    public int zombiesKilled = 0;
    public int zombiesToKill = 40;

    // Function to call when a zombie is killed
    public void ZombieKilled()
    {
        zombiesKilled++;

        // Check if the required number of zombies have been killed
        if (zombiesKilled >= zombiesToKill)
        {
            // If yes, deactivate the cage GameObject
            gameObject.SetActive(false);
        }
    }
}
