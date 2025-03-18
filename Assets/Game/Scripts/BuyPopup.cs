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
    private int shopItemUnitPrice;

    public void SetBuyPopup(ShopItemSO shopItemData)
    {
        shopItemIcon.sprite = shopItemData.itemIcon;
        ItemName.text = shopItemData.itemName;
        shopItemUnitPrice = shopItemData.buyingPrice;
    }
}
