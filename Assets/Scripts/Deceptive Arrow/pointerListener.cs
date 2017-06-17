
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//This is necessary for the arrowClick not to throw error NullReferenceException for trigger.triggers.Add(entryDown);
public class pointerListener : EventTrigger, IPointerDownHandler, IPointerUpHandler
{
    public GameObject wroc;
    
    Vector2 pointerDownPosition;

    public override void OnPointerDown(PointerEventData data)
    {
        wroc.GetComponentInChildren<Text>().text = "lala";
        pointerDownPosition = data.position;
        Debug.Log("OnPointerDownDelegate called.");
    }
    public override void OnPointerUp(PointerEventData data)
    {
        wroc.GetComponentInChildren<Text>().text = "laala";
        pointerDownPosition = data.position;
        Debug.Log("OnPointerDownDelegate called.");
    }
    public override void OnPointerClick(PointerEventData data)
    {
        wroc.GetComponentInChildren<Text>().text = "lasla";
        pointerDownPosition = data.position;
        Debug.Log("OnPointerDownDelegate called.");
    }


}
*/
