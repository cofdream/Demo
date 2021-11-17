using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    [System.Serializable]
    public class PlayerData
    {
        private static PlayerData instance;
        public static PlayerData Instance
        {
            get
            {
                if (instance == null)
                {
                    string path = "Assets/Resource/PlayerData.json";
                    if (System.IO.File.Exists(path))
                    {
                        var json = System.IO.File.ReadAllText(path);
                        instance = JsonUtility.FromJson<PlayerData>(json);
                    }
                    else
                    {
                        instance = new PlayerData();
                    }
                }
                return instance;
            }
        }

        public static void Save()
        {
            //var json = JsonUtility.ToJson(instance, true);
            //System.IO.File.WriteAllText("Assets/Resource/PlayerData.json", json);
        }


        public string Name;
        public bool Sex;

        public BagData BagData;

        public PetData[] PetDatas;
    }
}