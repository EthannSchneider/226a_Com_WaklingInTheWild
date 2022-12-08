using NuGet.Frameworks;
using WalkingInTheWild;
using static WalkingInTheWild.Cloth;
using static WalkingInTheWild.Walker;

namespace TestWalkingInTheWild
{
    public class TestsWalker
    {
        //region private attributes
        private Walker _walker;
        private string _pseudo;
        private Bagpack _bagpack = null;
        private float _maxLoad = 25.50f;
        //endregion private attributes

        [SetUp]
        public void Setup()
        {
            _pseudo = "Pseudo";
            _walker = new Walker(_pseudo);
            _bagpack = new Bagpack(_maxLoad);
        }

        [Test]
        public void Properties_AfterInstantiationDefaultValues_PropertiesAreCorrecltyReturned()
        {
            //given
            //refer to Setup()

            //when
            //constructor is called in Setup() 

            //then
            Assert.AreEqual(_pseudo, _walker.Pseudo);
            Assert.IsNull(_walker.Bagpack);
        }

        [Test]
        public void TakeBagpack_WalkerDoesntCarryABagpack_BagpackTaken()
        {
            //given
            //refer to Setup()
            Assert.Null(_walker.Bagpack);

            //when
            _walker.TakeBagpack(_bagpack);

            //then
            Assert.AreEqual(_bagpack, _walker.Bagpack);
        }

        [Test]
        public void TakeBagpack_WalkerAlreadyCarriesABagpack_ThrowException()
        {
            //given
            //refer to Setup()
            Assert.NotNull(_walker.Bagpack);

            //when
            //Event is called by the assertion

            //then
            Assert.Throws<WalkerAlreadyCarriesABagpackException>(() => _walker.TakeBagpack(_bagpack));
        }

        [Test]        
        public void DropBagpack_WalkerIsAlreadyCarringABagpack_WalkerDropsTheBagpack()
        {
            //given
            _walker.TakeBagpack(_bagpack);
            Assert.NotNull(_walker.Bagpack);

            //when
            _walker.DropBagpack();

            //then
            Assert.IsNull(_walker.Bagpack);
        }

        [Test]
        public void DropBagpack_WalkerIsNotCarringABagpack_ThrowException()
        {
            //given
            Assert.Null(_walker.Bagpack);

            //when
            //Event is called by the assertion

            //then
            Assert.Throws<WalkerDoesntCarryABagpackException>(() => _walker.DropBagpack());
        }

        
        [Test]
        public void LoadBagpack_BagpackAvailableLoadSingleCloth_ClothIsLoadedInBagpack()
        {
            //given
            List<Cloth> cloth = new List<Cloth>{ new Cloth("T-shirt") };
            _walker.TakeBagpack(_bagpack);

            //when
            Assert.IsEmpty(_walker.Bagpack.Clothes);
            _walker.LoadBagpack(cloth);

            //then
            Assert.IsNotEmpty(_walker.Bagpack.Clothes);
            _walker.DropBagpack();
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadMultipleCloths_ClothsAreLoadedInBagpack()
        {
            //given
            List<Cloth> cloth = new List<Cloth> { new Cloth("T-shirt"), new Cloth("Pants", true), new Cloth("Shoes"), new Cloth("Hat") };
            _walker.TakeBagpack(_bagpack);

            //when
            Assert.IsEmpty(_walker.Bagpack.Clothes);
            _walker.LoadBagpack(cloth);

            //then
            Assert.AreEqual(_walker.Bagpack.Clothes.Count, cloth.Count);
            _walker.DropBagpack();
        }

        [Test]
        public void LoadBagpack_ClothBagpackNotAvailable_ThrowException()
        {
            //given
            List<Cloth> cloth = new List<Cloth> { new Cloth("T-shirt"), new Cloth("Pants", true), new Cloth("Shoes"), new Cloth("Hat") };

            //when

            //then
            Assert.Throws<EmptyBagpackException>(() => _walker.LoadBagpack(cloth));
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadSingleEquipment_EquipmentIsLoadedInBagpack()
        {
            //given
            List<Equipment> equipment = new List<Equipment> { new Equipment("Tent", 1.2f) };
            _walker.TakeBagpack(_bagpack);

            //when
            Assert.IsEmpty(_walker.Bagpack.Equipments);
            _walker.LoadBagpack(equipment);

            //then
            Assert.IsNotEmpty(_walker.Bagpack.Equipments);
            _walker.DropBagpack();
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadMultipleEquipments_EquipmentAreLoadedInBagpack()
        {
            //given
            List<Equipment> equipment = new List<Equipment> { new Equipment("Tent", 1.2f), new Equipment("Sleeping bag", 1.5f), new Equipment("Stove", 0.5f), new Equipment("Cooking set", 0.3f) };
            _walker.TakeBagpack(_bagpack);

            //when
            Assert.IsEmpty(_walker.Bagpack.Equipments);
            _walker.LoadBagpack(equipment);

            //then
            Assert.IsNotEmpty(_walker.Bagpack.Equipments);
            _walker.DropBagpack();
        }

        [Test]
        public void LoadBagpack_EquipmentBagpackNotAvailable_ThrowException()
        {
            //given
            List<Equipment> equipment = new List<Equipment> { new Equipment("Tent", 1.2f), new Equipment("Sleeping bag", 1.5f), new Equipment("Stove", 0.5f), new Equipment("Cooking set", 0.3f) };

            //when

            //then
            Assert.Throws<EmptyBagpackException>(() => _walker.LoadBagpack(equipment));
        }

        [Test]
        public void EmptyBagpack_BagpackContainsClothsAndEquipment_BackpackIsEmpty()
        {
            //given
            _walker.TakeBagpack(_bagpack);
            List<Equipment> equipment = new List<Equipment> { new Equipment("Tent", 1.2f), new Equipment("Sleeping bag", 1.5f), new Equipment("Stove", 0.5f), new Equipment("Cooking set", 0.3f) };
            List<Cloth> cloth = new List<Cloth> { new Cloth("T-shirt"), new Cloth("Pants", true), new Cloth("Shoes"), new Cloth("Hat") };
            Assert.IsEmpty(_walker.Bagpack.Clothes);
            Assert.IsEmpty(_walker.Bagpack.Equipments);

            //when
            _walker.LoadBagpack(equipment);
            _walker.LoadBagpack(cloth);
            Assert.IsNotEmpty(_walker.Bagpack.Clothes);
            Assert.IsNotEmpty(_walker.Bagpack.Equipments);
            _walker.EmptyBagpack();

            //then
            Assert.IsEmpty(_walker.Bagpack.Clothes);
            Assert.IsEmpty(_walker.Bagpack.Equipments);
        }

        [Test]
        public void EmptyBagpack_BagpackDoesntContainNeitherClothsOrEquipment_ThrowException()
        {
            //given

            //when

            //then
            Assert.True(false);
        }
    }
}