using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CameraParamsDB", menuName = "Camera/CameraParamsDB")]
public class CameraParamsDB : ScriptableObject
{
    [SerializeField]private List<CameraParams> parameters;


    public CameraParams GetParams()
    {
        float width = Screen.width;
        float height = Screen.height;
        if (width / height <=1.34f)
        {
            return parameters[0];
        }
        else if (width / height <= 1.78f)
        {
            return parameters[1];
        }
        else
        {
            return parameters[2];
        }
    }

}
