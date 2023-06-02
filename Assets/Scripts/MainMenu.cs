using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  //This activates the "Play"button's functionality
    public void Play()
    {
      //When the player presses the "Play" button, the game will begin
        SceneManager.LoadScene("AnimalCareGame");
    }

  //The game will end when the "Quit" button is pressed
    public void Quit()
    {
        Application.Quit();
    }
}
