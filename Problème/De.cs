using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme {
    public class De {
        private char[] faces;
        private char faceAffichee;

        /// <summary>
        /// Constructeur de la classe <c>De</c>.
        /// </summary>
        /// <param name="faces"></param>
        public De(char[] faces) {
            this.faces = new char[6];
            for (int i = 0; i < 6; i++) {
                _ = Char.IsLetter(faces[i]) ? this.faces[i] = Char.ToUpper(faces[i]) : this.faces[i] = 'A';
            }
            faceAffichee = faces[0];
        }

        /// <summary>
        /// Propriété en getter uniquement de <c>faceAffichee</c>.
        /// </summary>
        public char FaceAffichee {
            get {return faceAffichee; }
        }

        /// <summary>
        /// Méthode pour tirer aléatoirement l'une des six faces du dé et l'assigner à la variable <c>faceAffichee</c>.
        /// </summary>
        /// <param name="r"></param>
        public void Lance(Random r) {
            faceAffichee = faces[r.Next(6)];
        }

        /// <summary>
        /// Override du <c>ToString()</c> de la classe <c>Object</c>.
        /// </summary>
        /// <returns>
        /// Un string qui décrit la classe <c>De</c>, ici la face affichée.
        /// </returns>
        public override string ToString() {
            return faceAffichee.ToString();
        }
    }
}
