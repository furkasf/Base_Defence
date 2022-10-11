using Data.ValueObject.StackData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(menuName = "BaseDefence/CD_Stack", fileName ="CD_Stack")]
    public class CD_Stack : ScriptableObject
    {
        public StackData Data;
    }
}
