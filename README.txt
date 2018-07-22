//==================================================
//
// FONCTIONNALITES ATTENDUES ET PROBLEMES
//
//==================================================
* Utilisation d'une feuille de style
	* D�finir le style des boutons Ajouter/Modifier/Supprimer/Sauvegarder/Fermer une bonne fois pour toutes
	=> voir pour la couleur des icones des boutons
* Responsive
* Performant
* Partage du code entre le client et le serveur (r�gles m�tier ?)
* S�curis� (Open Id Connect)
* Dockerable
* Ecran de type Liste
	* Ajout : OK
	* Modification : OK
	* Suppression (confirmation de suppression) : OK
	* Double clic pour ajout/modification
	* Filtres (li�s aux grilles ou pas)
	* Export PDF, Excel, ...
* Ecran de type Saisie
	* Validation des champs obligatoires
		* Pas encore impl�ment� dans Blazor => j'ai fair quelque chose (pour les chaines en tout cas car pour le reste, les nullables ne sont pas encore g�r�s)
* Cr�ation de contr�les personnalis�s
	* ComboBox
		* Utiliser SelectListItem afin de ne pas avoir � ajouter une ligne vide
		* bind et onchange ne peuvent pas �tre utilis�s simultan�ment => si on change, alors value
* Utilisation d'un layout (titre, boutons Sauvegarder/Fermer si Edit)
	* Placer Save et Close dans EditLayout. Comment appeler les fonctions Save et Close de EditComponentBase ?
	* Placer le titre dans ViewLayout. A ce jour, Steve Sanderson pr�conise de cr�er un wrapper de type composant (et pas un layout) contenant
	  la propri�t� Title et dans chaque composant, ajouter le code <ViewLayout Title=@Title> ... </ViewLayout>
* Utilisation de transition entre les pages
* Gestion des nullables
	* Pas encore impl�ment� dans Blazor

