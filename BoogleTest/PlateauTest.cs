using Microsoft.VisualStudio.TestTools.UnitTesting;
using Probleme;

namespace BoogleTest {
    [TestClass]
    public class PlateauTest {
        [TestMethod]
        public void Adjacence() {
            //les faces affichées d'un nouveau plateau sont toujours les mêmes, on peut donc chercher un mot dedans, puisque ce n'est pas aléatoire.
            Plateau monplateau = new Plateau("C:\\Users\\33769\\source\\repos\\Problème\\bin\\Debug\\netcoreapp3.1\\Des.txt");
            Assert.IsTrue(monplateau.Test_Plateau("BAR", true), "Le mot n'a pas été trouvé, l'algorithme n'adjacence ne fonctionne donc pas.");
        }
    }
}
