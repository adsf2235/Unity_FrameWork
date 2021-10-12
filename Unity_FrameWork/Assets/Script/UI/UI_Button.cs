using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
    
    enum Buttons
    {
        PointButton,

    }

    enum Texts
    {
        PointText,
        ScoreText,

    }

    enum Images
    {
        ItemImage,

    }

    


    private void Start()
    {
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        Get<Text>((int)Texts.ScoreText).text = "TEST";
        Bind<Image>(typeof(Images));
        GameObject go = GetImage((int)Images.ItemImage).gameObject;
        UI_DragHandler evt = go.GetComponent<UI_DragHandler>();
        evt.OnDragHandler += ((PointerEventData data) => { go.transform.position = data.position; });
    }



    public void OnClicked()
    {
        Debug.Log("Click!");
    }
}
