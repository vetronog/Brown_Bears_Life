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
    public static GameController instance;
    private void Start()
    {
        currentPlayer = playerBear;
        instance = this;
    }
    // Start is called before the first frame update
    public virtual void ChangeActivePlayer()
    {
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
        return currentPlayer.Roll();
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
