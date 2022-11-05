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

        public static string brainReleaseAPI = "http://192.168.50.11:3002/BCIOut";  // Local brain api
        // string targetUri = "http://dudoWeb.iptime.org:50200/BCIOut"; // 원격 brain api
        public static string visionReleaseAPI = "http://192.168.50.11:3002/VISIONOUT"; // Local vision api
        // public static string visionReleaseAPI = "http://dudoWeb.iptime.org:50200/VISIONOUT"  // 원격 vision api

        /// <summary>
        /// (int) ���� ���� ������ ������ ���� ������ �ִ�Ÿ���
        /// </summary>
        public static int MaxDistanceRandomRange = 10;

        /// <summary>
        /// ���� ���� ���
        /// </summary>
        public static float ContactBoundary = 1.5f;

        public static ContactStatus VisionContactStatus = ContactStatus.NULL;
    }
}
