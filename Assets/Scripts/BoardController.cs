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
        //Debug.Log("Winner Found:" + IsThereAWinner());
        //WhoWon();

        //Debug.Log("Available Sectors: " + CountAvailableSectors());
    }

    void DisableAllGameObjects()
    {
        foreach (Transform child in board.transform)
            child.gameObject.SetActive(false);
    }

    void EnableAllGameObjects()
    {
        Debug.Log("Enable All Game Objects function called");
        foreach (Transform child in board.transform)
            child.gameObject.SetActive(true);
    }

    public void ResetBoard()
    {
        foreach (Transform child in board.transform)
        {
            child.gameObject.SetActive(true);
            child.gameObject.GetComponent<SectorSystem>().xObject.SetActive(false);
            child.gameObject.GetComponent<SectorSystem>().oObject.SetActive(false);
        }
           
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
            if (!child.gameObject.GetComponent<SectorSystem>().GetState().Equals(blank))
            {
                count--;
            }
        }
        return count;
    }

    public int[] WhereIsTheWinner()
    {
        int[] noWinner= { };
        int[] winningArray1 = { 0, 1, 2 };
        int[] winningArray2 = { 3, 4, 5 };
        int[] winningArray3 = { 6, 7, 8 };
        int[] winningArray4 = { 0, 3, 6 };
        int[] winningArray5 = { 1, 4, 7 };
        int[] winningArray6 = { 2, 5, 8 };
        int[] winningArray7 = { 0, 4, 8 };
        int[] winningArray8 = { 2, 4, 6 };

        // check rows for X
        if (board.transform.GetChild(winningArray1[0]).GetComponent<SectorSystem>().GetState().Equals(placeX)
            && board.transform.GetChild(winningArray1[1]).GetComponent<SectorSystem>().GetState().Equals(placeX)
            && board.transform.GetChild(winningArray1[2]).GetComponent<SectorSystem>().GetState().Equals(placeX)) { return winningArray1; }

        if (board.transform.GetChild(winningArray2[0]).GetComponent<SectorSystem>().GetState().Equals(placeX)
           && board.transform.GetChild(winningArray2[1]).GetComponent<SectorSystem>().GetState().Equals(placeX)
           && board.transform.GetChild(winningArray2[2]).GetComponent<SectorSystem>().GetState().Equals(placeX)) { return winningArray2; }

        if (board.transform.GetChild(winningArray3[0]).GetComponent<SectorSystem>().GetState().Equals(placeX)
            && board.transform.GetChild(winningArray3[1]).GetComponent<SectorSystem>().GetState().Equals(placeX)
            && board.transform.GetChild(winningArray3[2]).GetComponent<SectorSystem>().GetState().Equals(placeX)) { return winningArray3; }

        if (board.transform.GetChild(winningArray4[0]).GetComponent<SectorSystem>().GetState().Equals(placeX)
            && board.transform.GetChild(winningArray4[1]).GetComponent<SectorSystem>().GetState().Equals(placeX)
            && board.transform.GetChild(winningArray4[2]).GetComponent<SectorSystem>().GetState().Equals(placeX)) { return winningArray4; }

        if (board.transform.GetChild(winningArray5[0]).GetComponent<SectorSystem>().GetState().Equals(placeX)
           && board.transform.GetChild(winningArray5[1]).GetComponent<SectorSystem>().GetState().Equals(placeX)
           && board.transform.GetChild(winningArray5[2]).GetComponent<SectorSystem>().GetState().Equals(placeX)) { return winningArray5; }

        if (board.transform.GetChild(winningArray6[0]).GetComponent<SectorSystem>().GetState().Equals(placeX)
           && board.transform.GetChild(winningArray6[1]).GetComponent<SectorSystem>().GetState().Equals(placeX)
           && board.transform.GetChild(winningArray6[2]).GetComponent<SectorSystem>().GetState().Equals(placeX)) { return winningArray6; }

        if (board.transform.GetChild(winningArray7[0]).GetComponent<SectorSystem>().GetState().Equals(placeX)
          && board.transform.GetChild(winningArray7[1]).GetComponent<SectorSystem>().GetState().Equals(placeX)
          && board.transform.GetChild(winningArray7[2]).GetComponent<SectorSystem>().GetState().Equals(placeX)) { return winningArray7; }

        if (board.transform.GetChild(winningArray8[0]).GetComponent<SectorSystem>().GetState().Equals(placeX)
         && board.transform.GetChild(winningArray8[1]).GetComponent<SectorSystem>().GetState().Equals(placeX)
         && board.transform.GetChild(winningArray8[2]).GetComponent<SectorSystem>().GetState().Equals(placeX)) { return winningArray8; }


        // check rows for O
        if (board.transform.GetChild(winningArray1[0]).GetComponent<SectorSystem>().GetState().Equals(placeO)
           && board.transform.GetChild(winningArray1[1]).GetComponent<SectorSystem>().GetState().Equals(placeO)
           && board.transform.GetChild(winningArray1[2]).GetComponent<SectorSystem>().GetState().Equals(placeO)) { return winningArray1; }

        if (board.transform.GetChild(winningArray2[0]).GetComponent<SectorSystem>().GetState().Equals(placeO)
           && board.transform.GetChild(winningArray2[1]).GetComponent<SectorSystem>().GetState().Equals(placeO)
           && board.transform.GetChild(winningArray2[2]).GetComponent<SectorSystem>().GetState().Equals(placeO)) { return winningArray2; }

        if (board.transform.GetChild(winningArray3[0]).GetComponent<SectorSystem>().GetState().Equals(placeO)
            && board.transform.GetChild(winningArray3[1]).GetComponent<SectorSystem>().GetState().Equals(placeO)
            && board.transform.GetChild(winningArray3[2]).GetComponent<SectorSystem>().GetState().Equals(placeO)) { return winningArray3; }

        if (board.transform.GetChild(winningArray4[0]).GetComponent<SectorSystem>().GetState().Equals(placeO)
            && board.transform.GetChild(winningArray4[1]).GetComponent<SectorSystem>().GetState().Equals(placeO)
            && board.transform.GetChild(winningArray4[2]).GetComponent<SectorSystem>().GetState().Equals(placeO)) { return winningArray4; }

        if (board.transform.GetChild(winningArray5[0]).GetComponent<SectorSystem>().GetState().Equals(placeO)
           && board.transform.GetChild(winningArray5[1]).GetComponent<SectorSystem>().GetState().Equals(placeO)
           && board.transform.GetChild(winningArray5[2]).GetComponent<SectorSystem>().GetState().Equals(placeO)) { return winningArray5; }

        if (board.transform.GetChild(winningArray6[0]).GetComponent<SectorSystem>().GetState().Equals(placeO)
           && board.transform.GetChild(winningArray6[1]).GetComponent<SectorSystem>().GetState().Equals(placeO)
           && board.transform.GetChild(winningArray6[2]).GetComponent<SectorSystem>().GetState().Equals(placeO)) { return winningArray6; }

        if (board.transform.GetChild(winningArray7[0]).GetComponent<SectorSystem>().GetState().Equals(placeO)
          && board.transform.GetChild(winningArray7[1]).GetComponent<SectorSystem>().GetState().Equals(placeO)
          && board.transform.GetChild(winningArray7[2]).GetComponent<SectorSystem>().GetState().Equals(placeO)) { return winningArray7; }

        if (board.transform.GetChild(winningArray8[0]).GetComponent<SectorSystem>().GetState().Equals(placeO)
         && board.transform.GetChild(winningArray8[1]).GetComponent<SectorSystem>().GetState().Equals(placeO)
         && board.transform.GetChild(winningArray8[2]).GetComponent<SectorSystem>().GetState().Equals(placeO)) { return winningArray8; }

        return noWinner;
    }

    public bool IsThereAWinner()
    {
        if (WhereIsTheWinner().Length == 3)
            return true;
        return false;
    }

    public int WhoWon()
    {
        if (IsThereAWinner()) {

            if (board.transform.GetChild(WhereIsTheWinner()[0]).GetComponent<SectorSystem>().GetState().Equals(placeX))
            {
                Debug.Log("Player is the Winner");
                return 1;
            }
            else
            {
                Debug.Log("Computer is the Winner");
                return -1;
            }
        }
        else if(CountAvailableSectors()==0 && !IsThereAWinner())
        {
            Debug.Log("The board is Tied");
            return 0;
        }
        else
        {
            Debug.Log("No Winner Found nor is the board full");
            return 0;
        }
       
    }

    public void TieTheBoard()
    {
        board.transform.GetChild(0).GetComponent<SectorSystem>().Place_X();
        board.transform.GetChild(1).GetComponent<SectorSystem>().Place_O();
        board.transform.GetChild(2).GetComponent<SectorSystem>().Place_X();
        board.transform.GetChild(3).GetComponent<SectorSystem>().Place_O();
        board.transform.GetChild(4).GetComponent<SectorSystem>().Place_X();
        board.transform.GetChild(5).GetComponent<SectorSystem>().Place_O();
        board.transform.GetChild(6).GetComponent<SectorSystem>().Place_O();
        board.transform.GetChild(7).GetComponent<SectorSystem>().Place_X();
        board.transform.GetChild(8).GetComponent<SectorSystem>().Place_O();
    }
}
