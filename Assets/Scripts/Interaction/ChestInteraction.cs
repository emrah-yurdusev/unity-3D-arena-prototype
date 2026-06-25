using UnityEngine;

public class ChestInteraction : MonoBehaviour, IInteractable
{
    public GameObject finalItem;
    public int requiredItems = 4;

    private bool isOpened;

    public string GetInteractionText()
    {
        if (isOpened)
        {
            return "Chest is already opened";
        }

        if (GameManager.Instance != null && GameManager.Instance.collectedItems >= requiredItems)
        {
            return "Press E to Open Chest";
        }

        return "Need 4 items to open chest";
    }

    public void Interact()
    {
        if (isOpened) return;

        if (GameManager.Instance == null) return;

        if (GameManager.Instance.collectedItems < requiredItems)
        {
            return;
        }

        OpenChest();
    }

    private void OpenChest()
    {
        isOpened = true;

        if (finalItem != null)
        {
            finalItem.SetActive(true);
        }

        transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);
    }
}