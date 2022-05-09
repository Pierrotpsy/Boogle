using System;
using System.Threading.Tasks;

namespace Probleme {
    public class Jeu {
        private static Dictionnaire mondico;
        private static Plateau monplateau;

        /// <summary>
        /// Méthode <c>Main</c> du projet.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            mondico = new Dictionnaire("MotsPossibles.txt", "français");
            monplateau = new Plateau("Des.txt");


            //Enlever le commentaire et commenter le main en dessous pour lancer l'IA et voir tous les mots qui peuvent être trouvés sur le plateau.
            /*IAJoueur IA = new IAJoueur();
            monplateau.LancerDes();
            IA.Generate(monplateau, mondico);*/

            Joueur j1 = new Joueur("Maxime");
            Joueur j2 = new Joueur("August");
            DateTime Start = DateTime.Now;
            while (DateTime.Now - Start < new TimeSpan(0, 6, 0)) {
                monplateau.LancerDes();
                playerTurn(j1.Nom, j1);
                monplateau.LancerDes();
                playerTurn(j2.Nom, j2);
            }
            if (j1.Score != j2.Score) {
                Console.WriteLine("La partie est finie, {0} a gagné avec un score de {1}.", j1.Score > j2.Score ? j1.Nom : j2.Nom, j1.Score > j2.Score ? j1.Score : j2.Score);
            } else Console.WriteLine("La partie est finie, match nul avec un score de {0}", j1.Score);

        }

        /// <summary>
        /// Méthode qui définit le tour d'un joueur. Les mots entrés seront comptés si les critères sont validés et si le tour a commencé depuis moins d'un minute.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="j"></param>
        static void playerTurn(string name, Joueur j) {
            Console.WriteLine("C'est au tour de {0}", name);
            Console.WriteLine(monplateau);
            DateTime turnStart = DateTime.Now;
            while (DateTime.Now - turnStart < new TimeSpan(0, 1, 0)) {
                Console.WriteLine("Votre score est de {0}. Saissez un nouveau mot : ", j.Score);
                string s = Console.ReadLine();
                if (DateTime.Now - turnStart < new TimeSpan(0, 1, 0) && s.Length >= 3 && !j.Contain(s) && mondico.RechercheDichoRecursif(s) && monplateau.Test_Plateau(s, true)) {
                    j.Score = s.Length;
                    j.Add_Mot(s);
                }
            }
        }
    }
}
