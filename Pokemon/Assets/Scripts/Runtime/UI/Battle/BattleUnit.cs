using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon
{
    public class BattleUnit : MonoBehaviour
    {
        [SerializeField] Image icon;

        [SerializeField] PokemonBase pokemonBase;
        [SerializeField] int level;
        [SerializeField] bool isPlayerUnit;

        public Pokemon Pokemon { get; set; }
        public void Setup()
        {
            Pokemon = new Pokemon(pokemonBase, level);
            if (isPlayerUnit)
            {
                icon.sprite = pokemonBase.BackSprite;
            }
            else
            {
                icon.sprite = pokemonBase.FrontSprite;
            }
        }
    }
}