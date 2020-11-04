using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScript1 : MonoBehaviour {
    public bool TutorialScene = false;
    public bool SingleTimeSlow = false;
    public GameObject Player;

    // Use this for initialization
    void Start()
    {

        Debug.Log(SceneManager.GetActiveScene().buildIndex);

        if (SceneManager.GetActiveScene().buildIndex == 2)
        { //checks if second tutorial scene 
            TutorialScene = true;
            //Debug.Log("Scene found");
            Player = GameObject.Find("Player");
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (TutorialScene == true && Player != null)
        {
            if (Player.GetComponent<Rigidbody2D>().gravityScale == 2f && SingleTimeSlow == false)
            {
                //Debug.Log("Time sloweeeeddd");
                Time.timeScale = 0.5f;
                SingleTimeSlow = true;
            }
        }
	}
}
