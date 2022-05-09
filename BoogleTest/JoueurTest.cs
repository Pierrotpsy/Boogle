using Microsoft.VisualStudio.TestTools.UnitTesting;
using Probleme;

namespace BoogleTest {
    [TestClass]
    public class JoueurTest {
        [TestMethod]
        public void MotAjouteContenu() {
            Joueur j1 = new Joueur("Maxime");
            j1.Add_Mot("mot");
            Assert.IsTrue(j1.Contain("mot"), "La méthode 'Add' et/ou 'Contain' ne fonctionne pas.");
        }
    }
}