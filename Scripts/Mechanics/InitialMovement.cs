using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InitialMovement : MonoBehaviour {

    public Rigidbody2D Player;
    public GameObject Player2;
    public HingeJoint2D PlayerHinge;

    public GameObject GrapplePoint;
    public GameObject GrapplePoint2;
    public GameObject SoundFXManager;

    public Animator anim;

    public float initialMultiplier = 200f;
    public float ForceMultiplier = 10f;
    public float maxSpeed = 15f;
    public float angleToTarget;
    public float force = 35f; //Base detachment Force
    public float currentForce; 
    public float maxForce = 50f; //Maximum Detachment Force
    public float seconds;
    public float timer = 0f;
   


    public float CurrentSpeed;
    Vector2 toVector;

    public bool CheckIfAttachedCamera;
    public bool initialDetachment = false;
    public bool GameStart;
    public bool GameEND = false;
    public bool GameWin = false;
    public bool CheckClick = false; //??

    public GraphicRaycaster m_Raycaster;
    public PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1.0f;
        Player = Player.GetComponent<Rigidbody2D>();
        Player.gravityScale = 0f;
        PlayerHinge = Player.GetComponent<HingeJoint2D>();
        GrapplePoint = GameObject.FindGameObjectWithTag("GrapplePoint");
        if (GrapplePoint.activeInHierarchy == false)
        {
            GrapplePoint2 = GrapplePoint;
            Debug.Log("Stage 1");
        }
        else
        {
            GrapplePoint2 = GrapplePoint.GetComponent<RopeController>().FindClosestGraple();
        }

        

   
    }

    float GetAngle(Vector3 From, Vector3 To)
    {
        Vector2 dir = new Vector2();

        dir.x = From.x - To.x;
        dir.y = From.y - To.y;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        return (angle);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        SoundFXManager.GetComponent<SoundFX>().PlayerCollisionAudio.Play();

        if (collision.gameObject.tag == "Bottom_Map") // Add another death condition for landing outside of map bounds
        {
            GameEND = true;
        } else if (collision.gameObject.tag == "Win_Map")
        {
            GameWin = true;
        }
    }



    // Update is called once per frame
    void FixedUpdate () {

        CheckClick = false;

        if (Input.GetMouseButtonDown(0) && GameStart == false && GameEND != true) 
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.name == "Pause_Button")
                {
                    CheckClick = true;
                    Debug.Log("Pause Button HIT " + CheckClick);
                }
            }

            if (CheckClick == false)
            {
                Debug.Log("Input. CheckClick Status: " + CheckClick);
                GameStart = true;
                Player.gravityScale = 2f;
                Player.AddForce(transform.right * initialMultiplier, ForceMode2D.Impulse);
                anim.Play("Sand_Entrance_Closing");
            }
        }

        if (GrapplePoint2.activeInHierarchy == true)
        {

            GrapplePoint2 = GrapplePoint.GetComponent<RopeController>().FindClosestGraple();
            CheckIfAttachedCamera = GrapplePoint2.GetComponent<RopeController>().CheckIfAttached;
            PlayerHinge.GetComponent<HingeJoint2D>();
        }

        if (GrapplePoint2.GetComponent<RopeController>().CheckIfAttached == true || PlayerHinge.enabled == true && Player.GetComponent<InitialMovement>().GameEND != true && GameStart == true)
        {
            if (seconds <= 8)
            {
                timer += Time.deltaTime;
                seconds = timer % 60;
                //Debug.Log("Time: " + seconds);
            } else
            {
                //Debug.Log("Maximum Force Reached");
            }
            Player.gravityScale = 0.5f;

            angleToTarget = GetAngle(GrapplePoint2.transform.position, Player.transform.position);

            initialDetachment = false;
            CheckIfAttachedCamera = true; //CheckIfAttached shows false negatives sometimes

            if (Player.velocity.magnitude <= maxSpeed && Player.GetComponent<InitialMovement>().GameEND != true)
            {

                switch (Mathf.RoundToInt(seconds)) { // Switch statements don't take floats
                    case 0:
                        maxSpeed = 9f;

                        break;

                    case 1:
                        maxSpeed = 9.5f;
                        break;

                    case 2:
                        maxSpeed = 10.5f;
                        break;

                    case 3:
                        maxSpeed = 11f;
                        break;

                    case 4:
                        maxSpeed = 11.5f;
                        break;

                    case 5:
                        maxSpeed = 12f;
                        break;

                    case 6:
                        maxSpeed = 12.5f;
                        break;

                    case 7:
                        maxSpeed = 13f;
                        break;

                    case 8:
                        maxSpeed = 13.5f;
                        break;
                }

                //Debug.Log(("Max Speed changed to: ") + maxSpeed);


                //Debug.Log("Current Speed: " + (CurrentSpeed = Player.velocity.magnitude));
                ForceMultiplier = maxSpeed - Player.velocity.magnitude;
                Player.AddForce((Player.transform.right * ForceMultiplier), ForceMode2D.Impulse);

            }

     

        } else if(initialDetachment == false && Player.GetComponent<InitialMovement>().GameEND != true && GameStart == true)
        {
            initialDetachment = true;

            Vector3 dir = Quaternion.AngleAxis(angleToTarget, Vector3.forward) * Vector3.right;
            currentForce = force * seconds;
            Player.gravityScale = 2f;
            Player.AddForce(dir * currentForce, ForceMode2D.Impulse);
            seconds = 0f;
            currentForce = 0f;
            timer = 0f;
            SoundFXManager.GetComponent<SoundFX>().PlayerJumpAudio.Play();


        } 
	}
}
