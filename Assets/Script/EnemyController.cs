using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public int enemySelect;
    public GameObject[] enemyList;
    GameObject actualEnemy;
    private int enemyCounter;


    // Start is called before the first frame update
    void Start()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCounter = enemyList.Length;
         InvokeRepeating("EnemyToTarget", 0f, 12f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P)) EnemyToTarget();

        
    }
    //12 segundos

    public void EnemyToTarget()
    {
        enemySelect = Random.Range(0, enemyList.Length);

        if (enemyList[enemySelect].GetComponent<Enemy>().state)

        {
            enemyCounter -= 1;
            enemyList[enemySelect].GetComponent<Enemy>().Run();
            actualEnemy = enemyList[enemySelect];
            Debug.Log(actualEnemy.name);

        }
        else EnemyToTarget();

    }


}
