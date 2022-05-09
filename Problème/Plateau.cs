using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Probleme {
    public class Plateau {
        private De[,] plateau = new De[4, 4];
        private List<char> valeursSup = new List<char>();

        /// <summary>
        /// Constructeur de la classe <c>Plateau</c>.
        /// </summary>
        /// <param name="file"></param>
        public Plateau(string file) {
            De[] des = new De[16];
            ReadFile(file, des);
            if (des.Length == 16) {
                for (int i = 0; i < 4; i++) {
                    for (int j = 0; j < 4; j++) {
                        plateau[i, j] = des[4 * i + j];
                        valeursSup.Add(plateau[i, j].FaceAffichee);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété en getter de <c>plateau</c>, elle s'appelle Des puisque Plateau est le nom de la classe. Nécessaire pour la classe <c>IAJoueur</c>.
        /// </summary>
        public De[,] Des {
            get { return plateau; }
        }
        /// <summary>
        /// Fonction qui va appeler la méthode d'instance <c>Lance(Random r)</c> de la classe <c>De</c> pour tous les dés composant le plateau.
        /// </summary>
        public void LancerDes() {
            Random r = new Random();
            foreach (De d in plateau) {
                d.Lance(r);
            }
        }

        /// <summary>
        /// Lecture du fichier passé en paramètre. Une exception est lancée si une erreur se produit lors de la lecture.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="des"></param>
        private void ReadFile(string file, De[] des) {
            try {
                StreamReader reader = new StreamReader(file);
                string[] lines = new string[File.ReadAllLines(file).Length];
                int i = 0;
                while (reader.Peek() > 0) {
                    lines[i] = reader.ReadLine();
                    i++;
                }

                string[] data;
                char sep = ';';
                for (i = 0; i < lines.Length; i++) {
                    data = lines[i].Split(sep);
                    des[i] = new De(string.Join("", data).ToCharArray());
                }
                reader.Close();
            } catch {
                throw new System.Exception("Chemin incorrect");
            }
            
        }

        /// <summary>
        /// Override du <c>ToString()</c> de la classe <c>Object</c>.
        /// </summary>
        /// <returns>
        /// Un string qui décrit la classe <c>Plateau</c>. Ici, cela constitue l'affichage du tableau, c'est-à-dire l'affichage de toutes les faces affichées
        /// des dés sous forme de carré 4*4.
        /// </returns>
        public override string ToString() {
            string s = "";
            for (int i = 0; i < plateau.GetLength(0); i++) {
                for (int j = 0; j < plateau.GetLength(1); j++) {
                    s += plateau[i, j] + " ";
                }
                s += "\n";
            }
            return s;
        }

        /// <summary>
        /// Fonction pour tester si le mot entré en paramètre est valide selon le plateau actuel. Cette fonction va vérifier que chaque lettre du mot est bien adjacente à la prochaine lettre du mot.
        /// Pour gérer les multiples occasions où la même lettre apparaît plusieurs fois autour d'une lettre du mot, des conditions sont employées pour qu'au moins un chemin à partir de la première lettre
        /// mène jusqu'à la dernière. Il y a donc deux parties dans cet algorithme récursif. Si la même lettre apparaît plusieurs fois, on crée plusieurs chemins (OU), et si la lettre
        /// n'apparaît qu'une fois, on continue l'algorithme (ET).
        /// En somme, on teste l'adjacence et le fait qu'on ne peut pas revenir sur une lettre déjà utilisée.
        /// </summary>
        /// <param name="mot"></param>
        /// <param name="first"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="b_a"></param>
        /// <param name="b_b"></param>
        /// <returns>
        /// Un <c>bool</c> qui indique si le mot est valide selon le critère d'adjacence ou non.
        /// </returns>
        public bool Test_Plateau(string mot, bool first, int a = 0, int b = 0, int b_a = 0, int b_b = 0) {
            mot = mot.ToUpper();
            //Console.WriteLine(mot + " " + mot.Length + " " + a + " " + b);
            int occurence = 0;
            for (int i = 0; i < valeursSup.Count; i++) {
                char ax = mot[0];
                char bx = valeursSup[i];
                _ = ax == bx ? occurence++ : 0;
            }
            bool Final = false;
            //Not the first iteration
            if ((!first && occurence == 1) || mot.Length == 1) {
                Final = true;
                bool change = false;
                bool up = a - 1 > -1;
                bool down = a + 1 < plateau.GetLength(0);
                bool left = b - 1 > -1;
                bool right = b + 1 < plateau.GetLength(1);

                if ((up && left) && plateau[a - 1, b - 1].FaceAffichee == mot[0] && (a - 1 != b_a || b - 1 != b_b)) {
                    change = true;
                    if (mot.Length > 1) Final &= Test_Plateau(mot.Substring(1), false, a-1, b-1, a, b);
                }
                if ((up && right) && plateau[a - 1, b + 1].FaceAffichee == mot[0] && (a - 1 != b_a || b + 1 != b_b)) {
                    change = true;
                    if (mot.Length > 1) Final &= Test_Plateau(mot.Substring(1), false, a-1, b+1, a, b);
                }
                if ((down && left) && plateau[a + 1, b - 1].FaceAffichee == mot[0] && (a + 1 != b_a || b - 1 != b_b)) {
                    change = true;
                    if (mot.Length > 1) Final &= Test_Plateau(mot.Substring(1), false, a+1, b-1, a, b);
                }
                if ((down && right) && plateau[a + 1, b + 1].FaceAffichee == mot[0] && (a + 1 != b_a || b + 1 != b_b)) {
                    change = true;
                    if (mot.Length > 1) Final &= Test_Plateau(mot.Substring(1), false, a+1, b+1, a, b);
                }
                if (up && plateau[a - 1, b].FaceAffichee == mot[0] && (a - 1 != b_a || b != b_b)) {
                    change = true;
                    if (mot.Length > 1) Final &= Test_Plateau(mot.Substring(1), false, a-1, b, a, b);
                }
                if (down && plateau[a + 1, b].FaceAffichee == mot[0] && (a + 1 != b_a || b != b_b)) {
                    change = true;
                    if (mot.Length > 1) Final &= Test_Plateau(mot.Substring(1), false, a+1, b, a, b);
                }
                if (left && plateau[a, b - 1].FaceAffichee == mot[0] && (a != b_a || b - 1 != b_b)) {
                    change = true;
                    if (mot.Length > 1) Final &= Test_Plateau(mot.Substring(1), false, a, b-1, a, b);
                }
                if (right && plateau[a, b + 1].FaceAffichee == mot[0] && (a != b_a || b + 1 != b_b)) {
                    change = true;
                    if (mot.Length > 1) Final &= Test_Plateau(mot.Substring(1), false, a, b+1, a, b);
                }
                if (mot.Length == 1) return change;
                return Final && change;
            } else {

                //First iteration and multiple occurences
                for (int i = 0; i < plateau.GetLength(0); i++) {
                    for (int j = 0; j < plateau.GetLength(1); j++) {
                        if (plateau[i, j].FaceAffichee == mot[0] && Vicinity(a, b, i,j, first)) {
                            Final |= Test_Plateau(mot.Substring(1), false, i, j, a, b);
                        }
                    }
                }
            }
            return Final;
        }

        /// <summary>
        /// Fonction pour vérifier si des coordonnées (a,b) et (na, nb) ont évoluées dans une direction quelconque.
        /// Cette fonction est nécessaire puisqu'on ne veut vérifier que les coordonnées ont évoluées seulement après la première itération de l'algorithme de recherche.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="na"></param>
        /// <param name="nb"></param>
        /// <param name="first"></param>
        /// <returns>
        /// Un <c>bool</c> qui indique si les coordonnées ont évoluées.
        /// </returns>
        private bool Vicinity(int a, int b, int na, int nb, bool first) {
            if (!first) {
                bool same = a == na && b == nb;
                /*bool up = na == a - 1;
                bool down = na == a + 1;
                bool right = nb == b + 1;
                bool left = nb == b - 1;*/

                return !same; //&& (up || down || right || left);
            }
            return true;
        }
    }
}
