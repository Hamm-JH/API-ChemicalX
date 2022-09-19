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
        private void Start()
        {
            // ���� Ÿ�� ����׷� ����
            GlobalSetting.BUILDTYPE = BuildType.Debug;

            DemoRunner.Instance.Run();
        }

        private void OnDestroy()
        {
            DemoRunner.Instance.Destroy();
        }

        // Update is called once per frame
        void Update()
        {
            // 1. EEG ������ ���
            PrintEEG(BrainAPI.CurrentEEG);

            // 2. Strongest EEG part ������ ���
            PrintStrongestEEGPart(BrainAPI.StrongestEEGPart);

            // 3. Device noises ���
            PrintDeviceNoises(BrainAPI.DeviceNoises);

            // 4. Equip status ���
            PrintEquipStatus(BrainAPI.IsDeciveEquipped);
        }
    }
}
