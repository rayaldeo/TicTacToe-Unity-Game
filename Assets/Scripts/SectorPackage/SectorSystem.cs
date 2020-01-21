using UnityEngine;
using System.Collections;

public class SectorSystem : StateMachine
 {

    GameObjectState placeX = new PlaceX();
    GameObjectState placeO = new PlaceO();
    GameObjectState blank = new Blank();

    public GameObject xObject;
    public GameObject oObject;

    public int location;

    public string state ="";

    // Start is called before the first frame update
    void Start()
    {
        state = blank.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("This is this sector's location: "+this.location +" and its state: "+this.state);
    }
    
    public void Place_X()
    {
        if(state== blank.ToString())
            state=SetState(placeX, xObject);
    }

    public void Place_O()
    {
        if (state == blank.ToString())
            state =SetState(placeO, oObject);
    }

    public void Blank()
    {
        state = SetStateBlank(blank, xObject, oObject);
    }

    public override string GetState()
    {
        return state;
    }

    public int GetLocation()
    {
        return location;
    }
}
