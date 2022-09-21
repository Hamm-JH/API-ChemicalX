using ChemicalX.Core.Brain;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChemicalX.Core
{
    public partial class APIServer : IBrain
    {
        #region Values
        private static APIServer instance;

        public static APIServer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new APIServer();
                }
                return instance;
            }
        }

        public bool bIsRunning { get; set; }

        #region Brain API

        public List<EEG> EEGData { get; set; }

        public List<EEGType> StrongestEEGIndex { get; set; }

        public List<bool> bEquipStatus { get; set; }

        public List<int> noiseLevel { get; set; }

        #endregion

        #endregion

        public async void Run()
        {
            bIsRunning = true;

            CreateDataset();

            RequestBrainData();
        }

        public void Destroy()
        {
            bIsRunning = false;
        }

        public void CreateDataset()
        {
            EEGData = new List<EEG>();
            EEGData.Add(new EEG());
            EEGData.Add(new EEG());

            // Null enum 코드 제외 요소 추가
            for (int i = 0; i < Enum.GetValues(typeof(EEGType)).Length -1; i++)
            {
                EEGData[0].Data.Add(0f);
                EEGData[1].Data.Add(0f);
            }

            StrongestEEGIndex = new List<EEGType>();
            StrongestEEGIndex.Add(EEGType.NULL);
            StrongestEEGIndex.Add(EEGType.NULL);

            bEquipStatus = new List<bool>();
            bEquipStatus.Add(false);
            bEquipStatus.Add(false);

            noiseLevel = new List<int>();
            noiseLevel.Add(0);
            noiseLevel.Add(0);
        }
    }
}
