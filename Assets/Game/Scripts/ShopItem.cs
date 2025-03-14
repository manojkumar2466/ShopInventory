using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopItem : MonoBehaviour
{

    [SerializeField]private Image image;


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

    public void Initialize(ShopItemSO data)
    {
        itemName = data.itemName;
        itemIcon = data.itemIcon;
        itemtype = data.itemtype;
        sellingPrice = data.sellingPrice;
        buyingPrice = data.buyingPrice;
        weight = data.weight;
        rarity = data.rarity;
        quantityAvailable = data.quantityAvailable;
        description = data.description;
        image.sprite = itemIcon;
    }
    
    
}
