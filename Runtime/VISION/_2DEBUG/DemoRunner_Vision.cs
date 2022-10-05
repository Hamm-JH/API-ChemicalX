using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace ChemicalX.Core
{
    public partial class DemoRunner_Vision
    {
        #region Values

        private static DemoRunner_Vision instance;

        public static DemoRunner_Vision Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DemoRunner_Vision();
                }
                return instance;
            }
        }

        #endregion

        //public DemoRunner_Vision()
        //{
        //    bIsRunning = true;
        //    bIsContacted = false;
        //    ContactedDistance = 0f;
        //    ContactedArea = 0f;
        //}

        public bool bIsRunning { get; set; }

        public bool bIsContacted { get; set; }

        public float ContactedDistance { get; set; }

        public float ContactedArea { get; set; }

        public async void Run()
        {
            bIsRunning = true;

            CreateContactedRange();
        }

        public void Destroy()
        {
            bIsRunning = false;
        }

        ~DemoRunner_Vision()
        {
            bIsRunning = false;
        }
    }
}
