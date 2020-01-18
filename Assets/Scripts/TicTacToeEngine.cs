using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeEngine : MonoBehaviour
{

    protected GameObjectState blank = new Blank();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IAmThinking(GameObject board)
    {
        Debug.Log("I am thinking..beep...bap...boop");
        Debug.Log("AI:"+board.transform.Find("GameObjects").transform.childCount);
        Debug.Log("Enabling sector 3");
        board.transform.Find("GameObjects").transform.GetChild(2).gameObject.GetComponent<SectorSystem>().Place_O();
    }
}
