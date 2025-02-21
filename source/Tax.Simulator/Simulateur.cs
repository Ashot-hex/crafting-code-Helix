using Tax.Simulator.Exceptions;

namespace Tax.Simulator;

public static class Simulateur
{
    private const int MOIS_PAR_ANNEE = 12; //Nombre de mois dans l'année

    private static readonly decimal[]
        TRANCHES_IMPOSITION = { 10225m, 26070m, 74545m, 160336m }; // Plafonds des tranches

    private static readonly decimal[] TAUX_IMPOSITION = { 0.0m, 0.11m, 0.30m, 0.41m, 0.45m }; // Taux correspondants

    public static decimal CalculerImpotsAnnuel(
        string situationFamiliale,
        decimal salaireMensuel,
        decimal salaireMensuelConjoint,
        int nombreEnfants
    )
    {
        if (situationFamiliale != "Célibataire" && situationFamiliale != "Marié/Pacsé")
        {
            throw new SituationFamilialeInvalide();
        }

        if (salaireMensuel <= 0)
        {
            throw new SalaireNegatif();
        }

        if (situationFamiliale == "Marié/Pacsé" && salaireMensuelConjoint < 0)
        {
            throw new SalaireNegatif();
        }

        if (nombreEnfants < 0)
        {
            throw new NombreEnfantsInvalide();
        }

        decimal revenuAnnuel;
        if (situationFamiliale == "Marié/Pacsé")
        {
            revenuAnnuel = (salaireMensuel + salaireMensuelConjoint) * MOIS_PAR_ANNEE;
        }
        else
        {
            revenuAnnuel = salaireMensuel * MOIS_PAR_ANNEE;
        }

        var baseQuotient = situationFamiliale == "Marié/Pacsé" ? 2 : 1;
        decimal quotientEnfants = 0m;

        if (nombreEnfants <= 2)
        {
            quotientEnfants = nombreEnfants / 2m;
        }
        else
        {
            quotientEnfants = 1.0m + (nombreEnfants - 2) * 0.5m;
        }

        var partsFiscales = baseQuotient + quotientEnfants;
        var revenuImposableParPart = revenuAnnuel / partsFiscales;

        decimal impot = 0;
        for (var i = 0; i < TRANCHES_IMPOSITION.Length; i++)
        {
            if (revenuImposableParPart <= TRANCHES_IMPOSITION[i])
            {
                impot += (revenuImposableParPart - (i > 0 ? TRANCHES_IMPOSITION[i - 1] : 0)) * TAUX_IMPOSITION[i];
                break;
            }

            impot += (TRANCHES_IMPOSITION[i] - (i > 0 ? TRANCHES_IMPOSITION[i - 1] : 0)) * TAUX_IMPOSITION[i];
        }

        if (revenuImposableParPart > TRANCHES_IMPOSITION[^1])
        {
            impot += (revenuImposableParPart - TRANCHES_IMPOSITION[^1]) * TAUX_IMPOSITION[^1];
        }

        return Math.Round(impot * partsFiscales, 2);
    }
}