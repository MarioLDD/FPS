using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Animator playerAnim;
    public NavMeshAgent navigation;
    public Transform target;


    public Transform a;
    public Transform b;
    public Transform c;
    public Transform d;


    void Start()
    {
        playerAnim = GetComponent<Animator>();
        navigation = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navigation.destination = target.position;
        // Debug.Log(navigation.desiredVelocity.magnitude);       velocidad definida
        //  Debug.Log(navigation.speed);  velocidad definida

        // Debug.Log(navigation.velocity.magnitude);   velocidad del movimiento

        if (navigation.velocity.magnitude > 0)
        {
            Walk();
            //   Run();
        }
        else
        {
            playerAnim.SetFloat("Speed_f", 0f);
        }


        void Walk()
        {
            playerAnim.SetFloat("Speed_f", 0.26f);
            playerAnim.SetBool("Static_b", true);
        }

        void Run()
        {
            playerAnim.SetFloat("Speed_f", 0.51f);
            playerAnim.SetBool("Static_b", true);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        float oA = Vector3.Distance(transform.position, a.transform.position);
        float oB = Vector3.Distance(transform.position, b.transform.position);
        float oC = Vector3.Distance(transform.position, c.transform.position);
        float oD = Vector3.Distance(transform.position, d.transform.position);

        if (oA < oC)
        {
            if (oB < oD)
            {
                if (oA < oB)
                {
                    // oA
                    Debug.Log("cerca de A");
                }
                else
                {
                    // oB
                    Debug.Log("cerca de B");
                }
            }
            else
            {
                if (oA < oD)
                {
                    // oA
                    Debug.Log("cerca de A");

                }
                else
                {
                    //oD
                    Debug.Log("cerca de D");

                }
            }
        }
        else
        {

            if (oB < oD)
            {
                if (oC < oB)
                {
                    // oC
                    Debug.Log("cerca de C");

                }
                else
                {
                    // oB
                    Debug.Log("cerca de B");

                }
            }
            else
            {
                if (oC < oD)
                {
                    // oC
                    Debug.Log("cerca de C");

                }
                else
                {
                    //oD
                    Debug.Log("cerca de D");

                }
            }

        }



       
    }
}
