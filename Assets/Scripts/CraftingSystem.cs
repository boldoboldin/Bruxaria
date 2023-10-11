
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : IItemHolder
{
    public const int gridSizeX = 1;
    public const int gridSizeY = 3;

    public event EventHandler OnGridChanged;

    private Dictionary<ItensCtrl.ItemType, List<ItensCtrl.ItemType[,]>> recipeDictionary;

    private ItensCtrl[,] itemArray;
    private ItensCtrl outputItem;

    public CraftingSystem()
    {
        itemArray = new ItensCtrl[gridSizeX, gridSizeY];

        recipeDictionary = new Dictionary<ItensCtrl.ItemType, List<ItensCtrl.ItemType[,]>>();

        //Diamond Recipes
        List<ItensCtrl.ItemType[,]> diamondRecipes = new List<ItensCtrl.ItemType[,]>();

        ItensCtrl.ItemType[,] recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Ruby;
        recipe[0, 1] = ItensCtrl.ItemType.Emerald;
        recipe[0, 2] = ItensCtrl.ItemType.Sapphire;
        diamondRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Ruby;
        recipe[0, 1] = ItensCtrl.ItemType.Sapphire;
        recipe[0, 2] = ItensCtrl.ItemType.Emerald;
        diamondRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Emerald;
        recipe[0, 1] = ItensCtrl.ItemType.Ruby;
        recipe[0, 2] = ItensCtrl.ItemType.Sapphire;
        diamondRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Emerald;
        recipe[0, 1] = ItensCtrl.ItemType.Sapphire;
        recipe[0, 2] = ItensCtrl.ItemType.Ruby;
        diamondRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Sapphire;
        recipe[0, 1] = ItensCtrl.ItemType.Ruby;
        recipe[0, 2] = ItensCtrl.ItemType.Emerald;
        diamondRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Sapphire;
        recipe[0, 1] = ItensCtrl.ItemType.Emerald;
        recipe[0, 2] = ItensCtrl.ItemType.Ruby;
        diamondRecipes.Add(recipe);

        recipeDictionary[ItensCtrl.ItemType.Diamond] = diamondRecipes;

        //Amethysta Recipes
        List<ItensCtrl.ItemType[,]> amethystaRecipes = new List<ItensCtrl.ItemType[,]>();

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Ruby;
        recipe[0, 1] = ItensCtrl.ItemType.Sapphire;
        recipe[0, 2] = ItensCtrl.ItemType.None;
        amethystaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Ruby;
        recipe[0, 1] = ItensCtrl.ItemType.None;
        recipe[0, 2] = ItensCtrl.ItemType.Sapphire;
        amethystaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Sapphire;
        recipe[0, 1] = ItensCtrl.ItemType.Ruby;
        recipe[0, 2] = ItensCtrl.ItemType.None;
        amethystaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Sapphire;
        recipe[0, 1] = ItensCtrl.ItemType.None;
        recipe[0, 2] = ItensCtrl.ItemType.Ruby;
        amethystaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.None;
        recipe[0, 1] = ItensCtrl.ItemType.Ruby;
        recipe[0, 2] = ItensCtrl.ItemType.Sapphire;
        amethystaRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.None;
        recipe[0, 1] = ItensCtrl.ItemType.Sapphire;
        recipe[0, 2] = ItensCtrl.ItemType.Ruby;
        amethystaRecipes.Add(recipe);

        recipeDictionary[ItensCtrl.ItemType.Amethysta] = amethystaRecipes;

        //Citrine Recipes
        List<ItensCtrl.ItemType[,]> citrineRecipes = new List<ItensCtrl.ItemType[,]>();

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Ruby;
        recipe[0, 1] = ItensCtrl.ItemType.Emerald;
        recipe[0, 2] = ItensCtrl.ItemType.None;
        citrineRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Ruby;
        recipe[0, 1] = ItensCtrl.ItemType.None;
        recipe[0, 2] = ItensCtrl.ItemType.Emerald;
        citrineRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Emerald;
        recipe[0, 1] = ItensCtrl.ItemType.Ruby;
        recipe[0, 2] = ItensCtrl.ItemType.None;
        citrineRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Emerald;
        recipe[0, 1] = ItensCtrl.ItemType.None;
        recipe[0, 2] = ItensCtrl.ItemType.Ruby;
        citrineRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.None;
        recipe[0, 1] = ItensCtrl.ItemType.Ruby;
        recipe[0, 2] = ItensCtrl.ItemType.Emerald;
        citrineRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.None;
        recipe[0, 1] = ItensCtrl.ItemType.Emerald;
        recipe[0, 2] = ItensCtrl.ItemType.Ruby;
        citrineRecipes.Add(recipe);

        recipeDictionary[ItensCtrl.ItemType.Citrine] = citrineRecipes;

        //Tourmaline Recipes
        List<ItensCtrl.ItemType[,]> tourmalineRecipes = new List<ItensCtrl.ItemType[,]>();

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Sapphire;
        recipe[0, 1] = ItensCtrl.ItemType.Emerald;
        recipe[0, 2] = ItensCtrl.ItemType.None;
        tourmalineRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Sapphire;
        recipe[0, 1] = ItensCtrl.ItemType.None;
        recipe[0, 2] = ItensCtrl.ItemType.Emerald;
        tourmalineRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Emerald;
        recipe[0, 1] = ItensCtrl.ItemType.Sapphire;
        recipe[0, 2] = ItensCtrl.ItemType.None;
        tourmalineRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Emerald;
        recipe[0, 1] = ItensCtrl.ItemType.None;
        recipe[0, 2] = ItensCtrl.ItemType.Sapphire;
        tourmalineRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.None;
        recipe[0, 1] = ItensCtrl.ItemType.Sapphire;
        recipe[0, 2] = ItensCtrl.ItemType.Emerald;
        tourmalineRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.None;
        recipe[0, 1] = ItensCtrl.ItemType.Emerald;
        recipe[0, 2] = ItensCtrl.ItemType.Sapphire;
        tourmalineRecipes.Add(recipe);

        recipeDictionary[ItensCtrl.ItemType.Tourmaline] = tourmalineRecipes;

        //Onyx Recipes
        List<ItensCtrl.ItemType[,]> onyxRecipes = new List<ItensCtrl.ItemType[,]>();

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Tourmaline;
        recipe[0, 1] = ItensCtrl.ItemType.Amethysta;
        recipe[0, 2] = ItensCtrl.ItemType.Citrine;
        onyxRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Tourmaline;
        recipe[0, 1] = ItensCtrl.ItemType.Citrine;
        recipe[0, 2] = ItensCtrl.ItemType.Amethysta;
        onyxRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Amethysta;
        recipe[0, 1] = ItensCtrl.ItemType.Tourmaline;
        recipe[0, 2] = ItensCtrl.ItemType.Citrine;
        onyxRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Amethysta;
        recipe[0, 1] = ItensCtrl.ItemType.Citrine;
        recipe[0, 2] = ItensCtrl.ItemType.Tourmaline;
        onyxRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Citrine;
        recipe[0, 1] = ItensCtrl.ItemType.Tourmaline;
        recipe[0, 2] = ItensCtrl.ItemType.Amethysta;
        onyxRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Citrine;
        recipe[0, 1] = ItensCtrl.ItemType.Amethysta;
        recipe[0, 2] = ItensCtrl.ItemType.Tourmaline;
        onyxRecipes.Add(recipe);

        recipeDictionary[ItensCtrl.ItemType.Onyx] = onyxRecipes;

        //Ruby Recipes
        List<ItensCtrl.ItemType[,]> rubyRecipes = new List<ItensCtrl.ItemType[,]>();

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Amethysta;
        recipe[0, 1] = ItensCtrl.ItemType.Citrine;
        recipe[0, 2] = ItensCtrl.ItemType.None;
        rubyRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Amethysta;
        recipe[0, 1] = ItensCtrl.ItemType.None;
        recipe[0, 2] = ItensCtrl.ItemType.Citrine;
        rubyRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Citrine;
        recipe[0, 1] = ItensCtrl.ItemType.Amethysta;
        recipe[0, 2] = ItensCtrl.ItemType.None;
        rubyRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Citrine;
        recipe[0, 1] = ItensCtrl.ItemType.None;
        recipe[0, 2] = ItensCtrl.ItemType.Amethysta;
        rubyRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.None;
        recipe[0, 1] = ItensCtrl.ItemType.Citrine;
        recipe[0, 2] = ItensCtrl.ItemType.Amethysta;
        rubyRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.None;
        recipe[0, 1] = ItensCtrl.ItemType.Amethysta;
        recipe[0, 2] = ItensCtrl.ItemType.Citrine;
        rubyRecipes.Add(recipe);

        recipeDictionary[ItensCtrl.ItemType.Ruby] = rubyRecipes;

        //Emerald Recipes
        List<ItensCtrl.ItemType[,]> emeraldRecipes = new List<ItensCtrl.ItemType[,]>();

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Tourmaline;
        recipe[0, 1] = ItensCtrl.ItemType.Citrine;
        recipe[0, 2] = ItensCtrl.ItemType.None;
        emeraldRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Tourmaline;
        recipe[0, 1] = ItensCtrl.ItemType.None;
        recipe[0, 2] = ItensCtrl.ItemType.Citrine;
        emeraldRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Citrine;
        recipe[0, 1] = ItensCtrl.ItemType.Tourmaline;
        recipe[0, 2] = ItensCtrl.ItemType.None;
        emeraldRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Citrine;
        recipe[0, 1] = ItensCtrl.ItemType.None;
        recipe[0, 2] = ItensCtrl.ItemType.Tourmaline;
        emeraldRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.None;
        recipe[0, 1] = ItensCtrl.ItemType.Citrine;
        recipe[0, 2] = ItensCtrl.ItemType.Tourmaline;
        emeraldRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.None;
        recipe[0, 1] = ItensCtrl.ItemType.Tourmaline;
        recipe[0, 2] = ItensCtrl.ItemType.Citrine;
        emeraldRecipes.Add(recipe);

        recipeDictionary[ItensCtrl.ItemType.Emerald] = emeraldRecipes;

        //Sapphire Recipes
        List<ItensCtrl.ItemType[,]> sapphireRecipes = new List<ItensCtrl.ItemType[,]>();

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Tourmaline;
        recipe[0, 1] = ItensCtrl.ItemType.Amethysta;
        recipe[0, 2] = ItensCtrl.ItemType.None;
        sapphireRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Tourmaline;
        recipe[0, 1] = ItensCtrl.ItemType.None;
        recipe[0, 2] = ItensCtrl.ItemType.Amethysta;
        sapphireRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Amethysta;
        recipe[0, 1] = ItensCtrl.ItemType.Tourmaline;
        recipe[0, 2] = ItensCtrl.ItemType.None;
        sapphireRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.Amethysta;
        recipe[0, 1] = ItensCtrl.ItemType.None;
        recipe[0, 2] = ItensCtrl.ItemType.Tourmaline;
        sapphireRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.None;
        recipe[0, 1] = ItensCtrl.ItemType.Amethysta;
        recipe[0, 2] = ItensCtrl.ItemType.Tourmaline;
        sapphireRecipes.Add(recipe);

        recipe = new ItensCtrl.ItemType[gridSizeX, gridSizeY];
        recipe[0, 0] = ItensCtrl.ItemType.None;
        recipe[0, 1] = ItensCtrl.ItemType.Tourmaline;
        recipe[0, 2] = ItensCtrl.ItemType.Amethysta;
        sapphireRecipes.Add(recipe);

        recipeDictionary[ItensCtrl.ItemType.Sapphire] = sapphireRecipes;
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
            List<ItensCtrl.ItemType[,]> recipeList = recipeDictionary[recipeItemType];

            foreach (ItensCtrl.ItemType[,] recipe in recipeList)
            {
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
