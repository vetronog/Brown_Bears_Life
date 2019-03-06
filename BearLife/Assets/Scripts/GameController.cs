using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player playerBear;
    [SerializeField] private Player playerMoose;
    private Player currentPlayer;
    public static GameController instance;
    private void Start()
    {
        currentPlayer = playerBear;
        instance = this;
    }
    // Start is called before the first frame update
    public void ChangeActivePlayer()
    {
        if(currentPlayer.Type == PlayerType.bear)
        {
            currentPlayer = playerMoose;
        }
        else
        {
            currentPlayer = playerBear;
        }
        changedPlayer(currentPlayer.transform);
        changedPlayerType(currentPlayer.Type);
    }
    public int RollActivePlayer()
    {
        return currentPlayer.Roll();
    }
    public event Action<Transform> changedPlayer;
    public event Action<PlayerType> changedPlayerType;


}
