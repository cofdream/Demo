using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace Pekemon
{
    public class SelectSex : MonoBehaviour
    {
        public Selectable Up;
        public Selectable Down;

        public bool isMan;

        private void Awake()
        {
            Up.Select();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log(EventSystem.current.currentSelectedGameObject.name);
            }
        }
    }
}
