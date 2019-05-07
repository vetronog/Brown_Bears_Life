using BearLife.PlayerSettings;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace BearLife.Multiplayer
{
    public class MultiplayerPlayerPresenter : PlayerPresenter, IPunObservable
    {
        private PhotonView _photonView;
        protected override void Awake()
        {
            base.Awake();
            _photonView = GetComponent<PhotonView>();
            Invoke("ChangeOwner", 0.1f);
        }
    
        private void ChangeOwner()
        {
            if (Type == PlayerType.moose)
            {
                Debug.Log(_photonView);
                Debug.Log(PhotonNetwork.PlayerList[1]);
                _photonView.TransferOwnership(PhotonNetwork.PlayerList[1]);
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            throw new System.NotImplementedException();
        }
        public Player GetOwner()
        {
            return _photonView.Owner;
        }
    }
}
