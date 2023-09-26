using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HP : MonoBehaviour
{
    // code by BMo
    
    [SerializeField] private GameObject heart;
    [SerializeField] private PlayerCtrl playerCtrl;
    List<HPGeren> hearts = new List<HPGeren>();

    private void OnEnable()
    {
        PlayerCtrl.OnPlayerDamage += DrawHearts;
    }

    private void OnDisable()
    {
        PlayerCtrl.OnPlayerDamage -= DrawHearts;
    }

    private void Start()
    {
        DrawHearts();
    }

    public void DrawHearts()
    {
        ClearHearts();

        float maxHPRemainder = playerCtrl.maxHP % 4;
        int heartsToMake = (int)((playerCtrl.maxHP / 4) + maxHPRemainder);

        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(playerCtrl.hp - (i * 4), 0, 4);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
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
