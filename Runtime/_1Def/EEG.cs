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
        /// �����Ͱ� ���� ���¿��� Ķ���극�̼� ����
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
