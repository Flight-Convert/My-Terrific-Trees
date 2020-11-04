using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Co2Meter : MonoBehaviour
{
    public float co2meter = .4f;
    
    void Start()
    {
        Transform bar = transform.Find("Bar");
        bar.localScale = new Vector3(co2meter,1f);
    }

    // Update is called once per frame
    void Update()
    {
        Transform bar = transform.Find("Bar");
        if (co2meter >100)
        {
            co2meter = 100;
        }
        if(co2meter <0)
        {
            co2meter = 0;
        }
        bar.localScale = new Vector3(co2meter, 1f);
    }
}
