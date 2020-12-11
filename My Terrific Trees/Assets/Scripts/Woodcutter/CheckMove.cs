using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Wolfgang Gross
* Group Project - My Terrific Trees
* Checks attached to 'Eye's of Woodcutter
* --
*/

public class CheckMove : MonoBehaviour
{
    /// <summary>
    /// Tells name of Side for check
    /// </summary>
    public string whichSide;

    //Reference the woodcutter class
    public Woodcutter woodcutter;

    public string whatsHere;

    public bool inATriggerZone = false;

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

    /*public void resetWhatsHere()
    {
        woodcutter.topEyeData = 0;
        woodcutter.leftEyeData = 0;
        woodcutter.rightEyeData = 0;
        woodcutter.bottomEyeData = 0;
    }*/

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Eye '" + whichSide + "' hit a triggerzone!: " + other.name);

        if (other.name == "Small Tree(Clone)")
        {
            //Debug.Log("Eye '" + whichSide + "' hit a triggerzone!: " + other.name);
            if (whichSide == "Eye Up")
            {
                whatsHere = "tree";
                woodcutter.setTopEyeData(1);
            }
            else if (whichSide == "Eye Left")
            {
                whatsHere = "tree";
                woodcutter.setLeftEyeData(1);
            }
            else if (whichSide == "Eye Right")
            {
                whatsHere = "tree";
                woodcutter.setRightEyeData(1);
            }
            else if (whichSide == "Eye Down")
            {
                whatsHere = "tree";
                woodcutter.setBottomEyeData(1);
            }
        }
        if (other.name == "Big Tree(Clone)")
        {
            //Debug.Log("Eye '" + whichSide + "' hit a triggerzone!: " + other.name);
            if (whichSide == "Eye Up")
            {
                whatsHere = "tree";
                woodcutter.setTopEyeData(1);
            }
            else if (whichSide == "Eye Left")
            {
                whatsHere = "tree";
                woodcutter.setLeftEyeData(1);
            }
            else if (whichSide == "Eye Right")
            {
                whatsHere = "tree";
                woodcutter.setRightEyeData(1);
            }
            else if (whichSide == "Eye Down")
            {
                whatsHere = "tree";
                woodcutter.setBottomEyeData(1);
            }
        }

        else if (other.name == "Outer Edge" || other.name == "Block")
        {
            //Debug.Log("Eye '" + whichSide + "' hit a triggerzone!: " + other.name);
            if (whichSide == "Eye Up")
            {
                whatsHere = "OffBoard";
                woodcutter.setTopEyeData(2);
            }
            else if (whichSide == "Eye Left")
            {
                whatsHere = "OffBoard";
                woodcutter.setLeftEyeData(2);
            }
            else if (whichSide == "Eye Right")
            {
                whatsHere = "OffBoard";
                woodcutter.setRightEyeData(2);
            }
            else if (whichSide == "Eye Down")
            {
                whatsHere = "OffBoard";
                woodcutter.setBottomEyeData(2);
            }
        }
    }
}
