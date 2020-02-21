using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected GameObjectState blank= new Blank();
    protected GameObjectState state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetState(GameObjectState state)
    {
        this.state = state;
    }


    public string SetState(GameObjectState state, GameObject gameObject)
    {
        this.state = state;
        StartCoroutine(state.PlaceObject(gameObject));
        return state.ToString();
    }

    public string SetStateBlank(GameObjectState state, GameObject gameObjectX, GameObject gameObjectO)
    {
        this.state = state;
        StartCoroutine(state.RemoveObject(gameObjectX, gameObjectO));
        return state.ToString();
    }

    public virtual GameObjectState GetState()
    {
        return state;
    }
}
