open System
open System.Xml.Serialization
//Méthode globale
let charToInt c = int c - int '0'

let listExpQc = ["Aller aux vues"; 
"Au plus sacrant";
"Avoir de la misère";
"Avoir de l'eau dans la cave";
"Avoir du coeur au ventre";
"Avoir du guts";
"Avoir du pain sur la planche";
"Avoir la guedille au nez";
"Avoir la journée dans le corps";
"Avoir la tête enflée";
"Avoir le cœur gros";
"Avoir le feu au cul";
"Avoir le motton";
"Avoir les baguettes en l'air";
"Avoir les mains plein de pouces";
"Avoir les deux yeux dans le même trou";
"Avoir l'estomac dans les talons";
"Avoir mal au coeur";
"Avoir une bad luck";
"Avoir une crotte sur le cœur";
"Boss de bécosse";
"Botcher son travail";
"C’est tiguidou";
"Ça regarde mal";
"Ça va mal à shop";
"Ne vaut pas de la chnoute";
"C'est de valeur";
"C'est le fun";
"C'est pas vargeux";
"C'est plate icitte";
"C'est tout un numéro";
"C'est un visage à deux faces";
"Virer son capot de bord";
"Chanter la pomme";
"Chic and swell";
"Coûter un bras";
"C’est une autre paire de manches";
"De seconde main";
"Donner un lift";
"Dur de comprenure";
"En titi";
"Être à côté de la track";
"Être aux oiseaux";
"Être dans de beaux draps";
"Être de bonne heure sur le piton";
"Être en mosus";
"Être gras dur";
"Être gratteux";
"Être mouillé jusqu'aux os";
"Être open";
"Être ratoureux";
"Être sur son trente-six";
"Être tiré à quatre épingles";
"Être willing";
"Fais de l'air!";
"Faire dur";
"Faire la baboune";
"Faire la grasse matinée";
"Tourner les coins ronds";
"Faire un bon deal";
"Fucker le chien";
"Fou comme un balai";
"Frapper un nœud";
"Frisé comme un mouton";
"Avoir frette";
"Grimper dans les rideaux";
"J’ai mon voyage!";
"En avoir son voyage";
"La levée du corps est raide";
"Lâcher son fou";
"Lâcher un ouac";
"L'affaire est dans le sac";
"Être en pieds de bas";
"Mets-en!";
"Mettre sa main au feu";
"Mettre ses culottes";
"Mouiller à boire debout";
"Sans queue ni tête";
"S’ouvrir la trappe";
"Pantoute";
"Parler à travers son chapeau";
"Partir pour la famille";
"Passer la nuit sur la corde à linge";
"Péter de la broue";
"Péter le feu";
"Pogner les nerfs";
"Prendre le champ";
"Prendre le mors aux dents";
"Prendre une brosse";
"Prendre ça mollo";
"Rêver en couleurs";
"Rire jaune";
"Rouge comme une tomate";
"Sacrer patience";
"Ne faire ni une ni deux";
"Se faire griller la couenne";
"Se faire laver";
"Matcher";
"Se ronger les sangs";
"Se tirer une bûche";
"Têtu comme une mule";
"Tenir ça mort";
"Tomber dans le panneau";
"Tourner autour du pot";
"Être slaqué";
"Il n’y a rien là";
"Y aller aux toasts";
"Ne pas mener de train";
"Il ment comme il respire";
"Y avoir du monde à la messe";
"Malcommode"]

let listSignifications=["Aller au cinéma";
"Au plus vite";
"Avoir de la difficulté";
"Avoir les pantalons trop courts";
"Être vaillant";
"Avoir du cran, du courage";
"Avoir beaucoup de travail";
"Avoir la morve au nez";
"Être fourbu après une journée éreintante";
"Être vaniteux, prétentieux";
"Être triste";
"Être très en colère ou être très pressé, fuir";
"Avoir la gorge serrée par l’émotion.";
"Gesticuler beaucoup par emportement, par nervosité"; 
"Être malhabile de ses mains";
"Être mal réveillé";
"Avoir très faim";
"Avoir envie de vomir";
"Être malchanceux";
"Avoir du ressentiment"; 
"Personne qui fait preuve d’une autorité prétentieuse malgré sa position hiérarchique modeste; petit chef";
"Faire un travail avec négligence";
"C’est très bien";
"Se présente ou s’annonce mal";
"Ça va très mal";
"Ne vaut pas grand chose";
"C'est regrettable";
"C'est amusant"; 
"Ne pas être extraordinaire, ne pas être terrible, être moche, médiocre";
"C'est ennuyant ici";
"Personne originale";
"Hypocrite";
"Changer d'opinion";
"Faire la cour";
"Être chic";
"Coûter très cher";
"C’est complètement différent à cause d’une plus grande difficulté";
"Usagé";
"Fait d’être transporté gratuitement dans un véhicule";
"Difficile à comprendre";
"Beaucoup";
"Être dans l'erreur";
"Être heureux";
"Être dans une situation inconfortable, embarrassante";
"Être levé tôt";
"Être en colère";
"Comblé, fin prêt, chanceux";
"Personne avare";
"Être complètement trempé";
"Ouvert, avoir l'esprit ouvert";
"Être rusé et sournois";
"Être habillé chic";
"Vêtu avec un soin minutieux";
"Être prêt, être partant";
"Déguerpis!";
"Avoir une apparence déplaisante, misérable ou ridicule";
"Faire la moue, bouder";
"Se lever très tard, rester paresseusement au lit";
"Expliquer qqch., procéder à qqch. de façon grossière, en sautant les points secondaires";
"Faire une bonne affaire";
"Ne rien faire, faire des choses inutiles. Déployer des efforts inutiles, avoir du mal à faire quelque chose";
"Très excité parce qu’on est très content d’apprendre quelque chose";
"Subir un échec";
"Très frisé";
"Avoir très froid"; 
"Être agité, s’énerver, s’emporter"; 
"Phrase exclamative servant à exprimer l’étonnement, la surprise, l’incrédulité";
"Être exaspéré";
"Le réveil est difficile";
"Donner libre cours à son envie de bouger de s’amuser";
"Crier de peur ou de surprise";
"L’affaire est pratiquement réglée, le succès de l’entreprise est assuré";
"Être en chaussettes, sans chaussures";
"Tu l’as dit!";
"En être sûr au point d’en jurer";
"Prendre l’initiative. Réagir en prenant ses responsabilités";
"Pleuvoir à verse, à seaux, à torrents, à flots";
"Dénué de sens";
"Parler alors que ce n’est pas le moment";
"Du tout";
"Parler à tort et à travers";
"Tomber enceinte";
"Rester debout toute la nuit";
"Se vanter";
"Avoir beaucoup d'énergie";
"S’énerver";
"Sortir de la route parce qu’on a perdu la maîtrise du véhicule";
"S’emporter";
"Se rendre ivre";
"Prendre relaxe, doucement";
"Se faire des illusions";
"Se forcer à rire, en dissimulant mal son dépit ou sa gêne";
"Être très rouge en raison d’une émotion intense";
"Laisser quelqu’un tranquille";
"Réagir très promptement";
"Se faire bronzer";
"Se faire dépouiller de tous ses biens";
"Trouver un partenaire amoureux à";
"Être très inquiet et impatient";
"S’approcher une chaise pour s’asseoir";
"Très têtu";
"Ne pas en parler";
"Tomber dans le piège";
"Perdre son temps en n’allant pas droit au but";
"Être congédié";
"C’est très facile à faire. Nul besoin de me remercier";
"Aller vite";
"Ne pas faire de bruit";
"Il ment de façon spontanée et continuelle";
"Y avoir foule";
"Qui est espiègle, turbulent, indiscipliné";]




let rec texte ((x:int),(pos:int),(resultat:int))=
    let mutable y:int = resultat
    let f:int = ((char)(x.ToString().Substring(pos,1))|>charToInt)
    y <- y + (pown f (x.ToString().Length))
    if pos = (x.ToString().Length-1) then 
        y
    else 
        texte(x,pos+1,y)

let Exercice1 x = 
    let mutable y = 0
    y <- texte(x,0,0)
    if y = x && x > 0 then "C'est un chiffre narcissique"
    else "Ce n'est pas un chiffre narcissique"

let Exercice2 x = 
    let mutable puiss = 0
    let mutable negatif = false
    if x < 0 then
         puiss <- (x.ToString().Length-2)
         negatif <- true
    elif x > 0 then
         puiss <- (x.ToString().Length-1)
    let mutable y:string =""
    for i in x.ToString() do
        let mutable f:int = i|>charToInt 
        if f <> -3 then
            if f > 0 && negatif=true then 
                f <- f - (f*2)
            if f <> 0 && puiss >= 1 then 
                y <- y + f.ToString()+"*10^"+puiss.ToString() + "+"
                puiss <- puiss - 1
            elif f <> 0 && puiss = 0 then
                y <- y + f.ToString()
                puiss <- puiss - 1
            elif f = 0 then 
                puiss <- puiss - 1
    if y.EndsWith("+") then y <- y.Substring(0,y.Length-1)
    y   


let Exercice3 ((h:int),(m:int),(p:string))((h1:int),(m1:int),(p1:string)) = 
    let mutable mauvaiseEntrée = false
    let mutable resultat = ""
    let mutable h = h
    let mutable h1 = h1
    if (m >= 60 || h >= 24 || (p <> "AM" && p <> "PM")) || (m1 >= 60 || h1 >= 24 || (p1 <> "AM" && p1 <> "PM")) || ((h >= 12 && p = "AM") && (h1 >= 12 && p = "AM"))  then
        resultat <- "mauvaise entrée"
        mauvaiseEntrée <- true
    if p = "PM" && h < 12 then
        h <- h+12
    if p1 = "PM" && h1 < 12 then
        h1 <- h1+12
    if mauvaiseEntrée = false then
        if p = "PM" && p1 = "AM" then
            resultat <- h1.ToString()+"h"+ m1.ToString()+ " "+ p1 
        elif p1 = "PM" && p = "AM" then
            resultat <- h.ToString()+"h"+ m.ToString()+ " "+ p
        elif (p = "AM" && p1 = "AM")||(p = "PM" && p1 = "PM")  then
            if h > h1 then
                resultat <- h1.ToString()+"h"+ m1.ToString()+ " "+ p1
            elif h1 > h then
                resultat <- h.ToString()+"h"+ m.ToString()+ " "+ p
            elif m > m1 then
                resultat <- h1.ToString()+"h"+ m1.ToString()+ " "+ p1
            elif m1 > m then
                resultat <- h.ToString()+"h"+ m.ToString()+ " "+ p
        elif p = p1 && h = h1 && m = m1 then
             resultat <- h.ToString()+"h"+ m.ToString()+ " "+ p
    resultat


let conditionSucces (nom:String,exam1:float,exam2:float,tp1:float,tp2:float,tp3:float) = 
    if ((exam1 + exam2)/2.0 < 60.0 || (tp1+tp2+tp3)/3.0 < 60.0 || ((exam1 + exam2)/2.0 + (tp1+tp2+tp3)/3.0) < 60.0) then
        false
    else
        true

let rec nomPlusMoyenne list retour (pos:int) = 
    let mutable moyenne = 0.0
    if pos < List.length(list) then
        let nom,exam1,exam2,tp1,tp2,tp3 = list.[pos]
        moyenne <- ((exam1*0.2)+(exam2*0.35)+(tp1*0.2)+(tp2*0.15)+(tp3*0.1))
        let tuple = (nom,moyenne)
        nomPlusMoyenne (list) (tuple::retour) (pos+1)
    else
        retour

let note tuple = 
    let nom,note = tuple
    note

let Exercice4 list = 
    //Afficher pour chaque étudiant sa moyenne sachant les pondérations suivantes
    let mutable moyenneEtudiant = 0.0
    let mutable moyenneClasse = 0.0
    let mutable NombreEleve = 0
    let mutable Variance = 0.0
    let mutable EcartType = 0.0

    for i in list do
        let nom,exam1,exam2,tp1,tp2,tp3 = i
        moyenneEtudiant <- ((exam1*0.2)+(exam2*0.35)+(tp1*0.2)+(tp2*0.15)+(tp3*0.1))
        moyenneClasse <- moyenneClasse + moyenneEtudiant
        printfn "Nom %s, Note moyenne: %s" nom (moyenneEtudiant.ToString("0.00")+"%")
        NombreEleve <- NombreEleve+1


    printfn "Moyenne de la classe: %s" ((moyenneClasse/(float)NombreEleve).ToString("0.00")+"%")


    for i in list do
        let nom,exam1,exam2,tp1,tp2,tp3 = i
        moyenneEtudiant <- ((exam1*0.2)+(exam2*0.35)+(tp1*0.2)+(tp2*0.15)+(tp3*0.1))
        Variance <- Variance + ((moyenneEtudiant - moyenneClasse)**2.0)
    Variance <- Variance/((float)NombreEleve)
    EcartType <- sqrt(Variance)
    printfn "Écart-type: %f" EcartType

    
    let liste1,liste2 = List.partition(fun elem -> conditionSucces(elem) = true)list
    printfn "Succès : %A \nÉchec: %A" liste1 liste2 

    let NomMoyenne = (nomPlusMoyenne list [] 0)
    let trier = List.sortByDescending(fun elem -> note(elem))NomMoyenne
    printfn "Liste moyenne trier:  %A" trier

    let mutable nomE,exam1E,exam2E,tp1E,tp2E,tp3E = ("",0.0,0.0,0.0,0.0,0.0)
    for i in list do    
        let nom,exam1,exam2,tp1,tp2,tp3 = i
        if ((exam1 - exam1E)+(exam2 - exam2E)+(tp1 - tp1E)+(tp2 - tp2E)+(tp3 - tp3E)) > 0.0 then
            nomE<-nom
            exam1E<-exam1
            exam2E<-exam2
            tp1E<-tp1
            tp2E<-tp2
            tp3E<-tp3
    printfn "L'étudiant récipiant d'or est %s avec exam1: %s , exam2: %s, tp1: %s, tp2: %s, tp3: %s" nomE (exam1E.ToString("0.00")+"%") (exam2E.ToString("0.00")+"%") (tp1E.ToString("0.00")+"%") (tp2E.ToString("0.00")+"%") (tp3E.ToString("0.00")+"%")


let Excercice51 expression=
    let mutable pos = -1
    for i = 0 to listExpQc.Length-1 do
        if listExpQc.[i]=expression then
            pos <- i
    if pos = -1 then
        "Expression non trouvée!"
    else
        listSignifications.[pos]
  
let Excercice52 (phrase:string) =
    let mots = (phrase.TrimEnd '.').ToLower().Split [|' '|]
    if (mots.[mots.Length-1] = "vient" || mots.[mots.Length-1] = "veux" || mots.[mots.Length-1] = "veulent" || mots.[mots.Length-1] = "écoutes" || mots.[mots.Length-1] = "abaisses" || mots.[mots.Length-1] = "accroît" || mots.[mots.Length-1] = "sais") then
        phrase + "-tu?"
    elif (Array.contains "a" mots) then
        mots.[Array.IndexOf(mots,"a")] <- "a-tu"
        String.Join(" ", mots)+"?"
    elif (Array.contains "ai" mots) then
        mots.[Array.IndexOf(mots,"a")] <- "ai-tu"
        String.Join(" ", mots)+"?"
    elif (Array.contains "y'a" mots) then
        mots.[Array.IndexOf(mots,"a")] <- "y'a-tu"
        String.Join(" ", mots)+"?"
    elif (Array.contains "l'ai" mots) then
        mots.[Array.IndexOf(mots,"a")] <- "l'ai-tu"
        String.Join(" ", mots)+"?"
    else
        String.Join(" ", Array.rev(mots))+"."

let Excercice53 (mot:string)=
    let mutable pos = []
    for i in [0..listSignifications.Length-1] do
        if(listSignifications.[i].ToLower().Contains(mot.ToLower())) then
            pos <- pos@[i]
    printfn"Liste:"
    for p in pos do
        printfn "%s" listExpQc.[p]

let Excercice54 =
    printf "Joueur1: "
    let nomJoueur1 = Console.ReadLine()
    printf "Joueur2: "
    let nomJoueur2 = Console.ReadLine()
    let mutable (ptsJ1:sbyte) = 0y
    let mutable (ptsJ2:sbyte) = 0y
    for tour in [1..20] do
        let pos = Random().Next(0,listExpQc.Length)
        if(Random().Next(0,2)=0)then
            let mutable question = tour.ToString()+". "+listExpQc.[pos]+" veut dire "+listSignifications.[pos]
            printfn "%s"question
            if(tour%2=1)then
                question <- nomJoueur1+" doit répondre vrai ou faux: "
                printf "%s"question
                let reponse = Console.ReadLine().ToLower()
                if(reponse = "vrai"||reponse = "v")then
                    ptsJ1 <- ptsJ1+2y
                else ptsJ1<-ptsJ1-1y
            else
                question <- nomJoueur2+" doit répondre vrai ou faux: "
                printf "%s"question
                let reponse = Console.ReadLine().ToLower()
                if(reponse = "vrai"||reponse = "v")then
                    ptsJ2 <- ptsJ2+2y
                else ptsJ2<-ptsJ2-1y
        else
            let pos2 = Random().Next(0,listExpQc.Length)
            let mutable question = tour.ToString()+". "+listExpQc.[pos2]+" veut dire "+listSignifications.[pos]
            printfn "%s"question
            if(tour%2=1)then
                question <- nomJoueur1+" doit répondre vrai ou faux: "
                printf "%s"question
                let reponse = Console.ReadLine().ToLower()
                if((reponse = "vrai"||reponse = "v")&&pos2=pos)then
                    ptsJ1 <- ptsJ1+2y
                elif((reponse = "faux"||reponse = "f")&&pos2<>pos)then
                    ptsJ1 <- ptsJ1+2y
                else ptsJ1<-ptsJ1-1y
            else
                question <- nomJoueur2+" doit répondre vrai ou faux: "
                printf "%s"question
                let reponse = Console.ReadLine().ToLower()
                if((reponse = "vrai"||reponse = "v")&&pos2=pos)then
                    ptsJ2 <- ptsJ2+2y
                elif((reponse = "faux"||reponse = "f")&&pos2<>pos)then
                    ptsJ2 <- ptsJ2+2y
                else ptsJ2<-ptsJ2-1y
    let mutable résultat = nomJoueur1+": "+ptsJ1.ToString()+" point(s)"
    printfn "%s"résultat
    résultat <- nomJoueur2+": "+ptsJ2.ToString()+" point(s)"
    printfn "%s"résultat
    if(ptsJ1=ptsJ2)then
        printfn "Les joueurs sont à égalité!"
    elif(ptsJ1<ptsJ2) then
        résultat <-"le gagnant est "+nomJoueur2+"!"
        printfn "%s" résultat
    else 
        résultat <-"le gagnant est "+nomJoueur1+"!"
        printfn "%s" résultat
    
[<EntryPoint>]
let main argv =
    Console.WriteLine("Exercice #1 : "+Exercice1 1634)
    Console.WriteLine("Exercice #2 : "+Exercice2 -1305)
    printfn "Exercice3: %s" (Exercice3(0,20,"AM")(11,23,"PM"))
    Exercice4([("samuel",60.0,50.0,80.0,90.0,70.0);("antoine",65.0,100.0,60.0,92.0,65.0);("test",80.0,80.0,80.0,90.0,90.0)])
    //printfn "Signification: %s" (Excercice51 "Frapper un nœud")
    //printfn "Pharse transformée: %s" (Excercice52 "Bonjour je vais bien.")
    //Excercice53 "vaillant"
    Excercice54
    Console.ReadKey()|>ignore;
    0 // return an integer exit code
