using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChemicalX.Core.API
{
    public class BrainAPI : MonoBehaviour, IAPI
    {
        public static List<EEG> CurrentEEG
        {
            get
            {
                if (GlobalSetting.BUILDTYPE == BuildType.Release)
                {
                    // TODO Release로 변경
                    return DemoRunner.Instance.EEGData;
                }
                else
                {
                    return DemoRunner.Instance.EEGData;
                }
            }
        }

        public static List<Brain.EEGType> StrongestEEGPart
        {
            get
            {
                if (GlobalSetting.BUILDTYPE == BuildType.Release)
                {
                    // TODO Release로 변경
                    return DemoRunner.Instance.StrongestEEGIndex;
                }
                else
                {
                    return DemoRunner.Instance.StrongestEEGIndex;
                }
            }
        }

        public static List<bool> IsDeciveEquipped
        {
            get
            {
                if (GlobalSetting.BUILDTYPE == BuildType.Release)
                {
                    return DemoRunner.Instance.bEquipStatus;
                }
                else
                {
                    return DemoRunner.Instance.bEquipStatus;
                }
            }
        }

        public static List<int> DeviceNoises
        {
            get
            {
                if (GlobalSetting.BUILDTYPE == BuildType.Release)
                {
                    return DemoRunner.Instance.noiseLevel;
                }
                else
                {
                    return DemoRunner.Instance.noiseLevel;
                }
            }
        }
    }
}
