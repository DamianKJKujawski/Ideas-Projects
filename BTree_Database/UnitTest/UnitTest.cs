using BTree_Database;



namespace UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BTree_Test()
        {
            BTree<int> _bTree = new (3);

            _bTree.Insert(1);
            _bTree.Insert(3);
            _bTree.Insert(7);
            _bTree.Insert(10);
            _bTree.Insert(11);

            // Save B-tree to file:
            _bTree.Save_ToFile("btree.db");



            // TEST:
            // Load B-tree from file:
            BTree<int> _loadedTree = new (3);
            _loadedTree.Load_FromFile("btree.db");

            // Search for a value in the loaded B-tree:
            int _valueFound = _loadedTree.Search(7);
            int _valueNotFound = _loadedTree.Search(5);

            Assert.Multiple(() =>
            {
                Assert.That(_valueFound, Is.EqualTo(7));
                Assert.That(_valueNotFound, Is.EqualTo(0));
            });

            Console.WriteLine("B-tree test completed successfully.");
        }
    }
}