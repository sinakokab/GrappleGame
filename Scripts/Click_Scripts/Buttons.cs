using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Purchasing;


public class Buttons : MonoBehaviour {

    public void Retry()
    {
        Debug.Log("Loading...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void GetRidOfADS()
    {
        if (PlayerPrefs.GetInt("IAP_ADS", 0) == 1)
        {
            // Make button invisible

        } else
        {
            // initiate Gplay transaction

        }
        
        // TODO 
    }
}
