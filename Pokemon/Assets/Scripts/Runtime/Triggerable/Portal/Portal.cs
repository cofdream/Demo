using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class Portal : MonoBehaviour, ITriggerable
    {
        public Portal targetPortal;

        private PlayerController playerController;

        private Vector3 Point => transform.position - new Vector3(0, 0.5f, 0);

        public bool PlayerTriggerable(PlayerController playerController)
        {
            this.playerController = playerController;
            playerController.MoveEnd += PlayerEndMove;
            return true;
        }
        private void PlayerEndMove()
        {
            StartCoroutine(Move());
        }
        IEnumerator Move()
        {
            playerController.Stop = true;

            yield return new WaitForSeconds(0.5f);

            playerController.transform.position = targetPortal.Point;

            playerController.MoveEnd -= PlayerEndMove;
            playerController.Stop = false;
            playerController = null;
        }
    }
}
