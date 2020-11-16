using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public bool seedPlanted;
    public Text textbox;
    
    // Start is called before the first frame update
    void Start()
    {
        seedPlanted = false;
        textbox.text = "Plant The Seed \nIn the Hole\n\nClick and drag\nto move the seed";
    }

    // Update is called once per frame
    void Update()
    {
        if (seedPlanted == true)
        {
            textbox.text = "Seed Planted! \nCongradulations";
        }
    }
}
