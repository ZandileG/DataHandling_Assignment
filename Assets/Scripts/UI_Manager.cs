using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
  //These are a reference to the Animal script
    public Animal cat;
    public Animal duck; 
    public Animal pig;

  //These are a reference to the text for the cat's stats
    public TextMeshProUGUI catAttentionText; 
    public TextMeshProUGUI catHungerText; 
    public TextMeshProUGUI catEnergyText; 
    public TextMeshProUGUI catHygieneText; 
    public TextMeshProUGUI catHealthText;

  //These are a reference to the text for the duck's stats
    public TextMeshProUGUI duckAttentionText; 
    public TextMeshProUGUI duckHungerText;
    public TextMeshProUGUI duckEnergyText;
    public TextMeshProUGUI duckHygieneText; 
    public TextMeshProUGUI duckHealthText;

  //These are a reference to the text for the pig's stats
    public TextMeshProUGUI pigAttentionText; 
    public TextMeshProUGUI pigHungerText; 
    public TextMeshProUGUI pigEnergyText; 
    public TextMeshProUGUI pigHygieneText; 
    public TextMeshProUGUI pigHealthText;


  //This is a reference to the Feedback teaxt that appears
  //when a worker has taken care of an animal
    public TextMeshProUGUI feedbackText;

    public void Update()
    {
      //Updates the current stats of each animal
        UpdateUI(cat, catAttentionText, catHungerText, 
                 catEnergyText, catHygieneText, catHealthText);

        UpdateUI(duck, duckAttentionText, duckHungerText,  
                 duckEnergyText, duckHygieneText, duckHealthText);

        UpdateUI(pig, pigAttentionText, pigHungerText, 
                 pigEnergyText, pigHygieneText, pigHealthText);
    }

    public void UpdateUI()
    {
        Update();
    }

  //Updates the text for each animal
    public void UpdateUI(Animal animal, TextMeshProUGUI attentionText, 
                         TextMeshProUGUI hungerText, TextMeshProUGUI energyText,
                         TextMeshProUGUI hygieneText, TextMeshProUGUI healthText)
    {
        attentionText.text = "Attention: " + animal.attention.ToString();
        hungerText.text = "Hunger: " + animal.hunger.ToString();
        energyText.text = "Energy: " + animal.energy.ToString();
        hygieneText.text = "Hygiene: " + animal.hygiene.ToString();
        healthText.text = "Health: " + animal.health.ToString();

      //Changes the text color to red if the value is less than 5
      //This shows the player what the animal needs 
        if (animal.attention == 0)
            attentionText.color = Color.red;
        else
            attentionText.color = Color.black;


        if (animal.hunger == 10)
            hungerText.color = Color.red;
        else
            hungerText.color = Color.black;


        if (animal.energy == 0)
            energyText.color = Color.red;
        else
            energyText.color = Color.black;


        if (animal.hygiene == 0)
            hygieneText.color = Color.red;
        else
            hygieneText.color = Color.black;


        if (animal.health == 0)
            healthText.color = Color.red;
        else
            healthText.color = Color.black;
    }

  //Returns the colour to black after the player has helped the animal
    private IEnumerator ResetTextColor(TextMeshProUGUI text, float delay)
    {
        yield return new WaitForSeconds(delay);
        text.color = Color.black;
    }
}

