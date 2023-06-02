using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
  //These are visible in the Inspector so that they can be entered there
    public float attention;
    public float hunger;
    public float energy;
    public float hygiene;
    public float health;
    
  //These are the rates at which the values of these attributes decrease
  //Hunger increases becuase an animal becomes more hungry when not fed
  //They are also etered in the Inspector
    public float attentionRate;
    public float hungerRate;
    public float energyRate;
    public float hygieneRate;
    public float healthRate;

    private Coroutine attentionCoroutine;
    private Coroutine hungerCoroutine;
    private Coroutine energyCoroutine;
    private Coroutine hygieneCoroutine;
    private Coroutine healthCoroutine;

  //Reference to the UI Manager 
    private UI_Manager uiManager;

    private void Start()
    {
      //Changes the attribute values over time
        attentionCoroutine = StartCoroutine(ChangeAttributeOverTime
                              (attention, attentionRate, UpdateAttention));

        hungerCoroutine = StartCoroutine(ChangeAttributeOverTime
                               (hunger, hungerRate, UpdateHunger));

        energyCoroutine = StartCoroutine(ChangeAttributeOverTime
                               (energy, energyRate, UpdateEnergy));

        hygieneCoroutine = StartCoroutine(ChangeAttributeOverTime
                             (hygiene, hygieneRate, UpdateHygiene));


        healthCoroutine = StartCoroutine(ChangeAttributeOverTime
                               (health, healthRate, UpdateHealth));

      //Gets the UI Manager game object
        uiManager = GameObject.FindObjectOfType<UI_Manager>();
    }

    //This changes the animal's attribute value after the worker interacts with it
    private IEnumerator ChangeAttributeOverTime(float attributeValue, float rate, System.Action<float> updateMethod)
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            attributeValue += rate;
            attributeValue = Mathf.Clamp(attributeValue, 0f, 10f);

            if (attributeValue >= 7f && attributeValue == hunger)
            {
                attributeValue = 0f;
            }

            else if (attributeValue <= 3f && (attributeValue == health || attributeValue == energy || attributeValue == attention))
            {
                attributeValue = 10f;
            }

            updateMethod(attributeValue);
        }
    }


  //This updates the UI for these stats 
    private void UpdateAttention(float value)
    {
        attention = value;
        uiManager.UpdateUI();

    }

    private void UpdateHunger(float value)
    {
        hunger = value;
        uiManager.UpdateUI();

    }

    private void UpdateEnergy(float value)
    {
        energy = value;
        uiManager.UpdateUI();

    }

    private void UpdateHygiene(float value)
    {
        hygiene = value;
        uiManager.UpdateUI();

    }

    private void UpdateHealth(float value)
    {
        health = value;
        uiManager.UpdateUI();
    }
}

