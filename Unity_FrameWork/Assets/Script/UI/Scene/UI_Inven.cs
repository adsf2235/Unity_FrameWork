using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel,

    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(GameObjects));
        GameObject gridpanel = Get<GameObject>((int)GameObjects.GridPanel);

        foreach (Transform child in gridpanel.transform)
        {
            Managers.Resource.Destory(child.gameObject);
        }

        for (int i = 0; i < 8; i++)
        {
            GameObject item = Managers.Resource.Instantiate("UI/Scene/UI_Inven_Item");
            item.transform.SetParent(gridpanel.transform);

        }
    }

    void Start()
    {
        Init();

    }

   
}
