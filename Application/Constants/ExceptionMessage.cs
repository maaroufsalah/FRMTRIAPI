using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{
    public class ExceptionMessage
    {
        public static class Authentication
        {
            public const string AUTH_NOT_FOUND = "Aucun compte enregistré avec {0}";
            public const string AUTH_ERR_CREDENTIALS = "Informations d'identification non valides pour {0}";
            public const string AUTH_NOT_CONFIRMED = "Le compte n'est pas vérifié pour {0}";

            public const string REG_USER_TAKEN = "Le nom d'utilisateur {0} est déjà utilisé";
            public const string REG_EMAIL_TAKEN = "L'adresse mail {0} est déjà utilisé";
            public const string REG_ERROR = "Une erreur s'est produite lors de la création du compte {}";
        }

        public static class Application
        {
            public const string ERROR_VALIDATION = "un ou plusieurs échecs de validation se sont produits";
        }
    }
}
