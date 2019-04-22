using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VK.Unity;

public class VkApiHandler : MonoBehaviour
{
    public void SendPost()
    {
#if UNITY_ANDROID
        if (!VKSDK.IsLoggedIn)
        {
            VKSDK.Login(new List<Scope>(new Scope[]{ Scope.Wall }));
        }

        if (!VKSDK.IsInitialized)
        {
            VKSDK.Init();
        }

        VKSDK.API("wall.post", new Dictionary<string, string>() { { "owner_id", VKSDK.UserId.ToString() }, { "message", "My post!!!!!!!!!!!!"} });

#endif
        Debug.Log("Message for vk");
    }
}
