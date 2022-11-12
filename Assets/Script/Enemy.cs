using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    private Animator playerAnim;
    public NavMeshAgent navigation;
    public Transform treeTarget;
    public GameObject enemyController;

    public Transform a;
    public Transform b;
    public Transform c;
    public Transform d;

    public bool randomState;
    public bool targetState;
    public bool state;


    void Start()
    {
        state = true;
        randomState = true;
        targetState = true;

        playerAnim = GetComponent<Animator>();
        navigation = GetComponent<NavMeshAgent>();

        InvokeRepeating("RandomNav", 2f, 5);
    }

    void Update()
    {

        // Debug.Log(navigation.desiredVelocity.magnitude);       velocidad definida
        //  Debug.Log(navigation.speed);  velocidad definida

        // Debug.Log(navigation.velocity.magnitude);   velocidad del movimiento


        if (navigation.velocity.magnitude < 1)
        {
            playerAnim.SetFloat("Speed_f", 0f);
            playerAnim.SetBool("Static_b", true);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb") && state)
        {
           // Debug.Log("le pegue");
            CancelInvoke();

            Escape();

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
                        Debug.Log("cerca de A");
                        navigation.SetDestination(new Vector3(transform.position.x, transform.position.y, a.position.z));
                    }
                    else
                    {
                        Debug.Log("cerca de B");
                        navigation.SetDestination(new Vector3(b.position.x, transform.position.y, transform.position.z));
                    }
                }
                else
                {
                    if (oA < oD)
                    {
                        Debug.Log("cerca de A");
                        navigation.SetDestination(new Vector3(transform.position.x, transform.position.y, a.position.z));
                    }
                    else
                    {
                        Debug.Log("cerca de D");
                        navigation.SetDestination(new Vector3(d.position.x, transform.position.y, transform.position.z));
                    }
                }
            }
            else
            {
                if (oB < oD)
                {
                    if (oC < oB)
                    {
                        Debug.Log("cerca de C");
                        navigation.SetDestination(new Vector3(transform.position.x, transform.position.y, c.position.z));
                    }
                    else
                    {
                        Debug.Log("cerca de B");
                        navigation.SetDestination(new Vector3(b.position.x, transform.position.y, transform.position.z));
                    }
                }
                else
                {
                    if (oC < oD)
                    {
                        Debug.Log("cerca de C");
                        navigation.SetDestination(new Vector3(transform.position.x, transform.position.y, c.position.z));
                    }
                    else
                    {
                        Debug.Log("cerca de D");
                        navigation.SetDestination(new Vector3(d.position.x, transform.position.y, transform.position.z));
                    }
                }
            }
            state = false;

            enemyController.gameObject.GetComponent<EnemyController>().EnemyKilled();
        }

        if (collision.gameObject.CompareTag("Bounds"))
        {
            //  Debug.Log("choc�");

            Destroy(gameObject);

        }

        if (collision.gameObject.CompareTag("TargetTree") && targetState)
        {
            targetState = false;
            enemyController.gameObject.GetComponent<EnemyController>().EggsCount();
            Debug.Log("eggsssss");
        }







    }

    void RandomNav()
    {
        if (randomState)
        {
            navigation.destination = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
        }

        Walk();
    }

    public void Walk()
    {
        navigation.speed = 3.5f;
        playerAnim.SetFloat("Speed_f", 0.26f);
        playerAnim.SetBool("Static_b", true);
    }
    public void Run()
    {
        navigation.speed = 5f;
        navigation.destination = treeTarget.position;
        playerAnim.SetFloat("Speed_f", 0.51f);
        playerAnim.SetBool("Static_b", true);
        randomState = false;
    }
    void Escape()
    {
        navigation.speed = 10f;
        playerAnim.SetFloat("Speed_f", 0.51f);
        playerAnim.SetBool("Static_b", true);
    }
}



