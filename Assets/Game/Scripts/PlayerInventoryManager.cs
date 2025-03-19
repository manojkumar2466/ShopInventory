using UnityEngine;
using System.Collections.Generic;

public class PlayerInventoryManager : MonoBehaviour
{

    public static PlayerInventoryManager Instance { get { return instance; } }
    private static PlayerInventoryManager instance;

    [SerializeField] private List<ShopItemTypesSO> typeListData;
    [SerializeField] public GameObject typeContent;
    [SerializeField] public GameObject itemContent;
    private List<ShopItemType> currentShopTypeList = new List<ShopItemType>();
    [SerializeField] private GameObject shopTypePrefab;

    public int currentActiveTab;
    private int currentWeight;
    private int maxWeight;
    

    private void Awake()
    {
        if (!instance)
        {
            instance = this;

        }
        else if (instance)
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        if (typeListData!=null)
        {
            for (int index = 0; index < typeListData.Count; index++)
            {
                GameObject Tab = Instantiate(shopTypePrefab);
                ShopItemType shopType = Tab.GetComponent<ShopItemType>();
                Tab.transform.SetParent(typeContent.transform);
                shopType.Instantiate(typeListData[index]);
                currentShopTypeList.Add(shopType);
                shopType.myId = index;
            }
            currentActiveTab = 0;
        }
    }

    public void HandleTabs()
    {
        if (currentShopTypeList != null && currentShopTypeList.Count > 0)
        {
            for (int index = 0; index < currentShopTypeList.Count; index++)
            {
                if (index == currentActiveTab)
                {
                    currentShopTypeList[index].ActivateShopItemonUI();
                }
                else if (index != currentActiveTab)
                {

                    currentShopTypeList[index].DeactiveShopItemsonUI();
                }
            }
        }
    }

    public void OnItemPurchased(ShopItem item,int count)
    {
        //if item is not already purchased before
        for(int index=0; index< currentShopTypeList.Count; index++)
        {
            if(item.shopItemtype==currentShopTypeList[index].shopitemType)
            {
                currentShopTypeList[index].AddPurchasedShopItemToPlayerInventory(item, count);
                currentActiveTab = index;
                break;
            }
        }
        HandleTabs();
        //if not just increase count
        //deacrese money from wallet
        //decrease item count in shop
        //update weight
    }

    public void OnItemSold(ShopItem item)
    {
        
        //check count and update UI;
        //addmoney back to wallet
        //add back item in shop
        //update weight
    }
   


}
