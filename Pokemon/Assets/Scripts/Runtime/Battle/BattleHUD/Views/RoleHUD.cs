using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Pekemon
{
    public class RoleHUD : MonoBehaviour
    {
        [SerializeField] Vector2 startPosition;
        [SerializeField] Vector2 endPosition;
        [SerializeField] RectTransform role;
        [SerializeField] float speed;

        [Header("Pet")]
        [SerializeField] Text txt_Name;
        [SerializeField] Text txt_Level;
        [SerializeField] Image img_HP;
        [SerializeField] Image img_Pet;

        public void SetData(string name, int level, float hp, Sprite sprite)
        {
            txt_Name.text = name;
            txt_Level.text = "Lv: " + level.ToString();
            img_HP.fillAmount = hp;
            img_Pet.sprite = sprite;
            img_Pet.SetNativeSize();
        }
        public void SetHP(float hp)
        {
            Debug.Log(hp);
            img_HP.fillAmount = hp;
        }


        public void EnterBattle()
        {
            role.anchoredPosition = startPosition;
        }
        public bool UpdateEnterBattle()
        {
            Vector2 pos = Vector2.MoveTowards(role.anchoredPosition, endPosition, speed * Time.deltaTime);

            if (Vector2.Distance(pos, endPosition) < 0.01f)
            {
                role.anchoredPosition = endPosition;
                return true;
            }
            else
            {
                role.anchoredPosition = pos;
                return false;
            }
        }


        public IEnumerator ZHPet()
        {
            var rectTran = img_Pet.GetComponent<RectTransform>();
            rectTran.localScale = Vector3.zero;

            Vector3 scale = Vector3.zero;
            while (true)
            {
                scale += Vector3.one * Time.deltaTime;

                if (scale.x >= 0.99f)
                {
                    rectTran.localScale = Vector3.one;
                    break;
                }
                else
                {
                    rectTran.localScale = scale;
                }

                yield return null;
            }

        }
    }
}
