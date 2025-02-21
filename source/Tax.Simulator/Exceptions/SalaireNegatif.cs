namespace Tax.Simulator.Exceptions;

/// <summary>
/// Exception levée quand un salaire fournit est négatif
/// </summary>
public class SalaireNegatif() : Exception("Les salaires doivent être positifs.");