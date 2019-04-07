using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class MultiplayerGameController : GameController,IPunObservable
{
    private Player _activePlayer;
    private PhotonView _photonView;
    // Start is called before the first frame update
    void Awake()
    {
        _activePlayer = PhotonNetwork.PlayerList[1];
        _photonView = GetComponent<PhotonView>();
    }

    public override void ChangeActivePlayer()
    {
        _photonView.RPC("TransferOwnership", RpcTarget.All);

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_activePlayer);
        }
        else
        {
            Player player = stream.ReceiveNext() as Photon.Realtime.Player;
            Debug.Log(player.UserId);
            if (_activePlayer != player)
            {
                //ChangeActivePlayer();
            }
        }
    }
    [PunRPC]
    private void TransferOwnership()
    {
        if (_activePlayer == PhotonNetwork.PlayerList[0])
            _activePlayer = PhotonNetwork.PlayerList[1];
        else
            _activePlayer = PhotonNetwork.PlayerList[0];

        if (currentPlayer.Type == PlayerType.bear)
        {
            currentPlayer = playerMoose;
        }
        else
        {
            currentPlayer = playerBear;
        }
        ChangedPlayer();
        ChangedPlayerType();
        if (currentPlayer.IsSkipping)
        {
            currentPlayer.SkipTurn(false);
            ChangeActivePlayer();
        }
    }

    public Player GetPlayer()
    {
        return _activePlayer;
    }
    
}
