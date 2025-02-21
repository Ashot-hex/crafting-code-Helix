using FluentAssertions;
using Tax.Simulator.Exceptions;

namespace Tax.Simulator.Tests.CalculsImpots;

public class ImpotsCoupleShould
{
    [Fact(DisplayName = "Calcul des impôts selon le salaire mensuel")]
    public void CalculSelonSalairePrincipal()
    {
        string situationFamiliale = "Marié/Pacsé";
        int salaireMensuelConjoint = 2500;
        int nombreEnfants = 0;

        int salaireMensuelPrincipal = 2000;
        decimal resultat = Simulateur.CalculerImpotsAnnuel(
            situationFamiliale,
            salaireMensuelPrincipal,
            salaireMensuelConjoint,
            nombreEnfants
        );
        resultat.Should().Be(4043.90m);

        salaireMensuelPrincipal = 0;
        Action action = () => Simulateur.CalculerImpotsAnnuel(
            situationFamiliale,
            salaireMensuelPrincipal,
            salaireMensuelConjoint,
            nombreEnfants
        );
        action.Should().Throw<SalaireNegatif>();

        salaireMensuelPrincipal = -2000;
        action = () => Simulateur.CalculerImpotsAnnuel(
            situationFamiliale,
            salaireMensuelPrincipal,
            salaireMensuelConjoint,
            nombreEnfants
        );

        action.Should().Throw<SalaireNegatif>();
    }

    [Fact(DisplayName = "Calcul des impôts selon le salaire mensuel du conjoint")]
    public void CalculSelonSalaireConjoint()
    {
        string situationFamiliale = "Marié/Pacsé";
        int salaireMensuelPrincipal = 2000;
        int nombreEnfants = 0;

        int salaireMensuelConjoint = 2500;
        decimal resultat = Simulateur.CalculerImpotsAnnuel(
            situationFamiliale,
            salaireMensuelPrincipal,
            salaireMensuelConjoint,
            nombreEnfants
        );
        resultat.Should().Be(4043.90m);

        salaireMensuelConjoint = -2000;
        Action action = () => Simulateur.CalculerImpotsAnnuel(
            situationFamiliale,
            salaireMensuelConjoint,
            salaireMensuelPrincipal,
            nombreEnfants
        );

        action.Should().Throw<SalaireNegatif>();
    }

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