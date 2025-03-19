using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemType : MonoBehaviour
{
    [SerializeField] Image iconImage;
    public EShopItemType shopitemType;
    [SerializeField] List<ShopItemSO> itemsData;
    private GameObject shopItemContent;
    private ShopInventoryManager shopmanager;
    private List<ShopItem> itemsCreated= new List<ShopItem>();
    public int myId;
    private Button button;
    ShopItemTypesSO shopTypeData;   


    public void Instantiate(ShopItemTypesSO data)
    {
        shopTypeData = data;
        iconImage.sprite = data.icon;
        shopitemType = data.shopItemType;
        shopmanager = ShopInventoryManager.Instance;
        shopItemContent = shopmanager.itemContent;
        itemsData = data.itemsList;
        GenerateItems();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonSelected);
        
    }

    private void GenerateItems()
    {
        if(itemsData == null)
        {
            return;
        }
        if (itemsData.Count > 0)
        {
            for(int index=0; index< itemsData.Count; index++)
            {
                
                GameObject item = Instantiate(shopmanager.ShopItemBlueprintObject);
                ShopItem shopItem = item.GetComponent<ShopItem>();
                shopItem.Initialize(itemsData[index], index);
                item.transform.SetParent(shopItemContent.transform);
                itemsCreated.Add(shopItem);
            }

        }
    }
   

    public void OnButtonSelected()
    {
        ShopInventoryManager.Instance.currentActiveTab = myId;
        ShopInventoryManager.Instance.HandleTabs();
        ShopInventoryManager.Instance.UpdateDescription(shopTypeData.description);
    }


    public void DeactiveShopItemsonUI()
    {
        if (itemsCreated != null)
        {
            for(int index=0; index< itemsCreated.Count; index++)
            {
                itemsCreated[index].gameObject.SetActive(false);
            }
        }
    }

    public void ActivateShopItemonUI()
    {

        if (itemsCreated != null)
        {
            for (int index = 0; index < itemsCreated.Count; index++)
            {
                itemsCreated[index].gameObject.SetActive(true);
            }
        }
    }
   
    
}
