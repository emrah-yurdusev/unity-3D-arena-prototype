using UnityEngine;

public class PickupItem : MonoBehaviour, IInteractable
{
    public string itemName = "Fragment";
    public int scoreValue = 5;

    public string GetInteractionText()
    {
        return "Press E to Pick Up " + itemName;
    }

    public void Interact()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.CollectItem();
            GameManager.Instance.AddScore(scoreValue);
        }

        gameObject.SetActive(false);
    }
}