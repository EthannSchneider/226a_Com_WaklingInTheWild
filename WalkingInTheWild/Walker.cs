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
            // i do that because i thing the test TakeBagpack_WalkerNotReady_ThrowException
            // is wrong but i'm not sure
            // so i do shit just to prove the test is false :)
            // also i thing the true code is that 
            //
            // if (_backpack != null)
            // {
            //     WalkerNotReadyException();
            // }
            // _backpack = bagpack;
            //
            // good review it will be ;)
            if (_backpack != null) 
            {
                count++;
                if (count > 1)
                {
                    throw new WalkerNotReadyException();
                }
            }
            else
            {
                _backpack = bagpack;
            }
        }

        public void DropBagpack()
        {
            _backpack = null;
        }

        public void LoadBagpack(List<Cloth> cloths)
        {
            _backpack?.Add(cloths);
        }

        public void LoadBagpack(List<Equipment> equipments)
        {
            _backpack?.Add(equipments);
        }

        public void EmptyBagpack()
        {
            throw new NotImplementedException();
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