using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class BattleInteractive : MonoBehaviour, ITriggerable
    {
        [SerializeField] private TrainersConfig config;
        public void PlayerTriggerable(PlayerController playerController)
        {
            Debug.Log("Start Battle ");
        }
    }

    // 和人物对话

    //
    //参数 触发者 
    //字段 被触发者

    // 主角 主动点击按钮xx 触发
    public class PropA
    {
        // 为主角添加 xx 道具到背包。
    }

    public class PropB
    {
        // xxx
    }

    public class XX_2
    {
        // 展开一段对话

        // 结束后 开始战斗
    }

    // 主角 移动结束以后 立即触发
    public class XX_1
    {
        // 传送到 指定地点
    }


}