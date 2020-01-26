using Assets.Scenes.Scripts.Enums;
using Assets.Scenes.Scripts.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scenes.Scripts.Controls
{
    public class CardTypeControl : MonoBehaviour
    {
        public GameObject SummonSettings;
        public GameObject SummonDisplay;
        public GameObject SummonDisplaySs;
        public Dropdown CardTypeDropDown;

        public void Start()
        {
            InitCardTypeDropDown();
        }


        public void InitCardTypeDropDown()
        {
            CardTypeDropDown.onValueChanged.AddListener(delegate {
                DropdownValueChanged(CardTypeDropDown);
            });

            foreach (var type in (CardType[])Enum.GetValues(typeof(CardType)))
            {
                CardTypeDropDown.AddOptions(new List<Dropdown.OptionData> { new Dropdown.OptionData(type.ToString()) });
            }
        }
        void DropdownValueChanged(Dropdown dropdown)
        {
            var cardType = EnumHelper.ParseEnum<CardType>(dropdown.options[dropdown.value].text);
            SummonSettings.SetActive(cardType == CardType.Summon);
            SummonDisplay.SetActive(cardType == CardType.Summon);
            SummonDisplaySs.SetActive(cardType == CardType.Summon);
        }

    }
}
