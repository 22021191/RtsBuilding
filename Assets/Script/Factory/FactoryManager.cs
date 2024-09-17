using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace FactoryPattern
{
    public class FactoryManager : Singleton<FactoryManager>
    {
        public Vector2Int gridSize = Vector2Int.one;
        public Vector2 cellSize = new Vector2(1, 1);
        public Sprite spriteCell;
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
            
        }
        void Start()
        {
            CreateGrid();
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
        void CreateGrid()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    CreateCell(x, y);
                }
            }
        }
        void CreateCell(int x, int y)
        {
            GameObject cell = new GameObject("Cell_" + x + "_" + y);
            cell.transform.position = new Vector3(x * cellSize.x+transform.position.x, y * cellSize.y+transform.position.y, 0);
            cell.transform.localScale = cellSize;
            SpriteRenderer sr = cell.AddComponent<SpriteRenderer>();
            sr.sprite = spriteCell;
            if ((x + y) % 2 == 0)
            {
                sr.color = Color.green;
            }
            cell.transform.parent = this.transform;
            BoxCollider2D collider = cell.AddComponent<BoxCollider2D>();
            cell.AddComponent<CellClickHandler>();
        }

    }
}