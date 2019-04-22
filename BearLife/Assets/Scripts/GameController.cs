using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] protected PlayerPresenter playerBear;
    [SerializeField] protected PlayerPresenter playerMoose;
    protected PlayerPresenter currentPlayer;
    protected bool turn;
    public static GameController instance;
    private void Start()
    {
        currentPlayer = playerBear;
        turn = true;
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentPlayer.Roll(1);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            currentPlayer.Roll(0);
        }
    }

    // Start is called before the first frame update
    public virtual void ChangeActivePlayer()
    {
        turn = true;
        if(currentPlayer.Type == PlayerType.bear)
        {
            currentPlayer = playerMoose;
        }
        else
        {
            currentPlayer = playerBear;
        }
        ChangedPlayer();
        ChangedPlayerType();        
        if(currentPlayer.IsSkipping)
        {
            currentPlayer.SkipTurn(false);
            ChangeActivePlayer();            
        }
    }
    public int RollActivePlayer()
    {
        if (turn)
        {
            turn = false;
            return currentPlayer.Roll();
        }
        else
        {
            return 0;
        }

    }

    protected void ChangedPlayerType()
    {
        if(changedPlayerType!= null)
            changedPlayerType(currentPlayer.Type);
    }

    protected void ChangedPlayer()
    {
        if(currentPlayer!= null)
            changedPlayer(currentPlayer.transform);
    }

    public PlayerPresenter GetCurrentPlayer
    {
        get { return currentPlayer; }
    }

    public void SkipTurn()
    {
        currentPlayer.SkipTurn(true);
    }

    public virtual void EndGame(PlayerType type)
    {
        SetEndGame(type);
        Debug.Log(string.Format("Winner is {0}", type.ToString()));
    }

    protected void SetEndGame(PlayerType type)
    {
        if (endGame != null)
        {
            endGame(type);
        }
    }

    public virtual void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public event Action<Transform> changedPlayer;
    public event Action<PlayerType> changedPlayerType;
    public event Action<PlayerType> endGame;

}
