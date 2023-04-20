using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTeleport : MonoBehaviour
{
    //Vi serializar en position som spelaren ska gå till
    [SerializeField]
    Vector3 position;
   // LevelShow levelshow;
    //DeathHandler dh;


    [SerializeField]
    bool isKillzone;


    float timer;

    CharacterController controller;
    PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        // levelshow = FindObjectOfType<LevelShow>();
        //dh = FindObjectOfType<DeathHandler>();
        controller = GetComponent<CharacterController>();
        pm = GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnControllerCollider(Collision collision)
    {
        //Vid en kollision flyttas spelaren till våran position
        collision.transform.position = position;
        if (isKillzone == false)
        {
            //levelshow.level += 1;
            controller.enabled = true;
            pm.enabled = true;
        }
        else
        {
            //Om spelaren nuddar en tp som är en killzone kommer spelaren att teleporteras men inte att få poäng.
            print("Player touched the killzone");
            //dh.deaths += 1;
            controller.enabled = false;
            pm.enabled = false;
        }
    }



}