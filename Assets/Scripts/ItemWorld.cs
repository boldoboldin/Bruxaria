using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawItemWorld(Vector3 position, ItensCtrl item)
    {
        Transform transform = Instantiate(ItensAsset.Instance.prefabItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    private Rigidbody2D rb2D;

    private ItensCtrl item;
    private SpriteRenderer sprtRenderer;

    [SerializeField] private float vel;

    public void Awake()
    {
        sprtRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(-vel, 0f);
    }

    public void SetItem(ItensCtrl item)
    {
        this.item = item;
        sprtRenderer.sprite = item.GetSprite();
    }

    public ItensCtrl GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
