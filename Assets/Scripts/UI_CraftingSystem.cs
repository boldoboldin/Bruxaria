using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CraftingSystem : MonoBehaviour
{

    [SerializeField] private Transform prefabUI_Item;

    private Transform[,] slotTransformArray;
    private Transform recipeSlotTransform, itemContainer;
    private CraftingSystem craftingSystem;

    private void Awake()
    {
        Transform gridContainer = transform.Find("GridContainer");
        itemContainer = transform.Find("ItemSlotContainer");

        slotTransformArray = new Transform[CraftingSystem.gridSizeX, CraftingSystem.gridSizeY];

        int x = 0;

        for (int y = 0; y < CraftingSystem.gridSizeY; y++)
        {
            slotTransformArray[x, y] = gridContainer.Find("Slot[" + x + "_" + y + "]");
            UI_CraftingSlot craftingSlot = slotTransformArray[x, y].GetComponent<UI_CraftingSlot>();
            craftingSlot.SetXY(x, y);
            craftingSlot.OnItemDropped += UI_CraftingSystem_OnItemDropped;

            Debug.Log(x);
            Debug.Log(y);
        }
        

        recipeSlotTransform = transform.Find("RecipeSlot");
        Debug.Log("Encontrou RecipeSlot");

        //CreateItem(0, 0, new ItensCtrl { itemType = ItensCtrl.ItemType.Ruby });
        //CreateRecipeItem(0, 0, new ItensCtrl { itemType = ItensCtrl.ItemType.Sapphire });
    }

    public void SetCraftingSystem(CraftingSystem craftingSystem)
    {
        this.craftingSystem = craftingSystem;
        craftingSystem.OnGridChanged += CraftingSystem_OnGridChanged;

        UpdateVisual();
    }

    private void CraftingSystem_OnGridChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UI_CraftingSystem_OnItemDropped(object sender, UI_CraftingSlot.OnItemDroppedEventArgs e)
    {
        craftingSystem.TryAddItem(e.item, e.x, e.y);
    }

    private void UpdateVisual()
    {
        // Clear old items
        foreach (Transform child in itemContainer)
        {
            Destroy(child.gameObject);
        }

        // Cycle through grid and spawn items
        for (int x = 0; x < CraftingSystem.gridSizeX; x++)
        {
            for (int y = 0; y < CraftingSystem.gridSizeY; y++)
            {
                if (!craftingSystem.IsEmpty(x, y))
                {
                    CreateItem(x, y, craftingSystem.GetItem(x, y));
                }
            }
        }

        if (craftingSystem.GetOutputItem() != null)
        {
            CreateRecipeItem(craftingSystem.GetOutputItem());
        }
    }

    private void CreateItem (int x, int y, ItensCtrl item)
    {
        Transform itemTransform = Instantiate(prefabUI_Item, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = slotTransformArray[x, y].GetComponent<RectTransform>().anchoredPosition;
        itemTransform.GetComponent<UI_Item>().SetItem(item);
        Debug.Log("Craftou errado");

    }

    private void CreateRecipeItem(ItensCtrl item)
    {
        Transform itemTransform = Instantiate(prefabUI_Item, itemContainer);
        RectTransform itemRectTransform = itemTransform.GetComponent<RectTransform>();
        itemRectTransform.anchoredPosition = recipeSlotTransform.GetComponent<RectTransform>().anchoredPosition;
        itemTransform.GetComponent<UI_Item>().SetItem(item);

        Debug.Log("Craftou certo");
    }
}
