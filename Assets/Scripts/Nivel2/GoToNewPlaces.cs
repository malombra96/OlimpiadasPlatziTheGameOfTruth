using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GoToNewPlaces : MonoBehaviour
{
    // nombre de la escena que me quiero dirigir 
    public string newPlaceName = "New Scene Name Here";
    //nombre del lugar a que me quiero dirigir 
    public string goToPlaceName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<PlayerController>().nextPlacesName = goToPlaceName;
            SceneManager.LoadScene(newPlaceName);
            
        }
    }
}
