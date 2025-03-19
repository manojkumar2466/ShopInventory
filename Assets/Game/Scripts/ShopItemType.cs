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
    private List<ShopItem> itemsCreated= new List<ShopItem>();
    public int myId;
    private Button button;
    ShopItemTypesSO shopTypeData;
    public EInventoryType inventoryType;


    public void Instantiate(ShopItemTypesSO data)
    {
        shopTypeData = data;
        iconImage.sprite = data.icon;
        shopitemType = data.shopItemType;
        inventoryType = data.inventoryType;
        if (inventoryType == EInventoryType.Shop)
        {
         
            shopItemContent = ShopInventoryManager.Instance.itemContent;

        }
        else if (inventoryType == EInventoryType.Player)
        {
            shopItemContent = PlayerInventoryManager.Instance.itemContent;
        }
        
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
                CreateShopItem(itemsData[index]);
            }

        }
    }

    private void CreateShopItem(ShopItemSO data)
    {
        GameObject item = Instantiate(ShopInventoryManager.Instance.ShopItemBlueprintObject);
        ShopItem shopItem = item.GetComponent<ShopItem>();
        shopItem.Initialize(data);
        item.transform.SetParent(shopItemContent.transform);
        itemsCreated.Add(shopItem);
    }

    public void OnButtonSelected()
    {
        if (inventoryType == EInventoryType.Shop)
        {
            ShopInventoryManager.Instance.currentActiveTab = myId;
            ShopInventoryManager.Instance.HandleTabs();
            ShopInventoryManager.Instance.UpdateDescription(shopTypeData.description);
            return;
        }

        PlayerInventoryManager.Instance.currentActiveTab = myId;
        PlayerInventoryManager.Instance.HandleTabs();
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


    public void AddPurchasedShopItemToPlayerInventory(ShopItem item, int count)
    {
       ShopItem newShopItem= itemsCreated.Find(shopItem => shopItem.shopItemdata.itemName.Equals(item.shopItemdata.itemName));
        if (newShopItem)
        {
            newShopItem.AddItemCount(count);
            itemsCreated.Add(newShopItem);
            newShopItem.RefreshShopItemUI();
        }
        else if (!newShopItem)
        {
            GameObject obj = Instantiate(ShopInventoryManager.Instance.ShopItemBlueprintObject);
            ShopItem shopItem = obj.GetComponent<ShopItem>();
            shopItem.inventoryType = EInventoryType.Player;
            ShopItemSO data = new ShopItemSO(item.shopItemdata);
            shopItem.Initialize(data);
            
            shopItem.quantityAvailable = count;
            
            obj.transform.SetParent(shopItemContent.transform);
            itemsCreated.Add(shopItem);
            shopItem.RefreshShopItemUI();
        }
    }
    
}
