using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirebaseTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseTestingTests;

namespace FirebaseTesting.Tests
{
    [TestClass()]
    public class FireRepoTests
    {
        string authentication = "your key";
        string baseurl = "https://yourdb.firebaseio.com/";
        FireRepo<Interns> repo ; 
        public FireRepoTests()
        {
            repo= new FireRepo<Interns>(authentication, baseurl, path);
        }
        string path = $"Interns/";
        [TestMethod()]
        public async Task AddTest()
        {
            Interns interns = new Interns()
            {
                id = Guid.NewGuid(),
                NameSurname = "Ali Zorlu",
                AddTime = DateTime.Now
            };
            try
            {
               await repo.Add(interns,interns.id);
            }
            catch (Exception e)
            {

                Assert.Fail(e.Message);
            }
        }
        [TestMethod()]
        public async Task ListTest()
        {
            List<Interns> result
                = await repo.GetList();
            Assert.IsNotNull(result);
        }
        [TestMethod()]
        public async Task SeriesTest()
        {
            Interns[] result = await repo.GetListSeries();
            Assert.IsNotNull(result);
        }
        [TestMethod()]
        public async Task FindTest()
        {
            Interns[] result = await repo.GetListSeries();
            var target = result[0];
            Console.WriteLine("Bulunan:"+target.NameSurname);
            var find = await repo.Find(target.id);
            Assert.AreEqual(find.id.ToString(), target.id.ToString());
        }        
        [TestMethod()]
        public async Task DeleteTest()
        {
            Interns[] list = await repo.GetListSeries();
            var targetDelete = list[0];
            await repo.Delete(targetDelete.id);
            
        }
        [TestMethod()]
        public async Task UpdateTest()
        {
            Interns[] result = await repo.GetListSeries();
            var beforeData = result[0];
            var afterData = result[0];
            afterData.NameSurname = "Serhat Üstek";            
                await repo.Update(afterData.id, afterData);
            Assert.AreEqual(afterData, beforeData);
        }
        [TestMethod()]
        public async Task ConnectionTest()
        {
            bool result = await repo.ConnectionTest();
            Assert.IsTrue(result);
        }
    }
}