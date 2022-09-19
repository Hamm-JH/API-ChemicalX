using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using ChemicalX.Core;
using ChemicalX.Core.API;
using ChemicalX.Core.Brain;

namespace ChemicalX.Core
{
    public partial class DemoCode : MonoBehaviour
    {
        /// <summary>
        /// EEG 데이터 출력
        /// </summary>
        /// <param name="data"></param>
        void PrintEEG(List<EEG> data)
        {
            Debug.Log("");
            Debug.Log("EEG");
            foreach (EEG e in data)
            {
                Debug.Log("EEG Data");
                for (int i = 0; i < e.Data.Count; i++)
                {
                    Debug.Log($"{i} : {e.Data[i]}");
                }
            }
        }

        /// <summary>
        /// StrongestEEGPart 출력
        /// </summary>
        /// <param name="data"></param>
        void PrintStrongestEEGPart(List<EEGType> data)
        {
            Debug.Log("");
            Debug.Log("Strongest eeg part");
            for (int i = 0; i < data.Count; i++)
            {
                Debug.Log($"plyaer {i} : {data[i].ToString()}");
            }
        }

        /// <summary>
        /// 장비 노이즈 출력
        /// </summary>
        /// <param name="data"></param>
        void PrintDeviceNoises(List<int> data)
        {
            Debug.Log("");
            Debug.Log("Device noises");
            for (int i = 0; i < data.Count; i++)
            {
                Debug.Log($"player {i} : {data[i].ToString()}");
            }
        }

        /// <summary>
        /// 장비 착용상태 출력
        /// </summary>
        /// <param name="data"></param>
        void PrintEquipStatus(List<bool> data)
        {
            Debug.Log("");
            Debug.Log("Equip status");
            for (int i = 0; i < data.Count; i++)
            {
                Debug.Log($"player {i} : {data[i].ToString()}");
            }
        }
    }
}
