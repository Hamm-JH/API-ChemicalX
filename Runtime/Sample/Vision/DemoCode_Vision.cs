using ChemicalX.Core.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChemicalX.Core
{
    /// <summary>
    /// 패키지 내부코드 바꿔도 리셋될 수 있음.
    /// </summary>
    public partial class DemoCode_Vision : MonoBehaviour
    {
        public BuildType buildType;

        // public private releaseURL;

        [Header("Demo")]
        /// <summary>
        /// 데모 데이터 조작용 열거변수
        /// </summary>
        public ContactStatus contactStatus;

        /// <summary>
        /// 감지거리 최대 경계값 (contactBoundary보다 작으면 에러발생)
        /// </summary>
        [Range(2, 10)]
        public int maxDistanceRandomRange;

        /// <summary>
        /// 접촉 판단 경계값 (maxDistanceRandomRange보다 크면 에러발생)
        /// </summary>
        public float contactBoundary;

        [Header("Debug")]
        private string currentAPI = GlobalSetting.visionReleaseAPI;
        public bool bDebugIsContacted;
        public bool bDebugContactedAreaRatio;
        public bool bDebugContactedUserDistance;

        // Start is called before the first frame update
        void Start()
        {
            GlobalSetting.BUILDTYPE = buildType;
            GlobalSetting.VisionContactStatus = contactStatus;
            GlobalSetting.MaxDistanceRandomRange = maxDistanceRandomRange;
            GlobalSetting.ContactBoundary = contactBoundary;
            currentAPI = GlobalSetting.visionReleaseAPI;

            if (buildType == BuildType.Debug)
            {
                DemoRunner_Vision.Instance.Run();
            }
            else
            {
                APIServer.Instance.Run();
            }
        }

        private void OnValidate()
        {
            GlobalSetting.BUILDTYPE = buildType;
            GlobalSetting.VisionContactStatus = contactStatus;
            GlobalSetting.MaxDistanceRandomRange = maxDistanceRandomRange;
            GlobalSetting.ContactBoundary = contactBoundary;
            currentAPI = GlobalSetting.visionReleaseAPI;
        }

        // Update is called once per frame
        void Update()
        {
            if (bDebugIsContacted)
            {
                // 1. 접촉여부 확인
                PrintIsContacted(VisionAPI.IsContacted);
            }

            if (bDebugContactedAreaRatio)
            {
                // 2. 접촉면적 확인
                PrintContactedAreaRatio(VisionAPI.ContactedAreaRatio);
            }

            if (bDebugContactedUserDistance)
            {
                // 3. 두 사람의 거리 확인
                PrintContactedUsersDistance(VisionAPI.ContactedUsersDistance);
            }
        }

        private void OnDestroy()
        {
            DemoRunner_Vision.Instance.Destroy();
            APIServer.Instance.Destroy();
        }
    }
}
