using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BehaviourToggleLanguaje : MonoBehaviour
{
    public void LanguajeChange(Toggle ingles)
    {
        
        Toggle SpanihsToggle = GetComponent<Toggle>();
        if (SpanihsToggle.isOn && Manager._Manager.idioma == Manager.Languaje.ingles)
        {
            Manager._Manager.idioma = Manager.Languaje.español;
            Manager._Manager.languajeChange();
        }

        if (ingles.isOn && Manager._Manager.idioma == Manager.Languaje.español)
        {
            Manager._Manager.idioma = Manager.Languaje.ingles;
            Manager._Manager.languajeChange();
        }

    }
}
