using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveWorker : MonoBehaviour
{
 //This is the animal's position
   public Vector3 targetPosition;

 //Checks if the worker has been clicked
   private bool isClicked = false;

 //This is the worker's original position
   private Vector3 originalPosition;

 //This is a reference to the Animal script
    public Animal animal;
 

    private void Start()
    {
        originalPosition = transform.position;
    }


    private void Update()
    {
        if (isClicked)
        {
          //Move the worker to the animal when it is clicked
            transform.position = Vector3.MoveTowards(transform.position, 
                                   targetPosition, Time.deltaTime * 30f);
        }
    }

    private void OnMouseDown()
    {
      //Makes the worker game object remain at the animal's position
        isClicked = true;
        targetPosition = new Vector3(transform.position.x, transform.position.z);

        //The worker increases the animal's values when they interact
          animal.attention = 10;
          animal.hunger = 0;
          animal.energy = 10;
          animal.hygiene = 10;
          animal.health = 10; 
    }

  //Takes the worker to its original position
  //after it has taken care of an animal
    private void OnMouseUp()
    {
        isClicked = false;
        Invoke("ResetPosition", 2f);
    }

    private void ResetPosition()
    {
        transform.position = originalPosition;
    }
}


