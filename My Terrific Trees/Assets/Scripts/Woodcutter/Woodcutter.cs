﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Wolfgang Gross
* Assignment 7
* Behavior for Woodcutter enemy
* --
*/

public class Woodcutter : MonoBehaviour
{
    //Set this from the inspector
    public string[] movePatternList; //Don't affect this list, use copy to manipulate vvv
    public string[] copyMovePattern;// Affect ME
    public int copyMoveIndex = 0; //Where in list we are
    private int patternListLength;

    //public bool readyToMove = false;

    public Rigidbody cutterRB;
    //public Rigidbody checkRB;

    public string initialMovement;
    public string currentMovement;
    public string previousMovement;
    public string nextMovement = "";

    public string goingDirection;

    public bool onBoard = false;

    private Vector3 goUp = new Vector3(0, 0, 1);
    private Vector3 goDown = new Vector3(0, 0, -1);
    private Vector3 goLeft = new Vector3(-1, 0, 0);
    private Vector3 goRight = new Vector3(1, 0, 0);

    public GameObject topEye;
    public GameObject leftEye;
    public GameObject rightEye;
    public GameObject bottomEye;

    CheckMove checkMoveUp;
    CheckMove checkMoveLeft;
    CheckMove checkMoveRight;
    CheckMove checkMoveDown;

    // Shows what is on this 'eye's tile, 0 - nothing here, 1 - tree here, 2 - off the board
    /// <summary>
    /// Variable updated each turn that gets data of whats at Top Triggerzone of Woodcutter Check
    /// </summary>
    public int topEyeData = 0;
    /// <summary>
    /// Variable updated each turn that gets data of whats at Left Triggerzone of Woodcutter Check
    /// </summary>
    public int leftEyeData = 0;
    /// <summary>
    /// Variable updated each turn that gets data of whats at Right Triggerzone of Woodcutter Check
    /// </summary>
    public int rightEyeData = 0;
    /// <summary>
    /// Variable updated each turn that gets data of whats at Bottom Triggerzone of Woodcutter Check
    /// </summary>
    public int bottomEyeData = 0;    

    public Vector3 currentLocation;

    public GameObject cutterCheck;

    // Start is called before the first frame update
    void Start()
    {
        copyMovePattern = movePatternList;
        patternListLength = movePatternList.Length;
    }

    private void FixedUpdate()
    {
        //*Debug Display of what the eye check is seeing
        Debug.Log("TopEye: " + topEyeData);
        Debug.Log("LeftEye: " + leftEyeData);
        Debug.Log("RightEye: " + rightEyeData);
        Debug.Log("BottomEye: " + bottomEyeData);

        //If not On board, reverse last action
        if (!onBoard)
        {
            //Do reverse of last move made to get offboard
            doReverseMovement(previousMovement); 
        }

        //If on board and ready to move
        if (!TurnManager.instance.isPlayerTurn)
        {
            //Figure out Movement First
            if (copyMoveIndex == patternListLength)
            {
                copyMoveIndex = 0;
            }

            string whereTo = copyMovePattern[copyMoveIndex];
            
            checkMovement(whereTo);
            
            if(nextMovement != "")
            {
                doMovement(nextMovement);
            }
            else
            {
                doMovement(goingDirection);
            }
            nextMovement = "";
            TurnManager.instance.startTurn();

        }
        else
        {
            //
        }
    }

    private void doReverseMovement(string lastMovement)
    {
        if (lastMovement == "up")
        {
            cutterRB.transform.position += goDown;
            previousMovement = lastMovement;
            currentMovement = "down";
        }
        if (lastMovement == "left")
        {
            cutterRB.transform.position += goRight;
            previousMovement = lastMovement;
            currentMovement = "right";
        }
        if (lastMovement == "right")
        {
            cutterRB.transform.position += goLeft;
            previousMovement = lastMovement;
            currentMovement = "left";
        }
        if (lastMovement == "down")
        {
            cutterRB.transform.position += goUp;
            previousMovement = lastMovement;
            currentMovement = "up";
        }

    }

    // Update with some Debugging features commented out
    void Update()
    {
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


    //Main logic behind movement behavior
    public void checkMovement(string Direction) 
    {
        cutterCheck.SetActive(true);

        topEye.GetComponent<BoxCollider>().enabled = true;
        leftEye.GetComponent<BoxCollider>().enabled = true;
        rightEye.GetComponent<BoxCollider>().enabled = true;
        bottomEye.GetComponent<BoxCollider>().enabled = true;
 
        //Check Whereto against that direction's 'eye'
        if (Direction == "up")
        {
            //check topEye's WhatsHere within CheckMove, 1 = Tree
            if(topEyeData == 1)
            {
                nextMovement = "up";
                copyMoveIndex += 1;
            }
            else if(leftEyeData == 1)
            {
                nextMovement = "left";
            }
            else if (rightEyeData == 1)
            {
                nextMovement = "right";
            }
            //repath if going off board
            else if (topEyeData == 2)
            {
                //Check first posible option to move 
                if (leftEyeData != 2)
                {
                    nextMovement = "left";
                }
                else if (rightEyeData != 2)
                {
                    nextMovement = "right";
                }
                else
                {
                    //Should never get here
                    nextMovement = "down";
                }
                copyMoveIndex += 1;
            }
            else
            {
                nextMovement = Direction;
                copyMoveIndex += 1;
            }
            
        }
        else if (Direction == "left")
        {
            //check leftEye's WhatsHere within CheckMove
            if (leftEyeData == 1)
            {
                nextMovement = "left";
                copyMoveIndex += 1;
            }
            else if (bottomEyeData == 1)
            {
                nextMovement = "down";
            }
            else if (topEyeData == 1)
            {
                nextMovement = "up";
            }
            //repath if going off board
            else if (leftEyeData == 2)
            {
                //Check first posible option to move 
                if (bottomEyeData != 2)
                {
                    nextMovement = "down";
                }
                else if (topEyeData != 2)
                {
                    nextMovement = "up";
                }
                else
                {
                    //Should never get here
                    nextMovement = "right";

                }
                copyMoveIndex += 1;
            }
            else
            {
                nextMovement = Direction;
                copyMoveIndex += 1;
            }

        }
        else if(Direction == "right")
        {
            //check rightEye's WhatsHere within CheckMove
            if (rightEyeData == 1)
            {
                nextMovement = "right";
                copyMoveIndex += 1;
            }
            else if (topEyeData == 1)
            {
                nextMovement = "up";
            }
            else if (bottomEyeData == 1)
            {
                nextMovement = "down";
            }
            //repath if going off board
            else if (rightEyeData == 2)
            {
                //Check first posible option to move 
                if (topEyeData != 2)
                {
                    nextMovement = "up";
                }
                else if (bottomEyeData != 2)
                {
                    nextMovement = "down";
                }
                else
                {
                    //Should never get here
                    nextMovement = "left";
                }
                copyMoveIndex += 1;
            }
            else
            {
                nextMovement = Direction;
                copyMoveIndex += 1;
            }

        }
        else if (Direction == "down")
        {
            //check bottomEye's WhatsHere within CheckMove
            if (bottomEyeData == 1)  
            {
                goingDirection = "down";
                copyMoveIndex += 1;
            }
            else if (rightEyeData == 1)
            {
                nextMovement = "right";
            }
            else if (leftEyeData == 1)
            {
                nextMovement = "left";
            }
            //repath if going off board
            else if (bottomEyeData == 2)
            {
                //Check first posible option to move 
                if (rightEyeData != 2)
                {
                    nextMovement = "right";
                }
                else if (leftEyeData != 2)
                {
                    nextMovement = "left";
                }
                else
                {
                    //Should never get here
                    nextMovement = "up";
                }
                copyMoveIndex += 1;
            }
            else
            {
                nextMovement = Direction;
                copyMoveIndex += 1;
            }

        }

        topEyeData = 0;
        leftEyeData = 0;
        rightEyeData = 0;
        bottomEyeData = 0;

        topEye.GetComponent<BoxCollider>().enabled = false;
        leftEye.GetComponent<BoxCollider>().enabled = false;
        rightEye.GetComponent<BoxCollider>().enabled = false;
        bottomEye.GetComponent<BoxCollider>().enabled = false;

        cutterCheck.SetActive(false);
    }


    private void doMovement(string movement)
    {
        if (movement == "auto")
        {
            //unimplemented - may use in future
            //readyToMove = false;
        }
        else
        {

            if (movement == "up")
            {
                cutterRB.transform.position += goUp;
                previousMovement = currentMovement;
                currentMovement = "up";
                
            }
            else if (movement == "down")
            {
                cutterRB.transform.position += goDown;
                previousMovement = currentMovement;
                currentMovement = "down";
                
            }
            else if (movement == "left")
            {
                cutterRB.transform.position += goLeft;
                previousMovement = currentMovement;
                currentMovement = "left";
                
            }
            else if (movement == "right")
            { 
                cutterRB.transform.position += goRight;
                previousMovement = currentMovement;
                currentMovement = "right";

            }
        }
    }
}
