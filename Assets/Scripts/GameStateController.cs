using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour 
{

    public GameObject board;
    public GameObject canvas;
    public enum BattleState { EMPTY,PLAYERTURN, ENEMYTURN }
    public BattleState state=BattleState.EMPTY;
    TicTacToeEngine ttte;

    private int boardObjectCount;

    // Start is called before the first frame update
    void Start()
    {
        ttte = new TicTacToeEngine();
        boardObjectCount = board.GetComponent<BoardController>().CountAvailableSectors();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(board.GetComponent<BoardController>().CountAvailableSectors());
        if (state == BattleState.PLAYERTURN)
        {
            Debug.Log("Player, choose where your position");
            if (board.GetComponent<BoardController>().CountAvailableSectors() == boardObjectCount - 1)
            {
                Debug.Log("Player completed their turn");
                state = BattleState.ENEMYTURN;
                boardObjectCount = board.GetComponent<BoardController>().CountAvailableSectors();
            }
        }
        else if(state == BattleState.ENEMYTURN)
        {
            Debug.Log("Computer is thinking");
            board.GetComponent<BoardController>().DisableBoardForPlayer();
            ttte.IAmThinking(board);
            if (board.GetComponent<BoardController>().CountAvailableSectors() == boardObjectCount - 1)
            {
                Debug.Log("Enemy has completed their turn");
                state = BattleState.PLAYERTURN;
                boardObjectCount = board.GetComponent<BoardController>().CountAvailableSectors();
                board.GetComponent<BoardController>().EnableBoardForPlayer();
            }
        }
        else
        {
            Debug.Log("Game has not started and who goes first has not been determined.");
        }
    }

    public void StartGame()
    {
        DecideWhoGoesFirst();
        //board.GetComponent<Blink>().enabled=(false);
        //board.GetComponent<TicTacToeEngine>().enabled=(true);
        board.GetComponent<BoardController>().resetBoard();
        canvas.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Button was clicked");
    }

    public void DecideWhoGoesFirst()
    {
      if(Random.Range(0, 2) == 0)
        {
            Debug.Log("Player goes first");
            state = BattleState.PLAYERTURN;
        }
        else
        {
            Debug.Log("Computer goes first");
            state = BattleState.ENEMYTURN;
        }
    }
}
