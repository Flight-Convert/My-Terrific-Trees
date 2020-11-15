using System;
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

        //checkForTrees();
        setCutterCheckOn();


        //If on board and ready to move
        if (!TurnManager.instance.isPlayerTurn)
        {
            //Figure out Movement First
            if (copyMoveIndex == patternListLength)
            {
                copyMoveIndex = 0;
            }

            string whereTo = copyMovePattern[copyMoveIndex];

            

            //If no trees around or one is in the woodcutter's path already
            if (checkForTrees() == false)
            {
                //Check if going offboard
                if (checkMovement(whereTo) != copyMovePattern[copyMoveIndex])
                {
                    if(checkMovement(whereTo) == "Error")
                    {
                        Debug.Log("checkMovement Failed");
                    }
                    else
                    {
                        //change whereTo to new direction shown in method
                        nextMovement = checkMovement(whereTo);
                        doMovement(nextMovement);
                    }                   
                }
                else
                {
                    nextMovement = whereTo;
                    doMovement(nextMovement);
                    copyMoveIndex += 1;
                }
            }
            else //If there is a tree
            {
                doMovement(nextMovement);
            }
            
            nextMovement = " ";
            //resetEyeData();

            //instead, increment enemies done their turn counter
            //if counter == max enemies then reset counter and startTurn
            TurnManager.instance.startTurn();
        }
        else
        {
            //
        }
    }

    public void setTopEyeData(int data)
    {
        topEyeData = data;
    }
    public void setLeftEyeData(int data)
    {
        leftEyeData = data;
    }
    public void setRightEyeData(int data)
    {
        rightEyeData = data;
    }
    public void setBottomEyeData(int data)
    {
        bottomEyeData = data;
    }

    /// <summary>
    /// Turns the Woodcutter's Check to active and enables it's box collider
    /// </summary>
    public void setCutterCheckOn()
    {
        cutterCheck.SetActive(true);

        /*topEye.GetComponent<BoxCollider>().enabled = true;
        leftEye.GetComponent<BoxCollider>().enabled = true;
        rightEye.GetComponent<BoxCollider>().enabled = true;
        bottomEye.GetComponent<BoxCollider>().enabled = true;*/
    }

    /// <summary>
    /// Turns the Woodcutter's Check to inactive and disables it's box collider
    /// </summary>
    public void setCutterCheckOff()
    {
        /*topEye.GetComponent<BoxCollider>().enabled = false;
        leftEye.GetComponent<BoxCollider>().enabled = false;
        rightEye.GetComponent<BoxCollider>().enabled = false;
        bottomEye.GetComponent<BoxCollider>().enabled = false;*/

        cutterCheck.SetActive(false);
    }

    /// <summary>
    /// Returns true if there is a tree around the woodcutter and the woodcutter is not already pathing to it before this method call
    /// </summary>
    /// <returns></returns>
    public bool checkForTrees()
    {
        //resetEyeData();
        setCutterCheckOn();

        //Checks clockwise
        if (topEyeData == 1)
        {
            if(copyMovePattern[copyMoveIndex] != "up")
            {
                Debug.Log("Changing Next direction to up");
                nextMovement = "up";
                setCutterCheckOff();
                return true;
            }
            else
            {
                Debug.Log("Tree in current path");
            }
            setCutterCheckOff();
            return false;
        }
        else if (rightEyeData == 1)
        {
            if (copyMovePattern[copyMoveIndex] != "right")
            {
                Debug.Log("Changing Next direction to right");
                nextMovement = "right";
                setCutterCheckOff();
                return true;
            }
            else
            {
                Debug.Log("Tree in current path");
            }
            setCutterCheckOff();
            return false;
        }
        else if (bottomEyeData == 1)
        {
            if (copyMovePattern[copyMoveIndex] != "down")
            {
                Debug.Log("Changing Next direction to down");
                nextMovement = "down";
                setCutterCheckOff();
                return true;
            }
            else
            {
                Debug.Log("Tree in current path");
            }
            setCutterCheckOff();
            return false;
        }
        else if (leftEyeData == 1)
        {
            if (copyMovePattern[copyMoveIndex] != "left")
            {
                Debug.Log("Changing Next direction to left");
                nextMovement = "left";
                setCutterCheckOff();
                return true;
            }
            else
            {
                Debug.Log("Tree in current path");
            }
            setCutterCheckOff();
            return false;
        }
        else
        {           
            Debug.Log("No Trees around this Woodcutter");
            setCutterCheckOff();
            return false;
        }
        
    }

    /// <summary>
    /// Quick function to reset data of what eyes 'see' 
    /// </summary>
    private void resetEyeData()
    {
        topEyeData = 0;
        leftEyeData = 0;
        rightEyeData = 0;
        bottomEyeData = 0;
    }

    private void doReverseMovement(string lastMovement)
    {
        if (lastMovement == "up")
        {
            cutterRB.transform.position += goDown;
            //previousMovement = lastMovement;
            //nextMovement = "down";
            doMovement("down");
        }
        else if (lastMovement == "left")
        {
            cutterRB.transform.position += goRight;
            //previousMovement = lastMovement;
            //nextMovement = "right";
            doMovement("right");
        }
        else if (lastMovement == "right")
        {
            cutterRB.transform.position += goLeft;
            //previousMovement = lastMovement;
            //nextMovement = "left";
            doMovement("left");
        }
        else if (lastMovement == "down")
        {
            cutterRB.transform.position += goUp;
            //previousMovement = lastMovement;
            //nextMovement = "up";
            doMovement("up");
        }

    }

    // Update with some Debugging features commented out
    void Update()
    {
        //throw away if statement after further logic is introduced
        /*
        if (Input.GetKeyDown("space"))
        {
            //
            cutterCheck.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            //
            cutterCheck.SetActive(false);
        }*/

    }


    /// <summary>
    /// Checks to make sure the player is not walking off the board if they walk in (param) "Direction", returns correct movement
    /// </summary>
    /// <param name="Direction"></param>
    public string checkMovement(string Direction) 
    {
        //resetEyeData();
        setCutterCheckOn();

        //Check Whereto against that direction's 'eye'
        if (Direction == "up")
        {
            //repath if going off board
            if (topEyeData == 2)
            {
                //Check first posible option to move 
                if (leftEyeData != 2)
                {
                    setCutterCheckOff();
                    return "left";
                }
                else if (rightEyeData != 2)
                {
                    setCutterCheckOff();
                    return "right";
                }
                else
                {
                    setCutterCheckOff();
                    return "down";
                }               
            }
            else
            {
                setCutterCheckOff();
                return "up";
            }
            
        }
        else if (Direction == "right")
        {
            //repath if going off board
            if (rightEyeData == 2)
            {
                //Check first posible option to move 
                if (topEyeData != 2)
                {
                    setCutterCheckOff();
                    return "up";
                }
                else if (bottomEyeData != 2)
                {
                    setCutterCheckOff();
                    return "down";
                }
                else
                {
                    setCutterCheckOff();
                    return "left";
                }
            }
            else
            {
                setCutterCheckOff();
                return "right";
            }

        }
        else if (Direction == "left")
        {
            //repath if going off board
            if (leftEyeData == 2)
            {
                //Check first posible option to move 
                if (bottomEyeData != 2)
                {
                    setCutterCheckOff();
                    return "down";
                }
                else if (topEyeData != 2)
                {
                    setCutterCheckOff();
                    return "up";
                }
                else
                {
                    setCutterCheckOff();
                    return "right";
                }
            }
            else
            {
                setCutterCheckOff();
                return "left";
            }

        }
        else if (Direction == "down")
        {
            //repath if going off board
            if (bottomEyeData == 2)
            {
                //Check first posible option to move 
                if (rightEyeData != 2)
                {
                    setCutterCheckOff();
                    return "right";
                }
                else if (leftEyeData != 2)
                {
                    setCutterCheckOff();
                    return "left";
                }
                else
                {
                    setCutterCheckOff();
                    return "up";
                }
            }
            else
            {
                setCutterCheckOff();
                return "down";
            }
        }
        else
        {
            setCutterCheckOff();
            Debug.Log("Direction was not inputed correctly for checkMovement");
            return "Error";
        }
    }


    private void doMovement(string movement)
    {
        currentMovement = movement;
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
