using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woodcutter : MonoBehaviour
{
    public bool readyToMove = false;

    public Rigidbody cutterRB;

    public string initialMovement;
    public string currentMovement;

    public bool onBoard = false;

    private Vector3 goUp = new Vector3(0, 0, 1);
    private Vector3 goDown = new Vector3(0, 0, -1);
    private Vector3 goLeft = new Vector3(-1, 0, 0);
    private Vector3 goRight = new Vector3(1, 0, 0);

    public bool goingUp = false;
    public bool goingDown = false;
    public bool goingLeft = false;
    public bool goingRight = false;

    public Vector3 currentLocation;

    public GameObject cutterCheck;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If not On board, get there
        if (!onBoard)
        {
            doMovement(initialMovement); //loops initial movement until on board
            //use "up", "down", "left", "right"
        }

        //update bools of "going"
        //updateGoing();



        //If on board and ready to move
        else if (readyToMove)
        {
            cutterCheck.SetActive(true);

            //Check for saplings at eye locations
            //CheckforTree()

            //if treeInSight = true
            //set currentMovement = direciton of tree for next line where move

            //Do movement forward check
            //MovementCheckForward(currentMovement);

            //goFowards
            //doMovement("auto");

        }
        else
        {
            //
        }

        //throw away if statement after further logic is introduced

        if (Input.GetKeyDown("space"))
        {
            //
            cutterCheck.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //
            cutterCheck.SetActive(false);
        }

    }

    /*private void updateGoing()
    {
        //throw new NotImplementedException();
        if (currentMovement == "up")
        {
            goingDown = false;
            goingLeft = false;
            goingRight = false;

            goingUp = true;
        }
        if (currentMovement == "left")
        {
            goingDown = false;
            goingRight = false;
            goingUp = false;
            
            goingLeft = true;
        }
        if (currentMovement == "down")
        {
            goingUp = false;
            goingLeft = false;
            goingRight = false;

            goingDown = true;
        }
        if (currentMovement == "right")
        {
            goingDown = false;
            goingLeft = false;
            goingUp = false;

            goingRight = false;            
        }
    }*/

    /*private void MovementCheckForward(string currentDirection)
    {
        //throw new NotImplementedException();
        if (currentDirection == "up")
        { 
            //reference to upcheck
            private GameObject upCheck = 
            //check if upcheck is available to move to (not outside)
            if()
            {

            }

        }
        else if (currentDirection == "left")
        {
            //reference to leftcheck

            //check if leftcheck is available to move to (not outside)
            if ()
            {

            }
        }
        else if (currentDirection == "down")
        {
            //reference to downcheck

            //check if downcheck is available to move to (not outside)
            if ()
            {

            }
        }
        else if (currentDirection == "right")
        {
            //reference to rightcheck

            //check if rightcheck is available to move to (not outside)
            if ()
            {

            }
        }

    }*/

    private void doMovement(string movement)
    {
        if (movement == "auto")
        {
            readyToMove = false;

            if (goingUp)
            {
                
                cutterRB.transform.position += goUp;
            }
            else if (goingDown)
            {
                cutterRB.transform.position += goDown;
            }
            else if (goingLeft)
            {
                cutterRB.transform.position += goLeft;
            }
            else if (goingRight)
            {
                cutterRB.transform.position += goRight;
            }
        }
        else
        {

            if (movement == "up")
            {
                cutterRB.transform.position += goUp;
                currentMovement = "up";
                
            }
            else if (movement == "down")
            {
                cutterRB.transform.position += goDown;
                currentMovement = "down";
                
            }
            else if (movement == "left")
            {
                cutterRB.transform.position += goLeft;
                currentMovement = "left";
                
            }
            else if (movement == "right")
            { 
                cutterRB.transform.position += goRight;
                currentMovement = "right";

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Edge"))
        {
            onBoard = true;
        }

        //if woodcutter directly walks on tree, destroy tree
        if (other.gameObject.CompareTag("Tree"))
        {
            Destroy(other.gameObject);
        }
    }

    //Changes direction in cclockwise order, for when 
    public void cclockwiseDirectionChange()
    {
        //
    }
}
