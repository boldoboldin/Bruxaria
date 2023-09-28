using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCtrl
{
    public event EventHandler OnItemListChanged;
    
    private List<ItensCtrl> itensList;

    public InventoryCtrl()
    {
        itensList = new List<ItensCtrl>();
    }

    public void AddItem(ItensCtrl item)
    {
        itensList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<ItensCtrl> GetItemList()
    {
        return itensList;
    }
}
