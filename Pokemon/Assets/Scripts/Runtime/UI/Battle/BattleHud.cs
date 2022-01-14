using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon
{
    public class BattleHud : MonoBehaviour
    {
        [SerializeField] Text nameText;
        [SerializeField] Text level;
        [SerializeField] HpBar health;

        [SerializeReference] Pokemon pokemon;


        public void SetData(Pokemon pokemon)
        {
            this.pokemon = pokemon;
            nameText.text = pokemon.PetBase.Name;
            level.text = "Lv: " + pokemon.Level.ToString();
            health.SetHp((float)pokemon.Hp / pokemon.MaxHp);
        }
    }
}