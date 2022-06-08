using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatePortal : MonoBehaviour
{
    [Tooltip("Platform Index # Should Match Room #")]
    [SerializeField] private GameObject[] platforms;
    private GameObject activePlatform;
    private int sceneIndex = 0;
    private bool portalActivated = false;

    private void Awake()
    {
        activePlatform = platforms[0];
        foreach(GameObject platform in platforms) { platform.SetActive(false); }
        activePlatform.SetActive(true);
    }

    public void UpdateGate(int gateNumber)
    {
        activePlatform.SetActive(false);
        activePlatform = platforms[gateNumber];
        activePlatform.SetActive(true);
        sceneIndex = gateNumber;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 10 && !portalActivated) { portalActivated = true; GameManager.Instance.GoToSceneAsynch(sceneIndex); }
    }
}
