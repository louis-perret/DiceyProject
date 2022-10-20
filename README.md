# DiceyProject

DiceyProject est un projet d'application permettant à l'utilisateur de faire des lancers de dés. Ainsi, il est possible d'utiliser des dés à plusieurs nombres de faces, en fonction de ce que l'utilisateur veut lancer, ainsi que plusieurs dés. (On pourra donc par exemple lancer 2 dés à 6 faces, 3 dés à 8 faces, ou 2 dés à 4 faces et un dé à 6 faces).

En plus de cela, l'utilisateur a la possibilité de créer un profil, qui lui permettra, en plus de s'authentifier dans l'application, de pouvoir avoir accès à l'historique de ses lancés. Ainsi, il pourra savoir s'il a eu une période particulièrement malchanceuse par exemple.

Aussi, des sessions sont présentes, afin de pouvoir garder l'historique des lancés de dés de plusieurs joueurs. Par exemple, lors d'une partie de jeu de rôle, afin de pouvoir se vanter de son nombre de succès critiques, ou bien trouver des excuses avec notre nombre d'échecs critique lors d'une session.

## Requirements

Afin de pouvoir build le projet, il faut utiliser le framework .NET en version 6.0.

Les NuGet que nous utilisons pour ce projet sont :

* EntityFramework afin de gérer la persistence dans les bases de données

* XUnit pour faire les tests unitaires

## Getting started

Afin de lancer notre application (pour l'instant uniquement disponible en mode console), il vous suffit de lancer la solution DiceyProject.sln, puis de générer et lancer l'assembly `FunctionalTest.csproj`

## Documentation

La documentation du projet, avec les sketchs et les différents diagrammes UML est disponible sur notre [wiki]((https://codefirst.iut.uca.fr/git/come.grienenberger/DiceyProject/wiki/Home)).

## Project Structure

Le projet est séparé en plusieurs assemblies afin de pouvoir gérer au mieux les dépendances, et éviter que par exemple, le modèle ait besoin des tests. Ce qui donne la structure suivante :


| Nom de l'assembly | Description | Dépendances |
| -------- | -------- | -------- |
| Modele | Ensemble des classes du modèle, avec à la fois les classes métier et les Managers | / |
| Persistance_Stub | Assembly comprenant des données métier entrées "en dur", modifiables uniquement par les développeurs | Modele |
| Persistance_EF | Assembly comprenant toutes les classes nécessaires à faire persister les classes métier en base de données, via EntityFramework | Modele, NuGet EntityFramework |
| FunctionalTest | Assembly comprenant les tests fonctionnels de l'application sous forme d'application console exécutable | Persistance_Stub, Persistance_EF, Modele|
| UT_Modele | Assembly de tests unitaires pour les classes du Modele | Modele, NuGet XUnit |
| UT_Persistance_EF | Assembly de tests unitaires pour les classes de Persitance_EF | Persistance_EF, NuGet XUnit |