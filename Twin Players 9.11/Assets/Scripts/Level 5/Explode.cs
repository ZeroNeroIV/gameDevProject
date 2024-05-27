using UnityEngine;

public class PlaneCollision : MonoBehaviour
{
    // Audio source for the collision sound
    private AudioSource _collisionAudioSource;

    // Array of sounds to mix
    public AudioClip[] sounds;

    private void Start() => _collisionAudioSource = GetComponent<AudioSource>();

    private void OnCollisionEnter(Collision other)
    {
        // Check if the collided object is the tower
        if (!other.collider.CompareTag("Tower")) return;
        // Mix all four sounds
        var mixedClip = MixSounds();
        // Play the mixed sound
        _collisionAudioSource.PlayOneShot(mixedClip);

        Destroy(gameObject);
    }

    private AudioClip MixSounds()
    {
        var length = Mathf.Min(sounds[0].samples, sounds[1].samples, sounds[2].samples, sounds[3].samples);
        var data = new float[length];

        // Initialize data with zeros
        for (var i = 0; i < length; i++)
            data[i] = 0f;

        // Mix the audio data of all four sounds
        foreach (var s in sounds)
        {
            var soundData = new float[length];
            s.GetData(soundData, 0);
            for (var i = 0; i < length; i++)
                data[i] += soundData[i] / 4; // Divide by 4 to normalize
        }

        // Create a new AudioClip with the mixed data
        var mixedClip = AudioClip.Create("MixedClip", length, 1, sounds[0].frequency, false);
        mixedClip.SetData(data, 0);

        return mixedClip;
    }
}
