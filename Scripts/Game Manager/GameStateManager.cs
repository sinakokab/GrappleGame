using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.Advertisements;

public class GameStateManager : MonoBehaviour {

    public GameObject GAMEOVER;
    public GameObject DeathParticles;
    public GameObject Player;
    public GameObject GAMEWIN;
    public GameObject Tutorial;
    public GameObject GrapplePoints;
    public GameObject DataStorageObject;
    public GameObject DeathCameraShake;

    public ParticleSystem ParticleSystem;

    public Text GameWinGrapleCount;
    public Text GrappleBestScore;
    public GameObject GrappleCount;

    public Vector3 PlayerDeathPosition;

    public int PreventGameWinLoop = 0;
    public int RoundsPlayed;

    public Animator TutorialAnim;

    string gameId = "";
    bool testMode = true;


    // Use this for initialization
    void Start () {
        Application.targetFrameRate = 60;
        Player = GameObject.FindGameObjectWithTag("Player");
        ParticleSystem = DeathParticles.GetComponent<ParticleSystem>();
        ParticleSystem.Stop();
        GrappleCount = GameObject.Find("GrappleCount");
        DeathCameraShake = GameObject.FindGameObjectWithTag("MainCamera");
        DataStorageObject = GameObject.Find("DataStorage");
        //Advertisement.Initialize(gameId, testMode);
    }
	



// Update is called once per frame
void FixedUpdate () {


        if (Player != null)
        {
            if (Player.GetComponent<InitialMovement>().GameEND == true)
            {
                PlayerDeathPosition = Player.transform.position;

                Destroy(Player);
                Debug.Log("Game END");

                DataStorageObject.GetComponent<SceneDataStorage>().RoundsPlayed += 1;
                Debug.Log("Rounds Played (DataStorage): " + DataStorageObject.GetComponent<SceneDataStorage>().RoundsPlayed.ToString()); //Saves numbers of rounds played for AD display after 5-6 games

                if (DataStorageObject.GetComponent<SceneDataStorage>().RoundsPlayed >= 7)
                {
                    //play ADS
                    Debug.Log("ADS playing");
                    //Advertisement.Show(); Android/IOS only
                }

                Instantiate(DeathParticles, PlayerDeathPosition, transform.rotation);
                DeathParticles.transform.position = PlayerDeathPosition;
                ParticleSystem.Play();
               



                if (TutorialAnim != null && Tutorial != null)
                {
                    TutorialAnim.SetBool("GameOver", true);
                    Tutorial.SetActive(false);
                }



            }
            else if (Player.GetComponent<InitialMovement>().GameWin == true && Player.GetComponent<InitialMovement>().GameEND != true && PreventGameWinLoop < 1) 
            {

                if (PlayerPrefs.GetFloat("Level " + SceneManager.GetActiveScene().buildIndex.ToString()) > GrappleCount.GetComponent<GrappleCounter>().NumberOfGrapples && PlayerPrefs.GetInt(("Level " + SceneManager.GetActiveScene().buildIndex.ToString() + " ScoreChanged")) > 0)
                {
                    PlayerPrefs.SetFloat(("Level " + SceneManager.GetActiveScene().buildIndex.ToString()), GrappleCount.GetComponent<GrappleCounter>().NumberOfGrapples);
                } else if (PlayerPrefs.GetInt("Level " + SceneManager.GetActiveScene().buildIndex.ToString() + " ScoreChanged") == 0)
                {
                    Debug.Log(SceneManager.GetActiveScene().buildIndex.ToString());
                    PlayerPrefs.SetFloat(("Level " + SceneManager.GetActiveScene().buildIndex.ToString()), GrappleCount.GetComponent<GrappleCounter>().NumberOfGrapples);
                    PlayerPrefs.SetInt(("Level " + SceneManager.GetActiveScene().buildIndex.ToString() + " ScoreChanged"), 1);
                }

                PlayerPrefs.SetInt(("Level " + SceneManager.GetActiveScene().buildIndex.ToString() + " Status"), 1); // 1 = completed stage, 0 = to be completed

                GrapplePoints.SetActive(false);
                PreventGameWinLoop += 1;
                GAMEWIN.SetActive(true);

                DataStorageObject.GetComponent<SceneDataStorage>().RoundsPlayed += 1;
                Debug.Log("Rounds Played (DataStorage): " + DataStorageObject.GetComponent<SceneDataStorage>().RoundsPlayed.ToString());

                if (DataStorageObject.GetComponent<SceneDataStorage>().RoundsPlayed >= 7)
                {
                    //play ADS
                    //Advertisement.Show();
                    Debug.Log("ADS playing");
                }

                GameWinGrapleCount.text = ("Score: " + GrappleCount.GetComponent<GrappleCounter>().NumberOfGrapples);
                GrappleBestScore.text = ("Best: " + PlayerPrefs.GetFloat("Level " + SceneManager.GetActiveScene().buildIndex.ToString()));
                Debug.Log("Game WIN");


                if (Tutorial != null)
                {
                    TutorialAnim.SetBool("GameOver", true);
                    Tutorial.SetActive(false);
                }

            }
        } else
        {
            GAMEOVER.SetActive(true);
            // Game over screen set active set AD after certain number of plays
        }
		
	}

  }
