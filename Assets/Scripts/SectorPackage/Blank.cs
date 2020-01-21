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

    public override IEnumerator RemoveObject(GameObject gameObjectX, GameObject gameObjectO)
    {
        gameObjectX.SetActive(false);
        gameObjectO.SetActive(false);
        yield break;
    }
}
