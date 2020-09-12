using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    public float jampspeed = 10.0f;
    public float movespeed = 5.0f;
    public int playerNumber;
    public float moveSpeed;
    public float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //前後左右操作
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -movespeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(movespeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-movespeed * Time.deltaTime, 0, 0);
        }
        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0.0f, jampspeed, 0.0f, ForceMode.Impulse);
        }
    }
}
