using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemType : MonoBehaviour
{

    private EShopItemType shopitemType;
    [SerializeField] List<ShopItemSO> itemsData;
    private GameObject shopItemContent;
    private ShopInventoryManager shopmanager;
    private List<ShopItem> items= new List<ShopItem>();
    public int myId;
    private Button button;

    void Start()
    {
        shopmanager = ShopInventoryManager.Instance;
        shopItemContent = shopmanager.itemContent;
        GenerateItems();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonSelected);
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
                items.Add(shopItem);
            }

        }
    }

    public void OnDeselected()
    {
        if(items!=null && items.Count > 0)
        {
            for(int index=0; index<items.Count; index++)
            {
                items[index].gameObject.SetActive(false);
            }
        }
    }

    public void OnButtonSelected()
    {
        ShopInventoryManager.Instance.currentActiveTab = myId;
        ShopInventoryManager.Instance.HandleTabs();
    }

    public void OnSelected()
    {

        if (items != null && items.Count > 0)
        {
            for (int index = 0; index < items.Count; index++)
            {
                items[index].gameObject.SetActive(true);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
