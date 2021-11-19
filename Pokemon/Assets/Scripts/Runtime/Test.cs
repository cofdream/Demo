using System.Diagnostics;
using UnityEngine;

namespace Pekemon
{
    public class Test : MonoBehaviour
    {

        public bool Call;
        public int length = 10000;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Call)
            {
                Call = false;

                //GameObject go;
                //go = gameObject;

                var go = new GameObject().GetComponent<ITriggerable>();

                System.Object go2 = go;


                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start(); //  开始监视代码

                //_________________要执行的函数______________________
                //Code……

                for (int i = 0; i < length; i++)
                {
                    if (go == null)
                    {
                        int t = i;
                    }
                }

                stopwatch.Stop(); //  停止监视
                UnityEngine.Debug.Log("go == null  " + stopwatch.Elapsed.TotalMilliseconds /*  获取总时间  毫秒数 */);



                stopwatch.Restart(); //  开始监视代码
                //_________________要执行的函数______________________
                //Code……

                for (int i = 0; i < length; i++)
                {
                    if (UnityEngine.Object.ReferenceEquals(go, null))
                    {
                        int t = i;
                    }
                }

                stopwatch.Stop(); //  停止监视
                UnityEngine.Debug.Log("object.ReferenceEquals(go, null)  " + stopwatch.Elapsed.TotalMilliseconds /*  获取总时间  毫秒数 */);



                stopwatch.Restart(); //  开始监视代码

                //_________________要执行的函数______________________
                //Code……

                for (int i = 0; i < length; i++)
                {
                    if (go2 == null)
                    {
                        int t = i;
                    }
                }

                stopwatch.Stop(); //  停止监视
                UnityEngine.Debug.Log("go2 == null  " + stopwatch.Elapsed.TotalMilliseconds /*  获取总时间  毫秒数 */);


                stopwatch.Restart(); //  开始监视代码

                //_________________要执行的函数______________________
                //Code……

                for (int i = 0; i < length; i++)
                {
                    if ((System.Object)go == null)
                    {
                        int t = i;
                    }
                }

                stopwatch.Stop(); //  停止监视
                UnityEngine.Debug.Log("(S.Object)go == null  " + stopwatch.Elapsed.TotalMilliseconds /*  获取总时间  毫秒数 */);



                stopwatch.Restart(); //  开始监视代码

                //_________________要执行的函数______________________
                //Code……

                for (int i = 0; i < length; i++)
                {
                    if ((System.Object)go == null)
                    {
                        int t = i;
                    }
                }

                stopwatch.Stop(); //  停止监视
                UnityEngine.Debug.Log("(S.Object)go == null  " + stopwatch.Elapsed.TotalMilliseconds /*  获取总时间  毫秒数 */);

            }
        }



    }
}
