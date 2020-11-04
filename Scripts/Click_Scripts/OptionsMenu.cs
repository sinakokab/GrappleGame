using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour {
    public Animator OptionsMenuAnimation;
    public GameObject MusicButton;
    public GameObject SoundButton;

    public Sprite MusicOn;
    public Sprite MusicOff;
    public Sprite SoundOn;
    public Sprite SoundOff;

    public Text MusicText;
    public Text SoundText;

    public bool MusicPlaying = true;
    public bool SoundPlaying = true;
    public bool initialSet = false;

    public bool TimePaused = false;

    public GameObject Options_Menu;
    public GameObject MusicSource;//camera
    public GameObject SoundFXManager;





    private void Awake()
    {

        if (SceneDataStorage.InitiallyChangedSettings == true && initialSet == false)
        {
            if (SceneDataStorage.SoundPlaying == true)
            {
                SoundPlaying = true;
                SoundButton.GetComponent<Image>().sprite = SoundOn;
                SoundText.text = "Mute Sound";
                SoundFXManager.SetActive(true);
            }
            else if (SceneDataStorage.SoundPlaying == false)
            {
                SoundPlaying = false;
                SoundButton.GetComponent<Image>().sprite = SoundOff;
                SoundText.text = "Play Sound";
                SoundFXManager.SetActive(false);
            }

            if (SceneDataStorage.MusicPlaying == true)
            {
                MusicPlaying = true;
                MusicButton.GetComponent<Image>().sprite = MusicOn;
                MusicText.text = "Mute Music";
                //MusicSource.GetComponent<AudioSource>().Play();
            }
            else if (SceneDataStorage.MusicPlaying == false)
            {
                MusicPlaying = false;
                MusicButton.GetComponent<Image>().sprite = MusicOff;
                MusicText.text = "Play Music";
                //MusicSource.GetComponent<AudioSource>().Pause();
            }

            initialSet = true;
        }
        else if(SceneDataStorage.InitiallyChangedSettings == false && initialSet == false)
        {
            SceneDataStorage.MusicPlaying = MusicPlaying;
            SceneDataStorage.SoundPlaying = SoundPlaying;
            initialSet = true;
    
        }
        //Music Playing = saved value, saving the player from having to pause every game

    }


    public void ResumeGame()
    { 

        Time.timeScale = 1.0f;
        Options_Menu.SetActive(false);
        TimePaused = false;
        //Time.timeScale = 1.0f;
        Debug.Log("Resumed");
    }

    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        TimePaused = false;
        Options_Menu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Home ()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Game_Start");
    }

    public void MusicToggle ()
    {
        if (MusicPlaying == false)
        {
            //Playing sprite
            MusicButton.GetComponent<Image>().sprite = MusicOn;
            MusicPlaying = true;

            SceneDataStorage.MusicPlaying = true;
            SceneDataStorage.InitiallyChangedSettings = true;
            MusicText.text = "Mute Music";
            //MusicSource.GetComponent<AudioSource>().Play();
        }
        else if (MusicPlaying == true)
        {
            // Muted
            MusicButton.GetComponent<Image>().sprite = MusicOff;
            MusicPlaying = false;
            SceneDataStorage.MusicPlaying = false;
            SceneDataStorage.InitiallyChangedSettings = true;
            MusicText.text = "Play Music";
            //MusicSource.GetComponent<AudioSource>().Pause();
        }
        // Change text and sprite per click
    }

    public void SoundToggle ()
    {
        if (SoundPlaying == false)
        {
            //Playing sprite
            SoundButton.GetComponent<Image>().sprite = SoundOn;
            SoundPlaying = true;
            SceneDataStorage.SoundPlaying = true;
            SceneDataStorage.InitiallyChangedSettings = true;
            SoundText.text = "Mute Sound";
            SoundFXManager.SetActive(true);
        }
        else if (SoundPlaying == true)
        {
            // Muted
            SoundButton.GetComponent<Image>().sprite = SoundOff;
            SoundPlaying = false;
            SceneDataStorage.SoundPlaying = false;
            SceneDataStorage.InitiallyChangedSettings = true;
            SoundText.text = "Play Sound";
            SoundFXManager.SetActive(false);
        }
    }

    public void NextLevel ()
    {
        //Debug.Log("Going...");

        if (Application.CanStreamedLevelBeLoaded(SceneManager.GetActiveScene().buildIndex + 1) == true)
        {
            Debug.Log("Next Level Loading...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (Application.CanStreamedLevelBeLoaded(SceneManager.GetActiveScene().buildIndex + 1) == false) 
        {
            Debug.Log("Next Level doesn't exist");
            //Game Completed screen
        }
    }

    public void Update()
    {
        bool singleLoop = false;

        if (Options_Menu.activeInHierarchy == true && singleLoop == false)
        {
            Time.timeScale = 0.0f;
        }
    }
}
