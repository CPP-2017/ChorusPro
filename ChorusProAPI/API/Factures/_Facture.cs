using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChorusProAPI.API
{
    public class ConsulterFacture
    {
        // identifiant technique de l’utilisateur courant dans le système CPP
        public int? idUtilisateurCourant { get; set; }

        // identifiant technique de la facture au sein de CPP 2017
        [CPPAttribute(obligatoire = true)]
        public int identifiantFactureCPP { get; set; }

        // code de la langue dans laquelle doivent être retournés les libellés multi-lingues varchar(2)
        // Par défaut, si aucune langue n'est précisée ou que celle-ci n'est pas prise en charge par le système, les libellés seront retournés en français.
        public string codeLangue { get; set; }

        // nombre de résultats maximum que l’on veut voir retournés pour une recherche
        // Par défaut, le service retourne au maximum 200 résultats
        public int nbResultatsMaximum { get; set; }
    }

    public class CadreDeFacturation
    {
        public string codeCadreFacturation { get; set; }
        public long codeValideur1 { get; set; }
        public int idValideur1 { get; set; }
        public string raisonSocialeValideur1 { get; set; }
        public string typeIdentifiantValideur1 { get; set; }
    }

    public class Destinataire
    {
        public string adresseDestinataireCodePays { get; set; }
        public string adresseDestinataireCodePostal { get; set; }
        public string adresseDestinataireComplement1 { get; set; }
        public string adresseDestinataireDetail { get; set; }
        public int adresseDestinataireId { get; set; }
        public string adresseDestinataireLibellePays { get; set; }
        public string adresseDestinataireVille { get; set; }
        public string codeDestinataire { get; set; }
        public string codeServiceExecutant { get; set; }
        public int idDestinataire { get; set; }
        public int idServiceExecutant { get; set; }
        public string libelleDestinataire { get; set; }
        public string libelleServiceExecutant { get; set; }
        public bool miseEnPaiementDestinataire { get; set; }
    }

    public class Fournisseur
    {
        public string adresseFournisseurCodePays { get; set; }
        public string adresseFournisseurCodePostal { get; set; }
        public string adresseFournisseurDetail { get; set; }
        public int adresseFournisseurId { get; set; }
        public string adresseFournisseurLibellePays { get; set; }
        public string adresseFournisseurVille { get; set; }
        public string codeFournisseur { get; set; }
        public string codeServiceFournisseur { get; set; }
        public int coordBancairesFournisseurCleIban { get; set; }
        public int coordBancairesFournisseurCleRib { get; set; }
        public int coordBancairesFournisseurCodeBanque { get; set; }
        public string coordBancairesFournisseurCodePays { get; set; }
        public string coordBancairesFournisseurCompteBancaire { get; set; }
        public int coordBancairesFournisseurId { get; set; }
        public string coordBancairesFournisseurType { get; set; }
        public int idFournisseur { get; set; }
        public int idServiceFournisseur { get; set; }
        public string libelleServiceFournisseur { get; set; }
        public string numeroRcsFournisseur { get; set; }
        public string raisonSocialeFournisseur { get; set; }
        public string typeIdentifiantFournisseur { get; set; }
    }

    public class LignePoste
    {
        public string lignePosteDenomination { get; set; }
        public int lignePosteMontantHtApresRemise { get; set; }
        public double lignePosteMontantTtcApresRemise { get; set; }
        public double lignePosteMontantTva { get; set; }
        public int lignePosteMontantUnitaireHT { get; set; }
        public int lignePosteNumero { get; set; }
        public int lignePosteQuantite { get; set; }
        public string lignePosteReference { get; set; }
        public int lignePosteUniteCode { get; set; }
        public string lignePosteUniteLibelle { get; set; }
        public int? lignePosteMontantRemiseHT { get; set; }
        public double? lignePosteTauxTvaManuel { get; set; }
    }

    public class LignesDePoste
    {
        public List<LignePoste> lignePoste { get; set; }
        public int nbResultatsParPageLignesPoste { get; set; }
        public int pageCouranteLignesPoste { get; set; }
        public int pagesLignesPoste { get; set; }
        public int totalLignesPoste { get; set; }
    }

    public class PieceJointe
    {
        public string pieceJointeDesignation { get; set; }
        public string pieceJointeExtension { get; set; }
        public int pieceJointeId { get; set; }
        public int pieceJointeIdLiaison { get; set; }
        public string pieceJointeTypeCode { get; set; }
        public string pieceJointeTypeLibelle { get; set; }
    }

    public class ListeDesPiecesJointes
    {
        public int nbResultatsParPageListePiecesJointe { get; set; }
        public int pageCouranteListePiecesJointe { get; set; }
        public int pagesListePiecesJointe { get; set; }
        public List<PieceJointe> pieceJointe { get; set; }
        public int totalListePiecesJointe { get; set; }
    }

    public class MontantTotal
    {
        public double montantAPayer { get; set; }
        public int montantHtTotal { get; set; }
        public int montantRemiseGlobaleTTC { get; set; }
        public double montantTVA { get; set; }
        public double montantTtcAvantRemiseGlobalTTC { get; set; }
        public double montantTtcTotal { get; set; }
        public string motifRemiseGlobaleTTC { get; set; }
    }

    public class PieceJointePrincipale
    {
        public int idLiaisonPieceJointePrincipale { get; set; }
        public int idPieceJointePrincipale { get; set; }
    }

    public class LigneTva
    {
        public int ligneTvaMontantBaseHtParTaux { get; set; }
        public double ligneTvaMontantTvaParTaux { get; set; }
        public double ligneTvaTauxManuel { get; set; }
    }

    public class RecapitulatifDeTva
    {
        public List<LigneTva> ligneTva { get; set; }
        public int nbResultatsParPageLignesRecapitulativesTVA { get; set; }
        public int pageCouranteLignesRecapitulativesTVA { get; set; }
        public int pagesLignesRecapitulativesTVA { get; set; }
        public int totalLignesRecapitulativesTVA { get; set; }
    }

    public class References
    {
        public string codeDeviseFacture { get; set; }
        public string dateCreationFacture { get; set; }
        public string dateEcheancePaiement { get; set; }
        public string dateFacture { get; set; }
        public string libelleDeviseFacture { get; set; }
        public string modePaiement { get; set; }
        public string numeroBonCommande { get; set; }
        public string numeroMarche { get; set; }
        public int tailleTotalePiecesJointes { get; set; }
        public string typeFacture { get; set; }
        public string typeTva { get; set; }
    }

    public class Facture
    {
        public int identifiantFactureCPP { get; set; }
        public string numeroFacture { get; set; }
        public string statutFacture { get; set; }
        public string modeDepot { get; set; }
        public Destinataire destinataire { get; set; }
        public CadreDeFacturation cadreDeFacturation { get; set; }
        public string commentaire { get; set; }
        public Fournisseur fournisseur { get; set; }
        public LignesDePoste lignesDePoste { get; set; }
        public ListeDesPiecesJointes listeDesPiecesJointes { get; set; }
        public MontantTotal montantTotal { get; set; }
        public PieceJointePrincipale pieceJointePrincipale { get; set; }
        public RecapitulatifDeTva recapitulatifDeTva { get; set; }
        public References references { get; set; }
    }
}
