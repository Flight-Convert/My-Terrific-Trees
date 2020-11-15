using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CheckOnTree : MonoBehaviour
{
    public Woodcutter woodCutter;

    public int outsideCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (outsideCounter == 0)
        {
            woodCutter.onBoard = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Woodcutter Stepped on a triggerzone!: " + other.name);
        /*if (other.gameObject.CompareTag("Edge"))
        {
            woodCutter.onBoard = true;
            //onBoard = true;
        }

        if (other.gameObject.CompareTag("Outside"))
        {
            woodCutter.onBoard = false;
            outsideCounter++;
            
        }*/

        //if woodcutter directly walks on tree, destroy tree

        if (other.name == "Small Tree(Clone)")
        {
            Destroy(other.gameObject);
        }

        if (other.name == "Big Tree(Clone)")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Outside"))
        {
            outsideCounter--;
        }
    }
}
