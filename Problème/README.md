### Lancer le code
* Fonction joueur contre joueur :
Pour lancer une partie "normale" joueur contre joueur, il suffit de compiler et d'exécuter le code.\
Pour changer les noms des joueurs, il faut le faire directement dans le code.
* Fonction IA : Pour faire fonctionner l'IA, il suffit de décommenter le code indiqué dans le fichier `Jeu.cs` et de commenter le code en dessous dans le `Main`.

### Organisation des fichiers

* Solution de test `BoogleTest` : contient des classes de Test, avec une ou plusieurs méthodes de test.
  * `PlateauTest` : une méthode pour vérifier que la condition d'adjacence est bien fonctionnelle.
  * `DicoTest` : trois méthodes, pour vérifier que le dictionnaire a bien été importé et que la recherche dans le dictionnaire fonctionne bien.
  * `JoueurTest` : une méthode pour vérifier que l'ajout d'un mot au total de mots dit par les joueurs et la recherche dans ce total fonctionne.
  * `DeTest` : une méthode qui va vérifier si un dé affiche toujours la même face après avoir été lancé. Si le dé retombe sur la même face, il faut relancer le test, la probabilité que cela arrive plusieurs fois d'affilée étant très faible.

* Solution `Probleme` : contient les classes qui constituent l'architecture pour le Boogle.
  * `Joueur` est la classe qui décrit un joueur.
  * `Plateau` est la classe qui définit un plateau comme un tableau de dés (ici 16 dés).
  * `De` est la classe qui définit un dé comme un tableau de 6 char
  * `Dictionnaire` est la classe qui définit un dictionnaire comme un tableau de listes de string.
  * `IAJoueur` est la classe qui définit une IA, cette classe hérite de la classe `Joueur`. 
  * `Jeu` est la classe contenant le `Main`. C'est ici qu'est défini le cours de la partie.