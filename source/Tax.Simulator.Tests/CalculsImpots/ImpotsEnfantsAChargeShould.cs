using FluentAssertions;
using Tax.Simulator.Exceptions;

namespace Tax.Simulator.Tests.CalculsImpots;

public class ImpotsEnfantsAChargeShould
{
    [Fact(DisplayName = "Calcul des impôts selon le nombre d'enfants à charge")]
    public void CalculSelonNombreEnfants()
    {
        string situationFamiliale = Foyer.COUPLE;
        int salaireMensuelPrincipal = 2000;
        int salaireMensuelConjoint = 2500;
        int nombreEnfants = 0;
        decimal resultat = Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                situationFamiliale,
                nombreEnfants,
                salaireMensuelPrincipal,
                salaireMensuelConjoint
            )
        );
        resultat.Should().Be(4043.90m);

        nombreEnfants = 5;
        resultat = Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                situationFamiliale,
                nombreEnfants,
                salaireMensuelPrincipal,
                salaireMensuelConjoint
            )
        );
        resultat.Should().Be(878.62m);

        nombreEnfants = -2;
        Action action = () => Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                situationFamiliale,
                nombreEnfants,
                salaireMensuelConjoint,
                salaireMensuelPrincipal
            )
        );

        action.Should().Throw<NombreEnfantsInvalide>();
    }
}