using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Probleme {
    public class Dictionnaire {
        private string langue;
        private List<string>[] dic = new List<string>[13];

        /// <summary>
        /// Constructeur de la classe <c>Dictionnaire</c>.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="langue"></param>
        public Dictionnaire(string path, string langue) {
            this.langue = langue;
            ReadFile(path);
        }

        /// <summary>
        /// Lecture du fichier passé en paramètre. Une exception est lancée si une erreur se produit lors de la lecture.
        /// Comme j'ai décidé d'utiliser un tableau de listes pour stocker le dictionnaire, cette lecture se produit de la manière suivante :
        /// On avance dans les lignes du fichier jusqu'à trouver le string "3" (on ne s'intéresse pas aux mots de moins de 3 lettres d'après l'énoncé).
        /// Ensuite, tant que la  ligne du fichier ne vaut pas "4", on stocke tous les mots trouvés dans la liste correspondant aux mots de longueur 3
        /// On répète cela pour toutes les longueurs de mots dans le dictionnaire (la longueur maximale est 15, ce qui donne un total de 13 listes)
        /// </summary>
        /// <param name="path"></param>
        private void ReadFile(string path) {
            try {
                StreamReader reader = new StreamReader(path);
                string[] lines = new string[File.ReadAllLines(path).Length];
                int i = 0;
                while (reader.Peek() > 0) {
                    lines[i] = reader.ReadLine();
                    i++;
                }

                string[] data;
                char sep = ' ';
                i = 0;
                int a = 4;
                while (lines[i] != "3") {
                    i++;
                }
                while (i < lines.Length) {
                    i++;
                    dic[a - 4] = new List<string>();
                    while (i < lines.Length && lines[i] != a.ToString()) {
                        data = lines[i].Split(sep);
                        for (int j = 0; j < data.Length; j++) {
                            dic[a - 4].Add(data[j]);
                        }
                        i++;
                    }
                    a++;
                }
                reader.Close();
            } catch {
                throw new System.Exception("Erreur de lecture. Vérifier le chemin.");
            }

        }

        /// <summary>
        /// Fonction qui appelle la fonction recherche avec une certaine liste, selon la longueur du mot en paramètre.
        /// </summary>
        /// <param name="mot"></param>
        /// <returns>
        /// Un <c>bool</c> qui indique si la recherche a donné un résultat.
        /// </returns>
        public bool RechercheDichoRecursif(string mot) {
            //return mot.Length > 2 ? (dic[mot.Length-3].BinarySearch(mot.ToUpper()) > -1 ? true : false) : false;
            return mot.Length > 2 ? (Recherche(dic[mot.Length - 3], mot.ToUpper(), 0, dic[mot.Length - 3].Count-1) > -1 ? true : false) : false;
        }

        /// <summary>
        /// Recherche d'un string dans une liste selon un algorithme binaire (dichotomique) récursif.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="mot"></param>
        /// <param name="debut"></param>
        /// <param name="fin"></param>
        /// <returns>
        /// L'indice du string cherché, -1 si pas trouvé.
        /// </returns>
        private int Recherche(List<string> list, string mot, int debut, int fin) {
            int milieu = (debut + fin)/ 2;
            if (list[milieu] == mot) {
                return milieu;
            } else if (debut >= fin || (debut == fin-1 && list[debut] != mot && list[fin] != mot)) {
                return -1;
            } else if (String.Compare(mot, list[milieu], true) < 0) {
                return Recherche(list, mot, debut, milieu);
            } else return Recherche(list, mot, milieu, fin);
        }

        /// <summary>
        /// Override du <c>ToString()</c> de la classe <c>Object</c>.
        /// </summary>
        /// <returns>
        /// Un string qui décrit la classe <c>Dictionnaire</c>.
        /// </returns>
        public override string ToString() {
            string s = String.Format("Langue : {0}\n", langue);
            for (int i = 0; i < dic.Length; i++) {
                s += "Mots à " + (i + 3) + " lettres : " + dic[i].Count + "\n";
            }
            return s;
        }

        /// <summary>
        /// Recherche dans tous les mots d'au moins un mot qui commence par le préfixe passé en paramètre. 
        /// La recherche n'est pas très efficace puisqu'elle parcoure toute la liste mais, puisqu'on ne commence la recherche qu'à partir des mots
        /// qui ont au moins le même nombre de lettres que le préfixe, et qu'on s'arrête dès qu'un mot qui commence par ce préfixe, ce n'est pas dérangeant.
        /// </summary>
        /// <param name="prefixe"></param>
        /// <returns>
        /// Bool qui indique si la recherche a été fructueuse.
        /// </returns>
        public bool RecherchePrefixe(string prefixe) {
            for (int i = Math.Max(prefixe.Length-3, 0); i < dic.Length; i++) {
                for (int j = 0; j < dic[i].Count; j++) {
                    if(dic[i][j].StartsWith(prefixe.ToUpper())) return true;
                }
            }
            return false;
        }
    }
}
