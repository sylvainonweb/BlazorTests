using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorTests.Data
{
    /// <summary>
    /// ATTENTION : pour moi, un modèle est différent d'une entité. Dans le cas de Blazor, je dirai que cela revient à ce qu'on a
    /// pour WPF à savoir des entités (données en base) et des ViewModels (présentation des données)
    /// 
    /// 1) Même si en base, l'id est obligatoire, il ne faut pas lui ajouter l'attribut Required car il serait demandé
    /// à la validation de l'écran de saisie alors qu'il est auto généré.
    /// 
    /// 2) Quid des entités renseignées en plusieurs fois
    ///     a) En base, les champs non renseignés dans le 1er écran doivent être NULLABLES sinon on ne pourrait pas sauvegarder le 1er écran
    ///     b) Il faut diviser l'entitié en 2 (1 classe par écran) pour pouvoir ajouter les attributs Required en fonction de l'écran
    ///     car ce n'est pas parce qu'un champ est nullable en base qu'on ne veut pas forcer l'utilisateur à le saisir quand il 
    ///     est sur un écran particulier. Exemple : si je demande les informations sur la banque (nom de la banque, IBAN, ...), je peux vouloir
    ///     le tout ou rien.
    ///     
    /// </summary>
    public class CompanyEntity
    {
        // [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? ActivityId { get; set; }
    }
}
