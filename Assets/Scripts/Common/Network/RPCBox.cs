using UnityEngine;
using PurrNet;

public class RPCBox : NetworkBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetColor(Color.red);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetColor(Color.green);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetColor(Color.blue);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetColor(Color.black);
        }
    }


    // https://youtu.be/h2YRwb0RhcA?si=dIdylJ-tc2_0FRv8 ( Send Data Guide Line )

    //// requireOwnership : false => everybody can call the server RPC 
    //   생략 가능
    //[ServerRpc(requireOwnership: false)]
    //private void SetColor(Color color)
    //{
    //    SetColor_Observer(color);
    //}

    [ServerRpc(requireOwnership:false)]
    private void SetColor(Color color, RPCInfo info = default)
    {
        //localPlayer.value
        //owner
        SetColor_Target(info.sender, color);
    }

    [TargetRpc]
    private void SetColor_Target(PlayerID target, Color color)
    {
        if (TryGetComponent<SpriteRenderer>(out SpriteRenderer _spriteRenderer))
        {
            _spriteRenderer.color = color;
        }
    }
    //[ObserversRpc]
    //private void SetColor(Color color)
    //{
    //    if (TryGetComponent<SpriteRenderer>(out SpriteRenderer _spriteRenderer))
    //    {
    //        _spriteRenderer.color = color;
    //    }
    //}
}
