using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public string teleportTag = "Teleport"; // The tag of the object that triggers the teleport
    public string checkpointTag = "Checkpoint"; // The tag of the checkpoints to which the player can teleport
    private Transform latestCheckpoint; // The latest touched checkpoint
    CharacterController controller;
    PlayerMovement pm;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        pm = GetComponent<PlayerMovement>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag(teleportTag))
        {
            if (latestCheckpoint != null)
            {
                print("telport");
                controller.enabled = false;
                pm.enabled = false;
                hit.transform.position = latestCheckpoint.position; // Teleport the player to the latest checkpoint
                
            }
        }
        else if (hit.transform.CompareTag(checkpointTag))
        {
            print("check");
            latestCheckpoint = hit.transform; // Update the latest touched checkpoint
            
        }
    }

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
