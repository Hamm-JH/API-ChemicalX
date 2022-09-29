using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChemicalX.Core
{
    public enum BuildType
    {
        Debug,
        Release
    }

    public enum EquipStatus
    {
        NULL = -1,

        /// <summary>
        /// ���� ����, ������ ���¸� �ѳ���� ������
        /// </summary>
        ALLRandom,
        StaticEquipped,
        RandomEquipped,
        StaticNotEquipped,
        RandomNotEquipped,
    }

    namespace Brain
    {
        public enum EEGType
        {
            NULL = -1,
            Delta = 0,
            Theta = 1,
            lowAlpha = 2,
            highAlpha = 3,
            lowBeta = 4,
            highBeta = 5,
            lowGamma = 6,
            midGamma = 7,
        }
    }
}
