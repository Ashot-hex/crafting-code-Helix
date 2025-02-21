using FluentAssertions;
using Tax.Simulator.Exceptions;

namespace Tax.Simulator.Tests.CalculsImpots;

public class ImpotsEnfantsACharge
{
    [Fact(DisplayName = "Calcul des impôts selon le nombre d'enfants à charge")]
    public void CalculSelonNombreEnfants()
    {
        string situationFamiliale = "Marié/Pacsé";
        int salaireMensuelPrincipal = 2000;
        int salaireMensuelConjoint = 2500;
        int nombreEnfants = 0;
        decimal resultat = Simulateur.CalculerImpotsAnnuel(
            situationFamiliale,
            salaireMensuelPrincipal,
            salaireMensuelConjoint,
            nombreEnfants
        );
        resultat.Should().Be(4043.90m);

        nombreEnfants = 5;
        resultat = Simulateur.CalculerImpotsAnnuel(
            situationFamiliale,
            salaireMensuelPrincipal,
            salaireMensuelConjoint,
            nombreEnfants
        );
        resultat.Should().Be(878.62m);

        nombreEnfants = -2;
        Action action = () => Simulateur.CalculerImpotsAnnuel(
            situationFamiliale,
            salaireMensuelConjoint,
            salaireMensuelPrincipal,
            nombreEnfants
        );

        action.Should().Throw<NombreEnfantsInvalide>();
    }
}