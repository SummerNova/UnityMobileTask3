using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Joystick : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler
{
    [SerializeField] Image knob;
    [SerializeField] Image joystickBackground;
    [SerializeField] PlayerController playerController;
    [SerializeField] float joystickLimit = 1;
    
    private Vector2 touchPosition;
    private Vector2 targetposition;


    private void OnValidate()
    {
        if (joystickLimit < 1) joystickLimit = 1;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (CalculateDistance(eventData.position) > joystickLimit)
        {
            targetposition = touchPosition + (eventData.position - touchPosition).normalized*joystickLimit;
        }
        else targetposition = eventData.position;
        transform.position = targetposition;

        playerController.MoveDirection = (targetposition - touchPosition) / joystickLimit;
    }

    private float CalculateDistance(Vector2 position)
    {
        return Vector2.Distance(position, touchPosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        playerController.MoveDirection = Vector2.zero; 
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("ItHappened");
        touchPosition = eventData.position;
        joystickBackground.transform.position = touchPosition;
        transform.position = touchPosition;
        joystickBackground.enabled = true;
        knob.color = new Color(1,1,1,1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        joystickBackground.enabled = false;
        knob.color = new Color(1, 1, 1, 0);
    }

    // Start is called before the first frame update
    
}
