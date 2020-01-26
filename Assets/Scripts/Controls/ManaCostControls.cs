using Assets.Scripts.Enums;
using Assets.Scripts.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scenes.Scripts
{

    public class ManaCostControls : MonoBehaviour
    {
        public Button OpenBtn;
        public Button CloseBtn;
        public GameObject ManaCostPanel;

        public InputField DeathCost;
        public InputField LifeCost;
        public InputField ChaosCost;
        public InputField OrderCost;
        public InputField ControlCost;
        public InputField GenericCost;
        public InputField Generic2Cost;

        public GameObject CardCostPresenter;
        public GameObject CardCostPresenterSS;

        void Start()
        {
            OpenBtn.onClick.AddListener(() => { ManaCostPanel.SetActive(true); });
            CloseBtn.onClick.AddListener(() => {
                ManaCostPanel.SetActive(false);
                CalculateAndPresentCost();
            });
        }

        private void CalculateAndPresentCost()
        {
            var list = new List<ItemWithCost>();
            if (!String.IsNullOrEmpty(DeathCost.text.Trim()))
                list.Add(new ItemWithCost { Allegiance = Allegiance.Death, Cost = DeathCost.text });
            if (!String.IsNullOrEmpty(LifeCost.text.Trim()))
                list.Add(new ItemWithCost { Allegiance = Allegiance.Life, Cost = LifeCost.text });
            if (!String.IsNullOrEmpty(ChaosCost.text.Trim()))
                list.Add(new ItemWithCost { Allegiance = Allegiance.Chaos, Cost = ChaosCost.text });
            if (!String.IsNullOrEmpty(OrderCost.text.Trim()))
                list.Add(new ItemWithCost { Allegiance = Allegiance.Order, Cost = OrderCost.text });
            if (!String.IsNullOrEmpty(ControlCost.text.Trim()))
                list.Add(new ItemWithCost { Allegiance = Allegiance.Control, Cost = ControlCost.text });
            if (!String.IsNullOrEmpty(GenericCost.text.Trim()))
                list.Add(new ItemWithCost { Allegiance = Allegiance.Generic, Cost = GenericCost.text });
            if (!String.IsNullOrEmpty(Generic2Cost.text.Trim()))
                list.Add(new ItemWithCost { Allegiance = Allegiance.Generic, Cost = Generic2Cost.text });

            var cardCostScript = CardCostPresenter.gameObject.GetComponent<CardCost>();
            var cardCostScriptSs = CardCostPresenterSS.gameObject.GetComponent<CardCost>();
            cardCostScript.AddItemWithCost(list);
            cardCostScriptSs.AddItemWithCost(list);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}