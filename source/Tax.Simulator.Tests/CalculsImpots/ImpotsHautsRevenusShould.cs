using FluentAssertions;

namespace Tax.Simulator.Tests.CalculsImpots;

public class ImpotsHautsRevenusShould
{
    [Fact(DisplayName = "Calcul des impôts pour un revenu inférieur au seuil de 500 000 EUR")]
    public void NePasAffecterLesRevenusInferieursA500K()
    {
        string situationFamiliale = Foyer.CELIBATAIRE;
        int nombreEnfants = 0;
        int salaireMensuelPrincipal = 2000; // 240 000 EUR/an
        decimal resultat = Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                situationFamiliale,
                nombreEnfants,
                salaireMensuelPrincipal
            )
        );
        resultat.Should().Be(1515.25m);
    }

    [Fact(DisplayName = "Calcul des impôts pour un revenu supérieur au seuil de 500 000 EUR")]
    public void AppliquerTaxeSurRevenusSuperieursA500K()
    {
        string situationFamiliale = Foyer.CELIBATAIRE;
        int nombreEnfants = 0;
        int salaireMensuelPrincipal = 45000; // 540 000 EUR/an

        decimal resultat = Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                situationFamiliale,
                nombreEnfants,
                salaireMensuelPrincipal)
        );

        resultat.Should().Be(223508.56m);
    }

    [Fact(DisplayName = "Calcul des impôts affecté par le quotient familial pour les foyers avec enfants")]
    public void AppliquerTaxeAvecQuotientFamilial()
    {
        string situationFamiliale = Foyer.COUPLE;
        int salaireMensuelPrincipal = 30000;
        int salaireMensuelConjoint = 25000;
        int nombreEnfants = 2;

        decimal resultat = Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                situationFamiliale,
                nombreEnfants,
                salaireMensuelPrincipal,
                salaireMensuelConjoint)
        );

        resultat.Should().Be(234925.68m);
    }
}