using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class arrowClick : MonoBehaviour  {

    Vector2 pointerDownPosition;
    Vector2 pointerUpPosition;
    public GameObject wroc;
    public GameObject triggerButton;

    // Use this for initialization
    void Start () {
        EventTrigger trigger = triggerButton.gameObject.AddComponent<EventTrigger>();
        //EventTrigger trigger = GetComponent<EventTrigger>();

        EventTrigger.Entry entryDown = new EventTrigger.Entry();
        entryDown.eventID = EventTriggerType.PointerDown;
        entryDown.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entryDown);

        EventTrigger.Entry entryUp = new EventTrigger.Entry();
        entryUp.eventID = EventTriggerType.PointerUp;
        entryUp.callback.AddListener((data) => { OnPointerUpDelegate((PointerEventData)data); });
        trigger.triggers.Add(entryUp);
    }

    public void OnPointerUpDelegate(PointerEventData data)
    {
        pointerUpPosition = data.position;
        Debug.Log("OnPointerDownDelegate called.");
        //wroc.GetComponentInChildren<Text>().text = "lala";
        wroc.GetComponentInChildren<Text>().text = pointerUpPosition.x.ToString();
    }
    
    public void OnPointerDownDelegate(PointerEventData data)
    {
        //wroc.GetComponentInChildren<Text>().text = "iksde";
        wroc.GetComponentInChildren<Text>().text = pointerDownPosition.x.ToString();
        pointerDownPosition = data.position;
        Debug.Log("OnPointerDownDelegate called.");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
