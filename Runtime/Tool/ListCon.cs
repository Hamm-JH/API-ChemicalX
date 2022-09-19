using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChemicalX.Core
{
    public static class ListCon
    {
        public static int WhereIsStrongestIndex(List<float> data)
        {
            int result = 0;
            float compare = data.Count != 0 ? data[0] : 0;
            
            for (int i = 0; i < data.Count; i++)
            {
                if (compare < data[i])
                {
                    result = i;
                    compare = data[i];
                }
            }

            return result;
        }
    }
}
