using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public static class ApplicationMessage
    {
        public const string InsertSuccess = "l'insertion a été effectuée avec succès.";
        public const string UpdateSuccess = "la modification a été effectuée avec succès.";
        public const string DeleteSuccess = "la suppréssion a été effectuée avec succès.";

        public const string InsertFailed = "Une erreur s'est produite lors de l'Insertion.";
        public const string UpdateFailed = "Une erreur s'est produite lors de la Modification.";
        public const string DeleteFailed = "Une erreur s'est produite lors de la Supression.";

        public const string ChampObligatoire = "Ce champ est obligatoire.";

    }

    public class AuthenticationMessage
    {
        public const string AUTHENTICATION_SUCCESS = "L'utilisateur {0} est authentifié";
        public const string REGISTRE_SUCCESS = "Le compte {0} est crée";

        public const string AUTH_NOT_FOUND = "Aucun compte enregistré avec {0}";
        public const string AUTH_ERR_CREDENTIALS = "Informations d'identification non valides pour {0}";
        public const string AUTH_NOT_CONFIRMED = "Le compte n'est pas vérifié pour {0}";

        public const string REG_USER_TAKEN = "Le nom d'utilisateur {0} est déjà utilisé";
        public const string REG_EMAIL_TAKEN = "L'adresse mail {0} est déjà utilisé";
        public const string REG_ERROR = "Une erreur s'est produite lors de la création du compte {}";
    }
}
