using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    // Audio source for the collision sound
    public AudioSource collisionAudioSource;

    // Array of sounds to mix
    public AudioClip[] sounds;

    void Start()
    {
        // Ensure there are exactly four sounds in the array
        if (sounds.Length != 4)
        {
            Debug.LogError("Please assign exactly four sounds in the inspector.");
            enabled = false;
            return;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is the tower
        if (other.CompareTag("Tower"))
        {
            // Mix all four sounds
            AudioClip mixedClip = MixSounds();

            // Play the mixed sound
            collisionAudioSource.PlayOneShot(mixedClip);
        }
    }

    AudioClip MixSounds()
    {
        int length = Mathf.Min(sounds[0].samples, sounds[1].samples, sounds[2].samples, sounds[3].samples);
        float[] data = new float[length];

        // Initialize data with zeros
        for (int i = 0; i < length; i++)
        {
            data[i] = 0f;
        }

        // Mix the audio data of all four sounds
        for (int s = 0; s < 4; s++)
        {
            float[] soundData = new float[length];
            sounds[s].GetData(soundData, 0);
            for (int i = 0; i < length; i++)
            {
                data[i] += soundData[i] / 4; // Divide by 4 to normalize
            }
        }

        // Create a new AudioClip with the mixed data
        AudioClip mixedClip = AudioClip.Create("MixedClip", length, 1, sounds[0].frequency, false);
        mixedClip.SetData(data, 0);

        return mixedClip;
    }
}
