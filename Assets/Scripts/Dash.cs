using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : PowerupBase
{
   
    public float dashSpeed;
    private float dashtTime;
    public float startDashTime;
    private int direction;

    public float speed;

    private PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        dashtTime = startDashTime;
    }
    public override void Activate(PlayerMovement player)
    {
        if (direction == 0)
        {
            direction = 1;
        dashtTime = startDashTime;
        transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (direction == 1)
        {
            pm.velocity = Vector3.forward * dashSpeed;
        }
    }
           

    // Update is called once per frame
   /* void Update()
    {
        if (direction == 0)
        {
            if (Input.GetButtonDown("Dash"))
            {
                direction = 1;
                dashtTime = startDashTime;
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
           /* else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
                dashtTime = startDashTime;
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            /* else if (Input.GetKeyDown(KeyCode.UpArrow))
             {
                 direction = 3;
                 dashtTime = startDashTime;
             }*/
           /* else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 4;
                dashtTime = startDashTime;
            }*/

       /* }
        if (dashtTime <= 0)
        {
            direction = 0;
            dashtTime = startDashTime;
            //rb.velocity = Vector2.zero;
        }
        else
        {
            dashtTime -= Time.deltaTime;

            if (direction == 1)
            {
                pm.velocity = Vector3.left * dashSpeed;
            }
            else if (direction == 2)
            {
                pm.velocity = Vector3.right * dashSpeed;
            }
            else if (direction == 3)
            {
                pm.velocity = Vector3.up * dashSpeed;
            }
            else if (direction == 4)
            {
                pm.velocity = Vector3.down * dashSpeed;
            }
        }
    }*/
}