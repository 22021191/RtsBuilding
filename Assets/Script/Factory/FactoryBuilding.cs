using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactoryPattern
{
    public abstract class FactoryBuilding : ScriptableObject
    {
        public abstract IFactoryBuilding CreateBuilding(Vector3 createPosition);
    }
}