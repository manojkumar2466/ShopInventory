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

public class ShopInventoryManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> shopItemTypesList;
    [SerializeField] private GameObject content;
    void Start()
    {
        if (shopItemTypesList.Count > 0)
        {
            for(int index=0; index< shopItemTypesList.Count; index++)
            {
                GameObject shopItemType = Instantiate(shopItemTypesList[index]);
                shopItemType.transform.SetParent(content.transform);
            }
        }
    }

   
}
