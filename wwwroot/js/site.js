window.JavascriptFunctions = {

    returnToCallerPage: function () {
        return history.back();
    },

    showAlert: function (message) {
        return alert(message);
    },

    initTable: function (tableId) {

        // FIXME : Attention, aujourd'hui, si j'appelle cette fonction dans OnInitAsync, ça plante
        // donc... Voir https://github.com/aspnet/AspNetCore/issues/8274
        //$(document).ready(function () {

            var table = $('#' + tableId).DataTable({
                 pagingType: "simple",

                // Traduction
                oLanguage: {
                    sSearch: "Rechercher",
                    sInfo: "de _START_ à _END_ sur _TOTAL_",
                    oPaginate: {
                        sPrevious: "Préc.",
                        sNext: "Suiv.",
                        sLengthMenu: "_MENU_"
                    }
                },

                // Définition des éléments de la grille à afficher
                dom: 'frtipB',

                // Customisation du bouton d'export Excel (icone, couleur, ...)
                buttons: [{
                    extend: 'excel',
                    text: "<span class='oi oi-data-transfer-download' aria-hidden='true'></span> Exporter",
                    className: 'btn btn-success excelButton',
                    exportOptions: {
                        modifier: {
                            page: 'all'
                        }
                    }
                }]
            });

            // Ajout de filtres de type ComboBox sur l'ensemble des colonnes
            $(".headerFilter").each(function (i) {
                var select = $('<select class="custom-select"><option value=""></option></select>')
                    .appendTo($(this).empty())
                    .on('change', function () {
                        var term = $(this).val();
                        table.column(i).search(term, false, false).draw();
                    });
                table.column(i).data().unique().sort().each(function (d, j) {
                    select.append('<option value="' + d + '">' + d + '</option>')
                });
            });
        //});
    }
};