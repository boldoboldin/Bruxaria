using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public ItensCtrl item;

    private void Awake()
    {
        ItemWorld.SpawItemWorld(transform.position, item);
        Destroy(gameObject);
    }
}
