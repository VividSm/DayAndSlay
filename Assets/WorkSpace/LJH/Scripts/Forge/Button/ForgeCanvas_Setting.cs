using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ForgeCanvas_Setting : MonoBehaviour
{
    [SerializeField] protected ForgeCanvas forge;
    
    [SerializeField] protected ItemButton defaultItemButton;
    [SerializeField] private Parts_kr parts;
    [SerializeField] private TextMeshProUGUI CreateButtonText;

    private void OnEnable()
    {
        forge.SetCurParts(parts);
        StartCoroutine(PreviewCoroutine());
    }

    private void Start()
    {
        if (LocalizationManager.CurrentLanguage == SystemLanguage.Korean)
        {
            CreateButtonText.text = "제작하기";
        }
        else
        {
            CreateButtonText.text = "CRAFT";
        }
    }

    private IEnumerator PreviewCoroutine()
    {
        yield return WaitCache.GetWait(0.05f);
        defaultItemButton.Tap_ItemButton();
    }
    
}
