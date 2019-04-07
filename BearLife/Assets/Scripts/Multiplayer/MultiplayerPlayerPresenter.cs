using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class MultiplayerPlayerPresenter : PlayerPresenter, IPunObservable
{
    private PhotonView _photonView;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }
    public Player GetOwner()
    {
        return _photonView.Owner;
    }
}
