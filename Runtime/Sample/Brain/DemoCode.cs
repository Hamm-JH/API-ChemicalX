using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using ChemicalX.Core;
using ChemicalX.Core.API;
using ChemicalX.Core.Brain;

namespace ChemicalX.Core
{
    /// <summary>
    /// ★★★ 패키지 내부코드 바꿔도 업데이트때 리셋될 수 있으니 참고용으로 확인만 해주시면 됩니다.
    /// </summary>
    public partial class DemoCode : MonoBehaviour
    {
        public BuildType buildType;
        public EquipStatus p1EquipStatus;
        public EquipStatus p2EquipStatus;

        [Header("Debug")]
        private string currentAPI;
        public bool bDebugEEG;
        public bool bDebugStrongestEEGPart;
        public bool bDebugDeviceNoises;
        public bool bDebugIsDeviceEquipped;

        private void Start()
        {
            // Start 1. 빌드 타입 디버그로 설정
            GlobalSetting.BUILDTYPE = buildType;
            GlobalSetting.Player1EquipStatus = p1EquipStatus;
            GlobalSetting.Player2EquipStatus = p2EquipStatus;
            currentAPI = GlobalSetting.brainReleaseAPI;

            if (buildType == BuildType.Debug)
            {
                // Start 2. 데모용 테스트 데이터 생성코드 실행
                DemoRunner.Instance.Run();
            }
            // BuildType.Release
            else
            {
                APIServer.Instance.Run();
            }
        }

        private void OnDestroy()
        {
            // End. 종료시 비동기 코드 동작 정지
            DemoRunner.Instance.Destroy();
            APIServer.Instance.Destroy();
        }

        private void OnValidate()
        {
            GlobalSetting.BUILDTYPE = buildType;
            GlobalSetting.Player1EquipStatus = p1EquipStatus;
            GlobalSetting.Player2EquipStatus = p2EquipStatus;
            currentAPI = GlobalSetting.brainReleaseAPI;
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
