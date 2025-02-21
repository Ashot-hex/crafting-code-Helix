using FluentAssertions;

namespace Tax.Simulator.Tests.Validation;

public class SimulateurShould
{
    [Fact(DisplayName = "Situation familiale invalide")]
    public void SituationFamilialeInvalide()
    {
        Action action = () => Simulateur.CalculerImpotsAnnuel(
            "Divorcé",
            3000,
            0,
            2
        );

        action.Should().Throw<ArgumentException>().WithMessage("Situation familiale invalide.");
    }

    [Fact(DisplayName = "Salaire mensuel négatif")]
    public void SalaireMensuelNegatif()
    {
        Action action = () => Simulateur.CalculerImpotsAnnuel(
            "Célibataire",
            -3000,
            0,
            2
        );

        action.Should().Throw<ArgumentException>().WithMessage("Les salaires doivent être positifs.");
    }

    [Fact(DisplayName = "Nombre enfants négatif")]
    public void NombreEnfantsNegatif()
    {
        Action action = () => Simulateur.CalculerImpotsAnnuel(
            "Marié/Pacsé",
            3000,
            2000,
            -2
        );

        action.Should().Throw<ArgumentException>().WithMessage("Le nombre d'enfants ne peut pas être négatif.");
    }
}