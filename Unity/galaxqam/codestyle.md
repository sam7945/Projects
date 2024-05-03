# Conventions de codage du projet

Tout le code sera écrit en **Anglais**. Les commentaires peuvent être écris en français afin de facilité la compréhension. 

## Conventions de nommage

Tous les objects et les scripts doivent avoir un nom anglais **significatif**. Ne pas utiliser d'acronymes ou d'abriéviation imcompréhensible du genre ``lp`` pour indiquer ``life point`` utilisez plutôt ``lifePoints``.

### Pascal Case

Utilisez le PascalCasing  lors du nommage des ``scripts``, ``objects`` et ``fonctions``

### Camel Case

Utilisez le camelCasing lors du nommage des ``variables`` interne des scripts.

## Conventions de disposition

Une bonne disposition utilise la mise en forme pour souligner la structure de votre code et en faciliter la lecture. Les exemples Microsoft et autres se conforment aux conventions suivantes :

- Utilisez les paramètres par défaut de l'éditeur de code (retrait intelligent, retrait de quatre caractères, tabulations enregistrées en tant qu'espaces). Pour plus d’informations, consultez Options, Éditeur de texte, C#, Mise en forme.

- Écrivez une seule instruction par ligne.

- Écrivez une seule déclaration par ligne.

- Si les lignes de continuation ne sont pas mises en retrait automatiquement, indentez-les à l'aide d'un taquet de tabulation (quatre espaces).

- Ajoutez au moins une ligne blanche entre les définitions des méthodes et les définitions des propriétés.

- Utilisez des parenthèses pour rendre apparentes les clauses d'une expression, comme illustré dans le code suivant.


```c#
if ((val1 > val2) && (val1 > val3))
{
    // Take appropriate action.
}
```

## Conventions de commentaire

- Placez le commentaire sur une ligne séparée, pas à la fin d'une ligne de code.

- Commencez le commentaire par une lettre majuscule.

- Terminez le texte de commentaire par un point.

- Insérez un espace entre le délimiteur de commentaire (//) et le texte du commentaire, comme illustré dans l'exemple suivant.

```C#
// The following declaration creates a query. It does not run
// the query.

```

- Ne créez pas de blocs mis en forme d’astérisque autour des commentaires.

- Assurez-vous que tous les membres publics ont les commentaires XML nécessaires pour fournir des descriptions appropriées sur leur comportement.

*** _tous les exemples et les normes proviennent du site de microsoft https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/coding-style/coding-conventions_ ***