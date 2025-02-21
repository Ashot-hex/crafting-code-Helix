using FluentAssertions;
using Tax.Simulator.Exceptions;

namespace Tax.Simulator.Tests.CalculsImpots;

public class ImpotsCelibataireShould
{
    private const string situationFamiliale = "Célibataire";
    private const int salaireMensuelConjoint = 0;

    [Fact(DisplayName = "Calcul des impôts selon le salaire mensuel")]
    public void CalculSelonSalaire()
    {
        int nombreEnfants = 0;

        int salaireMensuelPrincipal = 2000;
        decimal resultat = Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                situationFamiliale,
                nombreEnfants,
                salaireMensuelPrincipal
            )
        );
        resultat.Should().Be(1515.25m);

        salaireMensuelPrincipal = 0;
        Action action = () => Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                situationFamiliale,
                nombreEnfants,
                salaireMensuelPrincipal
            )
        );
        action.Should().Throw<SalaireNegatif>();

        salaireMensuelPrincipal = -2000;
        action = () => Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                situationFamiliale,
                nombreEnfants,
                salaireMensuelPrincipal
            )
        );

        action.Should().Throw<SalaireNegatif>();
    }

    [Fact(DisplayName = "Calcul des impôts selon le nombre d'enfants à charge")]
    public void CalculSelonNombreEnfants()
    {
        int salaireMensuelPrincipal = 2000;

        int nombreEnfants = 0;
        decimal resultat = Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                situationFamiliale,
                nombreEnfants,
                salaireMensuelPrincipal
            )
        );
        resultat.Should().Be(1515.25m);

        nombreEnfants = 1;
        resultat = Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                situationFamiliale,
                nombreEnfants,
                salaireMensuelPrincipal
            )
        );
        resultat.Should().Be(952.88m);

        nombreEnfants = -2;
        Action action = () => Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                situationFamiliale,
                nombreEnfants,
                salaireMensuelPrincipal
            )
        );

        action.Should().Throw<NombreEnfantsInvalide>();
    }
}