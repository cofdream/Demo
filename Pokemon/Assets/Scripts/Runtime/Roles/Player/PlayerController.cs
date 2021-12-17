using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pekemon
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] RoleControler roleControler;
        [SerializeField] LayerMask tiggerLayerMask;

        public bool State = true;

        private void Start()
        {
            roleControler.MoveEndEvent = MoveEnd;
        }



        private void MoveEnd()
        {
            var collider = Physics2D.OverlapCircle(transform.position, 0.4f, tiggerLayerMask);
            if ((object)collider != null)
            {
                if (collider.TryGetComponent<ITriggerable>(out var triggerable))
                {
                    roleControler.StopMove();
                    triggerable.PlayerTriggerable(this);
                }
            }
        }

        public void SetPosition(Vector3 position,Vector2 forward)
        {
            transform.position = position;
            roleControler.SetForward(forward);
        }


        //Input
        public void OnMove(UnityEngine.InputSystem.InputAction.CallbackContext context)
        {
            if (State == false)
            {
                return;
            }

            if (context.canceled)
            {
                roleControler.StopMove();
            }
            else if (context.performed)
            {
                roleControler.SetInutValue(context.ReadValue<Vector2>());
            }

            //// 模拟外部输入调用
            //Vector2 value;
            //value.x = Input.GetAxisRaw("Horizontal");
            //value.y = Input.GetAxisRaw("Vertical");


            //SetInutValue(value);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if ((object)roleControler == null)
            {
                return;
            }


            Vector3 position = roleControler.ForwardPoint;
            var collider = Physics2D.OverlapCircle(position, 0.4f, roleControler.ObstacleLayer);
            if (collider == null)
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.red;
            }

            Gizmos.DrawWireCube(position, Vector3.one * 0.4f);
        }
#endif
    }
}