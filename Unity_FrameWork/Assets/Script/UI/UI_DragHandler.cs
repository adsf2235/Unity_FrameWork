using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_DragHandler : MonoBehaviour,IDragHandler,IBeginDragHandler
{
   public Action<PointerEventData> OnBeginDragHandler = null;
   public Action<PointerEventData> OnDragHandler = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragHandler != null)
        {
            OnBeginDragHandler.Invoke(eventData);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragHandler != null)
        {
            OnDragHandler.Invoke(eventData);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
