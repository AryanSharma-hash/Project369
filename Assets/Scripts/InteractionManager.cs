using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class InteractionManager : MonoBehaviour
{
    public Camera playerCamera;
    public TMP_Text interactionText;

    public float interactDistance = 3f;

    private Door currentDoor;

    void Start()
    {
        interactionText.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckForDoor();

        if (currentDoor != null &&
            Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            currentDoor.Interact();
        }
    }

    void CheckForDoor()
    {
        currentDoor = null;

        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            Door door = hit.collider.GetComponentInParent<Door>();

            if (door != null)
            {
                currentDoor = door;

                interactionText.gameObject.SetActive(true);

                if (door.IsOpen())
                {
                    interactionText.text = "Press E to close";
                }
                else
                {
                    interactionText.text = "Press E to open";
                }

                return;
            }
        }

        interactionText.gameObject.SetActive(false);
    }
}