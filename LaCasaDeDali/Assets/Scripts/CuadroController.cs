using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadroController : MonoBehaviour
{
     public float visibilityDuration = 5f; // Duration in seconds for the object to be visible
    public AudioClip disappearSound; // Sound to play when the Pintura disappears

    private GameObject pinturaObject; // Reference to the Pintura GameObject
    private bool isVisible = true;
    private AudioSource audioSource;

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

        // Find AudioSource component within the Cuadro object
        audioSource = GetComponentInChildren<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource component not found. Sound effect will not play.");
        }
    }

    void Update()
    {
        // Hide the Pintura if its name is not "Cuadro2"
        if (gameObject.name.Equals("CuadroMartes"))
        {
            if (Time.timeSinceLevelLoad >= visibilityDuration && GameManager.pinturaVisible)
            {
            // Only play sound and set visibility if the Pintura is currently visible
                if (isVisible)
                {
                    // Play the sound effect
                    PlayDisappearSound();

                    // Hide the Pintura
                    isVisible = false;
                    SetPinturaVisibility();
                }
            }
        }
        else{

            // Check if the visibility duration has passed
            if (Time.timeSinceLevelLoad >= visibilityDuration)
            {
            // Only play sound and set visibility if the Pintura is currently visible
                if (isVisible)
                {
                    // Play the sound effect
                    PlayDisappearSound();

                    // Hide the Pintura
                    isVisible = false;
                    SetPinturaVisibility();
                }
            }
        }
        
    }

    void SetPinturaVisibility()
    {
        pinturaObject.SetActive(isVisible);
    }

    void PlayDisappearSound()
    {
        if (audioSource != null && disappearSound != null)
        {
            // Play the sound effect
            audioSource.PlayOneShot(disappearSound);
        }
    }
}
