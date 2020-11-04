using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonLevels : MonoBehaviour {

    public GameObject Sand;
    public GameObject Desert;
    public GameObject Beach;
    public Text LevelNumber;
    public int LevelNumberInt;

    void GoToLevel()
    {
        int.TryParse(LevelNumber.text, out LevelNumberInt);

        if (Sand.activeInHierarchy == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + LevelNumberInt);
        }
        else if (Desert.activeInHierarchy == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + LevelNumberInt + 10 ); //10 being the number of previous scenes in previous stage
        }
        else if (Beach.activeInHierarchy == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + LevelNumberInt + 20);
        }
    }
}
