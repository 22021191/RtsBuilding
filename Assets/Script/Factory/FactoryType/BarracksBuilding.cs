using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FactoryPattern
{
    public class BarracksBuilding : MonoBehaviour, IFactoryBuilding
    {
        public int woodCost { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int foodCost { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public int goldCost { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Initialize()
        {
            Debug.Log("Initialize barracks building");
        }
    }
}
