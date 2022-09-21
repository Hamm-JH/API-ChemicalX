using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChemicalX.Core
{
    internal interface IBrain
    {
        public bool bIsRunning { get; set; }

        /// <summary>
        /// EEG 데이터
        /// </summary>
        public List<EEG> EEGData { get; set; }

        /// <summary>
        /// 가장 강한 EEG index
        /// </summary>
        public List<Brain.EEGType> StrongestEEGIndex { get; set; }

        /// <summary>
        /// 장비 착용 상태
        /// </summary>
        public List<bool> bEquipStatus { get; set; }

        /// <summary>
        /// 장비 노이즈 레벨
        /// </summary>
        public List<int> noiseLevel { get; set; }
    }
}
