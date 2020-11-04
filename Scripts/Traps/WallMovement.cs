using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour {


    public GameObject Wall;
    public float moveSpeed = 1;

    public Vector3 startPoint;
    public Vector3 endPoint;
    public float endpointdifference = 0f;

    public bool hasreachedendpoint;


    //Two alternatives, either add a start/end gameobject or make the platform move + or - 10 units its start position.


    // Use this for initialization
    void Start()
    {

        startPoint = (Wall.transform.position);

        if (endpointdifference == 0f)
        {
            endPoint = new Vector3(Wall.transform.position.x + 8, Wall.transform.position.y, 0);
        }
        else if (endpointdifference > 0f)
        {
            endPoint = new Vector3(Wall.transform.position.x + endpointdifference, Wall.transform.position.y, 0);
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Wall.transform.position == endPoint)
        {
            hasreachedendpoint = true;
        }
        else if (Wall.transform.position == startPoint)
        {
            hasreachedendpoint = false;
        }

        if (Wall.transform.position != endPoint && hasreachedendpoint == false) //&& GrapplePlatform.transform.position == startPoint)
        {
            Wall.transform.position = Vector3.MoveTowards(Wall.transform.position, endPoint, Time.deltaTime * moveSpeed);
        }
        else if (Wall.transform.position != startPoint)
        {
            Wall.transform.position = Vector3.MoveTowards(Wall.transform.position, startPoint, Time.deltaTime * moveSpeed);
        }



    }
}
