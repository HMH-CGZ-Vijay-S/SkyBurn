
using UnityEngine;

public abstract class HeroJet : Jet
{
    protected float planeBuffer;

    public HeroJet()
    {
        planeBuffer = SetBounds();
    }

    public abstract void GameActions_STARTGAME();
    public abstract void StopAnimation();

    public abstract void SetPower(PowerUps powerUps);

    public virtual float SetBounds()
    {
        return 0.1f;
    }

    public abstract void Shooting();

}
