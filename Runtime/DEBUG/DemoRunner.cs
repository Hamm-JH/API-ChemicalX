using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace ChemicalX.Core
{
    public partial class DemoRunner
    {
        #region Values
        private static DemoRunner instance;

        public static DemoRunner Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DemoRunner();
                }
                return instance;
            }
        }

        bool bIsRunning;

        /// <summary>
        /// EEG 데이터
        /// </summary>
        public List<EEG> EEGData;

        /// <summary>
        /// 가장 강한 EEG index
        /// </summary>
        public List<Brain.EEGType> StrongestEEGIndex;

        /// <summary>
        /// 장비 착용 상태
        /// </summary>
        public List<bool> bEquipStatus;

        /// <summary>
        /// 장비 노이즈 레벨
        /// </summary>
        public List<int> noiseLevel;

        #endregion

        public async void Run()
        {
            bIsRunning = true;

            CreateCurrentEEG();
            CreateCurrentNoiseLevel();
        }


        public void Destroy()
        {
            bIsRunning = false;
        }

        ~DemoRunner()
        {
            bIsRunning = false;
        }
    }
}
