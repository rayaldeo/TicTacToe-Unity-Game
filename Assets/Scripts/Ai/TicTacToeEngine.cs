using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeEngine : MonoBehaviour
{

    protected GameObjectState blank = new Blank();
    protected GameObjectState placeX = new PlaceX();
    protected GameObjectState placeO = new PlaceO();
    float bestMove = -Mathf.Infinity;
    float bestLocation = -Mathf.Infinity;
    float depth = 0;

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

        for (int i = 0; i < board.transform.Find("GameObjects").transform.childCount; i++)
        {
            Debug.Log("Index:" + i);
            Transform sector = board.transform.Find("GameObjects").transform.GetChild(i);
            if (sector.GetComponent<SectorSystem>().GetState().Equals(blank.ToString()))
            {
                Debug.Log("MiniMax this shit!!");
                sector.GetComponent<SectorSystem>().SetState(placeO);
                float score = MiniMax(board, 0, false);
                sector.GetComponent<SectorSystem>().SetState(blank);
                Debug.Log("AI got this score:" + score);

                if (score > bestMove)
                {
                    bestMove = score;
                    bestLocation = i;
                }
            }
        }
        board.transform.Find("GameObjects").transform.GetChild((int)bestLocation).GetComponent<SectorSystem>().Place_O();
    }


    enum SCORE
    {
        X=1,
        O=-1,
        TIE=0
    }

    float MiniMax(GameObject board, int depth,bool isMaximizing)
    {
        float bestScore = -Mathf.Infinity;
        if (isMaximizing)
        {
            for (int i = 0; i < board.transform.Find("GameObjects").transform.childCount; i++)
            {
                Transform sector = board.transform.Find("GameObjects").transform.GetChild(i);
                if (sector.GetComponent<SectorSystem>().GetState().Equals(blank.ToString()))
                {
                    sector.GetComponent<SectorSystem>().SetState(placeO);
                    float currentScore = MiniMax(board, depth + 1, false);
                    sector.GetComponent<SectorSystem>().SetState(blank);
                    if (currentScore > bestScore)
                    {
                        bestScore = currentScore;
                    }
                }
            }
        }
        else
        {
            bestScore = Mathf.Infinity;
            for (int i = 0; i < board.transform.Find("GameObjects").transform.childCount; i++)
            {
                Transform sector = board.transform.Find("GameObjects").transform.GetChild(i);
                if (sector.GetComponent<SectorSystem>().GetState().Equals(blank.ToString()))
                {
                    sector.GetComponent<SectorSystem>().SetState(placeX);
                    float currentScore = MiniMax(board, depth + 1, false);
                    sector.GetComponent<SectorSystem>().SetState(blank);
                    if (currentScore < bestScore)
                    {
                        bestScore = currentScore;
                    }
                }
            }
        }
        return bestScore;
    }
}
