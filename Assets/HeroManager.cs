using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    private GameObject heroObject;
    public GameObject HeroPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        GameActions.STARTGAME += GameActions_STARTGAME;
        
    }

    private void GameActions_STARTGAME()
    {
        if (heroObject == null)
            heroObject = Instantiate(HeroPrefab);

        heroObject.SetActive(true);
    }

    // Update is called once per frame
    void OnDestroy()
    {
        GameActions.STARTGAME -= GameActions_STARTGAME;


    }
}
