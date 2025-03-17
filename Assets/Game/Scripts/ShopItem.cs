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
    private Button button;

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
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        ShopInventoryManager.Instance.UpdateDescription(description);
    }
    
    
}
