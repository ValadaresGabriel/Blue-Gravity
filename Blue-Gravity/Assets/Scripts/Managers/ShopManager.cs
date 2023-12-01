using System.Collections;
using System.Collections.Generic;
using ClothGravity.Items;
using ClothGravity.UI;
using UnityEngine;

namespace ClothGravity.ShopSystem
{
    public class ShopManager : MonoBehaviour
    {
        private static ShopManager Instance;

        [SerializeField] GameObject shopGameObject;
        [SerializeField] Transform itemsGroupTransform;
        [SerializeField] GameObject shopSlotPrefab;
        [SerializeField] ScrollManager scrollManager;

        private List<ItemSlot> itemSlots = new();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        public void OpenShop(List<Item> items)
        {
            shopGameObject.SetActive(true);

            foreach (Item item in items)
            {
                GameObject shopSlotInstance = Instantiate(shopSlotPrefab, itemsGroupTransform);
                ShopSlot shopSlot = shopSlotInstance.GetComponent<ShopSlot>();
                ItemSlot itemSlot = shopSlotInstance.GetComponent<ItemSlot>();

                itemSlot.Item = item;
                itemSlot.SetItemIcon();

                shopSlot.SetTitleAndPriceText(itemSlot.Item.itemName, itemSlot.Item.itemPrice.ToString(), itemSlot.Item.itemPrice);
            }

            scrollManager.RefreshScroll();
        }

        public void AttemptToCloseShop()
        {
            UIManager.CloseShop();
        }

        public void CloseShop()
        {
            shopGameObject.SetActive(false);

            foreach (Transform item in itemsGroupTransform)
            {
                Destroy(item.gameObject);
            }
        }
    }
}
