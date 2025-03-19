using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public enum EShopItemType
{
    Materials,
    Weapons,
    Consumables,
    Treasure
}

public enum EShopItemStatus
{
    Unsold,
    sold
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
    public GameObject ShopTypeItemBlueprintObject;
    [SerializeField] private GameObject BuyPopupGameobject;
    private BuyPopup buyPopup;
    [SerializeField] private List<ShopItemTypesSO> ItemTypeDataList;
   

    [SerializeField] private TextMeshProUGUI description;

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
        if(ItemTypeDataList!=null && ItemTypeDataList.Count>0)
        {

            for(int index=0; index<ItemTypeDataList.Count; index++)
            {
                GameObject tab = Instantiate(ShopTypeItemBlueprintObject);
                tab.transform.SetParent(itemtypcontent.transform);
                ShopItemType shopType = tab.GetComponent<ShopItemType>();
                shopType.Instantiate(ItemTypeDataList[index]);
                shopType.myId = index;
                typeList.Add(shopType);
            }
            currentActiveTab = 0;
            HandleTabs();
        }
        DisableBuyPopup();
        buyPopup = BuyPopupGameobject.GetComponent<BuyPopup>();
        

    }

    public void HandleTabs()
    {
        if (typeList != null && typeList.Count > 0)
        {
            for(int index=0; index< typeList.Count; index++)
            {
                if(index==currentActiveTab)
                {
                    
                    typeList[index].ActivateShopItemonUI();
                }
                else if( index != currentActiveTab)
                {
                    
                    typeList[index].DeactiveShopItemsonUI();
                }
            }
        }
    }


    public void UpdateDescription(string text)
    {
        description.text = text;
    }

    public void EnableBuyPopup(ShopItem shopItem)
    {
        buyPopup.SetBuyPopup(shopItem);
        BuyPopupGameobject.SetActive(true);
    }
    public void DisableBuyPopup()
    {
        BuyPopupGameobject.SetActive(false);
    }
   
}
