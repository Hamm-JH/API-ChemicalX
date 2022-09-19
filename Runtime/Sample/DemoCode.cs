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
            // 빌드 타입 디버그로 설정
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
            // 1. EEG 데이터 출력
            PrintEEG(BrainAPI.CurrentEEG);

            // 2. Strongest EEG part 데이터 출력
            PrintStrongestEEGPart(BrainAPI.StrongestEEGPart);

            // 3. Device noises 출력
            PrintDeviceNoises(BrainAPI.DeviceNoises);

            // 4. Equip status 출력
            PrintEquipStatus(BrainAPI.IsDeciveEquipped);
        }
    }
}
