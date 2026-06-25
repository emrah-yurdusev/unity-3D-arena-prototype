using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    public int requiredItems = 5;
    public float openHeight = 4f;

    private bool isOpened;

    public string GetInteractionText()
    {
        if (isOpened)
        {
            return "Door is already opened";
        }

        if (GameManager.Instance != null && GameManager.Instance.collectedItems >= requiredItems)
        {
            return "Press E to Open Door";
        }

        return "Need final key to open door";
    }

    public void Interact()
    {
        if (isOpened) return;

        if (GameManager.Instance == null) return;

        if (GameManager.Instance.collectedItems < requiredItems)
        {
            return;
        }

        OpenDoor();
    }

    private void OpenDoor()
    {
        isOpened = true;

        transform.position += Vector3.up * openHeight;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.WinGameFromDoor();
        }
    }
}