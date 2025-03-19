using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName ="ShopItem", menuName ="Shop/ShopItem")]
public class ShopItemSO :ScriptableObject
{
     public string itemName;
     public Sprite itemIcon;
     public EShopItemType itemtype;
     public int sellingPrice;
     public int buyingPrice;
     public int weight;
     public ERarity rarity;
     public int quantityAvailable;
     public string description;

    public ShopItemSO(ShopItemSO data)
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
    }
}
