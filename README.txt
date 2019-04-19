Les plus
	* ajouter une page est super simple. NavMenu + page razor avec route et c'est fini

Les moins
	* Le hot reload ne semble pas fonctionner
	* On peut mal nommé un composant dans le html => le composant ne s'affiche pas mais pas d'erreur à la compilation
	* Un modèle est différent d'une entité car même si en base la colonne Id est obligatoire, il n'est pas possible
	  d'ajouter l'attribut [Required] sur cette colonne sinon la validation des champs obligatoires déclencherait une erreur
	  => un écran = un modèle

Attention
	* Ne pas utiliser de uniquement des majuscules dans une partie d'un namespace. Exemple Neptune.AC. car à la compilation, ça plante car il convertit en Neptune.Ac
	* les contrôles Telerik ont besoin du réseau (même en dev) pour s'afficher (cdn en ligne)

A faire		
	* Voir pour placer les fichiers css, js (jquery, syncfusion, ...) dans un fichier séparé
	* Déployer le site via Docker (Alpine)

A voir
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




La structure souhaitée est la suivante. Celle ci permet de ne pas avoir à se déplacer dans tous les sens
quand on travaille sur un thème, un module
Areas
	Parameters
		Views
		Models
		Services
	Customers
		Views
		Models
		Services
	Administration
		Views
		Models
		Services
Note : les répertoires Views contiennent les pages mais aussi les composants utilisées pour cette page