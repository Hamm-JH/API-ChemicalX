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
            // 빌드 타입 디버그로 설정
            GlobalSetting.BUILDTYPE = BuildType.Debug;

            // 데모용 테스트 데이터 생성코드 실행
            DemoRunner.Instance.Run();
        }

        private void OnDestroy()
        {
            // 종료시 비동기 코드 동작 정지
            DemoRunner.Instance.Destroy();
        }

        // Update is called once per frame
        void Update()
        {
            if (bDebugEEG)
            {
                // 1. EEG 데이터 출력
                PrintEEG(BrainAPI.CurrentEEG);
            }

            if (bDebugStrongestEEGPart)
            {
                // 2. Strongest EEG part 데이터 출력
                PrintStrongestEEGPart(BrainAPI.StrongestEEGPart);
            }

            if (bDebugDeviceNoises)
            {
                // 3. Device noises 출력
                PrintDeviceNoises(BrainAPI.DeviceNoises);
            }

            if (bDebugIsDeviceEquipped)
            {
                // 4. Equip status 출력
                PrintEquipStatus(BrainAPI.IsDeciveEquipped);
            }
        }
    }
}
