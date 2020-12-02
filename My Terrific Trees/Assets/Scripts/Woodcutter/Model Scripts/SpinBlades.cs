using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBlades : MonoBehaviour
{
    public GameObject sawBladeUpper;
    public GameObject sawBladeLower;

    public float spinSpeedUpper = 8f;
    public float spinSpeedLower = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sawBladeLower.transform.Rotate(0f, -spinSpeedLower,0f);
        sawBladeUpper.transform.Rotate(0f, spinSpeedUpper, 0f);
    }
}
