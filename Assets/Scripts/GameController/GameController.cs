using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

}

//GameData
public class GameData
{

}

//PlayerData
public class PlayerData
{
    public string Name = "Name";
    public PlayerLevels Levels = new PlayerLevels();
    public Inventory Inventory = new Inventory();
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
        if (XP / 10 < 1)
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

public class Inventory
{
    public bool LimitedStorage = true;
    public int StorageLimit = 1;
    public List<ItemData> CurrentInv = new List<ItemData>();

    public bool AddInvItem(ItemData ItemToAdd)
    {
        if (CheckCanStore())
        {
            for (int EachListItem = 0; EachListItem < CurrentInv.Count; EachListItem++)
            {
                if (CurrentInv[EachListItem].Name == ItemToAdd.Name)
                {
                    CurrentInv[EachListItem].Quantity++;
                }
                else
                {
                    CurrentInv.Add(ItemToAdd);
                }
            }
            return true;
        }
        return false;
    }

    bool CheckCanStore()
    {
        //check if storage full
        return true;
    }

    public void RemoveItem(ItemData ItemToAdd)
    {

    }
}

[System.Serializable]
public class ItemData
{
    public string Name;
    public int Weight;
    public string Info;
    public int Quantity;

    public ItemData()
    {
        Name = "Nothing";
        Weight = 1;
        Info = "Some info about the item!";
        Quantity = 1;
    }

}