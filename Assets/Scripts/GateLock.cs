using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLock : MonoBehaviour
{
    // KEYS MUST BE NAMED WITH ONE SPACE BEFORE THE KEY NUMBER

    [SerializeField] private GatePortal gatePortal;
    int keyCount = 0;
    private string keyTag = "GateKey";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(keyTag))
        {
            // When a Key enters, increase the count
            keyCount++;
            if(keyCount == 1)
            {
                // If One key is in, grab the number from its name and pass it to GatePortal
                string[] subStrings = other.name.Split(" ");
                int.TryParse(subStrings[1], out int keyNumber);
                gatePortal.UpdateGate(keyNumber);
            }
            // Default to Room0
            else { gatePortal.UpdateGate(0); }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // When a Key leaves, decreace the count
        if (other.CompareTag(keyTag)) { keyCount--; }
    }
}
