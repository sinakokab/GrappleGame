using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionScript : MonoBehaviour {

    public GameObject StartScreen;
    public GameObject CreditScreen;
    public GameObject Grass;
    public GameObject Beach;
    public GameObject Desert;
    public GameObject Mountains;
    public GameObject LevelCompletionCheck;


    public void StartGame()
    {
        StartScreen.SetActive(false);
        Desert.SetActive(true);
        LevelCompletionCheck.GetComponent<MainNavigationScreen>().LevelCompletionCheck();


    }

    public void Credits()
    {
        StartScreen.SetActive(false);
        CreditScreen.SetActive(true);
    }

    public void HomeFromCredits ()
    {
        CreditScreen.SetActive(false);
        StartScreen.SetActive(true);
    }

    public void NextStage()
    {
        //Grass = GameObject.FindGameObjectWithTag("Grass");
        if (Desert.active == true)
        {
            Desert.SetActive(false);
            Beach.SetActive(true);
            LevelCompletionCheck.GetComponent<MainNavigationScreen>().LevelCompletionCheck();
            //singleclick = true;
        }
        else if (Beach.active == true)
        {
            Grass.SetActive(true);
            Beach.SetActive(false);
            LevelCompletionCheck.GetComponent<MainNavigationScreen>().LevelCompletionCheck();
            //singleclick = true;

        }

    }
    
    public void PreviousStage()
    {
        if (Beach.active == true)
        {
            Beach.SetActive(false);
            Desert.SetActive(true);
            LevelCompletionCheck.GetComponent<MainNavigationScreen>().LevelCompletionCheck();
            //singleclick = true;

        }
        else if (Grass.active == true)
        {
            Beach.SetActive(true);
            Grass.SetActive(false);
            LevelCompletionCheck.GetComponent<MainNavigationScreen>().LevelCompletionCheck();
            //singleclick = true;
        }

    }

}

