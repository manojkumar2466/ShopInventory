using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] private Image currencyIcon;
    [SerializeField] private Image shopItemIcon;
    [SerializeField] private TextMeshProUGUI ItemName;
    [SerializeField] private TextMeshProUGUI totalPrice;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Button actionButton;
    [SerializeField] private Button CancelButton;
    [SerializeField] private Button plusButton;
    [SerializeField] private Button minusButton;
    private int shopItemUnitPrice;
    private int currentItemPurchaseCount = 0;
    private ShopItem currentShopItem;
    [SerializeField] private TextMeshProUGUI saleTypeText;
    [SerializeField] private TextMeshProUGUI unitPriceText;
    [SerializeField] private GameObject AlertPopup;
    [SerializeField] private Button alertOkButton;
    private int weightbefore;
    private int currencyBefore;

    private void Start()
    {
        plusButton.onClick.AddListener(OnPlusButtonClicked);
        minusButton.onClick.AddListener(OnMinusButtonClicked);
        actionButton.onClick.AddListener(OnActionButtonClicked);
        CancelButton.onClick.AddListener(OnCancelButtonClicked);
        alertOkButton.onClick.AddListener(OnCancelButtonClicked);
    }
    public void SetPopup(ShopItem shopItem)
    {
        weightbefore = PlayerInventoryManager.Instance.itemsCurrentWeight;
        currencyBefore = PlayerInventoryManager.Instance.currentCurrency;
        currentShopItem = shopItem;
        ShopItemSO shopItemData = shopItem.shopItemdata;
        shopItemIcon.sprite = shopItemData.itemIcon;
        ItemName.text = shopItemData.itemName;
        if (shopItem.inventoryType == EInventoryType.Shop)
        {
            shopItemUnitPrice = shopItemData.buyingPrice;
            saleTypeText.text = "Buy Price:";            
            actionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Buy!";
        }
        else if (shopItem.inventoryType == EInventoryType.Player)
        {
            shopItemUnitPrice = shopItemData.sellingPrice;
            saleTypeText.text = "Sell Price:";
            actionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Sell!";
        }
        unitPriceText.text = shopItemUnitPrice.ToString();
        quantityText.text = currentItemPurchaseCount.ToString();
        
    }

    private void OnDisable()
    {
        currentItemPurchaseCount = 0;
        totalPrice.text = (shopItemUnitPrice * currentItemPurchaseCount).ToString() + "c";
        currentShopItem = null;
    }

    private void OnEnable()
    {
        currentItemPurchaseCount = 0;
        totalPrice.text = (shopItemUnitPrice * currentItemPurchaseCount).ToString() + "c";
    }


    private void OnPlusButtonClicked()
    {       


        if (currentShopItem.quantityAvailable > currentItemPurchaseCount &&
            PlayerInventoryManager.Instance.currentCurrency> currentShopItem.shopItemdata.buyingPrice)
        {
            currentItemPurchaseCount++;
            if (currentShopItem.inventoryType == EInventoryType.Shop)
            {
                PlayerInventoryManager.Instance.itemsCurrentWeight += currentShopItem.shopItemdata.weight;
                PlayerInventoryManager.Instance.currentCurrency -= currentShopItem.shopItemdata.buyingPrice;
            }
            else if(currentShopItem.inventoryType== EInventoryType.Player)
            {
                PlayerInventoryManager.Instance.itemsCurrentWeight -= currentShopItem.shopItemdata.weight;
                PlayerInventoryManager.Instance.currentCurrency += currentShopItem.shopItemdata.sellingPrice;
            }
            
            PlayerInventoryManager.Instance.itemWeightText.text = PlayerInventoryManager.Instance.itemsCurrentWeight.ToString();
            PlayerInventoryManager.Instance.currencyText.text = PlayerInventoryManager.Instance.currentCurrency.ToString();
        }

        if (PlayerInventoryManager.Instance.itemMaxWeight <
            PlayerInventoryManager.Instance.itemsCurrentWeight)
        {
            AlertPopup.SetActive(true);
        }

        totalPrice.text = (shopItemUnitPrice * currentItemPurchaseCount).ToString()+"c";
        quantityText.text = currentItemPurchaseCount.ToString();
    }

    private void OnMinusButtonClicked()
    {
        if (currentItemPurchaseCount > 0 )
        {
            currentItemPurchaseCount--;
            if (currentShopItem.inventoryType == EInventoryType.Shop)
            {
                PlayerInventoryManager.Instance.itemsCurrentWeight -= currentShopItem.shopItemdata.weight;
                PlayerInventoryManager.Instance.currentCurrency += currentShopItem.shopItemdata.buyingPrice;
            }
            else if (currentShopItem.inventoryType == EInventoryType.Player)
            {
                PlayerInventoryManager.Instance.itemsCurrentWeight += currentShopItem.shopItemdata.weight;
                PlayerInventoryManager.Instance.currentCurrency -= currentShopItem.shopItemdata.sellingPrice;
            }
            
            PlayerInventoryManager.Instance.itemWeightText.text = PlayerInventoryManager.Instance.itemsCurrentWeight.ToString();
            PlayerInventoryManager.Instance.currencyText.text = PlayerInventoryManager.Instance.currentCurrency.ToString();
        }

        totalPrice.text = (shopItemUnitPrice * currentItemPurchaseCount).ToString() + "c";
        quantityText.text = currentItemPurchaseCount.ToString();
    }

    private void OnActionButtonClicked()
    {
        if(currentShopItem.inventoryType== EInventoryType.Shop)
        {
            currentShopItem.OnItemPurchasedFromShop(currentItemPurchaseCount);
        }
        else if(currentShopItem.inventoryType== EInventoryType.Player)
        {
            currentShopItem.OnItemSoldFromInventory(currentItemPurchaseCount);
        }
       
        this.gameObject.SetActive(false);
    }

    private void OnCancelButtonClicked()
    {
        currentShopItem.OnPurchaseUnsuccessful();
        PlayerInventoryManager.Instance.itemsCurrentWeight = weightbefore;        
        PlayerInventoryManager.Instance.itemWeightText.text = PlayerInventoryManager.Instance.itemsCurrentWeight.ToString();
        PlayerInventoryManager.Instance.currentCurrency = currencyBefore;
        PlayerInventoryManager.Instance.currencyText.text = PlayerInventoryManager.Instance.currentCurrency.ToString();
        AlertPopup.SetActive(false);
        this.gameObject.SetActive(false);
    }

}
