# Document de design de GALAXQAM

Ce document de design présente la vision générale du jeu **Galaxqam** par l'équipe **SpecialOps6150**.

## Table des matières
- [Contexte](#contexte)
- [Inspiration](#inspiration)
- [Description](#description)
- [Écran titre](#titre)
- [Menus](#menu)
  * [Menu d'accueil](#menu_accueil)
  * [Menu de partie](#menu_partie)
  * [Menu des options](#menu_option)
  * [Menu de mort](#menu_mort)
  * [Menu des upgrades](#menu_upgrade)
- [But du jeu](#but)
- [Mécanique du jeu](#mecanique)
- [Environnement visuel](#visuel)
- [Environnement sonore](#son)
  * [Vaisseau principal](#son_vaisseau)
  * [Armes](#son_armes)
  * [Musique](#musique)
- [Éléments du jeu](#element)
  * [Décors](#decor)
  * [Vaisseau principal](#vaisseau)
    * [Vaisseau d'attaque](#vaisseau_attaque)
    * [Vaisseau rapide](#vaisseau_rapide)  
    * [Vaisseau armure](#vaisseau_armure)
    * [Contrôles](#vaisseau_controle)
    * [Attributs généraux](#vaisseau_attribut)  
      * [Armes](#vaisseau_arme)  
      * [Points de vie](#vaisseau_hp)  
      * [Powerups](#vaisseau_powerup)  
      * [Déplacements](#vaisseau_deplacement)  
  * [Ennemis](#ennemi)
    * [Styles généraux](#ennemi_style) 
    * [Attributs généraux](#ennemi_attribut)  
      * [Points de vie](#ennemi_hp)  
      * [Déplacements](#ennemi_deplacement) 
  * [Types de capsules](#capsule)
    * [Capsules de munitions](#capsule_munition)
    * [Capsules de Power Up](#capsule_powerup)
  * [Modes de jeu](#mode_jeu)
    * [Classique](#mode_classique)  
    * [Survie](#mode_survie)    
    * [Game master](#mode_gm)
  * [Sauvegarde](#sauvegarde)

## <a name='contexte'></a> Contexte

Notre projet de session consiste en la création d'un jeu vidéo où l'on pourra exercer les concepts liés à la conduite de projets informatiques. Nous avons choisis de revisiter les jeux vidéo classiques en proposant une approche plus moderne. Notre client, Éric Lavallée, est aussi un passionné de [Unity](https://unity.com/) et se propose gracieusement comme concepteur graphique et guide spirituel, en plus de son rôle de client. En effet, cela sera une initiation pour nous, la plupart des membres de notre équipe n'ayant jamais osés s'aventurer dans le monde du jeu vidéo. 
La programmation, bien sur, sera faite par nous, et le langage de programmation sélectionné est le [C#](https://fr.wikipedia.org/wiki/C_sharp).

## <a name='inspiration'></a> Inspiration

Les jeux d'arcade des années 80, l'âge d'or de telle machine, a vu son lot de
jeux qui sont restés dans l'imaginaire collectif. Bien inscrits dans la culture
populaire, des jeux comme "Ms. PacMan", "Donkey Kong" et "Centipedes", n'ont
pas besoin de présentation ni d'explication, même pour les plus jeunes, qui sont
nés bien après leur popularité.

C'est ce qui nous a de cet esprit que tire l'inspiration pour le jeu "**Galaxquam**" en plus
d'être directement inspiré d'autres jeux populaires de cette époque. Galaxian,
Galaga et Space invaders sont les principales sources de références pour la
conception de "Galaxqam".

Bien sûr, la culture populaire des films et téléséries de science-fiction de cette époque 
sont aussi des points d'appuis pour la création de ce jeu. Nous pouvons bien sûr penser à:
- Star Wars;
- Star Treck;
- Battlestar Galactica (première mouture);
- 2001, odyssée de l'espace.

Pour ne nommer que ceux-là.

[Space Invaders](https://fr.wikipedia.org/wiki/Space_Invaders) a conquis le monde en 1978, et est vu comme l'aïeul des jeux vidéo de type shoot'em up en deux dimensions. [Galaxian](https://fr.wikipedia.org/wiki/Galaxian) a suivi en 1979 avec des déplacements plus complexes et des graphiques améliorés. Il a même eu une suite en 1981 sous le nom de [Galaga](https://fr.wikipedia.org/wiki/Galaga).

## <a name='description'></a> Description du jeu

Vous êtes Capitaine Kirk "Yoda" Picard, défendeur d'une plateforme de 200 pieds
par 10, qui doit protéger cette plateforme à tout prix, devant des envahisseurs
incessants, bien déterminés à prendre possession du dernier espace plat de l'univers.

Pour effectuer votre mission, vous avez un vaisseau, des armes et votre agilité.
Vous aurez besoin d'être agressif, stratégique et surtout n'avoir pas de gros
standards de beauté puisque ce monde est extrêmement cubique et minimaliste.

En traversant les niveaux, vous pourrez améliorer vos armes, votre armure ou
votre agilité, dépendant de votre style de jeu.

**Galaxqam** est un clin d'oeil rempli de poussière d'étoile à tout le merveilleux
monde de la science-fiction des années 80.

## <a name='titre'></a> Écran titre (splash screen)

Un écran d'accueil qui s'affiche au début de la partie présente le titre, et
une perspective "artistique" du jeu. L'affichage dure 4 secondes environ (très
courts). 

## <a name='menu'></a> Les différents menus

### <a name='menu_accueil'></a> Menu d'accueil

- On pourrait faire un clin d'oeil aux arcades en pouvant appuyer sur un bouton
    pour mettre des "crédits"

- Une option départ permet de démarrer une partie mode normale du jeu

    * Niveau de difficulté (Nice to have)
        * Facile
            - Nombre/Rapidité/Dommage des tirs des ennemis sont moindres
        * Intermédiaire
            - Nombre/Rapidité/Dommage des tirs des ennemis sont moyens (niveau normal)
        * Expert
            - Nombre/Rapidité/Dommage des tirs des ennemis sont plus élevés que les deux autres modes

    * Modes de jeu
        - Mode classique
        - Mode survie
        - Mode panneau de contrôle

- Une option "paramètres" permettrait de fixer certains paramètres de la partie
    (ce qui est au fond notre mode débug et de balancement de la partie). Dans
    ce sous-menu, vous pouvez modifier l'ensemble des caractéristiques du
    vaisseau)
    - Paramètres sonores *en effet, bonne idée (balance pour musique et effets
        sonores)*
    - Consulter (et Modifier?) des commandes du jeu pour effectuer certaines actions (tirs, déplacement..etc) *zapping des commandes? vraiment si on a le temps*

Comme mentionné, le menu d'arrivé c'est les crédits un peu à la Star wars ensuite on peut appuyer sur démarrer.

On a un bouton pour aller au menu des caractéristiques/Aptitudes qu'on peut augmenter avec des points ramasser dans les niveaux. *Menu de création du personnage? ok.*

On a un bouton pour démarrer une partie.
Assumons pour le moment que l'on commence une nouvelle partie:

On a le choix entre 3 vaisseaux:

- 1 avec plus de vie
- 1 avec plus d'attaques
- 1 avec plus de rapidité


### <a name='menu_partie'></a> Menu de partie (Menu de pause durant une partie)
Accéder au menu : Touche Escape
Chaque jeu doit évidemment avoir l'option de faire pause. Le menu de pause pourrait avoir ces fonctionnalités: *en effet, bon point.*
- Continuer : résumer la partie *oui*
- Recommencer : recommencer la partie au début du niveau *oui*
- Sauvegarder : Nice to have (non prioritaire)
- Options (mêmes options que pour le menu principal) *une référence pour le menu
    option? Donc un autre menu..."
- Quitter partie : nous redirige vers le menu principal 

### <a name='menu_option'></a> Menu Option

Le menu option contient toutes les options de son, de contrôle et de graphique. 
On y accède par le menu principal et le menu de pause.

- Sons
    - volume effets sonores
    - volume musique
- Gameplay
    - Invincibilité
    - Déplacements
        - Translation
        - Forces *Oui, je veux avoir l'options des forces!*
- Contrôles
   - Peut-être mapping des déplacements? (Nice to have)

### <a name='menu_mort'></a> Menu de mort

Apparition d'un message indiquant l'échec du niveau, puis on demande au joueur s'il veut recommencer le niveau ou quitter.

### <a name='menu_upgrade'></a> Menu de choix d'upgrade

À chaque tableau réussit, le joueurs pourrait avoir à choisir quel attribut
augmenter sur son vaisseau. C'est avec ce menu que le joueur fait ce choix.

## <a name='mecanique'></a> Mécanique de jeu

TODO: décrire la mécanique de jeu (encore une fois, gardez ça pour la fin). La
"mécanique de jeu" est le meilleur terme que l'on a trouvé pour englober les
concepts de:

- Comment le jeu se joue;
- quel est le but du jeu;
- quelle est l'atmosphère générale de l'expérience de jeu;
- quels sont les contrôles et options;
- comment les ennemis réagissent à nos actions;
- etc.

## <a name='but'></a> But du jeu

Le but du jeu est de terminer tous les niveaux et de vaincre le boss, ou d'améliorer son pointage 
avec des combos d'attaques payants.

## <a name='visuel'></a> Environnement visuel

Le jeu est dans un environnement 3D avec un plan de vue latéral. Deux caméras
sont disponibles, la première prend l'ensemble de la scène et la deuxième place
le joueur dans le cockpit du vaisseau. L'utilisation d'une scène de type
parallaxe est envisagée. La projection 3D est de type orthogonal donc il n'y a
pas de perspective visible.

![Texte alternatif](/Images/vue-cockpit.JPG)

## <a name='sonore'></a> Environnement sonore

Musique électronique style CastleVania, mais plus "Spacy"
[Soundtrack CastleVania](https://www.youtube.com/watch?v=p5dPKJyDfF0&ab_channel=ragnarok_boi)

Pour moi, l'apothéose musicale des jeux du genre est "master of monsters". Une de
mes pistes sonores favorites du jeu est celle-ci. Je vous invite à écouter le
reste pour inspiration. 
[Master of monster - soundtrack](https://youtu.be/3kqCzCACtkw?t=376)

Sinon en voici d'autres:
[Contra nes](https://youtu.be/2mWZlNOzdv8?t=577)
[Metroid](https://www.youtube.com/watch?v=FnmtWx-fQOM)
[Megaman](https://www.youtube.com/watch?v=hkD3lEANa_4)

C'est suffisant pour démontrer l'esprit. 

@Osvaldo Laisse nous savoir comment tu verrais ca, comme c'est toi le chef
d'orchestre! 

### <a name='son_vaisseau'></a> Vaisseau du joueur

- Le vaisseau du joueur se déplace à l'horizontal, à une vitesse normale et plus lentement/rapidement 
dépendant du niveau de difficulté ou de capsules spéciales. 
- Le vaisseau du joueur a des points de vie, qu'il perd à chaque tir ennemi touché et chaque impact avec un autre vaisseau 
et qu'il peut regagner avec des capsules de vie bonus. 
- Le joueur peut tirer à volonté, en appuyant sur une touche, et des armes différentes sont disponibles et sont rechargeables
via des capsules d'énergie ou d'explosion. 
- Si le vaisseau perd toute sa vie, il explose, ce qui change sa représentation visuelle et un son dramatique marque sa mort.

### <a name='son_arme'></a> Armes

- court laser
- long laser
- rayon gamma
- machine gun
- lance grenade
- mini bombe nucléaire

### <a name='musique'></a> Musique

Les musiques peuvent aussi être simplement une ambiance sonore, une
représentation de l'univers sonore dans l'espace de manière fantaisiste. 

Les musiques devront avoir la capacité de faire des loops "seemless"
La musique pourrait s'accélérer progressivement au fur et à mesure que l'on avance sur la map et que la difficulté augmente

- Trame sonore ou ambiance pour les menus
- Trame sonore ou ambiance pour les jeux en soi
- Trame sonore ou ambiance pour le menu d'upgrade

## <a name='element'></a> Éléments de jeu

### <a name='decor'></a> Décors

Le menu principal ainsi que le menu de pause devrait avoir le même décor (background) avec un thème galactique (fond foncé/ciel étoilé) et des couleurs claires pour le texte afin d'assurer la visibilité des fonctionalités du menu.
Les décors (en background) pourraient avoir différent thèmes galactiques selon les niveaux, avec des couleurs différentes, voici des exemples de fonds de décors:

<img src="/Images/decor1.png" width=225 />
<img src="/Images/decor2.jpg" width=225 />
<img src="/Images/decor3.jpg" width=225 />
<img src="/Images/decor4.jpg" width=175 />

En ce qu'il en est du style (physique) des vaisseaux (joueur et ennemis) il serait possible de leur changer de couleur selon le niveau aussi.

### <a name='vaisseau'></a> Vaisseaux

#### <a name='vaisseau_attaque'></a>Vaisseau d'attaque

Ce vaisseau ferait plus de dommage avec ses projectiles que les autres vaisseaux. Il pourrait pouvoir équiper plus d'armes, etc.

<img src="/Images/Vaisseau-attaque.JPG" width=225 />

#### <a name='vaisseau_rapide'> Vaisseau rapide

Ce vaisseau serait significativement plus rapide que les deux autres. Il pourrait avoir une habilité de se téléporter (voyager dans le temps et l'espace ;).

<img src="/Images/Vaisseau-Rapide.JPG" width=225 />

#### <a name='vaisseau_armure'></a> Vaisseau Armure

Ce vaisseau serait plus lent que les deux autres, mais serait significativement plus résistant aux projectiles ennemis.

<img src="/Images/Vaisseau-Armure.JPG" width=225 />

Plusieurs modèles Blender sont gratuits sur ce [site](https://www.turbosquid.com/3d-models/3d-model-fighter-02-asterius-1805613).

#### <a name='vaisseau_controle'></a> Contrôles

Des mouvements simples frame par frame. Utilisation simple des touches Q,W,E,A,S,D si on utilise la vision cockpit.

Si on y va plus vers un style 3D vue par le haut du style Diablo 3. Je propose W,A,S,D seulement.

Changement d'armes avec les touches 1,2,3,4,5,6,7,8,9

Le vaisseau attaque sans arrêt. Possibilité d'activer un PowerUp avec la touche SPACE BAR!!!
(Autre possibilité : le vaisseau attaque seulement lorsqu'on appuie sur space. Permet de mieux "viser" ses tirs sur les ennemis)

#### <a name='vaisseau_attribut'></a> Attributs généraux

##### <a name='vaisseau_arme'></a> Armes

Comment acquérir une arme? sont-ils situés a certains endroits dans des niveaux du jeu ou ils sont acquéris comme récompense
lors de l'achèvement d'un certain niveau?
- Fusil Laser
- Lames ou objets en orbite autour du vaisseau
- Lance-roquette
- Lance feu d'artifice (explosions)
- Mines qui peuvent être lancées du vaisseau et qui explose au contact d'un ennemi

#### <a name='vaisseau_hp'></a> Points de vie

Le vaisseau peut avoir une barre de vie pour indiquer son niveau de vitalité, lorsque cette barre est à vide, on peut
considérer que le vaisseau est vaincu (mort) et que c'est la fin de la partie. Cette barre de vie peu aussi augmentée avec
l'acquisition de certains bonus/trésors à force que le joueur progresse dans les niveaux (pensez à une barre de mana).

#### <a name='vaisseau_powerup'></a> Power Up

- Supprime tout dans le champ de vision
- Rends invincible pendant une période de temps
- Redonne une amure
- Permets d'aller super vite
- Arrête le temps (tous les ennemis / powerups / bulles de vie arrêtent de bouger mais pas le vaisseau)

#### <a name='vaisseau_deplacement'></a> Déplacements

Développement d'un mode de déplacement par translation simple, puis possibilité d'inclure la physique si le temps le permet. Le vaisseau se déplace seulement sur l'axe des x (latéralement)

### <a name='ennemi'></a> Ennemis

#### <a name='ennemi_style'></a> Styles généraux

Des ennemis qui font un clin d'oeil à la science-fiction des années 80 comme mentionné par Eric. 
Des vaisseaux starwars, StarTrek, etc.

#### <a name='ennemi_attribut'></a> Attributs généraux

Les ennemis sont placés en formation au fond de la scène, puis certains se séparent pour lancer une attaque vers le joueur en s'approchant et en lançant des projectiles. Si le joueur les évite sans les tuer, ceux-ci retournent dans la formation.

#### <a name='ennemi_hp'></a> Points de vie

Chaque ennemi éliminé donne des points.
Points qui s'accumule après un certain nombre de temps sans s'être fait touché par un ennemi.
Évaluer la possibilité de faire des combos d'attaques qui donnent des multiplicateurs de points.(Nice to have)

#### <a name='ennemi_deplacement'></a> Déplacements

À définir

### <a name='capsule'></a> Types de capsules

#### <a name='capsule_munition'></a> Capsules de munitions

Pour recharger les armes plus puissantes, le joueur doit ramasser des capsules de munitions de type "Énergie" ou "Explosive".

#### <a name='capsule_powerup'></a> Capsules de Power Up

Pour pimenter le jeu, des capsules bonus apparaissent aléatoirement pendant le jeu, tel que des objets protecteurs autour du vaisseau, invincibilité, très grande vitesse de déplacement, double dég¸at, vie.

### <a name='mode_jeu'></a> Modes de jeu

Plusieurs modes de jeu ont été pensés pour galaxqam. Dans le cadre du projet de session, nous avons sélectionnés les modes de jeu essentiels. 
Les autres pourront être implémentés lors d'itérations futures.

#### <a name='mode_classique'></a> Mode normal

C'est le mode de jeu standard qui comprends un niveau et un boss, un GROS vaisseau ennemi qui tire partout et qui a beaucoup de vie.

#### <a name='mode_survie'></a> Mode survie

Le niveau de survie est un niveau interminable, sauf avec la mort du joueur.
Le jeu commence de la même manière que le mode classique avec un nombre d'ennemis déterminé. Cependant, un vaisseau ennemi
détruit est remplacé par un nouvel ennemi, de sorte qu'il est impossible de terminer le niveau comme le niveau classique.

- Lorsqu'un vaisseau ennemi est tué, il y a une chance que deux ennemis immédiatement à sa mort.
- Après x temps, les ennemis attaquent plus rapidement.
- Après x ennemis tués, un power up de vie tombe du ciel.
- Etc...

Le calibrage sera important parce que pour être le fun, il faut que le joueur puisse jouer un certain moment et que ça devienne 
de plus en plus difficile. Le panneau de contrôle pourrait nous aider à trouver cet équilibre d'expérience de jeu.
Quel sera votre meilleur score?

#### <a name='mode_gm'></a> Mode Game Master

Ce mode permet de modifier les paramètres du jeu dynamiquement dans le but de faciliter la présentation et le développement du jeu 
en permettant la navigation parmi les fonctionnalités disponibles. On pourra activer des scènes, des menus, faire tomber des capsules de munition, des PowerUps, activer des scénarios précis, changer des variables pendant une partie.

### <a name='sauvegarde'></a> Sauvegarde des meilleurs scores

Lorsque la partie est terminée, si le pointage du joueur est dans le top 10, on enregistre son pointage parmi les meilleurs scores. 
Il y a une liste de meilleurs scores par mode de jeu. 
Le nom sera demandé au moment de l'enregistrement du meilleur score.
