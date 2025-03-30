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
            if (ControllerInputPoller.instance.leftControllerSecondaryButton && ControllerInputPoller.instance.rightControllerSecondaryButton || Keyboard.current.yKey.isPressed && Keyboard.current.bKey.isPressed)
            {
                NetworkSystem.Instance.ReturnToSinglePlayer();
            }
        }
    }
}
