
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : IItemHolder
{
    public const int gridSizeX = 1;
    public const int gridSizeY = 3;

    public event EventHandler OnGridChanged;

    private Dictionary<ItensCtrl.ItemType, ItensCtrl.ItemType[,]> recipeDictionary;

    private ItensCtrl[,] itemArray;
    private ItensCtrl outputItem;

    public CraftingSystem()
    {
        itemArray = new ItensCtrl[gridSizeX, gridSizeY];

        recipeDictionary = new Dictionary<ItensCtrl.ItemType, ItensCtrl.ItemType[,]>();

        //Diamond 
        ItensCtrl.ItemType[,] recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Ruby;
        recipe[0, 1] = ItensCtrl.ItemType.Emerald;
        recipe[0, 2] = ItensCtrl.ItemType.Sapphire;
        recipeDictionary[ItensCtrl.ItemType.Diamond] = recipe;

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Tourmaline;
        recipe[0, 1] = ItensCtrl.ItemType.Amethysta;
        recipe[0, 2] = ItensCtrl.ItemType.Citrine;
        recipeDictionary[ItensCtrl.ItemType.Onyx] = recipe;
    }

    public bool IsEmpty(int x, int y)
    {
        return itemArray[x, y] == null;
    }

    public ItensCtrl GetItem(int x, int y)
    {
        return itemArray[x, y];
    }

    public void SetItem (ItensCtrl item, int x, int y)
    {
        if (item != null)
        {
            item.RemoveFromItemHolder();
            item.SetItemHolder(this);
        }
        itemArray[x, y] = item;
        CreateOutput();
        OnGridChanged?.Invoke(this, EventArgs.Empty);
    }

    public void IncreaseItemAMount (int x, int y)
    {
        GetItem(x, y).amount++;
        OnGridChanged?.Invoke(this, EventArgs.Empty);
    }

    public void DecreaseItemAmount(int x, int y)
    {
        if (GetItem(x, y) != null)
        {
            GetItem(x, y).amount--;
            if (GetItem(x, y).amount == 0)
            {
                RemoveItem(x, y);
            }
            OnGridChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public void RemoveItem(int x, int y)
    {
        SetItem(null, x, y);
    }

    public bool TryAddItem(ItensCtrl item, int x, int y)
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

    public void RemoveItem(ItensCtrl item)
    {
        if (item == outputItem)
        {
            // Removed output item
            ConsumeRecipeItems();
            CreateOutput();
            OnGridChanged?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            // Removed item from grid
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (GetItem(x, y) == item)
                    {
                        // Removed this one
                        RemoveItem(x, y);
                    }
                }
            }
        }
    }

    public void AddItem(ItensCtrl item) { }

    public bool CanAddItem() { return false; }

    private ItensCtrl.ItemType GetRecipeOutput()
    {
        foreach (ItensCtrl.ItemType recipeItemType in recipeDictionary.Keys)
        {
            ItensCtrl.ItemType[,] recipe = recipeDictionary[recipeItemType];

            bool completeRecipe = true;
            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    if (recipe[x, y] != ItensCtrl.ItemType.None)
                    {
                        // Recipe has Item in this position
                        if (IsEmpty(x, y) || GetItem(x, y).itemType != recipe[x, y])
                        {
                            // Empty position or different itemType
                            completeRecipe = false;
                        }
                    }
                }
            }

            if (completeRecipe)
            {
                return recipeItemType;
            }
        }
        return ItensCtrl.ItemType.None;
    }

    private void CreateOutput()
    {
        ItensCtrl.ItemType recipeOutput = GetRecipeOutput();
        if (recipeOutput == ItensCtrl.ItemType.None)
        {
            outputItem = null;
        }
        else
        {
            outputItem = new ItensCtrl { itemType = recipeOutput };
            outputItem.SetItemHolder(this);
        }
    }

    public ItensCtrl GetOutputItem()
    {
        return outputItem;
    }

    public void ConsumeRecipeItems()
    {
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                DecreaseItemAmount(x, y);
            }
        }
    }
}
