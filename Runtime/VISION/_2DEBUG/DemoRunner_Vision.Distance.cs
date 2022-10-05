using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace ChemicalX.Core
{
    public partial class DemoRunner_Vision
    {
        #region Create Contacted range

        async void CreateContactedRange()
        {
            InitContactedData();

            System.Random rand = new System.Random();

            while (bIsRunning)
            {
                SetContactedDistance(rand);
                SetIsContacted();
                SetContactedArea();

                await Task.Delay(200);
            }
        }


        private void InitContactedData()
        {
            this.bIsContacted = false;
            this.ContactedDistance = 0f;
            this.ContactedArea = 0f;
        }

        private void SetContactedDistance(System.Random rand)
        {
            switch (GlobalSetting.VisionContactStatus)
            {
                case ContactStatus.ALLRandom:
                    ContactedDistance = rand.Next(GlobalSetting.MaxDistanceRandomRange*10) / 10f;
                    break;

                case ContactStatus.StaticContacted:
                    ContactedDistance = GlobalSetting.ContactBoundary - 0.5f;
                    break;

                case ContactStatus.RandomContacted:
                    ContactedDistance = rand.Next((int)(GlobalSetting.ContactBoundary * 10)) / 10f;
                    break;

                case ContactStatus.StaticNotContacted:
                    ContactedDistance = GlobalSetting.ContactBoundary + 0.5f;
                    break;

                case ContactStatus.RandomNotContacted:
                    int value = (int)((GlobalSetting.MaxDistanceRandomRange - GlobalSetting.ContactBoundary) * 10);
                    ContactedDistance = GlobalSetting.ContactBoundary + (rand.Next(value) / 10f);
                    break;

                default:
                    ContactedDistance = GlobalSetting.ContactBoundary;
                    break;
            }
            //Debug.Log(ContactedDistance);

        }

        private void SetIsContacted()
        {
            bIsContacted = ContactedDistance < GlobalSetting.ContactBoundary ? true : false;
        }
        
        private void SetContactedArea()
        {
            float dist = ContactedDistance;
            
            if (dist < GlobalSetting.ContactBoundary)
            {
                float value = dist / GlobalSetting.ContactBoundary;

                ContactedArea = 1 - value;
            }
            else
            {
                ContactedArea = 0;
            }
        }

        #endregion


    }
}
