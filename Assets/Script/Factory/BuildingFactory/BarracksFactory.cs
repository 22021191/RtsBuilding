using FactoryPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FactoryPattern
{
    [CreateAssetMenu(fileName = "BarracksFactory", menuName = "Factories/BarracksFactory")]
    public class BarracksFactory : FactoryBuilding
    {
        [SerializeField]
        private BarracksBuilding _barracksPrefab;

        public override IFactoryBuilding CreateBuilding(Vector3 createPosition)
        {
            if (_barracksPrefab == null)
            {
                Debug.LogError("prefab is not assigned!");
                return null;
            }

            GameObject farmInstance = Instantiate(_barracksPrefab.gameObject, createPosition, Quaternion.identity);
            var building = farmInstance.GetComponent<IFactoryBuilding>();
            building.Initialize();
            return building;
        }
    }
}
