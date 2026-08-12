using UnityEngine;
using UnityEngine.InputSystem;

public class FootstepSystem : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] footsteps;

    public float stepInterval = 0.45f;

    private float stepTimer;

    void Update()
    {
        if (Keyboard.current == null)
            return;

        Vector2 movement = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            movement.y += 1;

        if (Keyboard.current.sKey.isPressed)
            movement.y -= 1;

        if (Keyboard.current.aKey.isPressed)
            movement.x -= 1;

        if (Keyboard.current.dKey.isPressed)
            movement.x += 1;

        bool isMoving = movement.magnitude > 0.1f;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    void PlayFootstep()
    {
        if (footsteps.Length == 0)
            return;

        AudioClip clip = footsteps[
            Random.Range(0, footsteps.Length)
        ];

        audioSource.PlayOneShot(clip);
    }
}