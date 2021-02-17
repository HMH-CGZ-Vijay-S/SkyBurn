using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBig : Enemy
{
    List<GameObject> bullets= new List<GameObject>();
    Vector3 toPosition;
    bool powerRelease = false;
    public override void CheckDamage()
    {
        if (Health < jetHealth / 3 && Random.Range(-2, 30) < 0&& !powerRelease)
        {
            GameActions.FIRESETPOWERUP(PowerUps.p3, transform.position);
            powerRelease = true;

        }
        if (Health<=0)
        {
            GameActions.FIREGAMEOVER();
            UIManager.instannce.AddScore(30);
            gameObject.SetActive(false);
        }

    }

    public override void SetInitialValues()
    {
        Health = jetHealth;
        powerRelease = false;
        toPosition = new Vector3(0, ScreenManager.instance.maxY-1, 0);
    }

    public override void SetMovement()
    {
        transform.position= Vector3.MoveTowards(transform.position, toPosition , jetSpeed*Time.deltaTime);
    }
    public override void Shoot()
    {
        GameObject hero = FindObjectOfType<HeroJet>().gameObject;
        Vector2 to = (hero.transform.position - transform.position);

        float angle = Mathf.Atan2(to.y, to.x) * Mathf.Rad2Deg;
        Quaternion q;
        //_bullet.transform.rotation = q;// Quaternion.Slerp(transform.rotation, q,1);
        if (bullets.Count < 1)
        {
            for (int i = 0; i < 10; i++)
            {
                 q = Quaternion.Euler(new Vector3(0, 0, angle+Random.Range(-5,5)));

                bullets.Add(Instantiate(bullet, transform.position, q));
                bullets[i].GetComponent<Bullet>().SetBullet( q, transform.position, 1);

            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                q = Quaternion.Euler(new Vector3(0, 0, angle + Random.Range(-5, 5)));

                bullets[i].transform.position = transform.position;
                bullets[i].GetComponent<Bullet>().SetBullet(q, transform.position, 1);

                bullets[i].gameObject.SetActive(true);
            }
        }

        Invoke("Shoot", 3);
    }
}
