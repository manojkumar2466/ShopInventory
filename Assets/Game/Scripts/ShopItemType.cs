using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemType : MonoBehaviour
{

    private EShopItemType shopitemType;
    [SerializeField] List<ShopItemSO> itemsData;
    private GameObject shopItemContent;
    private ShopInventoryManager shopmanager;

    void Start()
    {
        shopmanager = ShopInventoryManager.Instance;
        shopItemContent = shopmanager.itemContent;
        GenerateItems();
    }

    private void GenerateItems()
    {
        if(itemsData == null)
        {
            return;
        }
        if (itemsData.Count > 0)
        {
            for(int index=0; index< itemsData.Count; index++)
            {
                
                GameObject item = Instantiate(shopmanager.ShopItemBlueprintObject);
                ShopItem shopItem = item.GetComponent<ShopItem>();
                shopItem.Initialize(itemsData[index]);
                item.transform.SetParent(shopItemContent.transform);

            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
