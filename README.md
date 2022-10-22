![DiceyProject Banner](./images/Banner.jpg)

[![Build Status](https://codefirst.iut.uca.fr/api/badges/come.grienenberger/DiceyProject/status.svg)](https://codefirst.iut.uca.fr/come.grienenberger/DiceyProject)

# DiceyProject

| [Introduction](#introduction) | [Requirements](#requirements) | [Getting started](#getting-started) | [Where are we now ?](#where-are-we-now) | [Roadmap](#roadmap) | [Running the tests](#running-the-tests) | [Documentation](#documentation) | [Project structure](#project-structure) | [Contributors](#contributors) | 

## Introduction

DiceyProject est un projet d'application permettant à l'utilisateur de faire des lancers de dés. Ainsi, il est possible d'utiliser des dés à plusieurs nombres de faces, en fonction de ce que l'utilisateur veut lancer, ainsi que plusieurs dés. (On pourra donc par exemple lancer 2 dés à 6 faces, 3 dés à 8 faces, ou 2 dés à 4 faces et un dé à 6 faces).

En plus de cela, l'utilisateur a la possibilité de créer un profil, qui lui permettra, en plus de s'authentifier dans l'application, de pouvoir avoir accès à l'historique de ses lancés. Ainsi, il pourra savoir s'il a eu une période particulièrement malchanceuse par exemple.

Aussi, des sessions sont présentes, afin de pouvoir garder l'historique des lancés de dés de plusieurs joueurs. Par exemple, lors d'une partie de jeu de rôle, afin de pouvoir se vanter de son nombre de succès critiques, ou bien trouver des excuses avec notre nombre d'échecs critique lors d'une session.

---

## Requirements

Afin de pouvoir build le projet, il faut utiliser le framework .NET en version 6.0.

Les NuGet que nous utilisons pour ce projet sont :

* EntityFramework afin de gérer la persistence dans les bases de données

* XUnit pour faire les tests unitaires


---

## Getting started

Afin de lancer notre application (pour l'instant uniquement disponible en mode console), il vous suffit de lancer la solution DiceyProject.sln, puis de générer et lancer l'assembly `FunctionalTest.csproj`

---

## Where are we now?

✅ Le **Modèle** qui permet de représenter les **Profils**, **Dés** et **Lancés**

✅ Les **Tests unitaires** sur le **Modèle**

✅ **Persistance** du **Modèle** avec **EntityFramework**

✅ **Logs** de l'application

🔜 **Tests fonctionnels** sur le **Modèle** 

🔜 **Application console**

🔜 **Tests unitaire** complets sur toute la partie **EntityFramework**

---

## Roadmap

* Court terme : Fin de toute la partie *console* de l'application, avec **Modèle** et **Persistance** entièrement testés, et ajout d'une **Application console**

* Long terme : Création d'une **Web Api** afin de pouvoir faire fonctionner l'application avec un serveur, puis création d'une **Application Mobile** utilisant **Xamarin** qui utilise notre **Modèle**. 

---

## Running the tests

Les tests sont séparés dans plusieurs **Assembly**. Ainsi, voici ceux à exécuter en fonction de ce que vous voulez tester :
* UT_Modele : Tests unitaires sur le **Modèle** de l'application, qui testent les **Classes métier** et leurs logique, ainsi que les **Managers**

* UT_Persistance_EF : Tests unitaires sur la partie **EntityFramework**, vérifient que la **Persistance** des données est bien fonctionnelle en **Base de données**

* Functionnal_Tests : Tests fonctionnels sur l'entièreté de l'application, servant aussi d'application console.

---
## Documentation

La documentation du projet, avec les sketchs et les différents diagrammes UML est disponible sur notre **[wiki](https://codefirst.iut.uca.fr/git/come.grienenberger/DiceyProject/wiki/Home)**.

De plus, la documentation complète des classes peut être trouvée sur notre documentation **[Doxygen](https://codefirst.iut.uca.fr/documentation/come.grienenberger/doxygen/DiceyProject/html/)**.

---

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

---

## Contributors 

Grienenberger Come, groupe PM B3

Malvezin Neitah, groupe PM B3

Perret Louis, groupe PM A1