namespace Tax.Simulator.Exceptions;

/// <summary>
/// Exception levée quand un salaire fournit est négatif
/// </summary>
public class SalaireNegatif() : ArgumentException("Les salaires doivent être positifs.");