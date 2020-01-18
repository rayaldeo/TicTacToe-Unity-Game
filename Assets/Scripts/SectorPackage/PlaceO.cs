using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaceO : GameObjectState
{
   public override IEnumerator PlaceObject()
    {
        yield break;
    }

    public override IEnumerator PlaceObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield break;
    }

    public override string ToString()
    {
        return "This Sector is O";
    }
}
