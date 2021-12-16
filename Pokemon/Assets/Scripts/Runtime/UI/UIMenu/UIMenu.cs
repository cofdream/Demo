using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Pekemon
{
    public class UIMenu
    {
        private UIMenuMono ui;

        public UIMenu()
        {
            ui = GetBind<UIMenuMono>("Assets/Resource/Views/MenuView.prefab");
            ui.CanvasGroup.alpha = 0;

            ui.Btn_Pokedex.onClick.AddListener(OpenUIPokedex);
            ui.Btn_Pet.onClick.AddListener(OpenUIPet);
            ui.Btn_Bag.onClick.AddListener(OpenUIBag);
            ui.Btn_Back.onClick.AddListener(Close);

            EventSystem.current.SetSelectedGameObject(ui.Btn_Pokedex.gameObject);
        }
        public T GetBind<T>(string key) where T : MonoBehaviour
        {
            GameObject go = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(key);
            go = GameObject.Instantiate(go, GameObject.Find("Canvas").transform);
            go.TryGetComponent<T>(out T bind);
            return bind;
        }

        public void Dispose()
        {
            ui.Btn_Pokedex.onClick.RemoveListener(OpenUIPokedex);
            ui.Btn_Pet.onClick.RemoveListener(OpenUIPet);
            ui.Btn_Bag.onClick.RemoveListener(OpenUIBag);
            ui.Btn_Back.onClick.RemoveListener(Close);

            GameObject.Destroy(ui.gameObject);
            ui = null;
        }

        public void Show()
        {
            ui.CanvasGroup.alpha = 1;

            GlobalInput.UIAction.CancelQueue.Add(Close);
            GlobalInput.SetFirst(GlobalInput.UIAction);

            EventSystem.current.SetSelectedGameObject(ui.Btn_Pokedex.gameObject);
        }

        public void Close()
        {
            ui.CanvasGroup.alpha = 0;

            GlobalInput.UIAction.CancelQueue.Remove(Close);
            GlobalInput.RemoveFirst(GlobalInput.UIAction);

            Dispose();
        }


        public void OpenUIPokedex()
        {
            Debug.Log("OpenUIPokedex");
        }
        public void OpenUIPet()
        {
            Debug.Log("OpenUIPet");
        }
        public void OpenUIBag()
        {
            Debug.Log("OpenUIBag");
        }
    }
}