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
        public bool bDebugEEG;
        public bool bDebugStrongestEEGPart;
        public bool bDebugDeviceNoises;
        public bool bDebugIsDeviceEquipped;

        private void Start()
        {
            // ���� Ÿ�� ����׷� ����
            GlobalSetting.BUILDTYPE = BuildType.Debug;

            // ����� �׽�Ʈ ������ �����ڵ� ����
            DemoRunner.Instance.Run();
        }

        private void OnDestroy()
        {
            // ����� �񵿱� �ڵ� ���� ����
            DemoRunner.Instance.Destroy();
        }

        // Update is called once per frame
        void Update()
        {
            if (bDebugEEG)
            {
                // 1. EEG ������ ���
                PrintEEG(BrainAPI.CurrentEEG);
            }

            if (bDebugStrongestEEGPart)
            {
                // 2. Strongest EEG part ������ ���
                PrintStrongestEEGPart(BrainAPI.StrongestEEGPart);
            }

            if (bDebugDeviceNoises)
            {
                // 3. Device noises ���
                PrintDeviceNoises(BrainAPI.DeviceNoises);
            }

            if (bDebugIsDeviceEquipped)
            {
                // 4. Equip status ���
                PrintEquipStatus(BrainAPI.IsDeciveEquipped);
            }
        }
    }
}
