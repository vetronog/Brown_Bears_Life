using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private GameController _gc;
    [SerializeField]
    private Text _rollText;
    [SerializeField]
    private GameObject _endPanel;
    [SerializeField]
    private Text _playerText;

    private void Start()
    {
        _gc.changedPlayerType += ChangePlayerText;
        _gc.endGame += EndGame;
    }
    public void RollButton()
    {
        _rollText.text = _gc.RollActivePlayer().ToString();
    }

    private void ChangePlayerText(PlayerType type)
    {
        if(type == PlayerType.bear)
        {
            _playerText.text = "Медведь";
        }
        else
        {
            _playerText.text = "Лось";
        }
    }

    private void EndGame(PlayerType type)
    {
        _endPanel.SetActive(true);
    }

    public void Exit()
    {
        _gc.Exit();
    }
}
