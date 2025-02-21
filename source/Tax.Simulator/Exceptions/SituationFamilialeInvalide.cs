namespace Tax.Simulator.Exceptions;

/// <summary>
/// Exception levée quand on rencontre une situation familiale invalide pour le calcul
/// </summary>
public class SituationFamilialeInvalide() : ArgumentException("Situation Familiale Invalide.");