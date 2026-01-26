using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocalizationManager : MonoBehaviour
{
    private IEnumerator Start()
    {

        yield return LocalizationSettings.InitializationOperation;

        SystemLanguage currentLanguage = Application.systemLanguage;
        
        //시스템 언어에 따른 언어 설정
        if (currentLanguage == SystemLanguage.Korean)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
        }
        else
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
        } 
    }
}
