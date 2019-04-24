using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorTests.Data
{
    /// <summary>
    /// ATTENTION : pour moi, un mod�le est diff�rent d'une entit�. Dans le cas de Blazor, je dirai que cela revient � ce qu'on a
    /// pour WPF � savoir des entit�s (donn�es en base) et des ViewModels (pr�sentation des donn�es)
    /// 
    /// 1) M�me si en base, l'id est obligatoire, il ne faut pas lui ajouter l'attribut Required car il serait demand�
    /// � la validation de l'�cran de saisie alors qu'il est auto g�n�r�.
    /// 
    /// 2) Quid des entit�s renseign�es en plusieurs fois
    ///     a) En base, les champs non renseign�s dans le 1er �cran doivent �tre NULLABLES sinon on ne pourrait pas sauvegarder le 1er �cran
    ///     b) Il faut diviser l'entiti� en 2 (1 classe par �cran) pour pouvoir ajouter les attributs Required en fonction de l'�cran
    ///     car ce n'est pas parce qu'un champ est nullable en base qu'on ne veut pas forcer l'utilisateur � le saisir quand il 
    ///     est sur un �cran particulier. Exemple : si je demande les informations sur la banque (nom de la banque, IBAN, ...), je peux vouloir
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
