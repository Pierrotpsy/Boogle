using Microsoft.VisualStudio.TestTools.UnitTesting;
using Probleme;
using System;

namespace BoogleTest {
    [TestClass]
    public class DeTest {
        [TestMethod]
        public void Shuffle() {
            char[] faces = { 'a', 'b', 'c', 'd', 'e', 'f' };
            De d = new De(faces);
            char f1 = d.FaceAffichee;
            Random r = new Random();
            d.Lance(r);
            Assert.AreNotEqual(f1, d.FaceAffichee, "Le lancer de dé n'a pas fonctionné ou le dé est retombé sur la même lettre.");
        }
    }
}
