

using UnityEngine;

public abstract class Jet : MonoBehaviour ,IDamage
{

    public int jetHealth;

    #region HealthRegion

    protected int Health;

    void OnEnable ()
    {
        Health = jetHealth;
    }

    public void GiveDamage(int damage)
    {
        Health -= damage;
        CheckDamage();
    }
    public abstract void CheckDamage();


    #endregion

    #region ObjectcontrollingRegion
    private void Awake()
    {
        GameActions.GAMEOVER += GameActions_GAMEOVER;
    }

    private void GameActions_GAMEOVER()
    {
        CancelInvoke();
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameActions.GAMEOVER -= GameActions_GAMEOVER;

    }
    #endregion

}

