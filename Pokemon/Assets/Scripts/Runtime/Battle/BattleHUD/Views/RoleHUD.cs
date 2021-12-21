using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
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
        [SerializeField, FormerlySerializedAs("txt_Name")] Text NameText;
        [SerializeField, FormerlySerializedAs("txt_Level")] Text Level;
        [SerializeField, FormerlySerializedAs("img_HP")] Image HP;

        [Header("Obsolete")]
        [SerializeField, FormerlySerializedAs("img_Pet")] Image Pet;
        
        public void SetData(string name, int level, float hp, Sprite sprite)
        {
            NameText.text = name;
            Level.text = "Lv: " + level.ToString();
            HP.fillAmount = hp;
            Pet.sprite = sprite;
            Pet.SetNativeSize();
        }
        public void SetHP(float hp)
        {
            Debug.Log(hp);
            HP.fillAmount = hp;
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
            var rectTran = Pet.GetComponent<RectTransform>();
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


        [SerializeReference] Pokemon pokemon;

        public void Setup(Pokemon pokemon)
        {
            this.pokemon = pokemon;

            NameText.text = pokemon.PetBase.name;
            Level.text = "Lvl " + pokemon.Level.ToString();
        }
    }
}
