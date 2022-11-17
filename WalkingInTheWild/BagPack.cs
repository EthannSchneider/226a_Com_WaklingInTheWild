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
                //TODO coding style ???? naming convention
                float TotalWeight = 0;
                foreach (var equipement in _equipments)
                {
                    TotalWeight += equipement.Weight;
                }
                return _maxLoad-TotalWeight;
            }
        }

        public void Add(Cloth cloth)
        {
            _clothes.Add(cloth);
        }

        public void Add(Equipment equipment)
        {
            if(RemainingLoadCapacity-equipment.Weight < 0)
            {
                throw new MaximumLoadReachedException();
            }
            _equipments.Add(equipment);
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