using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Dragging : EventTrigger
{
    private bool dragging;
    //public GameObject seed = new GameObject();
    // Update is called once per frame
  
    public void Update()
    {
        if(dragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            
        }
        //if at planting location
        
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}
