using UnityEngine;

namespace BearLife.PlayerSettings
{
    public class PlayerView : IPlayerView
    {    
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerPresenter _presenter;

        public override void EndAnimation()
        {
            _animator.SetBool("walk", false);
        }

        public override void StartAnimation()
        {
            _animator.SetBool("walk",true);
        }

        public void SetPresenter(PlayerPresenter newPresenter)
        {
            _presenter = newPresenter;
        }

        void Update()
        {
            transform.position = _presenter.transform.position;
        }
    }
}

