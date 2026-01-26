using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ArmorForge : InteractableObj
{
    [Inject(Id = "ArmorForge")]
    GameObject forgeUi;

    [Inject(Id = "PopUp")]
    GameObject popUp;

    [SerializeField] private SystemWindowController controller;
    
    public InventoryInteraction inventory;
    
    public override void Interaction()
    {
        forgeUi.SetActive(!forgeUi.activeSelf);
        controller.OpenSystemWindow(SystemType.HELMET);
    }

    public override void UiOnOffMethod(Collision2D collision)
    {
        //popUp.GetComponent<PopUp>().objName = "방어구 제작대";
        
        if (LocalizationManager.CurrentLanguage == SystemLanguage.Korean)
        {
            popUp.GetComponent<PopUp>().objName = "방어구 제작대";
        }
        else
        {
            popUp.GetComponent<PopUp>().objName = "Armor Forge";
        }
        popUp.SetActive(!popUp.gameObject.activeSelf);
        
        if (inventory == null)
        {
            inventory = collision.gameObject.GetComponent<InventoryInteraction>();
        }
    }
}
