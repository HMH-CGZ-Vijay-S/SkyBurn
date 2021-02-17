using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroJet1 : HeroJet
{

    [SerializeField] int myJetPower = 10;

    private bool isMouseDown = false;

    private Vector3 inputMousePosition;

    public int speed = 1;
    // Start is called before the first frame update
    public float minX, maxX, minY, maxY;

    PowerUps currentPowerUp= PowerUps.p3;
    [SerializeField] GameObject[] bulletformations;

    

    void Start()
    {

        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = ScreenManager.instance.minX + planeBuffer;
        maxX = ScreenManager.instance.maxX - planeBuffer;
        minY = ScreenManager.instance.minY + planeBuffer;
        maxY = ScreenManager.instance.maxY - planeBuffer;

        GameActions_STARTGAME();

    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isMouseDown = true;
            inputMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMouseDown = false;
        }
        if (isMouseDown)
        {
            if (inputMousePosition != Input.mousePosition)
            {
                Vector3 currentPosition = Input.mousePosition;
                float distance = Vector3.Distance(inputMousePosition, currentPosition);

                Vector3 normalisedvector = (currentPosition - inputMousePosition).normalized;

                transform.Translate(normalisedvector * distance / 2 * speed * Time.deltaTime);
                inputMousePosition = Input.mousePosition;


            }
        }

        Vector2 pos = transform.position;

        if (transform.position.x > maxX)
        {
            pos.x = maxX;
        }
        else if (transform.position.x < minX)
        {
            pos.x = minX;
        }
        if (transform.position.y > maxY)
        {
            pos.y = maxY;
        }
        else if (transform.position.y < minY)
        {
            pos.y = minY;
        }
        transform.position = pos;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamage damage = collision.GetComponent<Jet>();
        if (damage != null)
        {
            damage.GiveDamage(myJetPower);
        }

        Power _power = collision.GetComponent<Power>();
        if(_power!=null)
        {
            SetPower(_power.powervalue);
            collision.gameObject.SetActive(false);
        }
    }



    #region Inherited
    public override void Shooting()
    {
        SetPower(PowerUps.p1);
    }
    public override float SetBounds()
    {
        return 0.2f;
    }
    public override void GameActions_STARTGAME()
    {

        if (gameObject.GetComponent<Animator>())
        {
            gameObject.GetComponent<Animator>().enabled = true;
        }
        Invoke("StopAnimation", 1);
    }

    public override void StopAnimation()
    {
        this.GetComponent<Animator>().enabled = false;
        Shooting();

    }


    public override void CheckDamage()
    {
        if (Health <= 0)
        {
            GameActions.FIREGAMEOVER();
        }
    }

    public override void SetPower(PowerUps powerUps)
    {
        if (currentPowerUp == powerUps)
        {
            return;
        }

        switch (powerUps)
        {
            case PowerUps.p1:
                bulletformations[0].SetActive(true);
                break;
            case PowerUps.p2:
                bulletformations[1].SetActive(true);

                break;
            case PowerUps.p3:
                bulletformations[2].SetActive(true);

                break;
        }
        bulletformations[(int)currentPowerUp].SetActive(false);
        currentPowerUp = powerUps;

    }



    public void SetBulletsOFF()
    {
        foreach (Transform _transform in transform.GetComponentInChildren<Transform>())
        {
            _transform.gameObject.SetActive(false);
        }
    }



    #endregion
}
