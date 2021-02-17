

using System;
using UnityEngine;

public static class GameActions 
{
    public static event Action STARTGAME,GAMEOVER;
    //public static event Action<int> HEALTH;
    public static event Action<PowerUps, Vector3> SETPOWERUP;

    public static event Action<int> LEVEL;


    public static void FIREGAMEOVER()
    {
        GAMEOVER?.Invoke();
    }
    public static void FIRESTARTGAME()
    {
        STARTGAME?.Invoke();
    }

    public static void FIRELEVEL(int value)
    {
        LEVEL?.Invoke(value);
    }
    public static void FIRESETPOWERUP(PowerUps _power, Vector3 pos )

    {
        SETPOWERUP?.Invoke(_power,pos);
}
}
