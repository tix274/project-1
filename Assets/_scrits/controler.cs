using System;
using UnityEngine;

public class controler : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [Range(1, 20)] [SerializeField] private float sencax;
    [Range(1, 20)] [SerializeField] private float sencay;
    private Vector3 capsule;
    private Rigidbody rb;
    [SerializeField] private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      rb = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        PlayerRotation();
        limitSpeed();
        print(rb.linearVelocity.magnitude);
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * speed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * speed * Time.deltaTime);
        }
        

    }

    private void PlayerRotation()
    {
        float deltax = Input.GetAxis("Mouse X") * sencax;
        float deltaY = Input.GetAxis("Mouse Y") * sencay;

        capsule.x+=-deltaY;
        capsule.x = Math.Clamp(capsule.x, -90, 90);

        capsule.y+=deltax;

        transform.rotation = Quaternion.Euler(transform.rotation.x, capsule.y, 0);
        camera.transform.rotation = Quaternion.Euler(capsule.x, capsule.y, 0);
    }

    void limitSpeed()
    {
        if (rb.linearVelocity.magnitude > 10)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * 10f;
        }
    }
  
    
}




