## Backlog
### **User Story 1: Calcul de l'impôt pour un célibataire** ✅
**En tant que** contribuable célibataire,  
**Je veux** calculer l'impôt sur mon revenu annuel basé sur les tranches d'imposition,  
**Afin de** comprendre combien je dois payer.

#### Critères d'acceptation :
- Le système doit accepter un salaire mensuel comme entrée.
- Le système doit multiplier le salaire mensuel par 12 pour obtenir le revenu annuel.
- L'impôt doit être calculé en appliquant les taux d'imposition par tranche.
- L'impôt total doit être retourné avec une précision de deux décimales.

#### Cas de test :
- **Entrée valide :**  
  - Situation familiale : "Célibataire"  
  - Salaire mensuel : 2000 EUR  
  - Résultat attendu : 1515,25 EUR
- **Entrée invalide :**  
  - Salaire mensuel : -2000 EUR  
  - Erreur attendue : "Les salaires doivent être positifs."

---

### **User Story 2: Calcul de l'impôt pour un couple marié ou pacsé** ✅
**En tant que** contribuable marié ou pacsé,  
**Je veux** inclure les revenus de mon conjoint dans le calcul des impôts,  
**Afin de** calculer notre impôt total en tenant compte de notre situation familiale.

#### Critères d'acceptation :
- Le système doit accepter les salaires mensuels des deux conjoints.
- Les revenus annuels des deux conjoints doivent être additionnés.
- Le quotient familial doit être calculé correctement pour un couple.
- L'impôt doit être réparti sur les parts fiscales.

#### Cas de test :
- **Entrée valide :**  
  - Situation familiale : "Marié/Pacsé"  
  - Salaire mensuel conjoint : 2500 EUR  
  - Salaire mensuel principal : 2000 EUR  
  - Nombre d'enfants : 0  
  - Résultat attendu : 4043,90 EUR
- **Entrée invalide :**  
  - Salaire mensuel conjoint : -2500 EUR  
  - Erreur attendue : "Les salaires doivent être positifs."

---

### **User Story 3: Prise en compte des enfants dans le quotient familial** ✅
**En tant que** contribuable ayant des enfants à charge,  
**Je veux** inclure les parts fiscales supplémentaires apportées par mes enfants,  
**Afin de** réduire l'impôt calculé.

#### Critères d'acceptation :
- Le système doit calculer les parts fiscales en ajoutant 0,5 part pour chaque enfant jusqu'à 2 enfants, et 1 part supplémentaire pour chaque enfant au-delà.
- Les parts fiscales doivent être utilisées pour diviser le revenu imposable.
- Le système doit appliquer correctement les tranches d'imposition après division.

#### Cas de test :
- **Entrée valide :**  
  - Situation familiale : "Marié/Pacsé"  
  - Salaire mensuel principal : 3000 EUR  
  - Salaire mensuel conjoint : 3000 EUR  
  - Nombre d'enfants : 3  
  - Résultat attendu : 3983,37 EUR
- **Entrée invalide :**  
  - Nombre d'enfants : -1  
  - Erreur attendue : "Le nombre d'enfants ne peut pas être négatif."

---

### **User Story 4: Validation des entrées utilisateur** ✅
**En tant que** utilisateur,  
**Je veux** recevoir une erreur claire lorsque je fournis des informations invalides,  
**Afin de** m'assurer que le calcul de l'impôt est basé sur des données correctes.

#### Critères d'acceptation :
- Le système doit rejeter une situation familiale autre que "Célibataire" ou "Marié/Pacsé".
- Le système doit rejeter un salaire mensuel négatif ou nul.
- Le système doit rejeter un nombre négatif d'enfants.

#### Cas de test :
- Situation familiale invalide : "Divorcé" -> Erreur attendue : "Situation familiale invalide."
- Salaire mensuel négatif : -3000 EUR -> Erreur attendue : "Les salaires doivent être positifs."
- Nombre d'enfants négatif : -1 -> Erreur attendue : "Le nombre d'enfants ne peut pas être négatif."

### Exemples
| Situation familiale | Salaire mensuel principal | Salaire mensuel conjoint | Nombre d'enfants | Résultat attendu    |
|----------------------|---------------------------|---------------------------|-------------------|---------------------|
| Célibataire          | 2000 EUR                 | 0 EUR                     | 0                 | 1515,25 EUR         |
| Célibataire          | 5000 EUR                 | 0 EUR                     | 2                 | 5843,9 EUR          |
| Marié/Pacsé          | 2000 EUR                 | 2500 EUR                  | 0                 | 4043,90 EUR         |
| Marié/Pacsé          | 3000 EUR                 | 3000 EUR                  | 3                 | 3983,37 EUR         |
| Marié/Pacsé          | 4000 EUR                 | 4000 EUR                  | 5                 | 5498,62 EUR         |
| Marié/Pacsé          | 8000 EUR                 | 2000 EUR                  | 1                 | 20804,88 EUR        |
| Marié/Pacsé          | 2000000 EUR              | 10000 EUR                 | 3                 | 10781579,96 EUR     |
| Célibataire          | 1978123,98 EUR           | 0 EUR                     | 0                 | 10661178,05 EUR     |
