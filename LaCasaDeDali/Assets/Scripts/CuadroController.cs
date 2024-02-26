using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadroController : MonoBehaviour
{
    public float visibilityDuration = 5f; // Duration in seconds for the object to be visible

    private GameObject pinturaObject; // Reference to the Pintura GameObject
    private float timer = 0f;
    private bool isVisible = true;

    void Start()
    {
        // Find Pintura object
        Transform marcoTransform = transform.Find("Marco");
        if (marcoTransform != null)
        {
            pinturaObject = marcoTransform.Find("Pintura").gameObject;
        }

        if (pinturaObject == null)
        {
            Debug.LogError("Pintura object not found.");
            return;
        }

        // Check if the object was previously hidden
        if (!PlayerPrefs.HasKey("PinturaVisible"))
        {
            PlayerPrefs.SetInt("PinturaVisible", 1);
        }
        else
        {
            int isVisibleInt = PlayerPrefs.GetInt("PinturaVisible");
            isVisible = isVisibleInt == 1;
        }

        // Set initial visibility
        SetPinturaVisibility();
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Check if the visibility duration has passed
        if (timer >= visibilityDuration)
        {
            isVisible = false;
            SetPinturaVisibility();

            // Reset timer for the next time the scene is loaded
            timer = 0f;
        }
    }

    void SetPinturaVisibility()
    {
        pinturaObject.SetActive(isVisible);

        // Store visibility state for next scene load
        PlayerPrefs.SetInt("PinturaVisible", isVisible ? 1 : 0);
    }
}
