using UnityEngine;

namespace BearLife.PlayerSettings
{
    public abstract class IPlayerView: MonoBehaviour
    {
        public abstract void StartAnimation();
        public abstract void EndAnimation();
    }
}
