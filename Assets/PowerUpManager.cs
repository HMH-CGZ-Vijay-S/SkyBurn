using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject powerUp;
    List<GameObject> powers= new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        GameActions.SETPOWERUP += GameActions_SETPOWERUP;
    }

    private void GameActions_SETPOWERUP(PowerUps obj,Vector3 pos)
    {
        for(int i=0;i< powers.Count;i++)
        {
            if(!powers[i].activeSelf)
            {
                powers[i].transform.position = pos;
                powers[i].GetComponent<Power>().powervalue = obj;
                return;

            }
        }

        powers.Add(Instantiate(powerUp,pos,Quaternion.identity));
        powers[powers.Count-1].GetComponent<Power>().powervalue = obj;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        GameActions.SETPOWERUP -= GameActions_SETPOWERUP;

    }
}
