using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChemicalX.Core
{
    public partial class DemoCode_Vision : MonoBehaviour
    {
        public void PrintIsContacted(bool isContacted)
        {
            Debug.Log("----------------------------");
            Debug.Log($"is contacted : {isContacted}");
        }

        public void PrintContactedAreaRatio(float contactedAreaRatio)
        {
            Debug.Log("----------------------------");
            Debug.Log($"contacted area ratio : {contactedAreaRatio}");
        }

        public void PrintContactedUsersDistance(float contactedUsersDistance)
        {
            Debug.Log("----------------------------");
            Debug.Log($"contacted user distance : {contactedUsersDistance}");
        }
    }
}
