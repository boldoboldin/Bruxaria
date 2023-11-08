using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItensCtrl
{
    public enum ItemType
    {
        None,
        Ruby,
        Emerald,
        Sapphire,
        Tourmaline,
        Amethysta,
        Citrine,
        Diamond,
        Onyx,

        GoldPotionL,
        GoldPotionS,
        HP_PotionL,
        HP_PotionS,
        BottleL,
        BottleS,

        HeartPiece,
        Heart,

        Wood,
        Stone,
        RedMushroom,
        BlueMushroom,
        GoldMushroom,
        Apple,
        GoldApple,
        RottenApple,
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

            case ItemType.GoldPotionL: return ItensAsset.Instance.goldPotionL_Sprt;
            case ItemType.GoldPotionS: return ItensAsset.Instance.goldPotionS_Sprt;
            case ItemType.HP_PotionL: return ItensAsset.Instance.hpPotionL_Sprt;
            case ItemType.HP_PotionS: return ItensAsset.Instance.hpPotionS_Sprt;
            case ItemType.BottleL: return ItensAsset.Instance.bottleL_Sprt;
            case ItemType.BottleS: return ItensAsset.Instance.bottleS_Sprt;

            case ItemType.HeartPiece: return ItensAsset.Instance.heartPieceSprt;
            case ItemType.Heart: return ItensAsset.Instance.heartSprt;

            case ItemType.Wood: return ItensAsset.Instance.woodSprt;
            case ItemType.Stone: return ItensAsset.Instance.stoneSprt;
            case ItemType.RedMushroom: return ItensAsset.Instance.redMushroomSprt;
            case ItemType.BlueMushroom: return ItensAsset.Instance.blueMushroomSprt;
            case ItemType.GoldMushroom: return ItensAsset.Instance.goldMushroomSprt;
            case ItemType.Apple: return ItensAsset.Instance.appleSprt;
            case ItemType.GoldApple: return ItensAsset.Instance.goldAppleSprt;
            case ItemType.RottenApple: return ItensAsset.Instance.rottenAppleSprt;
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

            case ItemType.Wood:
            case ItemType.Stone:
            case ItemType.RedMushroom:
            case ItemType.BlueMushroom:
            case ItemType.GoldMushroom:
            case ItemType.Apple:
            case ItemType.GoldApple:
            case ItemType.RottenApple:
                return true;

            case ItemType.GoldPotionL:
            case ItemType.GoldPotionS:
            case ItemType.HP_PotionL:
            case ItemType.HP_PotionS:
            case ItemType.BottleL:
            case ItemType.BottleS:

            case ItemType.HeartPiece:
            case ItemType.Heart:
                return false;
        }
    }
}
