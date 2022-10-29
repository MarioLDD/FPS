using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float velMin = 2;
    private float horizontalInput;
    private float forwardInput;
    private float verticalInput;
    public float rotacionSpeed = 150;
    private float rotacionInput;
    public GameObject pointFire;

    void Start()
    {
       
       Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotacionInput = Input.GetAxis("Mouse X");
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime * rotacionSpeed * rotacionInput);

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("bomba va");

            pointFire.GetComponent<Disparo>().Lanzar();
          //  Rigidbody fire = Instantiate(projectile, transform.position, transform.rotation);
            //fire.velocity = Vector3.
        }

        





    }




}


