using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bed : InteractableObj
{
    [Inject(Id = "PopUp")] private GameObject popUp;
    [Inject]SqlManager sqlManager;
    public override void Interaction()
    {
        Debug.Log("침대에 누움");
        //DayManager.instance.Save(sqlManager);
    }

    /// <summary>
    /// /// /// History : 2025.12.17
    /// 작성자 : 이재호
    /// 세금내는날 && 아침에는 텍스트 예외 처리 추가
    /// </summary>
    /// <param name="collision"></param>
    public override void UiOnOffMethod(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (IngameManager.instance.IsTaxDay() && DayManager.instance.GetDayOrNight() == DayAndNight.MORNING)
            {
                //popUp.GetComponent<PopUp>().SetText("오늘은 낮잠을 자면 안될거 같아");
                
                if (LocalizationManager.CurrentLanguage == SystemLanguage.Korean)
                {
                    popUp.GetComponent<PopUp>().SetText("오늘은 낮잠을 자면 안될거 같아");
                }
                else
                {
                    popUp.GetComponent<PopUp>().SetText("I probably shouldn’t take a nap today");
                }
            }

            if (!DungeonManager.hasDungeonEntered)
            {
                //popUp.GetComponent<PopUp>().SetText("내일이 첫 장사일인데.. \n오늘 밤은 던젼에 가야하지 않을까..?");
                
                if (LocalizationManager.CurrentLanguage == SystemLanguage.Korean)
                {
                    popUp.GetComponent<PopUp>().SetText("내일이 첫 장사일인데.. \n오늘 밤은 던젼에 가야하지 않을까..?");
                }
                else
                {
                    popUp.GetComponent<PopUp>().SetText("Tomorrow’s my first day in business… I have to go to the dungeon tonight");
                }
            }
            
            //popUp.GetComponent<PopUp>().objName = "침대";
            
            if (LocalizationManager.CurrentLanguage == SystemLanguage.Korean)
            {
                popUp.GetComponent<PopUp>().objName = "침대";
            }
            else
            {
                popUp.GetComponent<PopUp>().objName = "Bed";
            }
            popUp.SetActive(!popUp.gameObject.activeSelf);
        }
    }
}
