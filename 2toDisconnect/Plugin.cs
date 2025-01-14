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
            bool Button1 = ControllerInputPoller.instance.leftControllerSecondaryButton || Keyboard.current.yKey.isPressed;
            bool Button2 = ControllerInputPoller.instance.rightControllerSecondaryButton || Keyboard.current.bKey.isPressed;

            if (Button1 && Button2) // Y and B
            {
                NetworkSystem.Instance.ReturnToSinglePlayer(); // I could try PhotonNetwork.Disconnect();
                Debug.Log("Successfully disconnected.");
            }
            else if (Button1 && Button2 && PhotonNetwork.InRoom) // If the buttons are pressed, but still in room, send error.
            {
                Debug.LogError("Disconnect failed.");
            }
            else if (!PhotonNetwork.InRoom)
            {
                Debug.LogError("Error: Not in lobby!");
            }
        }
    }
}
