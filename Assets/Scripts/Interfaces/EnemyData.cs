
using UnityEngine;

public struct EnemyData
{
    public bool smallJets;
    public bool mediumJets;
    public bool largeJets;
    public bool animatedSmallJets;
    public bool animatedMediumJets;
    public int finalEnemyTime;
}

interface IEnemyData
{
    EnemyData Getenemys(int level);
}

interface ILevelEnemyData
{
    EnemyData GetLevelEnemyData();
}


public abstract class EnemyDataFactory : MonoBehaviour, IEnemyData
{

    public EnemyData Getenemys(int level)
    {
        ILevelEnemyData enemyData = new Level1EnemyData();
        switch (level)
        {
            case 1:
                enemyData = new Level1EnemyData();
                break;
            case 2:
                enemyData = new Level2EnemyData();
                break;
            case 3:
                enemyData = new Level3EnemyData();
                break;
            case 4:
                enemyData = new Level4EnemyData();
                break;
            case 5:
                enemyData = new Level5EnemyData();
                break;
        }
        return enemyData.GetLevelEnemyData();
    }
}



public class Level1EnemyData : ILevelEnemyData
{
    public EnemyData GetLevelEnemyData()
    {
        EnemyData enemyData = new EnemyData
        {
            smallJets = true,
            mediumJets = true,
            finalEnemyTime = 20
        };
        return enemyData;
    }
}
public class Level2EnemyData : ILevelEnemyData
{
    public EnemyData GetLevelEnemyData()
    {
        EnemyData enemyData = new EnemyData();
        enemyData.smallJets = true;
        enemyData.mediumJets = true;
        enemyData.animatedSmallJets = true;
        enemyData.finalEnemyTime = 30;
        return enemyData;
    }
}
public class Level3EnemyData : ILevelEnemyData
{
    public EnemyData GetLevelEnemyData()
    {
        EnemyData enemyData = new EnemyData();
        enemyData.smallJets = true;
        enemyData.mediumJets = true;
        enemyData.animatedSmallJets = true;
        enemyData.finalEnemyTime = 40;
        return enemyData;
    }
}
public class Level4EnemyData : ILevelEnemyData
{
    public EnemyData GetLevelEnemyData()
    {
        EnemyData enemyData = new EnemyData();
        enemyData.smallJets = true;
        enemyData.animatedSmallJets = true;
        enemyData.animatedMediumJets = true;
        enemyData.finalEnemyTime = 40;
        return enemyData;
    }
}
public class Level5EnemyData : ILevelEnemyData
{
    public EnemyData GetLevelEnemyData()
    {
        EnemyData enemyData = new EnemyData();
        enemyData.smallJets = true;
        enemyData.mediumJets = true;
        enemyData.animatedSmallJets = true;
        enemyData.animatedMediumJets = true;
        enemyData.finalEnemyTime = 40;
        return enemyData;
    }
}

