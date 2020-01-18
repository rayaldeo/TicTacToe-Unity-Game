using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaceX : GameObjectState
{

   public override IEnumerator PlaceObject()
    {
        Debug.Log("This State was Called Yay!!");
        yield break;
    }

    public override IEnumerator PlaceObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield break;
    }

    
    public override string ToString()
    {
        return "This Sector is X";
    }
}
