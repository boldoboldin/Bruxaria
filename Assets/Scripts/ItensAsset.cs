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

}
