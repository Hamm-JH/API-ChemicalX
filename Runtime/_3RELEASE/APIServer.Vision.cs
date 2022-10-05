using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChemicalX.Core
{
    public partial class APIServer : IBrain
    {
        internal async void RequestVisionData()
        {
            string targetUri = "http://dudoWeb.iptime.org:50200/VISIONOUT";

            while(bIsRunning)
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(targetUri);
                HttpWebResponse res = (HttpWebResponse)await req.GetResponseAsync();

                using (var reader = new System.IO.StreamReader(res.GetResponseStream()))
                {
                    string data = reader.ReadLine();

                    //Debug.Log(data);

                    JObject jObj = JObject.Parse(data);

                    bool isContacted = jObj["Contacted"].ToString() == "True" ? true : false;
                    float returnDist = float.Parse(jObj["ReturnDist"].ToString());
                    //Debug.Log(jObj["Contacted"].ToString());
                    //Debug.Log(jObj["ReturnDist"].ToString());

                    //Debug.Log(isContacted);
                    //Debug.Log(returnDist);

                    IsContacted = IsContacted;
                    ContactedUsersDistance = returnDist;

                    SetDist(returnDist);
                    SetIsContacted();
                    SetContactedArea();

                }

                res.Close();

                await Task.Delay(200);
            }

        }

        internal void SetDist(float dist)
        {
            ContactedUsersDistance = dist;
        }

        internal void SetIsContacted()
        {
            IsContacted = ContactedUsersDistance < GlobalSetting.ContactBoundary ? true : false;
        }

        internal void SetContactedArea()
        {
            float dist = ContactedUsersDistance;

            if (dist < GlobalSetting.ContactBoundary)
            {
                float value = dist / GlobalSetting.ContactBoundary;

                ContactedAreaRatio = 1 - value;
            }
            else
            {
                ContactedAreaRatio = 0;
            }
        }

        
    }
}
