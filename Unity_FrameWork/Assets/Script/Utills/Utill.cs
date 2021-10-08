using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utill 
{
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
    {
        if (go==null)
        {
            return null;
        }

        if (recursive == false)
        {

        }
        else
        {
            foreach (T component in go.GetComponentsInChildren<T>())
            {
                if (string.IsNullOrEmpty(name) || component.name == name)
                {
                    return component;
                }
            }
        }

    }

}
