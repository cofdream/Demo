﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Pekemon
{
    [System.Serializable]
    public class GameArchive
    {
        private readonly static string savePath;

        public static GameArchive Instance { get; private set; }

        private GameArchive() { }
        static GameArchive()
        {
#if UNITY_EDITOR
            savePath = Directory.GetParent(Application.dataPath) + "/GameArchive.json";
#else
            SavePath = Application.persistentDataPath + "/GameArchive.json";
#endif
            if (File.Exists(savePath))
            {
                var json = File.ReadAllText(savePath);
                Instance = JsonUtility.FromJson<GameArchive>(json);
            }
            else
            {
                Instance = new GameArchive();
            }
        }

        public Trainers Hero;

    }

    [System.Serializable]
    public class Trainers
    {
        public Pet[] Pets;
    }

}
