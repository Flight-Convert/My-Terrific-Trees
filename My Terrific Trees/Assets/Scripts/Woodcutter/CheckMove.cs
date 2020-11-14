using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CheckMove : MonoBehaviour
{
    /// <summary>
    /// Tells name of Side for check
    /// </summary>
    public string whichSide;

    //Reference the woodcutter class
    public Woodcutter woodcutter;

    // Start is called before the first frame update
    void Start()
    {
        whichSide = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string tellWhichSide()
    {
        return whichSide;
    }

    public void resetWhatsHere()
    {
        woodcutter.topEyeData = 0;
        woodcutter.leftEyeData = 0;
        woodcutter.rightEyeData = 0;
        woodcutter.bottomEyeData = 0;
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Small Tree")) 
        {
            if (whichSide == "top")
            {
                woodcutter.topEyeData = 1;
            }
            else if (whichSide == "left")
            {
                woodcutter.leftEyeData = 1;
            }
            else if (whichSide == "right")
            {
                woodcutter.rightEyeData = 1;
            }
            else if (whichSide == "bottom")
            {
                woodcutter.bottomEyeData = 1;
            }
        }

        else if (other.gameObject.CompareTag("Big Tree"))
        {
            if (whichSide == "top")
            {
                woodcutter.topEyeData = 1;
            }
            else if (whichSide == "left")
            {
                woodcutter.leftEyeData = 1;
            }
            else if (whichSide == "right")
            {
                woodcutter.rightEyeData = 1;
            }
            else if (whichSide == "bottom")
            {
                woodcutter.bottomEyeData = 1;
            }
        }

        else if (other.gameObject.CompareTag("Outside")) 
        {
            if (whichSide == "top")
            {
                woodcutter.topEyeData = 2;
            }
            else if (whichSide == "left")
            {
                woodcutter.leftEyeData = 2;
            }
            else if (whichSide == "right")
            {
                woodcutter.rightEyeData = 2;
            }
            else if (whichSide == "bottom")
            {
                woodcutter.bottomEyeData = 2;
            }
        }
    }
}
