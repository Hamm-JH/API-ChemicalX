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

        public bool bDebugIsContacted;
        public bool bDebugContactedAreaRatio;
        public bool bDebugContactedUserDistance;

        // Start is called before the first frame update
        void Start()
        {
            GlobalSetting.BUILDTYPE = buildType;
        }

        private void OnValidate()
        {
            GlobalSetting.BUILDTYPE = buildType;
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
    }
}
