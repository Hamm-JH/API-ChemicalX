using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace ChemicalX.Core
{
    /// <summary>
    /// 데모 데이터 생성 클래스
    /// </summary>
    public partial class DemoRunner
    {
        #region Create EEG data / Strongest EEG part

        /// <summary>
        /// 비동기 EEG 데이터 생성
        /// </summary>
        async void CreateCurrentEEG()
        {
            // TODO Create Step needs refactoring
            EEGData = new List<EEG>();
            EEGData.Add(InitSingleEEGData());
            EEGData.Add(InitSingleEEGData());

            // TODO Create Step needs refactoring
            StrongestEEGIndex = new List<Brain.EEGType>();
            StrongestEEGIndex.Add(Brain.EEGType.NULL);
            StrongestEEGIndex.Add(Brain.EEGType.NULL);

            System.Random rand = new System.Random();

            while (bIsRunning)
            {
                //Debug.Log("");
                //Debug.Log("Player1 EEG Data");
                SetSingleEEGData(EEGData[0], rand);
                SetStrongestEEGIndex(EEGData[0], 0);

                //Debug.Log("");
                //Debug.Log("Player2 EEG Data");
                SetSingleEEGData(EEGData[1], rand);
                SetStrongestEEGIndex(EEGData[1], 1);

                //Debug.Log("");

                await Task.Delay(1000);
            }

            EEGData = null;
        }

        /// <summary>
        /// 단일 EEG 데이터 초기화
        /// </summary>
        /// <returns></returns>
        public EEG InitSingleEEGData()
        {
            EEG eeGData = new EEG();

            for (int i = 0; i < 8; i++)
            {
                eeGData.Data.Add(0f);
            }

            return eeGData;
        }

        #endregion

        #region Set EEG data

        /// <summary>
        /// 단일 EEG 데이터 할당
        /// </summary>
        /// <param name="data"></param>
        /// <param name="rand"></param>
        public void SetSingleEEGData(EEG data, System.Random rand)
        {
            // Set Sum Data
            float sum = 0f;

            for (int i = 0; i < data.Data.Count; i++)
            {
                data.Data[i] = rand.Next(200000);
                sum += data.Data[i];
            }

            for (int i = 0; i < data.Data.Count; i++)
            {
                data.Data[i] = data.Data[i] / sum;
            }

            //for (int i = 0; i < data.Data.Count; i++)
            //{
            //    Debug.Log($"index {i} : {data.Data[i]}");
            //}
        }

        #endregion

        #region Set Strongest EEG Part

        /// <summary>
        /// EEG 할당시마다 제일 강한 EEGIndex를 구한다.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="playerIndex"></param>
        public void SetStrongestEEGIndex(EEG data, int playerIndex)
        {
            int result = ListCon.WhereIsStrongestIndex(data.Data);

            StrongestEEGIndex[playerIndex] = (Brain.EEGType)(result);
        }

        #endregion
    }
}
