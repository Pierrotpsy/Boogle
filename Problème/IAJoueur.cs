using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme {
    /// <summary>
    /// Classe pour l'IA de la partie bonus.
    /// </summary>
    class IAJoueur : Joueur {
        /// <summary>
        /// La classe <c>IAJoueur</c> hérite de la classe <c>Joueur</c>.
        /// </summary>
        public IAJoueur() : base("IA"){}

        /// <summary>
        /// Fonction qui sera appelée dans le <c>Main</c>. Elle permet d'appeler la méthode récursive qui va chercher tous les mots possibles dans le plateau.
        /// </summary>
        /// <param name="plateau"></param>
        /// <param name="dico"></param>
        public void Generate(Plateau plateau, Dictionnaire dico) {
            //Console.WriteLine(plateau);
            GenerateWords(plateau, dico);
            //Pour afficher 
            for (int i = 0; i < TotalMots.Count; i++) Console.WriteLine(TotalMots[i]);
        }

        /// <summary>
        /// Méthode récursive qui va chercher tous les mots possibles dans le plateau. Son temps d'exécution est acceptable, 3-5 secondes sur mon ordinateur.
        /// Le raisonnement derrière est le même que pour la recherche d'adjacence, mais en plus simple puisque l'on considère tous les chemins et on les élimine 
        /// avec des critères uniquement liés à leur présence dans le dictionnaire et leur taille.
        /// </summary>
        /// <param name="plateau"></param>
        /// <param name="dico"></param>
        /// <param name="mot"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="b_a"></param>
        /// <param name="b_b"></param>
        private void GenerateWords(Plateau plateau, Dictionnaire dico, string mot = "", int a = 0, int b = 0, int b_a = 0, int b_b = 0) {
            //Peut servir à montrer tous les appels de la méthode.
            //Console.WriteLine(mot);
            if (mot != "") {
                if (mot.Length > 15) return;
                if (mot.Length > 2 && !dico.RecherchePrefixe(mot)) return;
                if (mot.Length > 2 && dico.RechercheDichoRecursif(mot) && !TotalMots.Contains(mot)) Add_Mot(mot);
                bool up = a - 1 > -1;
                bool down = a + 1 < plateau.Des.GetLength(0);
                bool left = b - 1 > -1;
                bool right = b + 1 < plateau.Des.GetLength(1);
                if ((up && left) && (a - 1 != b_a || b - 1 != b_b)) {
                    mot += plateau.Des[a - 1, b - 1].FaceAffichee;
                    GenerateWords(plateau, dico, mot, a - 1, b - 1, a, b);
                }
                if ((up && right) && (a - 1 != b_a || b + 1 != b_b)) {
                    mot += plateau.Des[a - 1, b + 1].FaceAffichee;
                    GenerateWords(plateau, dico, mot, a - 1, b + 1, a, b);
                }
                if ((down && left) && (a + 1 != b_a || b - 1 != b_b)) {
                    mot += plateau.Des[a + 1, b - 1].FaceAffichee;
                    GenerateWords(plateau, dico, mot, a + 1, b - 1, a, b);
                }
                if ((down && right) && (a + 1 != b_a || b + 1 != b_b)) {
                    mot += plateau.Des[a + 1, b + 1].FaceAffichee;
                    GenerateWords(plateau, dico, mot, a + 1, b + 1, a, b);
                }
                if (up && (a - 1 != b_a || b != b_b)) {
                    mot += plateau.Des[a - 1, b].FaceAffichee;
                    GenerateWords(plateau, dico, mot, a - 1, b, a, b);
                }
                if (down && (a + 1 != b_a || b != b_b)) {
                    mot += plateau.Des[a + 1, b].FaceAffichee;
                    GenerateWords(plateau, dico, mot, a + 1, b, a, b);
                }
                if (left && (a != b_a || b - 1 != b_b)) {
                    mot += plateau.Des[a, b - 1].FaceAffichee;
                    GenerateWords(plateau, dico, mot, a, b - 1, a, b);
                }
                if (right && (a != b_a || b + 1 != b_b)) {
                    mot += plateau.Des[a, b + 1].FaceAffichee;
                    GenerateWords(plateau, dico, mot, a, b + 1, a, b);
                }
            } else {
                for (int i = 0; i < plateau.Des.GetLength(0); i++) {
                    for (int j = 0; j < plateau.Des.GetLength(1); j++) {
                        GenerateWords(plateau, dico, plateau.Des[i,j].FaceAffichee.ToString(), i, j, i, j);
                    }
                }
            }
        }

    }
}
