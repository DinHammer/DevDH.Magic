﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using devDhMagic = DevDH.Magic.Abstractions.Magic;

namespace ConsoleApp.NUnit
{
    [TestFixture]
    public class TestMgcObservableCollection : BaseTest
    {
        [OneTimeSetUp]
        public void Init()
        { }

        [Test]
        public void Test_MagicAdd()
        {
            devDhMagic.MgcObservableCollection<int> collection = new devDhMagic.MgcObservableCollection<int>();
            var toAdd =new List<int> { 1, 2, 3 };

            collection.CollectionChanged += (s, e) =>
              {
                  Assert.AreEqual(e.Action,
                                 NotifyCollectionChangedAction.Add,
                                 "AddRange didn't use Add like requested.");

                  Assert.IsNull(e.OldItems, "OldItems should be null.");

                  Assert.AreEqual(toAdd.Count,
                                  e.NewItems.Count,
                                  "Expected and actual OldItems don't match.");

                  for (var i = 0; i < toAdd.Count; i++)
                  {
                      Assert.AreEqual(toAdd[i], (int)e.NewItems[i],
                          "Expected and actual NewItems don't match.");
                  }
              };

            collection.MgcAddRange(toAdd);
        }

        [Test]
        public void Test_AddMgcEmpty()
        {
            devDhMagic.MgcObservableCollection<int> collection = new devDhMagic.MgcObservableCollection<int>();
            var toAdd = new int[0];

            collection.CollectionChanged += (s, e) =>
            {
                Assert.Fail("The event is raised.");
            };
            collection.MgcAddRange(toAdd);
        }

        [Test]
        public void Test_MgcReplaceRange()
        {
            devDhMagic.MgcObservableCollection<int> collection = new devDhMagic.MgcObservableCollection<int>();
            var toAdd = new[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 8, 9, 7, 9, 3, 2, 3 };
            var toRemove = new[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 0, 0 };
            collection.MgcAddRange(toRemove);
            collection.CollectionChanged += (s, e) =>
            {
                Assert.AreEqual(e.Action,
                                NotifyCollectionChangedAction.Reset,
                                "ReplaceRange didn't use Remove like requested.");

                Assert.IsNull(e.OldItems, "OldItems should be null.");
                Assert.IsNull(e.NewItems, "NewItems should be null.");

                Assert.AreEqual(collection.Count, toAdd.Length, "Lengths are not the same");

                for (var i = 0; i < toAdd.Length; i++)
                {
                    if (collection[i] != (int)toAdd[i])
                        Assert.Fail("Expected and actual items don't match.");
                }
            };
            collection.MgcReplaceRange(toAdd);
        }

		[Test]
		public void Test_ReplaceRange_on_non_empty_collection_should_always_raise_collection_changes()
		{
			devDhMagic.MgcObservableCollection<int> collection = new devDhMagic.MgcObservableCollection<int>(new[] { 1 });
			var toAdd = new int[0];
			var eventRaised = false;

			collection.CollectionChanged += (s, e) =>
			{
				eventRaised = true;
			};

			collection.MgcReplaceRange(toAdd);
			Assert.IsTrue(eventRaised, "Collection Reset should be raised.");
		}

		[Test]
		public void Test_ReplaceRange_on_empty_collection_should_NOT_raise_collection_changes_when_empty()
		{
			devDhMagic.MgcObservableCollection<int> collection = new devDhMagic.MgcObservableCollection<int>();
			var toAdd = new int[0];

			collection.CollectionChanged += (s, e) =>
			{
				Assert.Fail("Collection changes should NOT be raised.");
			};

			collection.MgcReplaceRange(toAdd);
		}

		[Test]
		public void Test_ReplaceRange_should_NOT_mutate_source()
		{
			var sourceData = new List<int>(new[] { 1, 2, 3 });
			devDhMagic.MgcObservableCollection<int> collection = new devDhMagic.MgcObservableCollection<int>(new[] { 1, 2, 3, 4, 5, 6 });

			collection.MgcReplaceRange(sourceData);

			Assert.IsTrue(sourceData.Count == 3, "source data was mutated");
		}

		[Test]
		public void Test_RemoveRangeRemoveTestMethod()
		{
			devDhMagic.MgcObservableCollection<int> collection = new devDhMagic.MgcObservableCollection<int>();
			var toAdd = new[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 8, 9, 7, 9, 3, 2, 3 };
			var toRemove = new[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 0, 0 };
			collection.MgcAddRange(toAdd);
			collection.CollectionChanged += (s, e) =>
			{
				if (e.Action != System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
					Assert.Fail("RemoveRange didn't use Remove like requested.");
				if (e.OldItems == null)
					Assert.Fail("OldItems should not be null.");
				var expected = new int[] { 1, 1, 2, 2, 3, 3, 4, 5, 5, 6, 7, 8, 9, 9 };
				if (expected.Length != e.OldItems.Count)
					Assert.Fail("Expected and actual OldItems don't match.");
				for (var i = 0; i < expected.Length; i++)
				{
					if (expected[i] != (int)e.OldItems[i])
						Assert.Fail("Expected and actual OldItems don't match.");
				}
			};
			collection.MgcRemoveRange(toRemove, NotifyCollectionChangedAction.Remove);

		}

		[Test]
		public void Test_RemoveRangeEmpty()
		{
			devDhMagic.MgcObservableCollection<int> collection = new devDhMagic.MgcObservableCollection<int>();
			var toAdd = new[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 8, 9, 7, 9, 3, 2, 3 };
			var toRemove = new int[0];
			collection.MgcAddRange(toAdd);
			collection.CollectionChanged += (s, e) =>
			{
				Assert.Fail("The event is raised.");
			};
			collection.MgcRemoveRange(toRemove, NotifyCollectionChangedAction.Remove);
		}

		[Test]
		public void Test_RemoveRange_should_NOT_mutate_source_when_source_data_is_not_present()
		{
			var sourceData = new List<int>(new[] { 1, 2, 3 });
			devDhMagic.MgcObservableCollection<int> collection = new devDhMagic.MgcObservableCollection<int>(new[] { 4, 5, 6 });

			collection.MgcRemoveRange(sourceData, NotifyCollectionChangedAction.Remove);

			Assert.IsTrue(sourceData.Count == 3, "source data was mutated");
		}

		[Test]
		public void Test_RemoveRange_should_NOT_mutate_source_when_source_data_is_present()
		{
			var sourceData = new List<int>(new[] { 1, 2, 3 });
			devDhMagic.MgcObservableCollection<int> collection = new devDhMagic.MgcObservableCollection<int>(new[] { 1, 2, 3, 4, 5, 6 });

			collection.MgcRemoveRange(sourceData, NotifyCollectionChangedAction.Remove);

			Assert.IsTrue(sourceData.Count == 3, "source data was mutated");
		}

		[Test]
		public void Test_RemoveRange_should_NOT_mutate_collection_when_source_data_is_not_present()
		{
			var sourceData = new List<int>(new[] { 1, 2, 3 });
			devDhMagic.MgcObservableCollection<int> collection = new devDhMagic.MgcObservableCollection<int>(new[] { 4, 5, 6, 7, 8, 9 });

			collection.MgcRemoveRange(sourceData, NotifyCollectionChangedAction.Remove);

			// the collection should not be modified if the source items are not found
			Assert.IsTrue(collection.Count == 6, "collection was mutated");
		}
	}
}
