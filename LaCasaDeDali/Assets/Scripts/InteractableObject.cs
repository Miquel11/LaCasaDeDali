using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public GameObject player;
    public float interactionDistance = 5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance <= interactionDistance)
        {
            // Interaction is within range
            Disappear();
            GameManager.interactedObjects++; // Increment the interacted objects counter
            GameManager.CheckInteractedObjects(); // Check if all objects have been interacted with
        }
    }

    private void Disappear()
    {
        gameObject.SetActive(false); // or Destroy(gameObject);
    }
}
