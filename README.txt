#BLOQUANT
* Voir pour gérer correctement les champs obligatoires. En effet, si la vérification des champs obligatoires se fait 
	via un attribut [Required] et que cet attibut est ajouté conformément aux champs obligatoires de la base, la vérification
	va déclencher une erreur car la propriété Id n'est pas renseigné lors d'un ajout
* Voir pour pouvoir binder des champs nullables aux contrôles (notamment les dates). 
  Semble avoir été pris en compte : public DateTimeOffset? OptionalExpiryDate { get; set; } (trouvé dans le code source de Github)

#A FAIRE
* Voir pour placer les fichiers css, js (jquery, syncfusion, ...) dans un fichier séparé
* Déployer le site via Docker (Alpine)
* Voir si possible d'utiliser du scss

#RESSENTI
* Les plus
	* ajouter une page est super simple. NavMenu + page razor avec route et c'est fini
* Les moins
	* Le hot reload ne semble pas fonctionner
	* On peut mal nommé un composant dans le html => le composant ne s'affiche pas mais pas d'erreur à la compilation
	* Impossible de réorganiser les répertoires comme je le veux (le projet ne compile plus). Exemple de structure
		Areas
			Parameters
				Views
				Models
				Services
			Customers
				Views
				Models
				Services
	  Note : les répertoires Views contiennent les pages mais aussi les composants utilisées pour cette page

#A NOTER
* Ne pas utiliser de uniquement des majuscules dans une partie d'un namespace. Exemple Neptune.AC. car à la compilation, ça plante car il convertit en Neptune.Ac
* les contrôles Telerik ont besoin du réseau (même en dev) pour s'afficher (cdn en ligne)
* Le passage de paramètre à un composant de type Page se fait comme ceci : https://stackoverflow.com/questions/54303437/redirecting-in-blazor-with-parameter

#LIENS INTERESSANTS
* EditForm (InputText, InputDate, ...) : https://www.telerik.com/blogs/first-look-forms-and-validation-in-razor-components
* Utiliser une classe du type SessionState : https://stackoverflow.com/questions/53913396/how-to-store-session-data-in-server-side-blazor
* Accéder à un fichier sur le serveur : https://dzone.com/articles/aspnet-core-replacement-for-servermappath
* Librairie type Boostrap : https://chanan.github.io/BlazorStrap/
* Librairie type Material : https://www.matblazor.com/BaseComponent
* Grid : https://github.com/Mewriick/Blazor.FlexGrid
* Grid : https://medium.com/swlh/how-to-create-a-reusable-grid-component-for-blazor-9de4b7a669d9
* Site magnifique fait en Blazor : https://discordapp.com/invite/Xg9ja5s
* Librairie Telerik : https://docs.telerik.com/blazor/introduction
* Police Open Iconic : https://aalmiray.github.io/ikonli/cheat-sheet-openiconic.html
