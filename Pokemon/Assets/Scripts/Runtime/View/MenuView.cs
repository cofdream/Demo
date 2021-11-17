using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Pekemon
{
    public class MenuView : MonoBehaviour
    {
        enum MenuType
        {
            None,
            Pokedex,
            Bag,
            Pet,
            Back,
        }

        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] private GameObject defaultSelect;

        private MenuType selectMenu;

        private void Awake()
        {
            canvasGroup.alpha = 1;

            GlobalInput.UIAction.Cancel = Close;
            GlobalInput.UIAction.Confirm = SelectMenu;
            GlobalInput.SetFirst(GlobalInput.UIAction);
        }

        private void Start()
        {
            EventSystem.current.SetSelectedGameObject(defaultSelect);
        }

        public void Close()
        {
            GlobalInput.UIAction.Cancel = null;
            GlobalInput.UIAction.Confirm = null;
            GlobalInput.RemoveFirst(GlobalInput.UIAction);

            UIManager.Close(gameObject);
            Destroy(gameObject);
        }

        private void SelectMenu()
        {
            switch (selectMenu)
            {
                case MenuType.Pokedex:
                    break;
                case MenuType.Bag:
                    UIManager.Get<BagView>();
                    break;
                case MenuType.Pet:
                    UIManager.Get<PetView>();
                    break;
                case MenuType.Back:
                    Close();
                    break;
            }
        }

        public void SelectPokedex()
        {
            selectMenu = MenuType.Pokedex;
        }
        public void SelectBag()
        {
            selectMenu = MenuType.Bag;
        }
        public void SelectPet()
        {
            selectMenu = MenuType.Pet;
        }
        public void SelectBack()
        {
            selectMenu = MenuType.Back;
        }
    }
}