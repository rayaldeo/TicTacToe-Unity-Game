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
        SetState(blank);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("This is this sector's location: "+this.location +" and its state: "+this.state);
        state = GetState();
    }
    
    public void Place_X()
    {
        if(GetState() == blank.ToString())
            SetState(placeX, xObject);
    }

    public void Place_O()
    {
        if (GetState()==blank.ToString())
            SetState(placeO, oObject);
    }

    public void Blank()
    {
        SetStateBlank(blank, xObject, oObject);
    }

    public int GetLocation()
    {
        return location;
    }
}
