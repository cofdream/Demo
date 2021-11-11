using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Pekemon
{
    /// <summary>
    /// 打字机
    /// </summary>
    [RequireComponent(typeof(Text))]
    public class TextTypewriter : MonoBehaviour, IMeshModifier
    {
        [SerializeField] private Text text;
        private float speed;
        private float time;
        private int index;
        private bool playState;
        private bool isRefresh;

        public UnityAction PlayEnd;

        public Text Text { set { text = value; } }


        private void Update()
        {
            if (playState)
            {
                time += Time.deltaTime;
                if (time >= speed)
                {
                    time -= speed;
                    isRefresh = true;
                    text.SetVerticesDirty();
                }
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (text == null)
            {
                text = GetComponent<Text>();
            }
        }
#endif    


        public void Play(float speed)
        {
            this.speed = speed;
            time = speed;
            playState = true;
            index = 4;
            isRefresh = false;
        }
        public void Stop()
        {
            playState = false;
        }


        [System.Obsolete("use IMeshModifier.ModifyMesh (VertexHelper verts) instead", false)]
        public void ModifyMesh(Mesh mesh) { }
        public void ModifyMesh(VertexHelper vh)
        {
            if (!isActiveAndEnabled || playState == false)
            {
                return;
            }

            if (isRefresh)
            {
                isRefresh = false;

            }
            UIVertex vertex = default;
            int length = vh.currentVertCount;
            for (int i = index; i < length; i++)
            {
                vh.PopulateUIVertex(ref vertex, i);
                vertex.color.a = 0;
                vh.SetUIVertex(vertex, i);
            }

            index += 4;
            if (index >= length + 4)
            {
                playState = false;
                PlayEnd?.Invoke();
            }
        }
    }
}