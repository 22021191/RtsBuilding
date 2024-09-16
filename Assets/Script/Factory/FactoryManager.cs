using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace FactoryPattern
{
    public class FactoryManager : Singleton<FactoryManager>
    {
        private Dictionary<Type, FactoryBuilding> _factories = new Dictionary<Type, FactoryBuilding>();

        [SerializeField]
        private List<FactoryBuilding> factoryList;
        protected override void Awake()
        {
            if (instance)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                RegisterAllFactories();
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void RegisterAllFactories()
        {
            foreach (var factory in factoryList)
            {
                RegisterFactory(factory);
            }
        }
        private void RegisterFactory(FactoryBuilding factory)
        {
            Type factoryType = factory.GetType();
            if (!_factories.ContainsKey(factoryType))
            {
                _factories.Add(factoryType, factory);
            }
            else
            {
                Debug.LogWarning($"Factory of type {factoryType} is already registered.");
            }
        }
        public FactoryBuilding GetFactoryByType(Type factoryType)
        {
            if (_factories.TryGetValue(factoryType, out var factory))
            {
                return factory;
            }

            Debug.LogError($"Factory of type {factoryType} not found!");
            return null;
        }

    }
}