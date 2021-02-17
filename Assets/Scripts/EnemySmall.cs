using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmall : Enemy
{
    public override void CheckDamage()
    {
        if(Health<=0)
        {
            gameObject.SetActive(false);
            UIManager.instannce.AddScore(10);

        }
    }

    public override void SetInitialValues()
    {
        Health = jetHealth;
    }

    public override void SetMovement()
    {
        transform.Translate(Vector3.down*jetSpeed*Time.deltaTime);
    }
    public override void Shoot()
    {
        GameObject hero = FindObjectOfType<HeroJet>().gameObject;
        Vector2 to = (hero.transform.position- transform.position);

        float angle = Mathf.Atan2(to.y, to.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        //_bullet.transform.rotation = q;// Quaternion.Slerp(transform.rotation, q,1);

        GameObject _bullet = Instantiate(bullet,transform.position,q);

        _bullet.GetComponent<Bullet>().SetBullet(q,transform.position,1);

    }
}
