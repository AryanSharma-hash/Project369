using UnityEngine;
using System.Collections;

public class BathroomHorrorEvent : MonoBehaviour
{
    public AudioSource horrorAudio;
    public Light bathroomLight;

    public float flickerDuration = 2f;
    public float flickerSpeed = 0.08f;

    private bool hasTriggered = false;

    public void TriggerEvent()
    {
        if (hasTriggered)
            return;

        hasTriggered = true;

        if (horrorAudio != null)
        {
            horrorAudio.Play();
        }

        if (bathroomLight != null)
        {
            StartCoroutine(FlickerLight());
        }
    }

    IEnumerator FlickerLight()
    {
        float timer = 0f;

        while (timer < flickerDuration)
        {
            bathroomLight.enabled = !bathroomLight.enabled;

            yield return new WaitForSeconds(flickerSpeed);

            timer += flickerSpeed;
        }

        bathroomLight.enabled = true;
    }
}