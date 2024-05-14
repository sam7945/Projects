using System;
using Hevadea;
using Hevadea.Entities;
using Hevadea.Registry;
using Hevadea.Systems.PlayerSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGame
{
    [TestClass]
    public class TestsUnitaires
    {       
        [TestMethod]
        public void TestAjoutEntities()
        {
            ENTITIES.Initialize();
            Assert.AreEqual(19, ENTITIES.BlueprintLibrary.Count);             
        }
    }
}
