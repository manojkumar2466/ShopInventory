using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EShopItemType
{
    Materials,
    Weapons,
    Consumables,
    Treasure
}

public enum ERarity
{
    VeryCommon,
    Common,
    Rare,
    Epic,
    Legendary
}

public class ShopInventoryManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> shopItemTypesList;
    [SerializeField] public GameObject itemtypcontent;
    [SerializeField] public GameObject itemContent;

    public GameObject ShopItemBlueprintObject;
    private static ShopInventoryManager instance;
    public static ShopInventoryManager Instance { get { return instance; } }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }   
        else if(instance)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (shopItemTypesList.Count > 0)
        {
            for(int index=0; index< shopItemTypesList.Count; index++)
            {
                GameObject shopItemType = Instantiate(shopItemTypesList[index]);
                shopItemType.transform.SetParent(itemtypcontent.transform);
            }
        }
    }

   
}
