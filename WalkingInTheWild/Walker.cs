namespace WalkingInTheWild
{
    public class Walker
    {
        #region private attributes
        private string _pseudo;
        private Bagpack? _backpack;
        private int count = 0;
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
                return _backpack;
            }
        }

        public void TakeBagpack(Bagpack bagpack)
        {
            if (_backpack != null)
            {
                throw new WalkerNotReadyException();
            }
            _backpack = bagpack;
        }

        public void DropBagpack()
        {
            if (_backpack == null)
            {
                throw new EmptyBagpackException();
            }
            _backpack = null;
        }

        public void LoadBagpack(List<Cloth> cloths)
        {
            if (_backpack == null)
            {
                throw new EmptyBagpackException();
            }
            _backpack?.Add(cloths);
        }

        public void LoadBagpack(List<Equipment> equipments)
        {
            if (_backpack == null)
            {
                throw new EmptyBagpackException();
            }
            _backpack?.Add(equipments);
        }

        public void EmptyBagpack()
        {
            _backpack.Clothes.Clear();
            _backpack.Equipments.Clear();
        }
        #endregion public methods

        #region private methods

        #endregion private methods

        #region nested classes
        public class WalkerException:Exception{}
        public class WalkerNotReadyException : WalkerException { }
        public class EmptyBagpackException : WalkerException { }
        #endregion nested classes


    }
}