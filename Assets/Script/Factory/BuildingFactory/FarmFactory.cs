using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FactoryPattern
{
    [CreateAssetMenu(fileName = "FarmFactory", menuName = "Factories/FarmFactory")]
    public class FarmFactory : FactoryBuilding
    {
        [SerializeField]
        private FarmBuilding _farmPrefab;

        public override IFactoryBuilding CreateBuilding(Vector3 createPosition)
        {
            if (_farmPrefab == null)
            {
                Debug.LogError("prefab is not assigned!");
                return null;
            }

            GameObject farmInstance = Instantiate(_farmPrefab.gameObject, createPosition, Quaternion.identity);
            var building = farmInstance.GetComponent<IFactoryBuilding>();
            building.Initialize();
            return building;
        }
    }
}
