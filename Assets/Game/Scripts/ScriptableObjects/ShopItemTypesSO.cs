using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[CreateAssetMenu(fileName ="ShopItemType", menuName="Shop/ShopItemType")]
public class ShopItemTypesSO : ScriptableObject
{
    public Sprite icon;
    public string description;
    public EShopItemType shopItemType;
    public EInventoryType inventoryType;
    public List<ShopItemSO> itemsList;
    
}
