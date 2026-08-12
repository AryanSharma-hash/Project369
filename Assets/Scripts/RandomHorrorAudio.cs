using UnityEngine;

public class RandomHorrorAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] horrorSounds;
    public Transform[] soundPoints;

    public float minimumDelay = 15f;
    public float maximumDelay = 30f;

    private float timer;

    void Start()
    {
        SetNextSoundTime();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            PlayRandomSound();
            SetNextSoundTime();
        }
    }

    void PlayRandomSound()
    {
        if (horrorSounds.Length == 0 || soundPoints.Length == 0)
            return;

        AudioClip clip = horrorSounds[
            Random.Range(0, horrorSounds.Length)
        ];

        Transform point = soundPoints[
            Random.Range(0, soundPoints.Length)
        ];

        audioSource.transform.position = point.position;

        audioSource.PlayOneShot(clip);
    }

    void SetNextSoundTime()
    {
        timer = Random.Range(minimumDelay, maximumDelay);
    }
}