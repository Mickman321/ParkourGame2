using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public string teleportTag = "Teleport"; // The tag of the object that triggers the teleport
    public string checkpointTag = "Checkpoint"; // The tag of the checkpoints to which the player can teleport
    private Transform latestCheckpoint; // The latest touched checkpoint

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(teleportTag))
        {
            if (latestCheckpoint != null)
            {
                other.transform.position = latestCheckpoint.position; // Teleport the player to the latest checkpoint
            }
        }
        else if (other.CompareTag(checkpointTag))
        {
            latestCheckpoint = other.transform; // Update the latest touched checkpoint
        }
    }
}
