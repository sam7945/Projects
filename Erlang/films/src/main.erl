%% ----------------------------------
%% @author Samuel Dextraze et Raphael Bernatchez
%% @copyright 2019
%% @doc
%% @end
%% ----------------------------------

-module(main).
-include("./film.hrl").
-include("./addresse.hrl").
-include("./pays.hrl").
-export([exercice1/0,exercice2/0,exercice3/0,getfilm/0,listfilm/0,getdate/0,print/1,getadresse/0,printtotal/1]).

%-----------------------------------------À LIRE-----------------------------------------------------
%Exercice 1 = main:exercice1().
%Exercice 2  = main:exercice2().
%Exercice 2 no.2 question 2(binaire) = main:exercice3().
%----------------------------------------------------------------------------------------------------

%listfilm()->
%	LISTFILM=[#film{id=1,nom="sam",type="Action",moyenne=8.0,acteurs="tfc",prix=10.4,nbvendu=5214,datesortie={2019,11,21}},
%			  #film{id=2,nom="dex",type="horrifique",moyenne=5.3,acteurs="vbg",prix=10.5,nbvendu=5214,datesortie={2019,11,22}},
%			  #film{id=3,nom="ant",type="science-fiction",moyenne=4.2,acteurs="mnb",prix=10.5,nbvendu=5214,datesortie={2019,11,23}},
%			  #film{id=4,nom="rap",type="action",moyenne=6.0,acteurs="bhj",prix=10.5,nbvendu=5214,datesortie={2019,11,24}},
%			  #film{id=5,nom="jer",type="politique",moyenne=3.2,acteurs="lkj",prix=10.6,nbvendu=5214,datesortie={2019,11,25}}],
%	LISTFILM.

listfilm() ->
	F1 = getfilm(),
	F2 = getfilm(),
	F3 = getfilm(),
	F4 = getfilm(),
	F5 = getfilm(),
	F = [F1,F2,F3,F4,F5],
	F.
getmoyenne() ->
		try {ok, [MOYENNE]} = io:fread("Note moyenne en chiffre a virgule du film: " , "~s"),
			list_to_float(MOYENNE)
		catch
			 _:_ -> io:fwrite("Moyenne invalide!!Recommencer~n"), getmoyenne()
		end.

getprix()->
		try {ok, [PRIX]} = io:fread("Prix du film en chiffre a virgule:" , "~s"),
		list_to_float(PRIX)
		catch
			_:_ -> io:fwrite("Prix invalide!!Recommencer avec un chiffre à point~n"), getmoyenne()
		end.

getfilmvendu() ->
		try  {ok, [NBVENDU]} = io:fread("Nombre de film vendu: " , "~s"),
		list_to_integer(NBVENDU)
		catch
			_:_ -> io:fwrite("Nombre invalide!!Recommencer~n"), getfilmvendu()
		end.

getfilm() ->
		{{YEAR,MONTH,DAY},{HOUR,MIN,SEC}} = erlang:localtime(),
		NOM = string:strip(io:get_line("Nom du film: "), right, $\n),
		TYPE = gettype(),
		MOYENNE = getmoyenne(),
		{ok, [ACTEURS]} = io:fread("Acteurs du film, separer par des virgules: " , "~s"),
		PRIX = getprix(),
		NBVENDU = getfilmvendu(),
		DATE = getdate(),
		F = #film{id=calendar:datetime_to_gregorian_seconds({{YEAR,MONTH,DAY},{HOUR,MIN,SEC}}),nom=NOM,type=TYPE,moyenne=MOYENNE,acteurs=ACTEURS,prix=PRIX,nbvendu=NBVENDU,datesortie=DATE},
		F.

choix(F) ->
	{ok, [CHOIX]} = io:fread("Question: " , "~s"),
	case CHOIX of
		"Q1" ->  U = film:titresfilmcher(F),print(U);
		"Q2" ->  U = film:titresfilmcheap(F), print(U);
		"Q3" ->  L = film:chiffreaffaire(F),print(L), choix(L);
		"Q4" ->  L = film:trie(F),print(L),choix(L);
		"Q5" ->  L = film:meilleurprofit(F),print(L);
		"Q6" ->  P = film:profittotal(F), printtotal(P);
		"Q7" ->  {ok, [NOM]} = io:fread("Nom de l'acteur: " , "~s"), T = film:titrefilm(F,NOM),print(T);
		"Q8" ->  T = film:titredate(F,getdate(),getdate()),print(T);
		_-> choix(F)
	end,
	choix(F).

gettype() ->
	{ok, [TYPE]} = io:fread("Type de film: " , "~s"),
	TY = string:to_lower(TYPE),
	if (TY == "action") or (TY == "espionnage") or (TY == "politique") or (TY == "science-fiction") or (TY == "horrifique") ->
			TYPE;
		true ->
			io:fwrite("Type incorrecte!!Recommencer~n"),
			gettype()
	end.

getannee() ->
	try  {ok, [ANNEE]} = io:fread("Date annee: " , "~s"),
		list_to_integer(ANNEE)
	catch
		_:_ -> io:fwrite("Nombre invalide!!Recommencer~n"), getannee()
	end.

getmois() ->
	try  {ok, [MOIS]} = io:fread("Date mois: " , "~s"),
		list_to_integer(MOIS)
	catch
		_:_ -> io:fwrite("Nombre invalide!!Recommencer~n"), getmois()
	end.

getjour() ->
	try  {ok, [JOUR]} = io:fread("Date jour: " , "~s"),
		list_to_integer(JOUR)
	catch
		_:_ -> io:fwrite("Nombre invalide!!Recommencer~n"), getjour()
	end.

getdate()->
	ANNEE = getannee(),
	MOIS = getmois(),
	JOUR = getjour(),

	B = calendar:valid_date(ANNEE,MOIS,JOUR),
	if B == false ->
		io:fwrite("Date invalide!!~n"),
		getdate();
	true ->
		{ANNEE,MOIS,JOUR}
	end.

printtotal(TOTAL) ->
	io:fwrite("~f Dollards\n",[TOTAL]).

print([])-> ok;
print([H|T]) ->
     io:fwrite("~p\n",[H]),
     print(T).

exercice1()->
	choix(listfilm()).


getadresse() ->
	{ok, [IP]} = io:fread("Entrez une addresse ip: " , "~s"),
	{{YEAR,MONTH,DAY},{HOUR,MIN,SEC}} = erlang:localtime(),
	A = #addresse{id=calendar:datetime_to_gregorian_seconds({{YEAR,MONTH,DAY},{HOUR,MIN,SEC}}),addresseip=IP,classe = addresse:classeip(addresse:adressetointtable(IP)),pays = getinfopays(IP)},
	io:fwrite("Addresse: ~p~nClasse: ~p~nPays: ~p~nForme binaire: ~p~n",[A#addresse.addresseip,A#addresse.classe,A#addresse.pays,addresse:iptobin(A#addresse.addresseip)]).

getinfopays(IP) ->
	INFO = string:strip(io:get_line("Entrez les informations sur les ip des pays: "), right, $\n),
	addresse:creationpays(re:split(INFO, ";", [{return, list}]),IP).

exercice2()->
	A = getadresse(),
	A.


exercice3()->
	PREMIER = string:strip(io:get_line("Entrez une chaine de caracteres binaires: "), right, $\n),
	DEUXIEME = string:strip(io:get_line("Entrez une deuxieme chaine de caracteres binaires: "), right, $\n),
	RES = addresse:retourbinaire(PREMIER,DEUXIEME,""),
    io:fwrite("resultat: ~s ~n",[RES]),
    io:fwrite("resultat en decimale: ~p.~p.~p.~p ~n",[list_to_integer(string:substr(RES, 1, 8),2),list_to_integer(string:substr(RES, 9, 8),2),list_to_integer(string:substr(RES, 17, 8),2),list_to_integer(string:substr(RES, 25, 8),2)]).


%193.188.127.0-193.188.127.255(Bahrain);193.188.64.0-193.188.95.255(Jordan);194.126.32.0-194.126.63.255(Kuwait);194.165.128.0-194.165.159.255(Jordan);194.170.0.0-194.170.255.255(United Arab Emirates);194.54.192.0-194.54.255.255(Kuwait);195.174.0.0-195.175.255.255(Turkey);195.226.224.0-195.226.255.255(Kuwait);195.229.0.0-195.229.255.255(United Arab Emirates);195.39.128.0-195.39.191.255(Kuwait);203.135.32.0-203.135.63.255(Pakistan);203.215.64.0-203.215.95.255(Philippines)


%10011110101011001001111010101101
%11111111111111111111111100000000
%10011110101011001001111000000000






