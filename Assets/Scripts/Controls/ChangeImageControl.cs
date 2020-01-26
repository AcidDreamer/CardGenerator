using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using SimpleFileBrowser;
using System.Collections;
using Assets.Scenes.Scripts.Controls;
using Assets.Scenes.Scripts.Enums;
using Assets.Scenes.Scripts.Helpers;
using System.IO;

namespace Assets.Scenes.Scripts
{
    public class ChangeImageControl : MonoBehaviour
    {
        public Button ImageBtn;
        public Button SsButton;
        public Image Image;
        public Image ImageSs;
        public Canvas Program;

        private string ScreenshotPath { get { return $"{Application.dataPath}//Screenshots"; } }
        public void Start()
        {
            ImageBtn.onClick.AddListener(AddImage);
            SsButton.onClick.AddListener(ScreenShot);
        }

        void ScreenShot()
        {
            var type = this.gameObject.GetComponent<CardTypeControl>();
            var cardType = EnumHelper.ParseEnum<CardType>(type.CardTypeDropDown.options[type.CardTypeDropDown.value].text);

            var name = this.gameObject.GetComponent<TextInputControl>();
            var nameStr = name.TitleText.text;

            if (!Directory.Exists(ScreenshotPath))
                Directory.CreateDirectory(ScreenshotPath);
            if (!Directory.Exists($"{ScreenshotPath}//{cardType}"))
                Directory.CreateDirectory($"{ScreenshotPath}//{cardType}");

            StartCoroutine(ScreenShotEnum($"{ ScreenshotPath}//{cardType}//{cardType}-{nameStr}"));
        }
        IEnumerator ScreenShotEnum(string cardName)
        {
            Program.enabled = false;
            yield return new WaitForSeconds(1);
            ScreenCapture.CaptureScreenshot($"{cardName}-{DateTime.UtcNow.Ticks}.png");
            yield return new WaitForSeconds(1);
            Program.enabled = true;
            Debug.Log("Ss");
        }

        void Update()
        {
        }

        void AddImage()
        {
            //// Open file with filter
            //var extensions = new[] {
            //    new ExtensionFilter("Image Files", "png", "jpg", "jpeg" ),
            //};
            //var path = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, false);
            //Debug.Log(path[0]);
            FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"));
            StartCoroutine(ShowLoadDialogCoroutine());

        }

        private IEnumerator ShowLoadDialogCoroutine()
        {
            yield return FileBrowser.WaitForLoadDialog(false, null, "Select Image", "Upload");

            Debug.Log(FileBrowser.Success + " " + FileBrowser.Result);

            if (FileBrowser.Success)
            {
                byte[] bytes = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result);
                var sprite = IMG2Sprite.LoadNewSprite(bytes);

                Image.sprite = sprite;
                ImageSs.sprite = sprite;

            }
        }

    }
}
