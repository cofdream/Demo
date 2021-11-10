using Cofdream.Asset;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Pekemon
{
    public class Dialog
    {
        private static Transform uiCanvas;
        private static DialogBind dialogBind;

        public static void Init()
        {
            var assetLoad = AssetsLoad.GetAssetLoad("Assets_Resource_UI");

            GameObject ui = assetLoad.Load<GameObject>("UI.prefab");
            ui = Object.Instantiate(ui);

            Object.DontDestroyOnLoad(ui);
            ui.hideFlags = HideFlags.DontSave;
            uiCanvas = ui.transform.GetComponentInChildren<Canvas>().transform;


            dialogBind = assetLoad.Load<DialogBind>("Dialog.prefab");
            dialogBind = Object.Instantiate(dialogBind, uiCanvas);
            dialogBind.gameObject.hideFlags = HideFlags.DontSave;

            assetLoad.UnloadAllLoadedObjects();
        }

        public static void Show(string content)
        {
            dialogBind.gameObject.SetActive(true);

            // 这是一段<color=red>打字机</color>文字.

            //解析

           


            // 把内容里的富文本提取出来

            // 记录富文本从第几个字符开始显示，
            //int length = content.Length;
            //char head = '<';

            //for (int i = 0; i < length; i++)
            //{
            //    if (content[i] == head)
            //    {
            //        Check(content, i, length);
            //    }
            //}

            //从左向右开始读<

        }

        private static void Check(string contet, int startIndex, int length)
        {

            char[] head = new char[] { 'b', '>' };
            int headLength = head.Length;

            if (startIndex + headLength >= length)
            {
                //剩余内容不足
                return;
            }

            for (int i = 0; i < headLength; i++)
            {
                char a = contet[startIndex + i];
                char b = head[i];
                if (a == b)
                {
                }
                else
                {
                    // 不是富文本
                    return;
                }
            }


            for (int i = startIndex; i < length; i++)
            {
                if (contet[i] == '<')
                {

                }
                else
                {
                    return;
                }
            }

            char[] end = new char[] { '<', '/', 'b', '>' };
            int endLength = end.Length;

            if (startIndex + headLength + endLength >= length)
            {
                //剩余内容不足
                return;
            }

            for (int i = 0; i < endLength; i++)
            {
                char a = contet[startIndex + i];
                char b = head[i];
                if (a == b)
                {
                }
                else
                {
                    // 不是富文本
                    return;
                }
            }
        }

    }

    public class Data
    {
        public char[] head;
        public char[] tail;
    }
}