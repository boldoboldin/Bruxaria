using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private PlayerCtrl player;
    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private UI_CraftingSystem uiCraftingSystem;

    // Start is called before the first frame update
    void Start()
    {
        uiInventory.SetPlayer(player);
        uiInventory.SetInventory(player.GetInventory());

        CraftingSystem craftingSystem = new CraftingSystem();
        //Item item = new Item { itemType = Item.ItemType.Diamond, amount = 1 };
        //craftingSystem.SetItem(item, 0, 0);
        //Debug.Log(craftingSystem.GetItem(0, 0));

        uiCraftingSystem.SetCraftingSystem(craftingSystem);
    }
}
