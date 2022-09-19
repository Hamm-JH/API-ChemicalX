using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace ChemicalX.Core
{
    /// <summary>
    /// ���� ������ ���� Ŭ����
    /// </summary>
    public partial class DemoRunner
    {
        #region Create EEG data / Strongest EEG part

        /// <summary>
        /// �񵿱� EEG ������ ����
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
        /// ���� EEG ������ �ʱ�ȭ
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
        /// ���� EEG ������ �Ҵ�
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
        /// EEG �Ҵ�ø��� ���� ���� EEGIndex�� ���Ѵ�.
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
