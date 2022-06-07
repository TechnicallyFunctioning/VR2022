using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

public class TeleportToggle : MonoBehaviour
{
    [SerializeField] private InputActionReference teleportButton;

    public UnityEvent OnTeleportActivate;
    public UnityEvent OnTeleportCancel;

    #region Input Action Listeners
    private void OnEnable()
    {
        teleportButton.action.performed += ActivateTeleport;
        teleportButton.action.canceled += DeactivateTeleport;
    }
    private void OnDisable()
    {
        teleportButton.action.performed -= ActivateTeleport;
        teleportButton.action.canceled -= DeactivateTeleport;
    }
    #endregion

    private void ActivateTeleport(InputAction.CallbackContext obj) => OnTeleportActivate.Invoke();

    private void DeactivateTeleport(InputAction.CallbackContext obj) => Invoke("TurnOffTeleport", .1f);

    private void TurnOffTeleport() => OnTeleportCancel.Invoke();
}
