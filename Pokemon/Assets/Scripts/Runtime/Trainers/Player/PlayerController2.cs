using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pekemon
{
    public class PlayerController2 : MonoBehaviour
    {
        [SerializeField] MoveControler moveControler;
        [SerializeField] private LayerMask notMoveLayerMask;
        [SerializeField] private LayerMask tiggerLayerMask;

        public Pet[] pets;

        private void Awake()
        {
            moveControler.CheckForwardGrid = () =>
            {
                var collider = Physics2D.OverlapCircle(moveControler.MoveToPosition, 0.4f, notMoveLayerMask);
                if (collider == null)
                {
                    return true;
                }
                else
                {
                    var obstacle = collider.GetComponent<Obstacle>();
                    if (obstacle == null)
                    {
                        return true;
                    }
                    else
                    {
                        return obstacle.CanMove();
                    }
                }
            };

            moveControler.MoveOnceEnd = () =>
            {
                bool result = true;
                var collider2D = Physics2D.OverlapCircle(moveControler.MoveToPosition, 0.4f, tiggerLayerMask);
                if (collider2D != null)
                {
                    var triggerable = collider2D.GetComponent<ITriggerable>();
                    if (triggerable != null)
                    {
                        triggerable.PlayerTriggerable(this);
                        result = false;
                    }
                }
                if (result == false)
                {
                    moveControler.StopMove();
                }
            };


            //-- 捡 道具 -> 给训练家添加道具


            // 传送门 
        }

        void Update()
        {

        }


        public void OnConfirm(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
        }
        public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if (context.started == false)
            {
                if (context.performed)
                {
                    var value = context.ReadValue<Vector2>();
                    moveControler.SetMoveValue(value);
                }
                else if (context.canceled)
                {
                    moveControler.StopMove();
                }
            }

            //Debug.Log($"started {context.started}  performed  {context.performed}  canceled {context.canceled} ");
        }
    }
}