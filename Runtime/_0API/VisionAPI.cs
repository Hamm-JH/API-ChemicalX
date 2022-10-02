using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChemicalX.Core.API
{
    public class VisionAPI : MonoBehaviour, IAPI
    {
        /// <summary>
        /// 두 사람이 접촉했는가?
        /// return true : 접촉함
        /// return false : 접촉하지 않음
        /// </summary>
        public static bool IsContacted
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 두 사람의 접촉 면적비
        /// return 0 ~ 1
        /// </summary>
        public static float ContactedAreaRatio
        {
            get
            {
                return 0;
                //return 1;
            }
        }

        /// <summary>
        /// 두 사람의 거리
        /// return ~(m)
        /// </summary>
        public static float ContactedUsersDistance
        {
            get
            {
                return 1; // 1m
            }
        }


    }
}
