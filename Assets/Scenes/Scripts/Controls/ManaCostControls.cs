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

        void Start()
        {
            OpenBtn.onClick.AddListener(() => { ManaCostPanel.SetActive(true); });
            CloseBtn.onClick.AddListener(() => { ManaCostPanel.SetActive(false); });
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}