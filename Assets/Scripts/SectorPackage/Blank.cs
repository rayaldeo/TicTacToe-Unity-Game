using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blank : GameObjectState
{
    public override IEnumerator PlaceObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield break;
    }

    public override string ToString()
    {
        return "Blank";
    }
}
