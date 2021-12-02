using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    //管理整个游戏的UI系统（？战斗内 外）

    public class UIFractory
    {
        //对外职责
        //获取UI
        public static T GetUI<T>() where T : class, UIBase, new()
        {
            T ui = new T();


            return default;
        }
        //关闭UI
        public static void Close<T>(T t) where T : UIBase
        {
        }
    }
}