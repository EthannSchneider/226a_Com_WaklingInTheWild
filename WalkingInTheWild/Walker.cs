namespace WalkingInTheWild
{
    public class Walker
    {
        #region private attributes
        private string _pseudo;
        private Bagpack? _bagpack;
        #endregion private attributes

        #region public methods
        public Walker(string pseudo)
        {
            _pseudo = pseudo;
        }

        public string Pseudo
        {
            get
            {
                return _pseudo;
            }
        }

        public Bagpack? Bagpack
        {
            get
            {
                return _bagpack;
            }
        }

        public void TakeBagpack(Bagpack bagpack)
        {
            if (_bagpack != null)
            {
                throw new WalkerAlreadyCarriesABagpackException();
            }
            _bagpack = bagpack;
        }

        public void DropBagpack()
        {
            if (_bagpack == null)
            {
                throw new WalkerDoesntCarryABagpackException();
            }
            _bagpack = null;
        }

        public void LoadBagpack(List<Cloth> cloths)
        {
            foreach (Cloth cloth in cloths)
            {
                _bagpack?.Add(cloth);
            }
        }

        public void LoadBagpack(List<Equipment> equipments)
        {
            foreach (Equipment equipment in equipments)
            {
                _bagpack?.Add(equipment);
            }
        }

        public void EmptyBagpack()
        {
            if (_bagpack.Clothes.Count == 0 && _bagpack.Equipments.Count == 0)
            {
                throw new BagpackDoesntContainNeitherClothesOrEquipment();
            }
            _bagpack.Clothes.Clear();
            _bagpack.Equipments.Clear();
        }
        #endregion public methods

        #region private methods

        #endregion private methods

        #region nested classes
        public class WalkerException:Exception{}
        public class WalkerAlreadyCarriesABagpackException : WalkerException { }
        public class WalkerDoesntCarryABagpackException : WalkerException { }
        public class EmptyBagpackException : WalkerException { }
        public class BagpackDoesntContainNeitherClothesOrEquipment : WalkerException { }
        #endregion nested classes
    }
}