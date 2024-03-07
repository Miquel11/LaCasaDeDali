using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WeekCounter : MonoBehaviour
{
    // TextMesh to display the current week and day
    public TMP_Text weekText;

    // Start is called before the first frame update
    void Start()
    {
        // Check if the "WeekNumber" PlayerPrefs key exists
        if (!PlayerPrefs.HasKey("WeekNumber"))
        {
            // If it doesn't exist, initialize it to 1
            PlayerPrefs.SetInt("WeekNumber", 1);
            PlayerPrefs.Save();
        }

        // Load the week number from PlayerPrefs
        int weekNum = PlayerPrefs.GetInt("WeekNumber");

        // Update the week display
        UpdateWeekDisplay(weekNum);
    }

    // This method will be called every time a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the loaded scene is one of the scenes from Monday to Wednesday
        if (scene.name == "EscenaLunes")
        {
            // Get the current week number
            int weekNum = PlayerPrefs.GetInt("WeekNumber");

            // Increment the week number
            weekNum++;

            // Save the updated week number
            PlayerPrefs.SetInt("WeekNumber", weekNum);
            PlayerPrefs.Save();

            // Update the week display
            UpdateWeekDisplay(weekNum);
        }
    }

    // Update the week display text
    void UpdateWeekDisplay(int weekNum)
    {
        // Get the current day based on the loaded scene
        string currentDay = GetCurrentDay();

        // Update the text mesh to display the current week number and day
        if (weekText != null)
        {
            weekText.text = "Week: " + weekNum + "\n" + currentDay;
        }
    }

    // Get the current day based on the loaded scene
    string GetCurrentDay()
    {
        string currentDay = "Unknown";

        // Check the loaded scene name and assign the corresponding day
        switch (SceneManager.GetActiveScene().name)
        {
            case "EscenaLunes":
                currentDay = "Monday";
                break;
            case "EscenaMartes":
                currentDay = "Tuesday";
                break;
            case "EscenaMiercoles":
                currentDay = "Wednesday";
                break;
            // Add cases for additional days if needed
        }

        return currentDay;
    }

    // Unsubscribe from the scene loaded event when the script is destroyed
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
