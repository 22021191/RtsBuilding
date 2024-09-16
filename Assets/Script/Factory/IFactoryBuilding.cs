
namespace FactoryPattern
{
    public interface IFactoryBuilding
    {
        public string name { get; set; }
        public int woodCost { get; set; }
        public int foodCost { get; set; }
        public int goldCost { get; set; }
        public void Initialize();
    }
}