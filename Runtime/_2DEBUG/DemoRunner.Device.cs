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

            while(bIsRunning)
            {
                //Debug.Log("Hello Noise");
                SetDeviceNoise(0, rand);
                SetDeviceNoise(1, rand);

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
        void SetDeviceNoise(int index, System.Random rand)
        {
            noiseLevel[index] = rand.Next(201);
        }

        #endregion

        #region Set equip status

        /// <summary>
        /// 장비 입력상태 할당
        /// </summary>
        /// <param name="index"></param>
        void SetEquipStatus(int index)
        {
            bEquipStatus[index] = noiseLevel[index] / 2 < 80 ? true : false;
        }

        #endregion
    }
}
