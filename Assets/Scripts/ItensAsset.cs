using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensAsset : MonoBehaviour
{
    public static ItensAsset Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform prefabItemWorld;

    public Sprite rubySprt;
    public Sprite emeraldSprt;
    public Sprite sapphireSprt;
    public Sprite tourmalineSprt;
    public Sprite amethystaSprt;
    public Sprite citrineSprt;
    public Sprite diamondSprt;
    public Sprite onyxSprt;

    public Sprite goldPotionL_Sprt;
    public Sprite goldPotionS_Sprt;
    public Sprite hpPotionL_Sprt;
    public Sprite hpPotionS_Sprt;
    public Sprite bottleL_Sprt;
    public Sprite bottleS_Sprt;

    public Sprite heartPieceSprt;
    public Sprite heartSprt;

    public Sprite woodSprt;
    public Sprite stoneSprt;
    public Sprite redMushroomSprt;
    public Sprite blueMushroomSprt;
    public Sprite goldMushroomSprt;
    public Sprite appleSprt;
    public Sprite goldAppleSprt;
    public Sprite rottenAppleSprt;
}
