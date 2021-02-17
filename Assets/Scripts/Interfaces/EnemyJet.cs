
using UnityEngine;

public abstract class Enemy : Jet
{
    public float jetSpeed;
    public GameObject bullet;
    private void OnEnable()
    {
        SetInitialValues();
        Shoot();
    }

    public abstract void SetInitialValues();
    public abstract void SetMovement();
    public abstract void Shoot();

    private void Update()
    {
        SetMovement();

        if(transform.position.y<ScreenManager.instance.minY)
        {
            gameObject.SetActive(false);
        }

    }


}

