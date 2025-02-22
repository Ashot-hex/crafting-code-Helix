﻿namespace Tax.Simulator.Exceptions;

/// <summary>
/// Exception levée quand on rencontre un nombre d'enfants invalide pour le calcul
/// </summary>
public class NombreEnfantsInvalide() : ArgumentException("Le nombre d'enfants ne peut pas être négatif.");