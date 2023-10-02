using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemHolder
{

    void RemoveItem(ItensCtrl item);
    void AddItem(ItensCtrl item);
    bool CanAddItem();

}
