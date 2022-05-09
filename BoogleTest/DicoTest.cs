using Microsoft.VisualStudio.TestTools.UnitTesting;
using Probleme;

namespace BoogleTest {
    [TestClass]
    public class DicoTest {
        [TestMethod]
        public void DernierMot() {
            Dictionnaire d = new Dictionnaire("C:\\Users\\33769\\source\\repos\\Probl�me\\bin\\Debug\\netcoreapp3.1\\MotsPossibles.txt", "Fran�ais");

            Assert.IsTrue(d.RechercheDichoRecursif("TRANSISTORISANT"), "Le dernier mot du dictionnaire n'a pas �t� trouv�");
        }

        [TestMethod]
        public void PremierMot() {
            Dictionnaire d = new Dictionnaire("C:\\Users\\33769\\source\\repos\\Probl�me\\bin\\Debug\\netcoreapp3.1\\MotsPossibles.txt", "Fran�ais");

            Assert.IsTrue(d.RechercheDichoRecursif("AAS"), "Le premier mot du dictionnaire n'a pas �t� trouv�");
        }

        [TestMethod]
        public void MotTropCourt() { 
            Dictionnaire d = new Dictionnaire("C:\\Users\\33769\\source\\repos\\Probl�me\\bin\\Debug\\netcoreapp3.1\\MotsPossibles.txt", "Fran�ais");

            Assert.IsTrue(!d.RechercheDichoRecursif("a"), "Le mot trop court a quand m�me �t� trouv�");
        }
    }
}
