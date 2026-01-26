using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private EquipCreateButton createButton;
    [SerializeField] private PreviewUI previewUi;
    public ItemData itemData;

    private Button createButton_Button;


    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Tap_ItemButton);
    }

    public void SetButtonItem(ItemData itemData)
    {
        this.itemData = itemData;
        //GetComponentInChildren<TextMeshProUGUI>().text = itemData.name;
        
        if (LocalizationManager.CurrentLanguage == SystemLanguage.Korean)
        {
            GetComponentInChildren<TextMeshProUGUI>().enableAutoSizing = false;
            GetComponentInChildren<TextMeshProUGUI>().fontSize = 28;
            GetComponentInChildren<TextMeshProUGUI>().text = itemData.Name;
        }
        else
        {
            GetComponentInChildren<TextMeshProUGUI>().enableAutoSizing = true;
            GetComponentInChildren<TextMeshProUGUI>().text = itemData.Name_En;
        }
    }

    public void Tap_ItemButton()
    {
        previewUi.SetPreview(itemData);
        createButton.SetCurSelectedItem(itemData);

        // 판단은 제작 버튼에게 맡김
        createButton.RefreshInteractable();
    }
}
