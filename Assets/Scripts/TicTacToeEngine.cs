using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeEngine : MonoBehaviour
{

    protected GameObjectState blank = new Blank();
    int bestMove = -1;
    int bestLocation = -1;
    int depth = 0;

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
        //Debug.Log("Enabling sector 3");
        //board.transform.Find("GameObjects").transform.GetChild(2).gameObject.GetComponent<SectorSystem>().Place_O();
        IAmThinkingRight(board);
    }


    public void IAmThinkingRight(GameObject board)
    {
        for(int i=0;i< board.transform.Find("GameObjects").transform.childCount;i++)
        {
            Debug.Log("Index:" + i);
            Transform sector = board.transform.Find("GameObjects").transform.GetChild(i);
            if (sector.GetComponent<SectorSystem>().GetState().Equals(blank.ToString()))
            {
                int score = MiniMax(board,0,true);
                if (score > bestMove)
                {
                    bestMove = score;
                    bestLocation = i;
                    sector.GetComponent<SectorSystem>().Place_O();
                }
            }
        }
        bestMove = -1;
    }
    enum SCORE
    {
        X=1,
        O=-1,
        TIE=0
    }
    int MiniMax(GameObject board, int depth,bool isMaximizing)
    {
        if (isMaximizing)
        {
            for (int i = 0; i < board.transform.Find("GameObjects").transform.childCount; i++)
            {
                Transform sector = board.transform.Find("GameObjects").transform.GetChild(i);
                if (sector.GetComponent<SectorSystem>().GetState().Equals(blank.ToString()))
                {
                    sector.GetComponent<SectorSystem>().Place_O();
                    int currentScore = MiniMax(board, depth + 1, false);
                    sector.GetComponent<SectorSystem>().Blank();
                }
            }
        }
        return 1;
        
    }
}
