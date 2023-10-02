using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItensCtrl
{
    public enum ItemType
    {
        Ruby,
        Emerald,
        Sapphire,
        Tourmaline,
        Amethysta,
        Citrine,
        Diamond,
        Onyx,

        HP_PotionL,
        HP_PotionS,
    }

    public ItemType itemType;
    public int amount = 1;
    private IItemHolder itemHolder;

    public void SetItemHolder(IItemHolder itemHolder)
    {
        this.itemHolder = itemHolder;
    }

    public IItemHolder GetItemHolder()
    {
        return itemHolder;
    }

    public void RemoveFromItemHolder()
    {
        if (itemHolder != null)
        {
            itemHolder.RemoveItem(this);
        }
    }

    public void MoveToAnotherItemHolder(IItemHolder newItemHolder)
    {
        RemoveFromItemHolder();
        // Add to new Item Holder
        newItemHolder.AddItem(this);
    }

    public Sprite GetSprite()
    {
        return GetSprite(itemType);
    }
    
    public static Sprite GetSprite(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Ruby: return ItensAsset.Instance.rubySprt;
            case ItemType.Emerald: return ItensAsset.Instance.emeraldSprt;
            case ItemType.Sapphire: return ItensAsset.Instance.sapphireSprt;
            case ItemType.Tourmaline: return ItensAsset.Instance.tourmalineSprt;
            case ItemType.Amethysta: return ItensAsset.Instance.amethystaSprt;
            case ItemType.Citrine: return ItensAsset.Instance.citrineSprt;
            case ItemType.Diamond: return ItensAsset.Instance.diamondSprt;
            case ItemType.Onyx: return ItensAsset.Instance.onyxSprt;

            case ItemType.HP_PotionL: return ItensAsset.Instance.hpPotionL_Sprt;
            case ItemType.HP_PotionS: return ItensAsset.Instance.hpPotionS_Sprt;
        }
    }

    public bool IsStackable()
    {
        return IsStackable(itemType);
    }

    public static bool IsStackable (ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Ruby:
            case ItemType.Emerald:
            case ItemType.Sapphire:
            case ItemType.Tourmaline:
            case ItemType.Amethysta:
            case ItemType.Citrine:
            case ItemType.Diamond:
            case ItemType.Onyx:
                return true;

            case ItemType.HP_PotionL:
            case ItemType.HP_PotionS:
                return false;
        }
    }
}
