using UnityEngine;
using PurrNet;
using TMPro;
using System;
using UnityEngine.InputSystem;

public class PlayerNumber : NetworkBehaviour
{
    public SyncVar<int> playerNumber = new(0, ownerAuth: true);
    public TMP_Text numberText;

    [SerializeField]
    private PlayerInput playerInput;

    private void Awake()
    {
        numberText.text = "0";
        playerNumber.onChanged += OnPlayerNumberChanged;

        
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        playerNumber.onChanged -= OnPlayerNumberChanged;
    }
    

    private void OnPlayerNumberChanged(int _newNumber)
    {
        numberText.text = _newNumber.ToString();
    }

    public void PlayerNumberUp(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            playerNumber.value++;
        }
    }

    public void PlayerNumberDown(InputAction.CallbackContext context)
    {
       

        if (context.performed)
        {
            playerNumber.value--;
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha0))
    //    {
    //        playerNumber.value++;
    //        Debug.Log(playerNumber.value.ToString());
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha5))
    //    {
    //        playerNumber.value--;
    //        Debug.Log(playerNumber.value.ToString());
    //    }
    //}
}
