using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGeren : MonoBehaviour
{
    // code by BMo

    [SerializeField] private Sprite fullHeart, threeQuartHeart, halfHeart, quarterHeart, emptyHeart;
    private Image heartImage;

    // Start is called before the first frame update
    void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    public void SetHeartImage(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.Empty:
                heartImage.sprite = emptyHeart;
                break;
            case HeartStatus.Quarter:
                heartImage.sprite = quarterHeart;
                break;
            case HeartStatus.Half:
                heartImage.sprite = halfHeart;
                break;
            case HeartStatus.ThreeQuart:
                heartImage.sprite = threeQuartHeart;
                break;
            case HeartStatus.Full:
                heartImage.sprite = fullHeart;
                break;
        }
    }
}

public enum HeartStatus
{
    Empty = 0,
    Quarter = 1,
    Half = 2,
    ThreeQuart = 3,
    Full = 4,
}