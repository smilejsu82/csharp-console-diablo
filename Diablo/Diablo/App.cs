using System;

namespace Diablo
{
    public enum eCharacterType {
                  
        NONE, BARBARIAN, AMAZON, SOSURISE, PALADIN
    }
    class App
    {
        //생성자 
        public App() {

            DataManager.GetInstance().LoadAllDatas();

            Console.WriteLine("******************");
            Console.WriteLine("***** Diablo *****");
            Console.WriteLine("*** Game Start ***");
            Console.WriteLine("******************");

            //용사여 처음오셨군요

            //1.바바리안
            //2.아마존
            //3.소서리스
            //4.팔라딘
            //케릭터 선택해주세요(숫자1 ~4) : 1

            CharacterData[] characterDatas = DataManager.GetInstance().GetCharacterDatas();
            for (int i = 0; i < characterDatas.Length; i++) {
                var data = characterDatas[i];
                int idx = i + 1;
                Console.WriteLine("{0}.{1}", idx,  data.name);
            }

            Console.Write("케릭터 선택해주세요(숫자1 ~4) : ");
            string input = Console.ReadLine();
            int num = int.Parse(input);
            CharacterData selectedCharacterData = characterDatas[num - 1];
            Console.WriteLine("어서오시게나 {0} 용사여...", selectedCharacterData.name);
            Console.WriteLine("무기를 주겠네...");
            eCharacterType characterType = (eCharacterType)num;
            
            WeaponData weaponData = DataManager.GetInstance().GetWeaponData(selectedCharacterData.id);  //선택한 케릭터 ID
            Weapon defaultWeapon = new Weapon(weaponData.id);

            // Test colors with blue background, white foreground.
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(weaponData.name);
            Console.ResetColor();

            Console.Write("를 획득 했습니다.");
            Console.WriteLine();
            
            

            if (characterType == eCharacterType.PALADIN) {
                Console.WriteLine("헛!!!");
                Console.WriteLine("나 팔라딘인디.... -_-;;");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine(".");
                Console.WriteLine("[목소리] 단검밖에 준비가 되지 않았네 미안하네...");
            }

        }
    }
}
