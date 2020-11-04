using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;
    public float FoV = 1000f;
    public float shakeAmount;
    public Vector3 originalcamPos;

    public GameObject Player;
    public GameObject GraplePoint;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Camera.main.fieldOfView = FoV;
        originalcamPos = transform.position;

        //transform.position = (Player.transform.position);


    }

    public void CameraShake ()
    {
        if (shakeAmount > 0) //&& Player.GetComponent<InitialMovement>().CheckIfAttachedCamera == true)
        {
            //Debug.Log("Shaking");

            Vector3 camPos = transform.position;
            //originalcamPos = transform.position;

            float offsetX = Random.value * shakeAmount * 2f - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2f - shakeAmount;

            camPos.x += offsetX;
            camPos.y += offsetY;

            transform.position = new Vector3((Mathf.Clamp(camPos.x, 3, 4)), (Mathf.Clamp(camPos.y, 0, 0.6f)), - 10f);
        }
    }


    //none of this works

    IEnumerator wait(float secondstowaitfor)
    {
        Debug.Log(secondstowaitfor);
        yield return new WaitForSecondsRealtime(secondstowaitfor);
    }

    public void CaneraShakeForSeconds (float secondstoshake, float shakingamount)
    { //timer doesnt work idk why
        //float seconds = 0f;
        float timer = 0f;
        //float timer2 = 0f;
        bool StopShaking = false;

        shakeAmount = shakingamount;
        Debug.Log("Started...");

        timer = Time.realtimeSinceStartup + 3f;
        Debug.Log(Time.realtimeSinceStartup);

        while (StopShaking != true)
        {

            if (Time.realtimeSinceStartup <= timer)
            {
                Debug.Log("timescale " + Time.timeScale);
                Debug.Log("Time shaking");
                CameraShake();
                StartCoroutine(wait(0.5f));
      
            } 
            else
            {
                Debug.Log("Time stopped shaking...");
                StopShaking = true;
            }
        }
    }


	// Update is called once per frame
	void Update () {
        //Debug.Log("Camera - " + Player.GetComponent<InitialMovement>().CheckIfAttachedCamera);

        if (Player != null)
        {
            if (Player.GetComponent<InitialMovement>().CheckIfAttachedCamera == false)
            {
                transform.position = originalcamPos;
                //float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref velocity.x, smoothTimeX);
                //float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref velocity.y, smoothTimeY);

                //transform.position = new Vector3(posX, posY, transform.position.z);
            }
            else if(Player.GetComponent<InitialMovement>().CheckIfAttachedCamera == true)
            {
                switch (Mathf.RoundToInt(Player.GetComponent<InitialMovement>().seconds))
                {

                    case 3:
                        shakeAmount = 0f;
                        break;

                    case 4:
                        shakeAmount = 0.0f;
                        break;

                    case 5:
                        shakeAmount = 0.005f;
                        break;

                    case 6:
                        shakeAmount = 0.0125f;
                        break;

                    case 7:
                        shakeAmount = 0.025f;
                        break;

                    case 8:
                        shakeAmount = 0.05f;
                        break;

                }
                CameraShake();
                //Debug.Log("Shake Amount: " + shakeAmount);
                shakeAmount = 0f;

            }
        }
    }
}
