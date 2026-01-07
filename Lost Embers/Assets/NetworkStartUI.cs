using UnityEngine;
using Unity.Netcode;

public class NetworkStartUI : MonoBehaviour

    // public void OnGUI()
    // {
    //     float w = 200f, h = 40f;
    //     float x = 10f, y = 10f;

    //     if(!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
    //     {
    //         if(GUI.Button(new Rect(x, y, w, h), "Start Host"))
    //         {
    //             NetworkManager.Singleton.StartHost();
    //         }

    //         y += h + 10f;

    //         if(GUI.Button(new Rect(x, y + h + 10, w, h), "Start Client"))
    //         {
    //             NetworkManager.Singleton.StartClient();
    //         }

    //         y += h + 10f;

    //         if(GUI.Button(new Rect(x, y + 2 * (h + 10), w, h), "Start Server"))
    //         {
    //             NetworkManager.Singleton.StartServer();
    //         }
    //     }
    // }


{
    private NetworkManager nm;

    void Start()
    {
        nm = NetworkManager.Singleton;
    }

    void OnGUI()
    {
        if (nm == null)
        {
            GUI.Label(new Rect(10, 10, 300, 40), "NetworkManager not ready");
            return;
        }

        float w = 200f, h = 40f;
        float x = 10f, y = 10f;

        if (!nm.IsClient && !nm.IsServer)
        {
            if (GUI.Button(new Rect(x, y, w, h), "Start Host"))
                nm.StartHost();

            y += h + 10f;

            if (GUI.Button(new Rect(x, y, w, h), "Start Client"))
                nm.StartClient();

            y += h + 10f;

            if (GUI.Button(new Rect(x, y, w, h), "Start Server"))
                nm.StartServer();
        }
    }


}
