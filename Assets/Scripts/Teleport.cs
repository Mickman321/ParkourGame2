using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public string teleportTag = "Teleport";
    private Transform latestCheckpoint;

    CharacterController controller;
    PlayerMovement pm;
    


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.transform.CompareTag(teleportTag))
            {
                
                if (latestCheckpoint != null)
                {
                    pm.velocity = new Vector3(0, 30, 0);

                }
            }
           
        }
    }
}
