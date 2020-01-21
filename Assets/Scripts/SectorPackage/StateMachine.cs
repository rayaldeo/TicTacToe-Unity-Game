using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected GameObjectState blank= new Blank();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public string SetState(GameObjectState state, GameObject gameObject)
    {
        //State = state;
        StartCoroutine(state.PlaceObject(gameObject));
        return state.ToString();
    }

    public string SetStateBlank(GameObjectState state, GameObject gameObjectX, GameObject gameObjectO)
    {
        //State = state;
        StartCoroutine(state.RemoveObject(gameObjectX, gameObjectO));
        return state.ToString();
    }

    public virtual string GetState()
    {
        return blank.ToString();
    }
}
