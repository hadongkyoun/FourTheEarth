using UnityEngine;
using PurrNet;
using TMPro;
using System;
using UnityEngine.InputSystem;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class PlayerNumber : NetworkBehaviour
{
    public SyncVar<int> playerNumber = new(0, ownerAuth: true);
    public TMP_Text numberText;

    protected override void OnSpawned(bool asServer)
    {
        base.OnSpawned(asServer);
        numberText.text = "0";
        playerNumber.onChanged += OnPlayerNumberChanged;

        if (isOwner && TryGetComponent<PlayerInputActionMapper>(out PlayerInputActionMapper _playerActionMapper))
        {
            PlayerInputActions playerInputActions = _playerActionMapper.PlayerInputActions;
            playerInputActions.Player.Interact.performed += PlayerNumberUp;
            playerInputActions.Player.Quest.performed += PlayerNumberDown;
            playerInputActions.Enable();
            _playerActionMapper.inputActionsEnabled = true;
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        playerNumber.onChanged -= OnPlayerNumberChanged;
        if (isOwner && TryGetComponent<PlayerInputActionMapper>(out PlayerInputActionMapper _playerActionMapper))
        {
            PlayerInputActions playerInputActions = _playerActionMapper.PlayerInputActions;
            playerInputActions.Player.Interact.performed -= PlayerNumberUp;
            playerInputActions.Player.Quest.performed -= PlayerNumberDown;
            _playerActionMapper.PlayerInputActions.Disable();
        }
    }


    private void OnPlayerNumberChanged(int _newNumber)
    {
        numberText.text = _newNumber.ToString();
    }

    public void PlayerNumberUp(InputAction.CallbackContext context)
    {
        playerNumber.value++;
    }


    public void PlayerNumberDown(InputAction.CallbackContext context)
    {
        playerNumber.value--;
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
