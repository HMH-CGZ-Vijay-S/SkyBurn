using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int maxSpawns=10,spawningCount = 0;
    public GameObject bullet;
    public int bulletspeed;
    public Color bulletColor;
    private List<GameObject> spawningBullets= new List<GameObject>();

    private void OnEnable()
    {
        InvokeRepeating("BulletSpawner", 0, .1f);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale==1)
            {
                Time.timeScale = 0;
            }
            else
                Time.timeScale = 1;

        }
    }


    void BulletSpawner()
    {
        if (spawningBullets.Count <= maxSpawns)
        {
            GameObject currentbullet = Instantiate(bullet,transform.position,transform.rotation);
            currentbullet.GetComponent<Bullet>().SetBullet(transform.rotation,transform.position,1+ bulletspeed, 1+ (bulletspeed/10));
            currentbullet.GetComponent<SpriteRenderer>().color = bulletColor;
            spawningBullets.Add(currentbullet);
        }
        else
        {
            spawningBullets[spawningCount].SetActive(true);
            spawningBullets[spawningCount].transform.position = transform.position;
            spawningBullets[spawningCount].transform.rotation = transform.rotation;

            spawningCount++;
            if (spawningCount > maxSpawns)
                spawningCount = 0;

        }


    }
    private void OnDisable()
    {
        CancelInvoke("BulletSpawner");
        foreach (GameObject _bullet in spawningBullets)
        {
            if(_bullet!=null)
            _bullet.SetActive(false);
        }
    }
}
