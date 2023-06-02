using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCycle : MonoBehaviour
{
   //This is the game session's time
    public float gameSessionTime = 0f;
    
  //Worker 1 is only available at 00:02
    public float worker1AvailabilityTime = 2f;

  //Worker 2 is only available at 00:06
    public float worker2AvailabilityTime = 4f;

  //Worker 3 is only available at 00:10
    public float worker3AvailabilityTime = 16f; 

  //This is a reference to the time and feedback texts
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI feedbackText;

  //This runs the clock when the game session starts
    private Coroutine gameSessionCoroutine;

    private void Start()
    {
        gameSessionCoroutine = StartCoroutine(GameSession());
    }

    private IEnumerator GameSession()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            gameSessionTime++;

          //This updates the time text with game's hour and minute
            int minutes = Mathf.FloorToInt(gameSessionTime / 60f);
            int seconds = Mathf.FloorToInt(gameSessionTime % 60f);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


          //Checks if the worker is available then it displays the feedback text
            if (gameSessionTime >= worker1AvailabilityTime && 
                gameSessionTime < worker2AvailabilityTime)
            {
                feedbackText.text = "Worker 1 is available!";
                feedbackText.gameObject.SetActive(true);
            }

            else if (gameSessionTime >= worker2AvailabilityTime &&
                     gameSessionTime < worker3AvailabilityTime)
            {
                feedbackText.text = "Worker 2 is available!";
                feedbackText.gameObject.SetActive(true);
            }

            else if (gameSessionTime >= worker3AvailabilityTime)
            {
                feedbackText.text = "Worker 3 is available!";
                feedbackText.gameObject.SetActive(true);
            }

            else
            {
                feedbackText.gameObject.SetActive(false);
            }
          
          //The text disappears when all the workers are available
            if (gameSessionTime >= worker3AvailabilityTime + 2f)
            {
                feedbackText.gameObject.SetActive(false);
            }
        }
    }
}
