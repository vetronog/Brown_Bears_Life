using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MultiplayerUIHandler : MonoBehaviour, IPunObservable
{
    [SerializeField]
    private MultiplayerGameController _gc;
    [SerializeField]
    private Text _rollText;
    [SerializeField]
    private Text _playerText;
    [SerializeField]
    private Button _rollButton;
    [SerializeField]
    private GameObject _endPanel;
    [SerializeField]
    private Photon.Realtime.Player _player;
    private PhotonView _photonView;

    private void Start()
    {
        _gc.changedPlayerType += ChangePlayerText;
        _gc.endGame += EndGame;
        _photonView = GetComponent<PhotonView>();
    }
    public void RollButton()
    {
        _rollText.text = _gc.RollActivePlayer().ToString();
    }

    private void ChangePlayerText(PlayerType type)
    {
        _photonView.RPC("UpdateState", RpcTarget.All);
    }
    [PunRPC]
    private void UpdateState()
    {
        _player = _gc.GetPlayer();
        if (_player == PhotonNetwork.LocalPlayer)
        {
            _playerText.text = "Твой Ход";
            _rollButton.interactable = true;
        }
        else
        {
            _playerText.text = "Ход Другого Игрока";
            _rollButton.interactable = false;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_player);
        }
        else
        {
            _player = stream.ReceiveNext() as Photon.Realtime.Player;
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
