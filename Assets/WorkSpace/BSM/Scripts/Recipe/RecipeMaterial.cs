using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipeMaterial : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI needItemCount;
    
    public void SetMaterialData(ItemData itemData, int requiredItemCount)
    {
        itemImage.sprite = itemData.ItemImage;
        if (LocalizationManager.CurrentLanguage == SystemLanguage.Korean)
        {
            itemName.text = itemData.Name;
        }
        else
        {
            itemName.text = itemData.Name_En;
        }
        
        int ownedItem = 0;

        if (InventoryInteraction.OwnedMaterialDict.ContainsKey(itemData.ItemId))
        {
            ownedItem = InventoryInteraction.OwnedMaterialDict[itemData.ItemId].ItemCount;
        }

        needItemCount.text = $"{ownedItem} / {requiredItemCount}";
    }
    
}
