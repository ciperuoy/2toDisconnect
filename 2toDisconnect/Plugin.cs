using BepInEx;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _2toDisconnect
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public void Update()
        {
            var input = ControllerInputPoller.instance.leftControllerSecondaryButton && ControllerInputPoller.instance.rightControllerSecondaryButton || Keyboard.current.yKey.isPressed && Keyboard.current.bKey.isPressed;

            if (input && PhotonNetwork.InRoom)
            {
                NetworkSystem.Instance.ReturnToSinglePlayer();
            }
            else if (input && !PhotonNetwork.InRoom)
            {
                Debug.LogError("2toDisconnect Error: Not in room!");
            }
        }
    }
}
