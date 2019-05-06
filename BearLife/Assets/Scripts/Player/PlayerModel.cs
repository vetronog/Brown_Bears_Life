using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    bear,
    moose,
    none
}

public class PlayerModel
{
    private PlayerType _type;
    private int _position;

    public void SetType(PlayerType newPlayerType)
    {
        _type = newPlayerType;
    }

    public PlayerType GetPlayerType
    {
        get
        {
            return _type;
        }
    }

    public void SetCurrentPosition(int newPos)
    {
        _position = newPos;
    }

    public int GetPosition
    {
        get
        {
            return _position;
        }
    }
}
