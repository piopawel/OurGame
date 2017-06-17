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
    Camera camera;

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

        camera = GetComponent<Camera>();
    }

    public void OnPointerUpDelegate(PointerEventData ped)
    {

        Vector2 localCursor;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), ped.position, ped.pressEventCamera, out localCursor))
            return;
        //pointerUpPosition = data.position.normalized;
        Debug.Log("OnPointerDownDelegate called.");
        //wroc.GetComponentInChildren<Text>().text = "lala";
        //wroc.GetComponentInChildren<Text>().text = pointerUpPosition.x.ToString();
        wroc.GetComponentInChildren<Text>().text = localCursor.x.ToString() + " aaa \n" + localCursor.y.ToString();
    }
    
    public void OnPointerDownDelegate(PointerEventData ped)
    {
        /*
        Vector3 position = Input.mousePosition;
        //wroc.GetComponentInChildren<Text>().text = "iksde";
        pointerDownPosition = data.position.normalized;
        //wroc.GetComponentInChildren<Text>().text = pointerDownPosition.x.ToString();
        wroc.GetComponentInChildren<Text>().text = position.x.ToString();
        Debug.Log("OnPointerDownDelegate called.");
        */
        Vector2 localCursor;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), ped.position, ped.pressEventCamera, out localCursor))
            return;
        //pointerUpPosition = data.position.normalized;
        Debug.Log("OnPointerDownDelegate called.");
        //wroc.GetComponentInChildren<Text>().text = "lala";
        //wroc.GetComponentInChildren<Text>().text = pointerUpPosition.x.ToString();
        wroc.GetComponentInChildren<Text>().text = localCursor.x.ToString() + " aaa \n" +localCursor.y.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
