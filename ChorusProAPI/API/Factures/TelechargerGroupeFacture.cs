using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    // La méthode telechargerGroupeFacture permet de télécharger une ou plusieurs factures émises, reçues ou à valider en précisant le format de réception(XML, PDF ou ZIP) et les pièces jointes associées à ces factures.Le dossier téléchargé ne doit pas dépasser la taille maximum d’un dossier de facturation (120 Mo), quelque soit le nombre de factures téléchargées.Si le dossier récupéré dépasse cette taille, une erreur 413 sera remontée.
    [RestAttribute(path = "factures/telecharger/groupe")]
    public class TelechargerGroupeFactureInput
    {
        public int? idUtilisateurCourant { get; set; }
        public int? idEspace { get; set; }
        // format sous lequel les factures ou les factures de travaux doivent être récupérées varchar(5)
        // Enumération avec 2 valeurs possibles : - PDF - PIVOT
        [CPP(obligatoire = true)]
        public string format { get; set; }
        // indicateur précisant si les pièces jointes complémentaires doivent être récupérées (uniquement si Format = "PDF") varchar(3)
        // Ce paramètre doit être renseigné uniquement si Format = « PDF ».
        // Enumération avec 2 valeurs possibles : - Oui - Non
        // Si le format passé en paramètre est « PIVOT », les pièces jointes sont systématiquement téléchargées.
        public string avecPiecesJointesComplementaires { get; set; }
        public Listefacture3[] listeFacture { get; set; }
    }

    public class Listefacture3
    {
        public int idFacture { get; set; }
    }

    public class TelechargerGroupeFactureOutput : CodeRetour
    {
        // fichier binaire encodé en base64
        // Le format du fichier à retourner diffère selon les cas suivants : 1) 
        // Si "Format" = "PIVOT" : Le service ne retourne qu'un seul fichier au format pivot, qui contiendra une ou plusieurs factures avec leurs pièces jointes uuencodées. 
        // 2.a) Si "Format" = "PDF", et qu'il n'y a qu'une seule pièce jointe à retourner pour une seule facture : Le service ne retourne qu'un seul fichier au format PDF. 
        // 2.b) Si "Format" = "PDF", et qu'il y a plusieurs pièces jointes à retourner pour une seule facture : Le service retourne une archive ZIP qui contient les pièces jointes au format PDF. 
        // 2.c) Si "Format" = "PDF", et qu'il y a plusieurs pièces jointes à retourner pour plusieurs factures : Le service retourne une archive ZIP qui contient les pièces jointes au format PDF. L'archive contient un répertoire par facture.
        public string fichierResultat { get; set; }
    }

}
