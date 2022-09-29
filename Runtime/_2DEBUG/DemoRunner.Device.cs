using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace ChemicalX.Core
{
    public partial class DemoRunner
    {
        #region Create Device Noise / Equip status

        /// <summary>
        /// 비동기 장비 데이터 수집 상태 데이터 생성
        /// </summary>
        async void CreateCurrentNoiseLevel()
        {
            InitNoiseValues();

            System.Random rand = new System.Random();

            while (bIsRunning)
            {
                //Debug.Log("Hello Noise");
                SetDeviceNoise(0, GlobalSetting.Player1EquipStatus, rand);
                SetDeviceNoise(1, GlobalSetting.Player1EquipStatus, rand);

                SetEquipStatus(0);
                SetEquipStatus(1);

                await Task.Delay(1000);
            }

            bEquipStatus = null;
            noiseLevel = null;
        }

        /// <summary>
        /// 노이즈 변수 생성
        /// </summary>
        void InitNoiseValues()
        {
            bEquipStatus = new List<bool>();
            bEquipStatus.Add(false);
            bEquipStatus.Add(false);

            noiseLevel = new List<int>();
            noiseLevel.Add(0);
            noiseLevel.Add(0);
        }

        #endregion

        #region Set device noise

        /// <summary>
        /// 장비 노이즈 레벨 할당
        /// </summary>
        /// <param name="index"></param>
        /// <param name="rand"></param>
        void SetDeviceNoise(int index, EquipStatus status, System.Random rand)
        {
            switch (status)
            {
                case EquipStatus.ALLRandom:
                    noiseLevel[index] = rand.Next(201) / 2;
                    break;

                case EquipStatus.StaticEquipped:
                    noiseLevel[index] = 0;
                    break;

                case EquipStatus.RandomEquipped:
                    noiseLevel[index] = rand.Next(161) / 2;
                    break;

                case EquipStatus.StaticNotEquipped:
                    noiseLevel[index] = 200 / 2;
                    break;

                case EquipStatus.RandomNotEquipped:
                    noiseLevel[index] = (160 + rand.Next(41)) / 2;
                    break;
            }
        }

        #endregion

        #region Set equip status

        /// <summary>
        /// 장비 입력상태 할당
        /// </summary>
        /// <param name="index"></param>
        void SetEquipStatus(int index)
        {
            bEquipStatus[index] = noiseLevel[index] <= 80 ? true : false;
        }

        #endregion
    }
}
