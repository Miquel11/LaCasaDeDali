using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour
{
    // The name of the scene you want to load
    public string sceneName = "EscenaLunes";

    // Update is called once per frame
    void Update()
    {
        // Check if the user clicks the mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            // Check if the ray hits a collider
            if (Physics.Raycast(ray, out hitInfo))
            {
                // Check if the collider belongs to the plane
                if (hitInfo.collider.gameObject == gameObject)
                {
                    // Load the scene
                    SceneManager.LoadScene(sceneName);
                }
            }
        }
    }
}
