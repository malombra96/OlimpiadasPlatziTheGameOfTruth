using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;

public class Manager : MonoBehaviour
{
    public static Manager _Manager; 
    
    public enum Languaje
    {
        ingles, español
    }

    public Languaje idioma;
    private string _urlInfo = "SpanishTexts";
    public XmlDocument globalInfo;
    public List<TextMeshProUGUI> MainView;
    public List<TextMeshProUGUI> SettingsView;
    void Awake(){
        if(_Manager == null){
            _Manager = this;
            DontDestroyOnLoad(this.transform.gameObject);
        }else{
            Destroy(this);
        }
        
       
    } 

    // Start is called before the first frame update
    void Start()
    {
        languajeChange();
    }

    public void languajeChange()
    {
        if (idioma == Languaje.español)
        {
            _urlInfo = "SpanishTexts";
            TextAsset _xmlTexts = Resources.Load<TextAsset>(_urlInfo);
            globalInfo = new XmlDocument();
            globalInfo.LoadXml(_xmlTexts.text);
            for (int i = 1; i < MainView.Count+1; i++)
                MainView[i-1].text = globalInfo.SelectSingleNode("/data/element[@title='MainView"+i+"']").InnerText;

            for (int i = 1; i < SettingsView.Count+1; i++)
                SettingsView[i-1].text = globalInfo.SelectSingleNode("/data/element[@title='SettingsView"+i+"']").InnerText;
        }
        else
        {
            _urlInfo = "EnglishTexts";
            TextAsset _xmlTexts = Resources.Load<TextAsset>(_urlInfo);
            globalInfo = new XmlDocument();
            globalInfo.LoadXml(_xmlTexts.text);
            for (int i = 1; i < MainView.Count+1; i++)
                MainView[i-1].text = globalInfo.SelectSingleNode("/data/element[@title='MainView"+i+"']").InnerText;

            for (int i = 1; i < SettingsView.Count+1; i++)
                SettingsView[i-1].text = globalInfo.SelectSingleNode("/data/element[@title='SettingsView"+i+"']").InnerText;

        }
    }

    // void SetLanguaje()
    // {
    //     for (int i = 0; i < MainView.Count; i++)
    //         MainView[i].text = globalInfo.SelectSingleNode("/data/element[@title='MainView"+i+"']").InnerText;
    // }

    void Update()
    {
        
    }
}
