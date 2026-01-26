using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpkeepPopUp : MonoBehaviour
{
    private Animator animator;
    
    [SerializeField] private TextMeshProUGUI title;

    [SerializeField][SerializedDictionary] private SerializedDictionary<string, GameObject> upkeepTextDict;
    //private int currentValue = 0;

    [SerializeField] private Button taxPayButton;
    
    [SerializeField] private float animationDuration = 0.75f;
    private RectMask2D mask;
    private SoundManager soundManager => SoundManager.Instance;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        mask = GetComponentInChildren<RectMask2D>();
    }

    private void Start()
    {
        IngameManager.instance.SetUpKeepText(upkeepTextDict);
        SetKoOrEng();
    }
  
    public void PlayOpen()
    {
        soundManager.PlaySfx(SFXSound.INVENTORY_FLIP);
        animator.Play("UpkeepOpen");
        StartCoroutine(OpenAnimationCompleteCoroutine());
    }

    public void PlayClose()
    {
        soundManager.PlaySfx(SFXSound.INVENTORY_FLIP);
        animator.Play("UpkeepClose");
        StartCoroutine(CloseAnimationCompleteCoroutine());
    }


    private IEnumerator OpenAnimationCompleteCoroutine()
    {
        yield return new WaitForSeconds(animationDuration);

    }

    private IEnumerator CloseAnimationCompleteCoroutine()
    {
        yield return new WaitForSeconds(animationDuration);

        gameObject.SetActive(false);
    }

    /// <summary>
    /// 마스크렌더링 / 애니메이션 이벤트로 호출
    /// </summary>
    /// <param name="padding">패딩값 left, bottom, right, up</param>
    public void RenderPadding(float padding)
    {
        mask.padding = new Vector4(padding, 0, padding, 0);
    }
    
    private void SetKoOrEng()
    {
        string debt;
        string interest;
        string playerGold;
        string minPrice;
        
        if (LocalizationManager.CurrentLanguage == SystemLanguage.Korean)
        {
            debt = "남은 채무액";      
            interest = "채무액에 따른 이자";
            playerGold = "보유한 골드";
            minPrice = "지불해야 하는 최소 골드";
        }
        else
        {
            debt = "Debt";      
            interest = "Interest";
            playerGold = "Gold You Have";
            minPrice = "Minimum Gold To Pay";
        }
        
        if (LocalizationManager.CurrentLanguage == SystemLanguage.Korean)
        {
            title.text = "빚 정산서";
        }
        else
        {
            title.text = "Debt Statement";
        }
        
        upkeepTextDict["Debt"].GetComponent<TextMeshProUGUI>().text = debt;
        upkeepTextDict["Interest"].GetComponent<TextMeshProUGUI>().text = interest;
        upkeepTextDict["PlayerGold"].GetComponent<TextMeshProUGUI>().text = playerGold;
        upkeepTextDict["Total"].GetComponent<TextMeshProUGUI>().text = minPrice;
    }
}