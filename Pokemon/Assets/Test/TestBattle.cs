using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Pekemon.Test2
{
    [System.Serializable]
    public class Pet
    {
        public int hp;
        public int atk;
        public int MaxHp;
        public int Speed;

        public Pet target;

        public Image Img;
        public Text ms;
        public Image hP_img;

        public IEnumerator Move()
        {
            ms.text = "开始攻击";
            yield return target.BeAttack(atk);
            ms.text = "结束攻击";
        }

        private IEnumerator BeAttack(int damge)
        {
            int curHp = hp - damge;
            int c = 0;

            if (curHp <= 0)
            {
                curHp = 0;
            }

            while (curHp > c)
            {
                c++;
                hP_img.fillAmount = (hp - c) / MaxHp;
                yield return null;
            }

            hp = curHp;
        }
    }

    public class TestBattle : MonoBehaviour
    {
        public Pet p1;
        public Pet p2;

        public Pet[] allPet;

        public int round;

        private void Start()
        {
            p1.MaxHp = p1.hp;
            p2.MaxHp = p2.hp;

            p1.target = p2;
            p2.target = p1;

            //allPet = new Pet[] { p1, p2 };

            round = 0;
        }

        IEnumerator Ruound()
        {
            for (int i = 0; i < allPet.Length; i++)
            {
                yield return allPet[i].Move();
            }

            //p1_ms.text = "播放技能动画中";
            //yield return new WaitForSeconds(0.5f);

            //p2_ms.text = "播放被技能命中动画";
            //yield return new WaitForSeconds(0.5f);

            //int hp = p2.hp - p1.atk;
            //if (hp <= 0)
            //{
            //    hp = 0;

            //    Debug.Log(time + "开始扣血动画");
            //    p2_ms.text = "开始扣血动画";
            //    yield return new WaitForSeconds(1);

            //    Debug.Log(time + "死亡动画.");
            //}
            //else
            //{
            //    Debug.Log(time + "开始扣血动画");
            //    yield return new WaitForSeconds(1);
            //}
            //yield return Damage(p2, p1.atk);
        }

        public void GetSelectTarget()
        {

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                allPet[0] = p1;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                allPet[1] = p1;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(Ruound());
            }
        }

        static IEnumerator Damage(Pet pet, int damage)
        {
            int hp = pet.hp - damage;
            if (hp <= 0)
            {
                hp = 0;
                Debug.Log(time + "开始扣血动画");
                yield return new WaitForSeconds(1);

                Debug.Log(time + "死亡动画.");
            }
            else
            {
                Debug.Log(time + "开始扣血动画");
                yield return new WaitForSeconds(1);
            }
        }


        private static string time => System.DateTime.Now.ToString("mm:ss") + "  ";
    }
}