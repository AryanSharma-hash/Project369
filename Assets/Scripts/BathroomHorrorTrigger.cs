using UnityEngine;

public class BathroomHorrorTrigger : MonoBehaviour
{
    public BathroomHorrorEvent horrorEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            horrorEvent.TriggerEvent();
        }
    }
}