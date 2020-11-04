using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour {

    public GameObject RopeLink;
    public GameObject RopeLinkLong;
    public GameObject Player;
    public GameObject AttachmentPoint;
    public GameObject GrapplePointObject;
    public GameObject PauseManager;
    public GameObject PauseButton;
    public GameObject GrappleCount;

    public Rigidbody2D GrapplePoint;
    public Rigidbody2D previousRB;

    public bool CheckIfAttached;
    public bool TimeStopped;

    public int links = 1;
    public int numberofpoints = 1;

    public float distance = 2;
    public float NumberOfGrapples = 0f;

    public Vector3 AvailableGrapleRadius = new Vector3(5f, 5f, 0);
    public Bounds area;



    // Use this for initialization
    void Start () {
        area = new Bounds(GrapplePoint.transform.position, AvailableGrapleRadius);
        GrappleCount = GameObject.Find("GrappleCount");
        CheckIfAttached = false;

	}

     void GenerateRope ()
     {

        HingeJoint2D hinge = Player.GetComponent<HingeJoint2D>();
        hinge.enabled = true;
        Rigidbody2D previousRB = AttachmentPoint.GetComponent<Rigidbody2D>();

        for (int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(RopeLink, transform.position, Quaternion.identity);
            link.gameObject.tag = "Rope";
            link.transform.SetParent(AttachmentPoint.transform);

            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;
            previousRB = link.GetComponent<Rigidbody2D>();

            if (i == (links - 1))
            {
                hinge.connectedBody = previousRB;
            }
        }
     }

    void MissleTest()
    {
        Time.timeScale = 1.0f;
        GrappleCount.GetComponent<GrappleCounter>().NumberOfGrapples += 1;
        CheckIfAttached = true;
        HingeJoint2D hinge = Player.GetComponent<HingeJoint2D>();
        hinge.enabled = true;
        Rigidbody2D previousRB = AttachmentPoint.GetComponent<Rigidbody2D>();
        hinge.connectedBody = previousRB;

        JointMotor2D motor = hinge.motor;
        motor.motorSpeed = 100f;
        hinge.motor = motor;

    }

    void GenerateRopeLine()
    {
        Vector3[] positionArray = new[] { AttachmentPoint.transform.position, Player.transform.position };
        for (int i = 0; i < numberofpoints; i++)
        {
            Player.GetComponent<LineRenderer>().SetPosition(i, positionArray[i]);
        }
    }

    void ReattachPlayer()
    {
        if (Input.GetMouseButtonDown(0) && (Player.GetComponent<HingeJoint2D>().enabled == false)) 
        {


            if (area.Contains(Player.transform.position)) 
            {
                AttachmentPoint = FindClosestGraple();
                Debug.Log("Graple Point - " + AttachmentPoint.name);
                CheckIfAttached = true;
                MissleTest();

            }
        }
    }

    void DeattachPlayer()
    {
        if (Input.GetMouseButtonUp(0))
        {
            HingeJoint2D hinge = Player.GetComponent<HingeJoint2D>();
            Player.GetComponent<Rigidbody2D>().gravityScale = 1f;
            hinge.enabled = false;
            CheckIfAttached = false;
        }
    }

    void DestroyRope()
    {
        var RopeClones = GameObject.FindGameObjectsWithTag("Rope");
        foreach(GameObject rope in RopeClones){
            GameObject.Destroy(rope);
        }
    }

    public GameObject FindClosestGraple()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("GrapplePoint");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector2 position = Vector3Convert(Player.transform.position);
        foreach (GameObject go in gos)
        {
            Vector2 diff = Vector3Convert(go.transform.position) - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    public Vector2 Vector3Convert(Vector3 toconvert)
    {
        Vector2 converted = new Vector2(toconvert.x, toconvert.y);
        return converted;
    }

    // Update is called once per frame
    void Update()
    {

        if (CheckIfAttached == false && Player != null && Player.GetComponent<InitialMovement>().GameEND != true && Player.GetComponent<InitialMovement>().GameStart == true && TimeStopped == false && PauseManager.GetComponent<OptionsMenu>().TimePaused == false)
        {
            ReattachPlayer();
        }
        else if (CheckIfAttached == true && Player != null && Player.GetComponent<InitialMovement>().GameEND != true && Player.GetComponent<InitialMovement>().GameStart == true) //&& PauseManager.GetComponent<OptionsMenu>().TimePaused == false)
        {
            DeattachPlayer();
        }
    }
}
