using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class ItensCtrl
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
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
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
        }
    }
}
