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


    private Rigidbody rb;

    void Start()
    {

        Y = 3.5f;
        rb = GetComponent<Rigidbody>();
        this.transform.position = new Vector3(X, Y, Z);
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            if (speedF < 20)
            {
                speedF += 0.4f;
            }
        }
        else
        {
            if (speedF > 0)
            {
                speedF -= 0.4f;
            }
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotationL = 20f;
        }
        else
        {
            rotationL = 0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (speedB < 20)
            {
                speedB += 0.4f;
            }
        }
        else
        {
            if (speedB > 0)
            {
                speedB -= 0.4f;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
     
            rotationR = 20f;
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