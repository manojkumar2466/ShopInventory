using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopItem : MonoBehaviour
{

    [SerializeField]private Image image;
    [SerializeField] private TextMeshProUGUI count;


    //data
    private string itemName;
    private Sprite itemIcon;
    public EShopItemType shopItemtype;
    private int sellingPrice;
    private int buyingPrice;
    private int weight;
    private ERarity rarity;
    public int quantityAvailable;
    private string description;
    private Button button;
    private bool isDescriptionDisplayed = false;
    public int ID;
    [SerializeField] TextMeshProUGUI currentCountText;
    public EShopItemStatus status = EShopItemStatus.Unsold;
    public ShopItemSO shopItemdata { get; private set; }
    public EInventoryType inventoryType=EInventoryType.Shop;
    private ShopItemType shopType;
    public void Initialize(ShopItemSO data, ShopItemType itemtype)
    {
        shopType = itemtype;
        shopItemdata = data;
        itemName = shopItemdata.itemName;
        itemIcon = shopItemdata.itemIcon;
        shopItemtype = shopItemdata.itemtype;
        sellingPrice = shopItemdata.sellingPrice;
        buyingPrice = shopItemdata.buyingPrice;
        weight = shopItemdata.weight;
        rarity = shopItemdata.rarity;
        quantityAvailable = shopItemdata.quantityAvailable;
        description = shopItemdata.description;
        image.sprite = itemIcon;
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        count.text = quantityAvailable.ToString();

    }

    public void AddItemCount(int count)
    {
        quantityAvailable+=count;
        shopItemdata.quantityAvailable=quantityAvailable;

    }
    public void RefreshShopItemUI()
    {
        currentCountText.text = quantityAvailable.ToString();
    }

    void OnButtonClick()
    {
        if (inventoryType == EInventoryType.Shop)
        {
            if (isDescriptionDisplayed)
            {
                ShopInventoryManager.Instance.EnableBuyPopup(this);
                return;
            }
            ShopInventoryManager.Instance.UpdateDescription(description);
            isDescriptionDisplayed = true;
        }
        else if(inventoryType== EInventoryType.Player)
        {
            PlayerInventoryManager.Instance.Enablepopup(this);
        }
       
    }

    


    //called  on purchased or on selling item 
    public void OnItemPurchasedFromShop(int count)
    {
        quantityAvailable -= count;
        shopItemdata.quantityAvailable = quantityAvailable;        
        PlayerInventoryManager.Instance.OnItemPurchased(this, count);
        RefreshShopItemUI();
        isDescriptionDisplayed = false;

    }

    public void  OnPurchaseUnsuccessful()
    {
        isDescriptionDisplayed = false;
    }

    public void OnItemSoldFromInventory(int count)
    {
        quantityAvailable -= count;
        shopItemdata.quantityAvailable = quantityAvailable;
        ShopInventoryManager.Instance.OnItemSoldBack(this, count);
        RefreshShopItemUI();
        if (quantityAvailable <= 0)
        {
            shopType.RemoveItem(this);
            Destroy(this.gameObject);
        }
    }


   
   

    private void OnEnable()
    {
        isDescriptionDisplayed = false;
    }

    private void OnDisable()
    {
        isDescriptionDisplayed = false;
    }


}
