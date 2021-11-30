﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pekemon
{
    public class RoleHUD : MonoBehaviour
    {
        [SerializeField] Vector2 startPosition;
        [SerializeField] Vector2 endPosition;
        [SerializeField] RectTransform role;
        [SerializeField] float speed;


        public void RoleEnter(UnityAction endCallback)
        {
            StartCoroutine(Enter(endCallback));
        }

        private IEnumerator Enter(UnityAction endCallback)
        {
            role.anchoredPosition = startPosition;

            while (true)
            {
                yield return null;
                Vector2 pos = Vector2.MoveTowards(role.anchoredPosition, endPosition, speed * Time.deltaTime);

                if (Vector2.Distance(pos, endPosition) < 0.01f)
                {
                    role.anchoredPosition = endPosition;
                    endCallback?.Invoke();
                    yield break;
                }
                else
                {
                    role.anchoredPosition = pos;
                }
            }
        }

        public void ThrowPet()
        {
            role.gameObject.SetActive(false);
            Debug.Log("Throw Pet.");
        }
    }
}
