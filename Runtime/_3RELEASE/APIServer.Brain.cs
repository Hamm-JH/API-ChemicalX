using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading;
using System;

namespace ChemicalX.Core
{
    #region Server to client Brain data

    public class JSONData_Brain
    {
        public PlayerBrainData data1;
        public PlayerBrainData data2;
    }

    public class PlayerBrainData
    {
        public int Meditation;

        public int Attention;

        public EEG_Data EEG;

        public int PoorSignal;
    }

    public class EEG_Data
    {
        public float delta;

        public float theta;

        public float lowAlpha;

        public float highAlpha;

        public float lowBeta;

        public float highBeta;

        public float lowGamma;

        public float midGamma;
    }
    #endregion

    public partial class APIServer : IBrain
    {
        internal async void RequestBrainData()
        {
            //UnityWebRequest req = new UnityWebRequest("192.168.10.11:3002/CON");

            string targetUri = "http://dudoWeb.iptime.org:50200/BCIOut";
            //string targetUri = "http://192.168.10.11:3002/BCIOut";    // 로컬


            while (bIsRunning)
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(targetUri);
                HttpWebResponse res = (HttpWebResponse)await req.GetResponseAsync();
                //Debug.Log(res.StatusCode);
                //Debug.Log(res.ToString());

                using (var reader = new System.IO.StreamReader(res.GetResponseStream()))
                {
                    string data = reader.ReadLine();
                    //Debug.Log(data);

                    JObject jObj = JObject.Parse(data);

                    JSONData_Brain jsonData = JsonConvert.DeserializeObject<JSONData_Brain>(data);
                    //Debug.Log("Hello jsonData");

                    //Debug.Log(jObj["data1"].ToString());
                    //Debug.Log(jObj["data2"].ToString());

                    ParsePacketData(jsonData);
                }

                res.Close();

                await Task.Delay(1000);
            }
        }

        /// <summary>
        /// 받은 패킷데이터를 분할
        /// </summary>
        /// <param name="data"></param>
        public void ParsePacketData(JSONData_Brain data)
        {
            //data.data1;
            //data.data2;

            //data.data1.EEG;
            //data.data2.EEG;

            SetSingleEEGData(data.data1.EEG, 0);
            SetSingleEEGData(data.data2.EEG, 1);

            SetStrongestEEGIndex(0);
            SetStrongestEEGIndex(1);
        }

        #region Set EEG data

        /// <summary>
        /// EEG 데이터를 할당한다.
        /// </summary>
        /// <param name="data"></param>
        public void SetSingleEEGData(EEG_Data data, int index)
        {
            EEGData[index].Data[0] = data.delta;
            EEGData[index].Data[1] = data.theta;
            EEGData[index].Data[2] = data.lowAlpha;
            EEGData[index].Data[3] = data.highAlpha;
            EEGData[index].Data[4] = data.lowBeta;
            EEGData[index].Data[5] = data.highBeta;
            EEGData[index].Data[6] = data.lowGamma;
            EEGData[index].Data[7] = data.midGamma;

            EEGData[index].Calibration();
        }

        #endregion

        #region Set Strongest EEG index

        /// <summary>
        /// 제일 강한 신호가 발생한 인덱스 할당
        /// </summary>
        /// <param name="index"></param>
        public void SetStrongestEEGIndex(int index)
        {
            StrongestEEGIndex[index] = EEGData[index].StrongestEEGpart();
        }

        #endregion

        #region '''


        #endregion

        //HttpWebRequest webReq;

        //void StartWebRequest()
        //{
        //    webReq.BeginGetResponse(new System.AsyncCallback(FinishWebRequest), null);
        //}

        //void FinishWebRequest(IAsyncResult result)
        //{
        //    result.
        //}

        //async void GetRequest(string uri)
        //{
        //    using (UnityWebRequest req = UnityWebRequest.Get(uri))
        //    {
        //        await Task.Run(req.SendWebRequest);

        //        if (req.result == UnityWebRequest.Result.Success)
        //        {
        //            Debug.Log($"success. received : {req.downloadHandler.text}");
        //        }
        //        else
        //        {
        //            Debug.Log($"error : {req.result.ToString()}");
        //        }
        //    }
        //}
    }
}
