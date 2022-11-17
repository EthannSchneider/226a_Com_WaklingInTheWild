﻿namespace WalkingInTheWild
{
    public class Equipment
    {
        //region private attributes
        private string _description;
        private float _weight;
        //endregion private attributes

        //region public methods
        public Equipment(string description, float weight)
        {
            //TODO Does it make sens to set the escription if the weight is to small ?
            _description = description;
            if(weight < 0)
            {
                throw new TooSmallerWeight();
            }
            _weight = weight;
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public float Weight
        {
            get
            {
                return _weight;
            }
        }
        //endregion public methods

        //region private methods
        //endregion private methods

        //region nested classes
        public class EquipmentException : Exception { }
        public class TooSmallerWeight : EquipmentException { }
        //enregion  nested classes
    }
}