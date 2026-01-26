using TMPro;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public string objName;
    [SerializeField] private TextMeshProUGUI text;


    public void SetText(string text) => this.text.text = text;
    private void OnEnable()
    {
        if (text.text == "")
        {
            //text.text = $"스페이스바를 눌러서 \n {objName} 사용하기";
            
            if (LocalizationManager.CurrentLanguage == SystemLanguage.Korean)
            {
                text.text = $"스페이스바를 눌러서 \n {objName} 사용하기";
            }
            else
            {
                text.text = $"Use {objName} by pressing SpaceBar";
            }
        }
    }

    /// <summary>
    /// 팝업이 꺼질때 빈 문자열로 변경
    /// </summary>
    private void OnDisable()
    {
        text.text = "";
    }
    
    
}
