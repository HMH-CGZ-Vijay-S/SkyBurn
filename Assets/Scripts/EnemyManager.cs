using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : EnemyDataFactory
{
    public GameObject enemySmall,enemyMedium,enemyLarge,enemyMediumAnimated;
    public List<GameObject> smallEnemys,mediumEnemys,smallWave,animatedMedium;

    private int maxEnemysCount=10;
    private int levelNUmber=1;
    private void Start()
    {
    }
    private void Awake()
    {
        GameActions.GAMEOVER += GameActions_GAMEOVE;
        GameActions.STARTGAME += GameActions_STARTGAME;
        GameActions.LEVEL += GameActions_LEVEL;
    }

    private void GameActions_LEVEL(int value)
    {

     levelNUmber=value;
    }

    private void GameActions_STARTGAME()
    {
        Invoke("SpawnEnemies", 2);
    }

    private void GameActions_GAMEOVE()
    {
        CancelInvoke();
        StopAllCoroutines();
    }

    void SpawnEnemies()
    {
      EnemyData currentData  = Getenemys(levelNUmber);

        if(currentData.smallJets)
        {
            InvokeRepeating( "SpawnSmallJet",0,1);
        }
        if (currentData.mediumJets)
        {
            InvokeRepeating("SpawnMediumJet", 10, 10);
        }
        if(currentData.animatedMediumJets)
        {
            InvokeRepeating("SpawnAnimatedMediumJet", 10, 10);
        }
        if (currentData.animatedSmallJets)
        {
            StartCoroutine("SpawnSmallWave",25);
        }
        Invoke("SpawnLargeJet", currentData.finalEnemyTime);
    }

    void SpawnSmallJet()
    {
        Vector2 randomPosition = new Vector2(Random.Range(ScreenManager.instance.minX,ScreenManager.instance.maxX),ScreenManager.instance.maxY);

            for (int enemyNumber = 0; enemyNumber < smallEnemys.Count; enemyNumber++)
            {
            if (smallEnemys[enemyNumber] != null && !smallEnemys[enemyNumber].activeSelf)
            {
                smallEnemys[enemyNumber].transform.position = randomPosition;
                smallEnemys[enemyNumber].SetActive(true);
                return;
            }

            }

        smallEnemys.Add(Instantiate(enemySmall, randomPosition, Quaternion.identity));


    }
    void SpawnMediumJet()
    {
        Vector2 randomPosition = new Vector2(Random.Range(ScreenManager.instance.minX, ScreenManager.instance.maxX), ScreenManager.instance.maxY);

        for (int enemyNumber = 0; enemyNumber < mediumEnemys.Count; enemyNumber++)
        {
            if (mediumEnemys[enemyNumber] != null && !mediumEnemys[enemyNumber].activeSelf)
            {
                mediumEnemys[enemyNumber].transform.position = randomPosition;
                mediumEnemys[enemyNumber].SetActive(true);
                return;
            }

        }

        mediumEnemys.Add(Instantiate(enemyMedium, randomPosition, Quaternion.identity));


    }
    void SpawnAnimatedMediumJet()
    {
        Vector2 randomPosition = new Vector2(Random.Range(ScreenManager.instance.minX, ScreenManager.instance.maxX), ScreenManager.instance.maxY);

        for (int enemyNumber = 0; enemyNumber < animatedMedium.Count; enemyNumber++)
        {
            if (animatedMedium[enemyNumber] != null && !animatedMedium[enemyNumber].activeSelf)
            {
                animatedMedium[enemyNumber].transform.position = randomPosition;
                animatedMedium[enemyNumber].SetActive(true);
                return;
            }

        }

        animatedMedium.Add(Instantiate(enemyMediumAnimated, randomPosition, Quaternion.identity));


    }
    IEnumerator SpawnSmallWave(int value)
    {
        yield return new WaitForSeconds(value);

        Vector2 randomPosition = new Vector2(ScreenManager.instance.minX, ScreenManager.instance.maxY);

        for (int enemyNumber = 0; enemyNumber < 10; enemyNumber++)
        {
            if (smallWave.Count>enemyNumber && !smallWave[enemyNumber].activeSelf)
            {
                smallWave[enemyNumber].transform.position = randomPosition;
                smallWave[enemyNumber].SetActive(true);
            }
            else
            {
                GameObject wave = Instantiate(enemySmall, randomPosition, Quaternion.identity);
                wave.AddComponent<EnemySmallWave>();
                smallWave.Add(wave);

            }

            yield return new WaitForSeconds(1);
        }

        StartCoroutine("SpawnSmallWave", 20);



    }
    void SpawnLargeJet()
    {
        Instantiate(enemyLarge, new Vector3(0,ScreenManager.instance.maxY+2), Quaternion.identity);

    }
    private void OnDestroy()
    {
        GameActions.GAMEOVER -= GameActions_GAMEOVE;
        GameActions.STARTGAME -= GameActions_STARTGAME;
        GameActions.LEVEL -= GameActions_LEVEL;



    }

}



