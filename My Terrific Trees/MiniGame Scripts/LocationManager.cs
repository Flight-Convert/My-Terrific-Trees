using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    public GameObject seed;
    public GameObject dirtPile;
    public TextManager textManagerScript;
    // Start is called before the first frame update
    void Start()
    {
       textManagerScript = GameObject.FindGameObjectWithTag("TextManager").GetComponent<TextManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (seed.transform.position.x > -50 && seed.transform.position.x < 50 && seed.transform.position.y > -12 && seed.transform.position.y < 20)
        
        if(seed.transform.position.x > 550)
        {
            //seed.SetActive(false);
           // WaitForSeconds(5f);
        }
        else
        {
            seed.SetActive(false);
            Debug.Log("Seed X position: " + seed.transform.position.x);
            dirtPile.SetActive(true);
            textManagerScript.seedPlanted = true;
        }
    }
}
