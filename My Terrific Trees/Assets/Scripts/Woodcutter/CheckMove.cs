using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CheckMove : MonoBehaviour
{
    /// <summary>
    /// Shows what is on this 'eye's tile, 0 - nothing here, 1 - tree here, 2 - off the board
    /// </summary>
    //public int whatsHere = 0;

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

    /*public string tellWhichSide()
    {

        return whichSide;
    }*/

    public void resetWhatsHere()
    {
        
        //whatsHere = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Small Tree")) 
        {
            //whatsHere = 1;
        }

        else if (other.gameObject.CompareTag("Big Tree"))
        {
            //whatsHere = 1;
        }

        else if (other.gameObject.CompareTag("Outside")) 
        {
            //whatsHere = 2;
        }
    }
}
