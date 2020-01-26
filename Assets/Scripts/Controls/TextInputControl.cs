using Assets.Scenes.Scripts.Enums;
using Assets.Scenes.Scripts.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextInputControl : MonoBehaviour
{

    public InputField TitleInput;
    public Text TitleText;
    public Text TitleTextSs;

    public InputField HeaderInput;
    public Text HeaderText;
    public Text HeaderTextSs;

    public InputField EffectInput;
    public Button TapButton;
    public Text EffectText;
    public Text EffectTextSs;

    public InputField HealthInput;
    public Text HealthText;
    public Text HealthTextSs;
    public InputField MagicDmgInput;
    public Text MagicDmgText;
    public Text MagicDmgTextSs;
    public InputField PhysicalInput;
    public Text PhysicalText;
    public Text PhysicalTextSs;

    // Start is called before the first frame update
    public void Start()
    {
        TapButton.onClick.AddListener(() => 
        {
            EffectInput.text += "↵";
        });

        TitleInput.onValueChanged.AddListener(delegate { ChangeTitle(); });
        HeaderInput.onValueChanged.AddListener(delegate { ChangeHeader(); });
        EffectInput.onValueChanged.AddListener(delegate { ChangeDescription(); });
        PhysicalInput.onValueChanged.AddListener(delegate { ChangePhysical(); });
        MagicDmgInput.onValueChanged.AddListener(delegate { ChangeMagic(); });
        HealthInput.onValueChanged.AddListener(delegate { ChangeHealth(); });
    }
    
    // Invoked when the value of the text field changes.
    public void ChangeTitle()
    {
        TitleText.text = TitleInput.text;
        TitleTextSs.text = TitleInput.text;
    }
    public void ChangeHeader()
    {
        HeaderText.text = HeaderInput.text;
        HeaderTextSs.text = HeaderInput.text;
    }
    public void ChangeDescription()
    {
        EffectText.text = EffectInput.text;
        EffectTextSs.text = EffectInput.text;
    }
    public void ChangePhysical()
    {
        PhysicalText.text = PhysicalInput.text;
        PhysicalTextSs.text = PhysicalInput.text;
    }
    public void ChangeMagic()
    {
        MagicDmgText.text = MagicDmgInput.text;
        MagicDmgTextSs.text = MagicDmgInput.text;
    }
    public void ChangeHealth()
    {
        HealthText.text = HealthInput.text;
        HealthTextSs.text = HealthInput.text;
    }
}
