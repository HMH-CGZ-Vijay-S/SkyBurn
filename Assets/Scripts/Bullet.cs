using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool heroBullet;
    public int bulletPower;
    float booletSpeed;


    public void SetBullet(Quaternion _rotatation, Vector3 _position,int _bulletPower, float _booletSpeed=0.2f)
    {
        transform.rotation=_rotatation;
        transform.localPosition = _position;
        bulletPower = _bulletPower;
        booletSpeed = _booletSpeed;

    }

    void Update()
    {
        transform.Translate(transform.up * Utility.bulletSpeed * Time.deltaTime* booletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamage damage = collision.GetComponent<HeroJet>();
        if(heroBullet)
        {
            damage  = collision.GetComponent<Enemy>();
        }
        if (damage != null)
        {
            damage.GiveDamage(bulletPower);
            gameObject.SetActive(false);

        }
    }
}

