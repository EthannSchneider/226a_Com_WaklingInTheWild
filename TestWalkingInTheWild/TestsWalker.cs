using NuGet.Frameworks;
using WalkingInTheWild;
using static WalkingInTheWild.Cloth;
using static WalkingInTheWild.Walker;

namespace TestWalkingInTheWild
{
    public class TestsWalker
    {
        //region private attributes
        private Walker walker;
        private string pseudo;
        //endregion private attributes

        [SetUp]
        public void Setup()
        {
            pseudo = "Pseudo";
            walker = new Walker(pseudo);    
        }

        [Test]
        public void Properties_AfterInstantiationDefaultValues_PropertiesAreCorrecltyReturned()
        {
            //given
            //refer to Setup()

            //when
            //constructor is called in Setup() 

            //then
            Assert.AreEqual(pseudo, walker.Pseudo);
            Assert.IsNull(walker.Bagpack);
        }

        [Test]
        public void TakeBagpack_WalkerReady_BagpackTaken()
        {
            //given
            //refer to Setup()
            Bagpack bagpack = new Bagpack(20.00f);
            Assert.Null(walker.Bagpack);

            //when
            this.walker.TakeBagpack(bagpack);

            //then
            Assert.AreEqual(bagpack, walker.Bagpack);
        }

        [Test]
        public void TakeBagpack_WalkerNotReady_ThrowException()
        {
            //given
            //refer to Setup()
            Bagpack bagpack = new Bagpack(20.00f);
            walker.TakeBagpack(bagpack);
            Assert.NotNull(walker.Bagpack);

            //when
            //Event is called by the assertion

            //then
            Assert.Throws<WalkerNotReadyException>(() => walker.TakeBagpack(bagpack));
        }
        
        [Test]        
        public void DropBagpack_WalkerIsCarringABagpack_WalkerDropsTheBagpack()
        {
            //given
            Bagpack bagpack = new Bagpack(20.00f);
            walker.TakeBagpack(bagpack);

            //when
            Assert.AreEqual(bagpack, walker.Bagpack);
            walker.DropBagpack();

            //then
            Assert.IsNull(walker.Bagpack);
        }

        [Test]
        public void DropBagpack_WalkerIsNotCarringABagpack_ThrowException()
        {
            //given

            //when

            //then
            Assert.Throws<EmptyBagpackException>(() => walker.DropBagpack());
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadSingleCloth_ClothIsLoadedInBagpack()
        {
            //given
            Bagpack bagpack = new Bagpack(20.00f);
            List<Cloth> cloth = new List<Cloth>{ new Cloth("T-shirt") };
            walker.TakeBagpack(bagpack);

            //when
            Assert.IsEmpty(walker.Bagpack.Clothes);
            walker.LoadBagpack(cloth);

            //then
            Assert.IsNotEmpty(walker.Bagpack.Clothes);
            walker.DropBagpack();
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadMultipleCloths_ClothsAreLoadedInBagpack()
        {
            //given
            Bagpack bagpack = new Bagpack(20.00f);
            List<Cloth> cloth = new List<Cloth> { new Cloth("T-shirt"), new Cloth("Pants", true), new Cloth("Shoes"), new Cloth("Hat") };
            walker.TakeBagpack(bagpack);

            //when
            Assert.IsEmpty(walker.Bagpack.Clothes);
            walker.LoadBagpack(cloth);

            //then
            Assert.AreEqual(walker.Bagpack.Clothes.Count, cloth.Count);
            walker.DropBagpack();
        }

        [Test]
        public void LoadBagpack_ClothBagpackNotAvailable_ThrowException()
        {
            //given
            List<Cloth> cloth = new List<Cloth> { new Cloth("T-shirt"), new Cloth("Pants", true), new Cloth("Shoes"), new Cloth("Hat") };

            //when

            //then
            Assert.Throws<EmptyBagpackException>(() => walker.LoadBagpack(cloth));
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadSingleEquipment_EquipmentIsLoadedInBagpack()
        {
            //given
            Bagpack bagpack = new Bagpack(20.00f);
            List<Equipment> equipment = new List<Equipment> { new Equipment("Tent", 1.2f) };
            walker.TakeBagpack(bagpack);

            //when
            Assert.IsEmpty(walker.Bagpack.Equipments);
            walker.LoadBagpack(equipment);

            //then
            Assert.IsNotEmpty(walker.Bagpack.Equipments);
            walker.DropBagpack();
        }

        [Test]
        public void LoadBagpack_BagpackAvailableLoadMultipleEquipments_EquipmentAreLoadedInBagpack()
        {
            //given
            Bagpack bagpack = new Bagpack(20.00f);
            List<Equipment> equipment = new List<Equipment> { new Equipment("Tent", 1.2f), new Equipment("Sleeping bag", 1.5f), new Equipment("Stove", 0.5f), new Equipment("Cooking set", 0.3f) };
            walker.TakeBagpack(bagpack);

            //when
            Assert.IsEmpty(walker.Bagpack.Equipments);
            walker.LoadBagpack(equipment);

            //then
            Assert.IsNotEmpty(walker.Bagpack.Equipments);
            walker.DropBagpack();
        }

        [Test]
        public void LoadBagpack_EquipmentBagpackNotAvailable_ThrowException()
        {
            //given
            List<Equipment> equipment = new List<Equipment> { new Equipment("Tent", 1.2f), new Equipment("Sleeping bag", 1.5f), new Equipment("Stove", 0.5f), new Equipment("Cooking set", 0.3f) };

            //when

            //then
            Assert.Throws<EmptyBagpackException>(() => walker.LoadBagpack(equipment));
        }

        [Test]
        public void EmptyBagpack_BagpackContainsClothsAndEquipment_BackpackIsEmpty()
        {
            //given
            Bagpack bagpack = new Bagpack(20.00f);
            walker.TakeBagpack(bagpack);
            List<Equipment> equipment = new List<Equipment> { new Equipment("Tent", 1.2f), new Equipment("Sleeping bag", 1.5f), new Equipment("Stove", 0.5f), new Equipment("Cooking set", 0.3f) };
            List<Cloth> cloth = new List<Cloth> { new Cloth("T-shirt"), new Cloth("Pants", true), new Cloth("Shoes"), new Cloth("Hat") };
            Assert.IsEmpty(walker.Bagpack.Clothes);
            Assert.IsEmpty(walker.Bagpack.Equipments);

            //when
            walker.LoadBagpack(equipment);
            walker.LoadBagpack(cloth);
            Assert.IsNotEmpty(walker.Bagpack.Clothes);
            Assert.IsNotEmpty(walker.Bagpack.Equipments);
            walker.EmptyBagpack();

            //then
            Assert.IsEmpty(walker.Bagpack.Clothes);
            Assert.IsEmpty(walker.Bagpack.Equipments);
        }

        [Test]
        public void EmptyBagpack_BagpackDoesntContainNeitherClothsOrEquipment_ThrowException()
        {
            //given

            //when

            //then
        }
    }
}