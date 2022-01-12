using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;


namespace Diablo
{
    class DataManager
    {
        private static DataManager instance;
        private const string DATA_PATH = "./Datas";
        private Dictionary<int, CharacterData> dicCharacterDatas;
        private Dictionary<int, WeaponData> dicWeaponDatas;
        private Dictionary<int, MonsterData> dicMonsterDatas;

        private DataManager() {
            this.dicCharacterDatas = new Dictionary<int, CharacterData>();
            this.dicWeaponDatas = new Dictionary<int, WeaponData>();
            this.dicMonsterDatas = new Dictionary<int, MonsterData>();
        }

        public static DataManager GetInstance() {
            if (DataManager.instance == null) DataManager.instance = new DataManager();
            return DataManager.instance;
        }

        public void LoadAllDatas() {
            string path = string.Format("{0}/{1}", DATA_PATH, "character_data.json");
            string json = File.ReadAllText(path);
            this.dicCharacterDatas = JsonConvert.DeserializeObject<CharacterData[]>(json).ToDictionary(x => x.id);

            path = string.Format("{0}/{1}", DATA_PATH, "weapon_data.json");
            json = File.ReadAllText(path);
            this.dicWeaponDatas = JsonConvert.DeserializeObject<WeaponData[]>(json).ToDictionary(x => x.id);

            path = string.Format("{0}/{1}", DATA_PATH, "monster_data.json");
            json = File.ReadAllText(path);
            this.dicMonsterDatas = JsonConvert.DeserializeObject<MonsterData[]>(json).ToDictionary(x => x.id);

            Console.WriteLine("모든 데이터를 로드 했습니다.");
            Console.WriteLine("케릭터 데이터 : {0}개", this.dicCharacterDatas.Count);
            Console.WriteLine("무기 데이터 : {0}개", this.dicWeaponDatas.Count);
            Console.WriteLine("몬스터 데이터 : {0}개", this.dicMonsterDatas.Count);
        }

        public CharacterData[] GetCharacterDatas() {
            
            //CharacterData[] arr = new CharacterData[this.dicCharacterDatas.Values.Count];
            //int i = 0;
            //foreach (var val in this.dicCharacterDatas.Values) {
            //    arr[i++] = val;
            //}
            //return arr;

            return this.dicCharacterDatas.Values.ToArray();

        }

        public WeaponData GetWeaponData(int characterId) {
            var characterData =  this.dicCharacterDatas[characterId];
            var weaponData = this.dicWeaponDatas[characterData.defaultWeaponId];
            return weaponData;
        }
    }
}
