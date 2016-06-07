using UnityEngine;
using System.Collections;

public class MovementPlayer : MonoBehaviour
{

    private float X = 0;
    private float Y = 0;
    private float Z = 0;

    public float speedF = 0;
    private float speedB = 0;
    private float rotationR = 0;
    private float rotationL = 0;

    private float rotateL = 50f;
    private float rotateR = 50f;
    private float moveF = 0.4f;
    private float moveB = 0.4f;

    private Rigidbody rb;

    void Start()
    {

        //Y = 3.5f;
        rb = GetComponent<Rigidbody>();
        this.transform.position = new Vector3(X, Y, Z);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            if (speedF < 20)
            {
                speedF += moveF;
            }
        }
        else
        {
            if (speedF > 0)
            {
                speedF -= moveF;
            }
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotationL = rotateL;
        }
        else
        {
            rotationL = 0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (speedB < 20)
            {
                speedB += moveB;
            }
        }
        else
        {
            if (speedB > 0)
            {
                speedB -= moveB;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
     
            rotationR = rotateR;
        }
        else
        {
            rotationR = 0f;
        }


    }


    void FixedUpdate()
    {

        float rotation = rotationR - rotationL;
        float speed = speedF - speedB;

        rb.MovePosition(rb.position + (transform.TransformDirection(Vector3.forward) * speed * Time.fixedDeltaTime));
        rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * rotation * Time.fixedDeltaTime));

        
    }


}