using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarGeren : MonoBehaviour
{
    // code by BMo
    
    [SerializeField] private GameObject heart;
    [SerializeField] private PlayerCtrl playerCtrl;
    List<HPGeren> hearts = new List<HPGeren>();

    private void Start()
    {
        DrawHearts();
    }

    public void DrawHearts()
    {
        ClearHearts();

        float maxHPRemainder = playerCtrl.maxHP % 2;
        int heartsToMake = (int)((playerCtrl.maxHP / 2) + maxHPRemainder);

        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

    }
    
    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heart);
        newHeart.transform.SetParent(transform);

        HPGeren heartComponent = newHeart.GetComponent<HPGeren>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }
    
    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HPGeren>();
    }
}
