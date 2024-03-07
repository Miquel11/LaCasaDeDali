using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int interactedObjects = 0;
    public static bool pinturaVisible = true;

    // Method to check if all objects have been interacted with
    public static void CheckInteractedObjects()
    {
        if (interactedObjects >= 3)
        {
            pinturaVisible = false;
        }
    }
}
