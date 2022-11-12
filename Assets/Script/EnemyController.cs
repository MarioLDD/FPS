using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public int enemySelect;
    public GameObject[] enemyList;
    GameObject actualEnemy;
    public GameObject timeControl;

    public int enemyCounter;
    private int Kills;
    private int eggsRemaining;
    public TMP_Text killsUI;

    // Start is called before the first frame update
    void Start()
    {
        enemyList = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCounter = enemyList.Length;
         InvokeRepeating("EnemyToTarget", 20f, 12f);
        Kills = 0;
        eggsRemaining = 3;
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

        if (enemyList[enemySelect].GetComponent<Enemy>().randomState)

        {
            enemyList[enemySelect].GetComponent<Enemy>().Run();
            actualEnemy = enemyList[enemySelect];       //sacar
            Debug.Log(actualEnemy.name);                //sacar

        }
        else EnemyToTarget();

    }

    public void EnemyKilled()
    {
        Kills++;
        killsUI.text = Kills.ToString();
        enemyCounter--;
        if(enemyCounter == 0)
        {
            timeControl.GetComponent<TimeControl>().Score();
           // SceneManager.LoadScene("WinMenu");
        }

    }

    public void EggsCount()
    {
        eggsRemaining--;

        if(eggsRemaining == 0)
        {
           // Time.timeScale = 0f;
            SceneManager.LoadScene("GameOverMenu");
        }
    }
}
