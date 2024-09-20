using UnityEngine;

public class BallSoundEffects : MonoBehaviour
{
    private AudioSource audioSource;  // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the ball collides with either the "LeftWall" or "RightWall"
        if (collision.gameObject.name == "PlayerGoal" || collision.gameObject.name == "AIGoal")
        {
            if (audioSource != null)
            {
                audioSource.Play();  // Play the sound effect
            }
        }
    }
}
