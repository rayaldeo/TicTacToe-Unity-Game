using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TicTacToeEngine : MonoBehaviour
{

    public GameObject board;

    protected GameObjectState blank = new Blank();
    protected GameObjectState placeX = new PlaceX();
    protected GameObjectState placeO = new PlaceO();
    float depth = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IAmThinking()
    {
        float bestScore = -Mathf.Infinity;
        float bestLocation=-1;
        Debug.Log("I am thinking..beep...bap...boop");

        for (int i = 0; i < board.transform.childCount; i++)
        {
            Transform sector = board.transform.GetChild(i);
            if (sector.GetComponent<SectorSystem>().GetState().Equals(blank))
            {
                //Debug.Log("MiniMax this shit!!");
                sector.GetComponent<SectorSystem>().SetState(placeO);
                float score = MiniMax(this.board, 0, false);
                sector.GetComponent<SectorSystem>().SetState(blank);
                Debug.Log("AI got this score:" + score);

                if (score > bestScore)
                {
                    bestScore = score;
                    bestLocation = i;
                    Debug.Log("Best Location:" + bestLocation);
                }
            }
        }
        board.transform.GetChild((int)bestLocation).GetComponent<SectorSystem>().Place_O();
    }


    float MiniMax(GameObject board, int depth,bool isMaximizing)
    {
        int whoWon = board.GetComponent<BoardController>().WhoWon();
        if (whoWon != 0)
        {
            return whoWon;
            Debug.Log("Predicting who won:" + whoWon);
        }
       
        if (isMaximizing)
        {
            float bestScore = -Mathf.Infinity;
            for (int i = 0; i < board.transform.childCount; i++)
            {
                Transform sector = board.transform.GetChild(i);
                if (sector.GetComponent<SectorSystem>().GetState().Equals(blank))
                {
                    sector.GetComponent<SectorSystem>().SetState(placeO);
                    float currentScore = MiniMax(this.board, depth + 1, false);
                    sector.GetComponent<SectorSystem>().SetState(blank);
                    bestScore = Math.Max(currentScore, bestScore);
                }
            }
            return bestScore;
        }
        else
        {
            float bestScore = Mathf.Infinity;
            for (int i = 0; i < board.transform.childCount; i++)
            {
                Transform sector = board.transform.GetChild(i);
                if (sector.GetComponent<SectorSystem>().GetState().Equals(blank))
                {
                    sector.GetComponent<SectorSystem>().SetState(placeX);
                    float currentScore = MiniMax(this.board, depth + 1, true);
                    sector.GetComponent<SectorSystem>().SetState(blank);
                    bestScore = Math.Min(currentScore, bestScore);
                }
            }
            return bestScore;
        }
    }
}
