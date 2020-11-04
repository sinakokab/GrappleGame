using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicScript : MonoBehaviour {

    public AudioSource Song;

    public AudioClip BeachSong;
    public AudioClip DesertSong;
    public AudioClip GrassSong;

    public float BuildIndexCheck;

    public static MusicScript i;

    public bool SingleLoop = false;

    private void Awake()
    {

        if (!i)
        {
            i = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckStageSong()
    {

        if (BuildIndexCheck != SceneManager.GetActiveScene().buildIndex) {
            Debug.Log("Checking name");

            if (SceneManager.GetActiveScene().name.Contains("Sand"))
            {
                Debug.Log("DESERT SONG SET");
                Song.clip = DesertSong;
                Song.Play();
            }
            else if (SceneManager.GetActiveScene().name.Contains("Beach"))
            {
                gameObject.GetComponent<AudioSource>().clip = BeachSong;
                gameObject.GetComponent<AudioSource>().Play();
            }
            else if (SceneManager.GetActiveScene().name.Contains("Grass"))
            {
                gameObject.GetComponent<AudioSource>().clip = GrassSong;
                gameObject.GetComponent<AudioSource>().Play();
            }
            else
            {
                gameObject.GetComponent<AudioSource>().Pause();
            }
        }

        BuildIndexCheck = SceneManager.GetActiveScene().buildIndex;

    }


    // Use this for initialization
    void CheckStatus () {

        if (SceneDataStorage.InitiallyChangedSettings == true)
        {
            //Debug.Log("Music Script inital setting change");
            if (SceneDataStorage.MusicPlaying == true)
            {
                //Song.enabled = false;
                gameObject.GetComponent<AudioSource>().enabled = true;
               // Debug.Log("Playing....");
                SingleLoop = true;

            }
            else if (SceneDataStorage.MusicPlaying == false)
            {
                //Debug.Log("Not supposed to be playing music");
                gameObject.GetComponent<AudioSource>().enabled = false;
                SingleLoop = true;
            }
        }

	}

    void Update()
    {
        CheckStatus();
        CheckStageSong();
    }

}
