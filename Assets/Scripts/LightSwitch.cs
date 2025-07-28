using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour
{
    public Toggle lightSwitch;
    public GameObject blackOverlayPanel;

    // Start is called before the first frame update
    void Start()
    {
        if (lightSwitch != null)
        {
            lightSwitch.onValueChanged.AddListener(OnToggleChanged);        //onValueChanged was learned through https://docs.unity3d.com/2018.1/Documentation/ScriptReference/UI.Toggle-onValueChanged.html
                                                                            //for AddListener, I used this youtube video https://www.youtube.com/watch?v=JoMb2rbYEnk
        }

        if (blackOverlayPanel != null)
        {
            blackOverlayPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnToggleChanged(bool isOn)
    {
        if (blackOverlayPanel != null)
        {
            blackOverlayPanel.SetActive(!isOn);
        }
    }

}
