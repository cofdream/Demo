using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class Portal : MonoBehaviour, ITriggerable
    {
        [SerializeField] Portal targetPortal;
        [SerializeField] Vector2 forward;

        private PlayerController playerController;


        public void PlayerTriggerable(PlayerController playerController)
        {
            this.playerController = playerController;
            StartCoroutine(PlayerPortal());
        }

        IEnumerator PlayerPortal()
        {
            yield return null;
            Debug.Log("start protal.");

            //停止控制
            playerController.State = false;


            //黑屏Mask

            playerController.SetPosition(targetPortal.transform.position, targetPortal.forward);

            //恢复
            playerController.State = true;
            yield return new WaitForSeconds(0.5f);
        }
    }
}