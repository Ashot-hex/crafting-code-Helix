using FluentAssertions;

namespace Tax.Simulator.Tests.Validation;

public class FoyerShould
{
    [Fact]
    public void CalculPartsFiscalesCelibataire()
    {
        Foyer f;
        f = new Foyer("Célibataire", 0, 1000, 1000);
        f.PartsFiscales.Should().Be(1);
        f = new Foyer("Célibataire", 1, 1000, 1000);
        f.PartsFiscales.Should().Be(1.5m);
        f = new Foyer("Célibataire", 2, 1000, 1000);
        f.PartsFiscales.Should().Be(2);
        f = new Foyer("Célibataire", 3, 1000, 1000);
        f.PartsFiscales.Should().Be(2.5m);
        f = new Foyer("Célibataire", 4, 1000, 1000);
        f.PartsFiscales.Should().Be(3);
        f = new Foyer("Célibataire", 5, 1000, 1000);
        f.PartsFiscales.Should().Be(3.5m);
    }

    [Fact]
    public void CalculPartsFiscalesCouple()
    {
        Foyer f;

        f = new Foyer("Marié/Pacsé", 0, 1000, 1000);
        f.PartsFiscales.Should().Be(2);
        f = new Foyer("Marié/Pacsé", 1, 1000, 1000);
        f.PartsFiscales.Should().Be(2.5m);
        f = new Foyer("Marié/Pacsé", 2, 1000, 1000);
        f.PartsFiscales.Should().Be(3);
        f = new Foyer("Marié/Pacsé", 3, 1000, 1000);
        f.PartsFiscales.Should().Be(3.5m);
        f = new Foyer("Marié/Pacsé", 4, 1000, 1000);
        f.PartsFiscales.Should().Be(4);
        f = new Foyer("Marié/Pacsé", 5, 1000, 1000);
        f.PartsFiscales.Should().Be(4.5m);
    }

    [Fact]
    public void ConstuctionEtValidation()
    {
        string situationValide = "Marié/Pacsé";
        string situationInvalide = "Invalide";

        int nbEnfantsValide = 1;
        int nbEnfantsInvalide = -3;

        decimal salaireValide = 1500m;
        decimal salaireInvalide = -1500m;

        Action validTestCase = () => new Foyer(situationValide, nbEnfantsValide, salaireValide, salaireValide);
        Action[] testCases =
        {
            () => new Foyer(situationInvalide, nbEnfantsValide, salaireValide, salaireValide),
            () => new Foyer(situationValide, nbEnfantsInvalide, salaireValide, salaireValide),
            () => new Foyer(situationInvalide, nbEnfantsInvalide, salaireValide, salaireValide),
            () => new Foyer(situationValide, nbEnfantsValide, salaireInvalide, salaireValide),
            () => new Foyer(situationInvalide, nbEnfantsValide, salaireInvalide, salaireValide),
            () => new Foyer(situationInvalide, nbEnfantsInvalide, salaireInvalide, salaireValide),
            () => new Foyer(situationValide, nbEnfantsValide, salaireValide, salaireInvalide),
            () => new Foyer(situationInvalide, nbEnfantsValide, salaireValide, salaireInvalide),
            () => new Foyer(situationInvalide, nbEnfantsInvalide, salaireValide, salaireInvalide),
            () => new Foyer(situationInvalide, nbEnfantsInvalide, salaireInvalide, salaireInvalide)
        };

        foreach (Action action in testCases)
        {
            action.Should().Throw<ArgumentException>();
        }

        validTestCase.Should().NotThrow();
    }

    [Fact]
    public void CalculSalaireMensuelTotal()
    {
        string situationFamiliale = "Marié/Pacsé";
        int nombreEnfants = 0;

        Foyer f;

        f = new Foyer(situationFamiliale, nombreEnfants, 1000, 1000);
        f.SalaireMensuelTotal.Should().Be(2000);

        f = new Foyer(situationFamiliale, nombreEnfants, 2000, 1000);
        f.SalaireMensuelTotal.Should().Be(3000);

        f = new Foyer(situationFamiliale, nombreEnfants, 1000, 2500);
        f.SalaireMensuelTotal.Should().Be(3500);
    }
}