using Assets.Classes.Games;
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

        EventTrigger.Entry entryDown = new EventTrigger.Entry();
        entryDown.eventID = EventTriggerType.PointerDown;
        entryDown.callback.AddListener((data) => { OnPointerDownDelegate((PointerEventData)data); });
        trigger.triggers.Add(entryDown);

        EventTrigger.Entry entryUp = new EventTrigger.Entry();
        entryUp.eventID = EventTriggerType.PointerUp;
        entryUp.callback.AddListener((data) => { OnPointerUpDelegate((PointerEventData)data); });
        trigger.triggers.Add(entryUp);
    }

       
    public void OnPointerDownDelegate(PointerEventData ped)
    {
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), ped.position, ped.pressEventCamera, out pointerDownPosition))
            return;
    }

    public void OnPointerUpDelegate(PointerEventData ped)
    {
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), ped.position, ped.pressEventCamera, out pointerUpPosition))
            return;
        float diffX = pointerUpPosition.x - pointerDownPosition.x;
        float diffY = pointerUpPosition.y - pointerDownPosition.y;
        wroc.GetComponentInChildren<Text>().text = diffX.ToString() + "\n" + diffY.ToString();
        if (moveIsCorrect(diffX, diffY))
        {
            GameObject[] arrows = GameObject.FindGameObjectsWithTag("arrow");
            foreach(GameObject arrow in arrows)
            {
                Destroy(arrow);
            }
            DeceptiveArrow.resetArrows();
            ArrowCreation arrowCreation = new ArrowCreation();
            arrowCreation.createArrow();
        }
    }
    

    private bool moveIsCorrect(float diffX, float diffY)
    {
        if (DeceptiveArrow.arrows[0].direction == Directions.E)
        {
            if ((diffX > 0 && DeceptiveArrow.arrows[0].color == Colors.blue) || (diffX < 0 && DeceptiveArrow.arrows[0].color == Colors.red))
                return true;
        } else if (DeceptiveArrow.arrows[0].direction == Directions.W)
        {
            if ((diffX < 0 && DeceptiveArrow.arrows[0].color == Colors.blue) || (diffX > 0 && DeceptiveArrow.arrows[0].color == Colors.red))
                return true;
        } else if (DeceptiveArrow.arrows[0].direction == Directions.N)
        {
            if ((diffY > 0 && DeceptiveArrow.arrows[0].color == Colors.blue) || (diffX < 0 && DeceptiveArrow.arrows[0].color == Colors.red))
                return true;
        } else
        {
            if((diffY < 0 && DeceptiveArrow.arrows[0].color == Colors.blue) || (diffY > 0 && DeceptiveArrow.arrows[0].color == Colors.red))
                return true;
        }
        return false;
    }
}
