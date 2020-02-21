using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameObjectState
{
        
    public virtual IEnumerator PlaceObject()
    {
        yield break;
    }

    public virtual IEnumerator PlaceObject(GameObject gameObject)
    {
        yield break;
    }

    public virtual IEnumerator RemoveObject()
    {
        yield break;
    }

    public virtual IEnumerator RemoveObject(GameObject gameObjectX, GameObject gameObjectO)
    {
        yield break;
    }

    public abstract string ToString();

    public virtual bool PlayerTurnFinish()
    {
        return true;
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() == this.GetType())
            return true;
        return false;   
    }



}
