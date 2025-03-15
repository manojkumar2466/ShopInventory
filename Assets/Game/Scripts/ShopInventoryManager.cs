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
    private List<ShopItemType> typeList = new List<ShopItemType>(); 
    public int currentActiveTab;
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
                ShopItemType itemType = shopItemType.GetComponent<ShopItemType>();
                if (itemType)
                {
                    itemType.myId = index;
                }
                typeList.Add(itemType);
            }
            currentActiveTab = 0;
            HandleTabs();
        }
        
    }

    public void HandleTabs()
    {
        if (typeList != null && typeList.Count > 0)
        {
            for(int index=0; index<typeList.Count; index++)
            {
                if (index == currentActiveTab)
                {
                    typeList[index].OnSelected();
                }
                else
                {
                    typeList[index].OnDeselected();
                }
            }
        }
    }



   
}
