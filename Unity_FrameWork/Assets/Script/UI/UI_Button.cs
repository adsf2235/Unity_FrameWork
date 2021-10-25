using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    int _score = 0;
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
        Init();
    }

    public override void Init()
    {
        base.Init();

        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));


        GameObject go = GetImage((int)Images.ItemImage).gameObject;
        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; }, Define.UIEvent.Drag);

        GetButton((int)Buttons.PointButton).gameObject.AddUIEvent(OnClicked);
    }


    public void OnClicked(PointerEventData data)
    {
        Debug.Log("Click");
        _score++;
        GetText((int)Texts.ScoreText).text = $"Score :{_score}";
    }
}
