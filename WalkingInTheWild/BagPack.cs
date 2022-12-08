namespace WalkingInTheWild
{
    public class Bagpack
    {
        //region private attributes
        private List<Cloth> _clothes = new List<Cloth>();
        private List<Equipment> _equipments = new List<Equipment>();
        private readonly float _maxLoad;    
        //endregion private attributes

        //region public methods
        public Bagpack(float maxLoad)
        {
            _maxLoad = maxLoad;
        }
        
        public List<Cloth> Clothes
        {
            get
            {
                return _clothes;
            }
        }

        public List<Equipment> Equipments
        {
            get
            {
                return _equipments;
            }
        }

        public float RemainingLoadCapacity
        {
            get
            {
                return _maxLoad - _equipments.Sum(equipment => equipment.Weight);
                //var maxload = _maxLoad;
                //foreach (Equipment equipment in _equipments)
                //{
                //    maxload -= equipment.Weight;
                //}
                //return maxload;
            }
        }

        public void Add(Cloth cloth)
        {
            _clothes.Add(cloth);
        }

        public void Add(List<Cloth> cloth)
        {
            _clothes.AddRange(cloth);
        }

        public void Add(Equipment equipment)
        {
            if (equipment.Weight > RemainingLoadCapacity)
            {
                throw new MaximumLoadReachedException();
            }
            _equipments.Add(equipment);
        }

        public void Add(List<Equipment> equipments)
        {
            foreach (Equipment equipment in equipments)
            {
                Add(equipment);
            }
        }
        //endregion public methods

        //region private methods
        //endregion private methods

        //region nested classes
        public class BagpackException : Exception { }
        public class MaximumLoadReachedException : BagpackException { }
        //enregion  nested classes
    }
}