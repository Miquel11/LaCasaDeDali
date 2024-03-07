using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text countdownTextMesh;
    public float countdownDuration = 60f;

    private float timer;

    void Start()
    {
        timer = countdownDuration;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        UpdateCountdownText();

        if (timer <= 0)
        {
            // Call another script or function when countdown reaches zero
            ChangeScene.TimeEnds();
            // Call your other script or function here
            // Example: MyOtherScript.MyFunction();
        }
    }

    void UpdateCountdownText()
    {
        int seconds = Mathf.RoundToInt(timer);
        countdownTextMesh.text = seconds.ToString();
    }
}
