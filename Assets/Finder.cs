using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Finder 
{
    public static GameObject RayHitFromScreen(Vector3 hitPosition)
    {
        Ray ray=Convertor.ScreenPointToRay(hitPosition);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit,float.PositiveInfinity,GameManager.Instance.ClickableMask))
        {
            return hit.transform.gameObject;
        } return null;
    }
    public static T RayHitFromScreen<T>(Vector3 hitPosition)
    {
        GameObject go=RayHitFromScreen(hitPosition);
        if(go==null) return default(T);
        object o=go.GetComponent(typeof(T));
        if(o==null) return default(T);
        return (T) Convert.ChangeType(o,typeof(T));
    }
   
}
