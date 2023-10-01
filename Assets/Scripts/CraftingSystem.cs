
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem
{
    public const int gridSizeX = 1;
    public const int gridSizeY = 3;
    private ItensCtrl[,] itemArray;
    
    public CraftingSystem()
    {
        itemArray = new ItensCtrl[gridSizeX, gridSizeY];
    }

    private bool IsEmpty(int x, int y)
    {
        return itemArray[x, y] == null;
    }

    private ItensCtrl GetItem(int x, int y)
    {
        return itemArray[x, y];
    }

    private void SetItem (ItensCtrl item, int x, int y)
    {
        itemArray[x, y] = item;
    }

    private void IncreaseItemAMount (int x, int y)
    {
        GetItem(x, y).amount++;
    }

    private void DecreaseItemAMount(int x, int y)
    {
        GetItem(x, y).amount--;
    }

    private void RemoveItem(int x, int y)
    {
        SetItem(null, x, y);
    }

    private bool TryAddItem(ItensCtrl item, int x, int y)
    {
        if (IsEmpty(x, y))
        {
            SetItem(item, x, y);
            return true;
        }
        else
        {
            if (item.itemType == GetItem(x, y).itemType)
            {
                IncreaseItemAMount(x, y);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
