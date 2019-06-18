#BLOQUANT
* Doublon entre OnValidSubmit du EditForm et SaveAction du wrapper


#A FAIRE
* Voir si possible d'ajouter un attribut ConvertToString à une propriété afin de regénérer une propriété du type Id / IdAsString
* Voir si la notion de modèle proposée par LLBLGEN ne permettrait pas de générer les modèles à utiliser pour les écrans de saisie
* Voir si possible d'utiliser du scss (Web Compiler)
* Déployer le site via Docker (Alpine)

#IMPORTANT
* Le Live Reload (dotnet watch run) ne détecte par défaut que les changements effectués sur les fichiers cs (pas sur les fichiers razor)
=> ajouter ça dans le fichier csproj 
  <ItemGroup>
    <Watch Include="**\*.razor"/>
  </ItemGroup>
* Pour pouvoir binder des champs nullables aux contrôles (notamment les dates), il faut forcément utiliser les contrôles 
  InputXXX (exemple : InputDate) sinon erreur du type "CS0029 Cannot implicitly convert type 'string' to 'System.DateTime?'

* Pour moi, un modèle est différent d'une entité. Dans le cas de Blazor, je dirai que cela revient à ce qu'on a
  pour WPF à savoir des entités (données en base) et des ViewModels (présentation des données)
  1) Même si en base, l'id est obligatoire, il ne faut pas ajouter l'attribut Required sur cette propriété car il 
  interdirait la validation de l'écran de saisie alors qu'il est auto généré.
  2) Quid des entités renseignées en plusieurs fois
	a) En base, les champs non renseignés dans le 1er écran doivent être NULLABLES sinon on ne pourrait pas sauvegarder le 1er écran
	b) Il faut diviser l'entitié en 2 (1 classe par écran) pour pouvoir ajouter les attributs Required en fonction de l'écran
	car ce n'est pas parce qu'un champ est nullable en base qu'on ne veut pas forcer l'utilisateur à le saisir quand il 
	est sur un écran particulier. Exemple : si je demande les informations sur la banque (nom de la banque, IBAN, ...), je peux vouloir
	le tout ou rien.

 * Possibilité de séparer les fichiers css via la commande import. Exemple @import url('search-button.css');
 * Le passage de paramètre à un composant de type Page se fait comme ceci : https://stackoverflow.com/questions/54303437/redirecting-in-blazor-with-parameter
 * On peut mal nommé un composant dans le html => le composant ne s'affiche pas mais pas d'erreur à la compilation
 * Obligé de définir les paramètres d'url en string et donc de créer 2 propriétés, une en string l'autre dans le bon type
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

* Pour retrouver l'ip du conteneur Docker sous Windows, ipconfig et rechercher Carte Ethernet vEthernet (DockerNAT)
* Ne pas utiliser de uniquement des majuscules dans une partie d'un namespace. Exemple Neptune.AC. car à la compilation, ça plante car il convertit en Neptune.Ac
* Les contrôles Telerik ont besoin du réseau (même en dev) pour s'afficher (cdn en ligne)


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
* libman : permet d'installer facilement (bouton droit Add\Client side libraries) les librairies client présentes sur https://cdnjs.com
  voir https://github.com/aspnet/LibraryManager et https://docs.microsoft.com/fr-fr/aspnet/core/client-side/libman/libman-vs?view=aspnetcore-2.2
