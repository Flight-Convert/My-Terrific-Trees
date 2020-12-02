using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Wolfgang Gross
* Group Project - My Terrific Trees
* Check attached to Woodcutter hitbox to check if on a tree
* --
*/

public class CheckOnTree : MonoBehaviour
{
    public Woodcutter woodCutter; 

    public int outsideCounter = 0;

    AudioSource audioSource;
    public AudioClip chainsawAudio;

    /// <summary>
    /// How many trees a woodcutter has chopped until they level_UP. reset at reaching 2
    /// </summary>
    public int logCount = 0;
    /// <summary>
    /// How many moves a Woodcutter gets each turn, over equivalent rounds
    /// </summary>
    /// 
    public int logCount_UpgradeMax = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        /*if(movementLevel <= 0) //do this where instantiated ref -> movementLevel from (woodcutter)
        {
            movementLevel = 1;
        }*/

        audioSource = GetComponent<AudioSource>();
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
     
        if(logCount >= logCount_UpgradeMax)
        {
            logCount = 0;
            woodCutter.increment_MovementLevel();
            //woodCutter.movementLevel++;
            //movementLevel += 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Woodcutter Stepped on a triggerzone!: " + other.name);

        //if woodcutter directly walks on tree, destroy tree

        if (other.name == "Small Tree(Clone)")
        {

            Destroy(other.gameObject);
            logCount += 1;
            audioSource.PlayOneShot(chainsawAudio, 0.25f);
            GameManager.instance.score -= 2;
        }

        if (other.name == "Big Tree(Clone)")
        {

            Destroy(other.gameObject);
            logCount += 1;
            audioSource.PlayOneShot(chainsawAudio, 0.25f);
            GameManager.instance.score -= 3;
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
