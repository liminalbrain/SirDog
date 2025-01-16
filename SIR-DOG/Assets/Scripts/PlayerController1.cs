using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float jumpForce = 300.0f;
    public float speed = 10.0f;
    public float maxGroundDistance = 1.5f;
    private bool isGrounded;
    public bool allowDoubleJump = false;
    private int amountOfJumps = 0;
    private float Zmovement = 0f;
    private float Xmovement = 0f;
    public CheckPoints lastCP;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (lastCP = null)
        {
            lastCP = GameObject.Find("Checkpoint0").GetComponent<CheckPoints>();
        }
    }

    void LateUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, maxGroundDistance);
        if (isGrounded == true)
        {
            amountOfJumps = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Zmovement = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Zmovement = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Xmovement = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Xmovement = -1;
        }

        if ((Xmovement != 0) && (Zmovement != 0))
        {
            transform.position = transform.position + ((transform.forward * Zmovement) * speed * Time.deltaTime * 0.7f);
            transform.position = transform.position + ((transform.right * Xmovement) * speed * Time.deltaTime * 0.7f);
        }

        if ((Xmovement == 0) || (Zmovement == 0))
        {
            transform.position = transform.position + ((transform.forward * Zmovement) * speed * Time.deltaTime);
            transform.position = transform.position + ((transform.right * Xmovement) * speed * Time.deltaTime);
        }

        Xmovement = 0;
        Zmovement = 0;


        if (Input.GetKeyDown("space"))
        {

            if (isGrounded)
            {
                // turn on the cursor
                GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpForce, 0.0f));
                amountOfJumps = 1;
            }
            else if (amountOfJumps < 2 && allowDoubleJump)
            {
                // turn on the cursor
                GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, jumpForce, 0.0f));
                amountOfJumps = 2;
            }

        }
    }

    public void RespawnPlayer()
    {
        Debug.Log("Respawn called");
        this.gameObject.transform.position = lastCP.transform.position;
    }
}