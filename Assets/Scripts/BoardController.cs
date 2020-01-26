using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public GameObject board;
    protected GameObjectState blank = new Blank();
    protected GameObjectState placeX = new PlaceX();
    protected GameObjectState placeO = new PlaceO();


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

        Debug.Log("Winner Found:" + whereIsTheWinner());
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

    public bool whereIsTheWinner()
    {
        int[] winningArray1 = { 0, 1, 2 };
        int[] winningArray2 = { 3, 4, 5 };
        int[] winningArray3 = { 6, 7, 8 };
        int[] winningArray4 = { 0, 3, 6 };
        int[] winningArray5 = { 1, 4, 7 };
        int[] winningArray6 = { 2, 5, 8 };
        int[] winningArray7 = { 0, 4, 8 };
        int[] winningArray8 = { 2, 4, 6 };

        // check rows
        if (board.transform.GetChild(winningArray1[0]).GetComponent<SectorSystem>().GetState() == (placeX.ToString()) 
            && board.transform.GetChild(winningArray1[1]).GetComponent<SectorSystem>().GetState() == (placeX.ToString())
            && board.transform.GetChild(winningArray1[2]).GetComponent<SectorSystem>().GetState() == (placeX.ToString())) { return true; }

        if (board.transform.GetChild(winningArray2[0]).GetComponent<SectorSystem>().GetState() == (placeX.ToString())
           && board.transform.GetChild(winningArray2[1]).GetComponent<SectorSystem>().GetState() == (placeX.ToString())
           && board.transform.GetChild(winningArray2[2]).GetComponent<SectorSystem>().GetState() == (placeX.ToString())) { return true; }

        if (board.transform.GetChild(winningArray3[0]).GetComponent<SectorSystem>().GetState() == (placeX.ToString())
          && board.transform.GetChild(winningArray3[1]).GetComponent<SectorSystem>().GetState() == (placeX.ToString())
          && board.transform.GetChild(winningArray3[2]).GetComponent<SectorSystem>().GetState() == (placeX.ToString())) { return true; }
        //if (board[1, 0] == player && board[1, 1] == player && board[1, 2] == player) { return true; }
        //if (board[2, 0] == player && board[2, 1] == player && board[2, 2] == player) { return true; }

        //// check columns
        //if (board[0, 0] == player && board[1, 0] == player && board[2, 0] == player) { return true; }
        //if (board[0, 1] == player && board[1, 1] == player && board[2, 1] == player) { return true; }
        //if (board[0, 2] == player && board[1, 2] == player && board[2, 2] == player) { return true; }

        //// check diags
        //if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) { return true; }
        //if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player) { return true; }

        return false;
    }
}
