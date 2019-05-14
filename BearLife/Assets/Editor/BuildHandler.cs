using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildHandler : MonoBehaviour
{
    static void Start()
         {
             string[] scenes = {"Assets/Scenes/Lobby.unity", "Assets/Scenes/SampleScene.unity", "Assets/Scenes/MultiplayerScene.unity" };
             BuildPipeline.BuildPlayer(scenes, "StandaloneWindows64", BuildTarget.StandaloneWindows64, BuildOptions.None);
         }
}
