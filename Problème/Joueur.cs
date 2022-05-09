using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme {
    public class Joueur {
        private string nom;
        private int score = 0;
        private static List<string> totalMots = new List<string>();

        /// <summary>
        /// Constructeur de la classe <c>Joueur</c>.
        /// </summary>
        /// <param name="nom"></param>
        public Joueur(string nom) {
            this.nom = nom;
        }

        /// <summary>
        /// Propriété en getter de <c>totalMots</c>. Nécessaire pour la classe <c>IAJoueur</c>.
        /// </summary>
        public List<string> TotalMots {
            get { return totalMots; }
        }
        /// <summary>
        /// Méthode pour vérifier si un mot a déjà été joué au cours de la partie.
        /// </summary>
        /// <param name="mot"></param>
        /// <returns>
        /// Un <c>bool</c> qui indique si le mot a été trouvé.
        /// </returns>
        public bool Contain(string mot) {
            return totalMots.Contains(mot.ToUpper());
        }

        /// <summary>
        /// Méthode pour ajouter un mot à la liste de tous les mots joués dans la partie.
        /// </summary>
        /// <param name="mot"></param>
        public void Add_Mot(string mot) {
            totalMots.Add(mot.ToUpper());
        }

        /// <summary>
        /// Override du <c>ToString()</c> de la classe <c>Object</c>.
        /// </summary>
        /// <returns>
        /// Un string qui décrit la classe <c>Joueur</c>.
        /// </returns>
        public override string ToString() {
            return String.Format("Nom : {0}, Score : {1}", nom, score) ;
        }

        /// <summary>
        /// Propriété en getter et setter de <c>score</c>. Le setter est directement en += pour plus de facilité.
        /// </summary>
        public int Score {
            get { return score; }
            set { score += value; }
        }

        /// <summary>
        /// Propriété en getter et setter de <c>nom</c>;
        /// </summary>
        public string Nom {
            get { return nom; }
            set { nom = value; }
        }
    }
}
