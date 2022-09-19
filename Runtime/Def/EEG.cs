using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChemicalX.Core
{
    public class EEG
    {
        public EEG()
        {
            Data = new List<float>();
        }

        public List<float> Data
        {
            get; set;
        }
    }
}
