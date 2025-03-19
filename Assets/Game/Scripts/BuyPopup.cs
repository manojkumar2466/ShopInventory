using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuyPopup : MonoBehaviour
{
    [SerializeField] private Image currencyIcon;
    [SerializeField] private Image shopItemIcon;
    [SerializeField] private TextMeshProUGUI ItemName;
    [SerializeField] private TextMeshProUGUI totalPrice;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button CancelButton;
    [SerializeField] private Button plusButton;
    [SerializeField] private Button minusButton;
    private int shopItemUnitPrice;
    private int currentItemPurchaseCount = 0;
    private ShopItem currentShopItem;

    private void Start()
    {
        plusButton.onClick.AddListener(OnPlusButtonClicked);
        minusButton.onClick.AddListener(OnMinusButtonClicked);
        buyButton.onClick.AddListener(OnBuyButtonClicked);
        CancelButton.onClick.AddListener(OnCancelButtonClicked);
    }
    public void SetBuyPopup(ShopItem shopItem)
    {
        currentShopItem = shopItem;
        ShopItemSO shopItemData = shopItem.shopItemdata;
        shopItemIcon.sprite = shopItemData.itemIcon;
        ItemName.text = shopItemData.itemName;
        shopItemUnitPrice = shopItemData.buyingPrice;
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
        currentItemPurchaseCount++;
        totalPrice.text = (shopItemUnitPrice * currentItemPurchaseCount).ToString()+"c";
        quantityText.text = currentItemPurchaseCount.ToString();
    }

    private void OnMinusButtonClicked()
    {
        currentItemPurchaseCount--;
        totalPrice.text = (shopItemUnitPrice * currentItemPurchaseCount).ToString() + "c";
        quantityText.text = currentItemPurchaseCount.ToString();
    }

    private void OnBuyButtonClicked()
    {
        currentShopItem.OnItemPurchasedFromShop(currentItemPurchaseCount);
        this.gameObject.SetActive(false);
    }

    private void OnCancelButtonClicked()
    {
        currentShopItem.OnPurchaseUnsuccessful();
        this.gameObject.SetActive(false);
    }

}
