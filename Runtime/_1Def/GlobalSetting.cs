using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChemicalX.Core
{
    public static class GlobalSetting
    {
        public static BuildType BUILDTYPE = BuildType.Debug;
        public static EquipStatus Player1EquipStatus = EquipStatus.NULL;
        public static EquipStatus Player2EquipStatus = EquipStatus.NULL;

        /// <summary>
        /// (int) 비전 데모 데이터 생성시 접근 데이터 최대거리값
        /// </summary>
        public static int MaxDistanceRandomRange = 10;

        /// <summary>
        /// 접근 판정 경계
        /// </summary>
        public static float ContactBoundary = 1.5f;

        public static ContactStatus VisionContactStatus = ContactStatus.NULL;
    }
}
