using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCtrl : IItemHolder
{
    public event EventHandler OnItemListChanged;
    
    private List<ItensCtrl> itensList;
    private Action<ItensCtrl> useItemAct;
    public InventorySlot[] inventorySlotArray;
    public bool start = true;

    public InventoryCtrl(Action<ItensCtrl> useItemAct, int inventorySlotCount)
    {
        if(start == true)
        {
            this.useItemAct = useItemAct;
            itensList = new List<ItensCtrl>();

            inventorySlotArray = new InventorySlot[inventorySlotCount];
            for (int i = 0; i < inventorySlotCount; i++)
            {
                inventorySlotArray[i] = new InventorySlot(i);
            }

            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.SuorDePombo });

            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.VerrugaDeSapo });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.OlhoDeCobraCega });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.OlhoDePeixe });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.RaboDeCalango });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.PernaDeCobra });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.PernaDeBarata });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.CabeloDeRaboDeRato });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.BundaDeTanajura });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.UnhaDeVelho });

            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.MandiocaBraba });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Amendoim });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Cogumelo });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Azeitona });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.FrutasVermelhas });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.FrutosDoMar });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.SacheDeMiojo });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Adocante });

            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.AlmaDeLagosta });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.RestoDeRaloDePia });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Amarelo });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.TuttiFruti });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.PlutonioEnriquecido });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.CacoDeVidro });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.CheiroDeUnicornio });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.CheiroDeCarro });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.AUltimaLagrima });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Luxuria });

            start = false;
        }
        else
        {
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.SuorDePombo });

            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.VerrugaDeSapo });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.OlhoDeCobraCega });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.OlhoDePeixe });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.RaboDeCalango });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.PernaDeCobra });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.PernaDeBarata });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.CabeloDeRaboDeRato });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.BundaDeTanajura });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.UnhaDeVelho });

            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.MandiocaBraba });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Amendoim });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Cogumelo });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Azeitona });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.FrutasVermelhas });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.FrutosDoMar });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.SacheDeMiojo });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Adocante });

            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.AlmaDeLagosta });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.RestoDeRaloDePia });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Amarelo });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.TuttiFruti });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.PlutonioEnriquecido });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.CacoDeVidro });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.CheiroDeUnicornio });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.CheiroDeCarro });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.AUltimaLagrima });
            AddItem(new ItensCtrl { itemType = ItensCtrl.ItemType.Luxuria });
        }
        
        
    }

    public InventorySlot GetEmptyInventorySlot()
    {
        foreach (InventorySlot inventorySlot in inventorySlotArray)
        {
            if (inventorySlot.IsEmpty())
            {
                return inventorySlot;
            }
        }
        Debug.LogError("Cannot find an empty InventorySlot!");
        return null;
    }

    public InventorySlot GetInventorySlotWithItem(ItensCtrl item)
    {
        foreach (InventorySlot inventorySlot in inventorySlotArray)
        {
            if (inventorySlot.GetItem() == item)
            {
                return inventorySlot;
            }
        }
        Debug.LogError("Cannot find Item " + item + " in a InventorySlot!");
        return null;
    }


    public void AddItem(ItensCtrl item)
    {
        //itensList.Add(item);
        //item.SetItemHolder(this);
        //GetEmptyInventorySlot().SetItem(item);
        //OnItemListChanged?.Invoke(this, EventArgs.Empty);
        AddItemMergeAmount(item);
    }

    public void AddItemMergeAmount(ItensCtrl item)
    {
        if (item.IsStackable())
        {
            bool itemAlredyInInventory = false;

            foreach (ItensCtrl inventory in itensList)
            {
                if (inventory.itemType == item.itemType)
                {
                    inventory.amount += item.amount;
                    itemAlredyInInventory = true;
                }
            }

            if (!itemAlredyInInventory)
            {
                itensList.Add(item);
                item.SetItemHolder(this);
                GetEmptyInventorySlot().SetItem(item);
            }
        }
        else
        {
            itensList.Add(item);
            item.SetItemHolder(this);
            GetEmptyInventorySlot().SetItem(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(ItensCtrl item)
    {
        GetInventorySlotWithItem(item).RemoveItem();
        itensList.Remove(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItemRemoveAmount(ItensCtrl item)
    {
        if (item.IsStackable())
        {
            ItensCtrl itemInInventory = null;

            foreach (ItensCtrl inventory in itensList)
            {
                if (inventory.itemType == item.itemType)
                {
                    inventory.amount -= item.amount;
                    itemInInventory = inventory;
                }
            }

            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                GetInventorySlotWithItem(itemInInventory).RemoveItem();
                itensList.Remove(itemInInventory);
            }
        }
        else
        {
            GetInventorySlotWithItem(item).RemoveItem();
            itensList.Remove(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void AddItem(ItensCtrl item, InventorySlot inventorySlot)
    {
        // Add Item to a specific Inventory slot
        itensList.Add(item);
        item.SetItemHolder(this);
        inventorySlot.SetItem(item);

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem (ItensCtrl item)
    {
        useItemAct(item);
    }

    public List<ItensCtrl> GetItemList()
    {
        return itensList;
    }

    public InventorySlot[] GetInventorySlotArray()
    {
        return inventorySlotArray;
    }

    public bool CanAddItem()
    {
        return GetEmptyInventorySlot() != null;
    }

    public class InventorySlot
    {

        private int index;
        private ItensCtrl item;

        public InventorySlot(int index)
        {
            this.index = index;
        }

        public ItensCtrl GetItem()
        {
            return item;
        }

        public void SetItem(ItensCtrl item)
        {
            this.item = item;
        }

        public void RemoveItem()
        {
            item = null;
        }

        public bool IsEmpty()
        {
            return item == null;
        }

    }
}