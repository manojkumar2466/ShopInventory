using UnityEngine;
using System.Collections.Generic;

public class PlayerInventoryManager : MonoBehaviour
{

    public static PlayerInventoryManager Instance { get { return instance; } }
    private static PlayerInventoryManager instance;

    [SerializeField] private List<ShopItemTypesSO> typeListData;
    [SerializeField] private GameObject typeContent;
    private List<ShopItemType> currentShopTypeList = new List<ShopItemType>();
    [SerializeField] private GameObject shopTypePrefab;

    

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

            }
        }
    }
        

    public void OnItemPurchased(ShopItem item)
    {
        //if item is not already purchased before
        for(int index=0; index< currentShopTypeList.Count; index++)
        {
            
        }
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
