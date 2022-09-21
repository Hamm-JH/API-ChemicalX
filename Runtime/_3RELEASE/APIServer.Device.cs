using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChemicalX.Core
{
    public partial class APIServer : IBrain
    {
        #region Set device noise

        internal void SetDeviceNoise(PlayerBrainData data, int index)
        {
            noiseLevel[index] = data.PoorSignal;
        }

        #endregion

        #region Set equip status

        internal void SetEquipStatus(int index)
        {
            bEquipStatus[index] = noiseLevel[index] < 80 ? true : false;
        }

        #endregion
    }
}
