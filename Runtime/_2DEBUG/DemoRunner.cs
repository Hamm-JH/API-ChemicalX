using ChemicalX.Core.Brain;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace ChemicalX.Core
{
    public partial class DemoRunner : IBrain
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

        public bool bIsRunning { get; set; }

        public List<EEG> EEGData { get; set; }

        public List<EEGType> StrongestEEGIndex { get; set; }

        public List<bool> bEquipStatus { get; set; }

        public List<int> noiseLevel { get; set; }

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
