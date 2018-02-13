+using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

//GameData
public class GameData
{

}

//PlayerData
public class PlayerData
{
    public string Name;
    public PlayerLevels Levels;
}

public class PlayerLevels
{
    public int TotalLevel;
    public int CombatXP;
    public int CombatLevel;
    public int WoodCuttingXP;
    public int WoodCuttingLevel;
    public int MiningXP;
    public int MiningLevel;

    public void AddXP(Level WhichLevelToAdd, int AmountXP)
    {
        switch (WhichLevelToAdd)
        {
            case Level.Combat:
                CombatXP = CombatXP + AmountXP;
                CombatLevel = CalculateLevel(CombatXP);
                break;
            case Level.WoodCutting:
                WoodCuttingXP = WoodCuttingXP + AmountXP;
                WoodCuttingLevel = CalculateLevel(WoodCuttingXP);
                break;
            case Level.Mining:
                MiningXP = MiningXP + AmountXP;
                MiningLevel = CalculateLevel(MiningXP);
                break;
        }
        TotalLevel = CombatLevel + WoodCuttingLevel + MiningLevel;
    }

    int CalculateLevel(int XP)
    {
        if(XP / 10 < 1)
        {
            return 1;
        }
        else return XP / 10;
        //NeedsMore
    }

    public enum Level
{
    Combat,
    WoodCutting,
    Mining
}
}