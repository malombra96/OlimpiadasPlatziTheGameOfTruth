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
    public List<TextMeshProUGUI> Controles1;
    public List<TextMeshProUGUI> Controles2;
    public List<TextMeshProUGUI> ControlesOpcion1;
    public List<TextMeshProUGUI> ControlesOpcion2;
    
    public KeyCode Up = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode Right = KeyCode.D ;
    public KeyCode Left = KeyCode.A;
    public KeyCode Jump = KeyCode.Space;
    public KeyCode Fire1 = KeyCode.Z;

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

            for (int i = 1; i < Controles1.Count + 1; i++)
            {
                Controles1[i-1].text = globalInfo.SelectSingleNode("/data/element[@title='controles"+i+"']").InnerText;
                Controles2[i-1].text = globalInfo.SelectSingleNode("/data/element[@title='controles"+i+"']").InnerText;
            }
            
            for (int i = 1; i < ControlesOpcion1.Count+1; i++)
                ControlesOpcion1[i-1].text = globalInfo.SelectSingleNode("/data/element[@title='Opcion1."+i+"']").InnerText;

            for (int i = 1; i < ControlesOpcion2.Count+1; i++)
                ControlesOpcion2[i-1].text = globalInfo.SelectSingleNode("/data/element[@title='Opcion2."+i+"']").InnerText;
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

            for (int i = 1; i < Controles1.Count + 1; i++)
            {
                Controles1[i-1].text = globalInfo.SelectSingleNode("/data/element[@title='controles"+i+"']").InnerText;
                Controles2[i-1].text = globalInfo.SelectSingleNode("/data/element[@title='controles"+i+"']").InnerText;
            }
            
            for (int i = 1; i < ControlesOpcion1.Count+1; i++)
                ControlesOpcion1[i-1].text = globalInfo.SelectSingleNode("/data/element[@title='Opcion1."+i+"']").InnerText;

            for (int i = 1; i < ControlesOpcion2.Count+1; i++)
                ControlesOpcion2[i-1].text = globalInfo.SelectSingleNode("/data/element[@title='Opcion2."+i+"']").InnerText;
        }
    }

    public void ControlerOpcion1()
    {
        Up = KeyCode.W;
        Down = KeyCode.S;
        Right = KeyCode.D ;
        Left = KeyCode.A;
        Jump = KeyCode.Space;
        Fire1 = KeyCode.Z;
    }
    
    public void ControlerOpcion2()
    {
        Up = KeyCode.UpArrow;
        Down = KeyCode.DownArrow;
        Right = KeyCode.RightArrow;
        Left = KeyCode.LeftArrow;
        Jump = KeyCode.C;
        Fire1 = KeyCode.A;
    }

}
