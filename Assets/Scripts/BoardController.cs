using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public GameObject board;
    protected GameObjectState blank = new Blank();

    // Start is called before the first frame update
    void Start()
    {
        //enableAllGameObjects();
        //resetBoard();
    }

    // Update is called once per frame
    void Update()
    {

        if (BoardIsNotFull())
        {
            Debug.Log("Board Controller has been started");
        }
        //foreach (Transform child in board.transform)
        //{
        //    while (child.gameObject.GetComponent<SectorSystem>().GetState().equals(blank.GetString()))
        //    {
        //        Debug.Log("This is this sector's location: " + child.gameObject.GetComponent<SectorSystem>().GetLocation() + " and its state: " + child.gameObject.GetComponent<SectorSystem>().GetState());
        //    }
        //}
        //Debug.Log("Game has been started");
    }

    void disableAllGameObjects()
    {
        foreach (Transform child in board.transform)
            child.gameObject.SetActive(false);
    }

    void enableAllGameObjects()
    {
        Debug.Log("Enable All Game Objects function called");
        foreach (Transform child in board.transform)
            child.gameObject.SetActive(true);
    }

    public void resetBoard()
    {
        foreach (Transform child in board.transform)
        {
            child.gameObject.SetActive(true);
            child.gameObject.GetComponent<SectorSystem>().xObject.SetActive(false);
            child.gameObject.GetComponent<SectorSystem>().oObject.SetActive(false);
        }
           
    }

    public bool BoardIsNotFull()
    {
        return true;
        //foreach (Transform child in board.transform)
        //{
        //    if (!child.gameObject.GetComponent<SectorSystem>().GetState().equals(blank.GetString()))
        //    {
        //        Debug.Log("This is this sector's location: " + child.gameObject.GetComponent<SectorSystem>().GetLocation() + " and its state: " + child.gameObject.GetComponent<SectorSystem>().GetState());
        //    }
        //}
    }

    public void DisableBoardForPlayer()
    {
        foreach (Transform child in board.transform)
            child.gameObject.transform.Find("Canvas").gameObject.SetActive(false);
    }

    public void EnableBoardForPlayer()
    {
        foreach (Transform child in board.transform)
            child.gameObject.transform.Find("Canvas").gameObject.SetActive(true);
    }

    public int CountAvailableSectors()
    {
        int count = board.transform.childCount;
        foreach (Transform child in board.transform)
        {
            if (!child.gameObject.GetComponent<SectorSystem>().GetState().Equals(blank.ToString()))
            {
                count--;
            }
        }
        return count;
    }
}
