using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speedUp = 8f;
    public float speed = 4f;
    public float verticalSpeed = 5f;
    public float rotacionSpeed = 150f;
    private float rotacionInput;
    public GameObject pointFire;
    private float minAltitud = 1f;
    private float maxAltitud = 10f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rotacionInput = Input.GetAxis("Mouse X");

        if (transform.position.y < maxAltitud)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * Time.deltaTime * verticalSpeed);
            }
        }
        if (transform.position.y > minAltitud)
        {
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * Time.deltaTime * verticalSpeed);
            }
        }
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.forward * speedUp * Time.deltaTime);
        }

        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        transform.Rotate(Vector3.up * Time.deltaTime * rotacionSpeed * rotacionInput);

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("bomba va");

            pointFire.GetComponent<Disparo>().Lanzar();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            speed = 0;
            speedUp = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Food"))
        {
            Debug.Log("comidaaaa");
            Destroy(other.gameObject);
            pointFire.GetComponent<Disparo>().Reload();
        }
    }



}


