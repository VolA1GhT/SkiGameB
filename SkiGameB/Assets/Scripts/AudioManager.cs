using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip hitClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Obstacle.OnPlayerHit += PlayCollisionSound;
    }

    private void PlayCollisionSound()
    {
        audioSource.PlayOneShot(hitClip);
        Debug.Log("SOUNDHIT");
    }
}
