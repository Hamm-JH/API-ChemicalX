using System.Collections;
using System.Collections.Generic;
using ChemicalX.Core.Brain;
using UnityEngine;

namespace ChemicalX.Core
{
    public class EEG
    {
        public EEG()
        {
            Data = new List<float>();
        }

        public List<float> Data
        {
            get; set;
        }

        /// <summary>
        /// 데이터가 들어온 상태에서 캘리브레이션 수행
        /// </summary>
        public void Calibration()
        {
            float sum = 0f;

            for (int i = 0; i < Data.Count; i++)
            {
                sum += Data[i];
            }

            if (sum > 0f)
            {
                for (int i = 0; i < Data.Count; i++)
                {
                    Data[i] = Data[i] / sum;
                }
            }
        }

        public EEGType StrongestEEGpart()
        {
            EEGType tp = EEGType.NULL;

            int result = ListCon.WhereIsStrongestIndex(Data);

            tp = (EEGType)result;

            return tp;
        }
    }
}
