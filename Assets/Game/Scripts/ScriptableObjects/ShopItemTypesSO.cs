using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[CreateAssetMenu(fileName ="ShopItemType", menuName="Shop/ShopItemType")]
public class ShopItemTypesSO : ScriptableObject
{
    public Image displayImage;
    public TextMeshProUGUI description;
    public EShopItemType shopItemType;
    public List<ShopItem> itemsList;
}
