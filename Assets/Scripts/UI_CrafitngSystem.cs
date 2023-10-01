using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CrafitngSystem : MonoBehaviour
{

    [SerializeField] private Transform prefabUI_Item;

    private Transform[,] slotTransformArray;
    private Transform recipeSlotTransform, itemContainer;

    private void Awake()
    {
        Transform gridContainer = transform.Find("GridContainer");

        itemContainer = transform.Find("ItemContainer");
        slotTransformArray = new Transform[CraftingSystem.gridSizeX, CraftingSystem.gridSizeY];

        for (int x = 0; x < CraftingSystem.gridSizeX; x++)
        {
            for (int y = 0; y < CraftingSystem.gridSizeY; y++)
            {
                slotTransformArray[x, y] = gridContainer.Find("Grid[" + x + "_" + y + "]");
            }
        }

        recipeSlotTransform = transform.Find("RecipeSlot");

        CreateItem(0, 0, new ItensCtrl { itemType = ItensCtrl.ItemType.Ruby });
        CreateRecipeItem(0, 0, new ItensCtrl { itemType = ItensCtrl.ItemType.Sapphire });
    }

    private void CreateItem (int x, int y, ItensCtrl item)
    {
        Transform itemTransform = Instantiate(prefabUI_Item, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = slotTransformArray[x, y].GetComponent<RectTransform>().anchoredPosition;
        //itemTransform.GetComponent<DragDropSystem>().SetItem(item);
    }

    private void CreateRecipeItem(int x, int y, ItensCtrl item)
    {
        Transform itemTransform = Instantiate(prefabUI_Item, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = recipeSlotTransform.GetComponent<RectTransform>().anchoredPosition;
        //itemTransform.GetComponent<DragDropSystem>().SetItem(item);
    }
}
