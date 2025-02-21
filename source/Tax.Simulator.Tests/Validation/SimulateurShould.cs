using FluentAssertions;
using Tax.Simulator.Exceptions;

namespace Tax.Simulator.Tests.Validation;

public class SimulateurShould
{
    [Fact(DisplayName = "Situation familiale invalide")]
    public void SituationFamilialeInvalide()
    {
        Action action = () => Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                "Divorcé", // Invalide
                2,
                3000
            )
        );

        action.Should().Throw<SituationFamilialeInvalide>().WithMessage("Situation familiale invalide.");
    }

    [Fact(DisplayName = "Salaire mensuel négatif")]
    public void SalaireMensuelNegatif()
    {
        Action action = () => Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                Foyer.CELIBATAIRE,
                2,
                -3000
            )
        );

        action.Should().Throw<SalaireNegatif>().WithMessage("Les salaires doivent être positifs.");
    }

    [Fact(DisplayName = "Nombre enfants négatif")]
    public void NombreEnfantsNegatif()
    {
        Action action = () => Simulateur.CalculerImpotsAnnuel(
            new Foyer(
                Foyer.COUPLE,
                -2,
                3000,
                2000
            )
        );

        action.Should().Throw<NombreEnfantsInvalide>().WithMessage("Le nombre d'enfants ne peut pas être négatif.");
    }
}