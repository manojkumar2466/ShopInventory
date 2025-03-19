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
    private EShopItemType itemtype;
    private int sellingPrice;
    private int buyingPrice;
    private int weight;
    private ERarity rarity;
    private int quantityAvailable;
    private string description;
    private Button button;
    private bool isDescriptionDisplayed = false;
    public int ID;
    [SerializeField] TextMeshProUGUI currentCountText;
    public EShopItemStatus status = EShopItemStatus.Unsold;
    public ShopItemSO shopItemdata { get; private set; }
    public void Initialize(ShopItemSO data, int id)
    {
        shopItemdata = data;
        itemName = shopItemdata.itemName;
        itemIcon = shopItemdata.itemIcon;
        itemtype = shopItemdata.itemtype;
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
        ID = id;

    }

    public void RefreshShopItemUI()
    {
        currentCountText.text = quantityAvailable.ToString();
    }

    void OnButtonClick()
    {        
        if(isDescriptionDisplayed)
        {
            ShopInventoryManager.Instance.EnableBuyPopup(this);
            return;
        }
        ShopInventoryManager.Instance.UpdateDescription(description);
        isDescriptionDisplayed = true;
        DisplayBuyPopup();
    }

    private void DisplayBuyPopup()
    {
        //disable clicks allover the screen except newly activated popup.
    }


    //called  on purchased or on selling item 
    public void OnItemPurchasedOrSell(int count)
    {
        quantityAvailable -= count;
        RefreshShopItemUI();
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
