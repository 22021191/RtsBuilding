using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FactoryPattern
{
    [CreateAssetMenu(fileName = "StorageFactory", menuName = "Factories/StorageFactory")]
    public class StorageFactory : FactoryBuilding
    {
        [SerializeField]
        private StorageBuilding _storagePrefab;

        public override IFactoryBuilding CreateBuilding(Vector3 createPosition)
        {
            if (_storagePrefab == null)
            {
                Debug.LogError("prefab is not assigned!");
                return null;
            }

            GameObject farmInstance = Instantiate(_storagePrefab.gameObject, createPosition, Quaternion.identity);
            var building = farmInstance.GetComponent<IFactoryBuilding>();
            building.Initialize();
            return building;
        }
    }
}
