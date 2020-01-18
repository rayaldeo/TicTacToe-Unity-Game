using UnityEngine;
using System.Collections;

public class SectorSystem : StateMachine
 {

    public GameObjectState placeX = new PlaceX();
    public GameObjectState placeO = new PlaceO();

    public GameObject xObject;
    public GameObject oObject;

    public int location;

    string state = "Blank";

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("This is this sector's location: "+this.location +" and its state: "+this.state);
    }
    
    public void Place_X()
    {
        state=SetState(placeX, xObject);
    }

    public void Place_O()
    {
        state=SetState(placeO, oObject);
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
