using UnityEngine;

namespace BearLife.CameraSettings
{
    [CreateAssetMenu(fileName = "CameraParams", menuName = "Camera/CameraParams")]
    public class CameraParams : ScriptableObject
    {
        public float maxOffsetX;
        public float maxOffsetY;
        public float maxSize;
    
    }
}
