using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager 
{
    int _order = 10;

    Stack<UI_Popup> _popups = new Stack<UI_Popup>();
    UI_Scene _scene = null;

    public GameObject Root
    {
        get
        {
            GameObject root = GameObject.Find("@UI_Root");
            if (root == null)
            {
                root = new GameObject() { name = "@UI_Root" };
            }
            return root;
        }
    }

    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup = Utill.GetOrAddComponet<T>(go);
        _popups.Push(popup);
        go.transform.SetParent(Root.transform);

        return popup;
    }
    public T ShowSceneUI<T>(string name = null) where T : UI_Scene
    {
        if (string.IsNullOrEmpty(name))
        {
            name = typeof(T).Name;
        }

        GameObject go = Managers.Resource.Instantiate($"UI/Scene/{name}");
        T scene = Utill.GetOrAddComponet<T>(go);
        _scene = scene;
        go.transform.SetParent(Root.transform);


        return scene;
    }

    public void SetCanvas(GameObject go, bool sort)
    {
        Canvas canvas = Utill.GetOrAddComponet<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }

    }
    
    public void ClosePopupUI()
    {
        if (_popups.Count == 0)
        {
            return;
        }
        UI_Popup popup = _popups.Pop();
        Managers.Resource.Destory(popup.gameObject);
        _order--;
        popup = null;
    }

    public void ClosePopupUI(UI_Popup popup)
    {
        if (_popups.Count == 0)
        {
            return;
        }

        if (_popups.Peek() == popup)
        {
            ClosePopupUI();
        }
        else
        {
            Debug.Log($"Failed to Close {popup}");
        }
    }

    public void CloseAllPopupUI()
    {
        while (_popups.Count < 0)
        {
            ClosePopupUI();
        }
    }
    
}
