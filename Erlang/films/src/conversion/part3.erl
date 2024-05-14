%% ----------------------------------
%% @author Samuel Dextraze
%% @copyright 2019
%% @doc
%% @end
%% ----------------------------------

-module(part3).
-include("pays.hrl").
-export([listepays/0,main/0,choixpays/1,printdevise/2,paysparnom/2,calculparpays/2,changeargentine/2,paysavisiter/4,printvisite/1]).


listepays() ->
	LISTPAYS=[#pays{id = 1,nom= "Etats Unis",devise="Dollard",conversion=1.3595},
			  #pays{id = 2,nom= "Union Européenne",devise="Euro",conversion=1.4475},
			  #pays{id = 3,nom= "Angleterre",devise="Livre",conversion=1.6995},
			  #pays{id = 4,nom= "Suisse",devise="Franc",conversion=1.3451},
			  #pays{id = 5,nom= "Japon",devise="Yen",conversion=0.0126},
			  #pays{id = 6,nom= "Arabie Saoudite",devise="Riyal",conversion=0.3964},
			  #pays{id = 7,nom= "Afrique du sud",devise="Rand",conversion=0.1042},
			  #pays{id = 8,nom= "Argentine",devise="Peso",conversion=0.0934},
			  #pays{id = 9,nom= "Australie",devise="Dollard",conversion=1.0343},
			  #pays{id = 10,nom="Bahamas",devise="Dollard",conversion=1.4462},
			  #pays{id = 11,nom="Barbade",devise="Dollard",conversion=0.7366},
			  #pays{id = 12,nom="Brésil",devise="Real",conversion=0.4220}],
	LISTPAYS.


main() ->
	L = listepays(),
	{ok, [CHOIX]} = io:fread("Question: " , "~s"),
	case CHOIX of
		"1" ->  choixpays(L);
		"2" ->  P = changeargentine(L,[]),{ok, [MONTANT]} = io:fread("Montant pour le voyage: " , "~d"),V = paysavisiter(P,MONTANT,[],0), printvisite(V);
		_-> main()
	end.

changeargentine([],PAYS) -> PAYS;
changeargentine([H|T],PAYSCHANGER) ->
	if H#pays.nom == "Argentine" ->
			P = #pays{id = H#pays.id,nom= H#pays.nom,devise=H#pays.devise,conversion=0.0126},
			C = lists:append(PAYSCHANGER,[P]),
			changeargentine(T,C);
		true -> 
			C = lists:append(PAYSCHANGER,[H]),
			changeargentine(T,C)
	end.
	
paysavisiter([],_,PAYSVISITE,_) -> PAYSVISITE;
paysavisiter([H|T],MONTANT,PAYSVISITE,MAX) ->
	ARGENT = MONTANT/H#pays.conversion,
	if ARGENT > MAX ->
			paysavisiter(T,MONTANT,[{H#pays.nom,H#pays.devise,ARGENT}],ARGENT);
	   ARGENT == MAX ->
			paysavisiter(T,MONTANT, lists:append(PAYSVISITE,[{H#pays.nom,H#pays.devise,ARGENT}]),ARGENT);
	   ARGENT < MAX ->
			paysavisiter(T,MONTANT,PAYSVISITE,MAX)
	end.
		
paysparnom([H|T],NOM) ->
	if H#pays.nom == NOM ->
			H;
		true-> paysparnom(T,NOM)
	end.

calculparpays(PAYS,MONTANT) ->
	R = MONTANT/PAYS#pays.conversion,
	printdevise(R,PAYS#pays.devise).
	
getchoix() -> 
	try  {ok, [CHOIXPAYS]} = io:fread("Choix pays: " , "~s"),
		list_to_integer(CHOIXPAYS)
	catch
		_:_ -> io:fwrite("Nombre invalide!!Recommencer~n"), getchoix()
	end.
	
getmontant() ->
	try  {ok, [CHOIXMONTANT]} = io:fread("Montant CAN avec virgule: " , "~s"),
		list_to_float(CHOIXMONTANT)
	catch
		_:_ -> io:fwrite("Nombre invalide!!Recommencer~n"), getmontant()
	end.
	
choixpays(PAYS) ->
	io:fwrite("1)Etats Unis      ~n"),
	io:fwrite("2)Union Européenne~n"),
	io:fwrite("3)Angleterre      ~n"),
	io:fwrite("4)Suisse          ~n"),
	io:fwrite("5)Japon           ~n"),
	io:fwrite("6)Arabie Saoudite ~n"),
	io:fwrite("7)Afrique du sud  ~n"),
	io:fwrite("8)Argentine       ~n"),
	io:fwrite("9)Australie       ~n"),
	io:fwrite("10)Bahamas        ~n"),
	io:fwrite("11)Barbade        ~n"),
	io:fwrite("12)Brésil         ~n"),
	CHOIXPAYS = getchoix(),
	CHOIXMONTANT = getmontant(),
	case CHOIXPAYS of
		1 ->P = paysparnom(PAYS,"Etats Unis"),calculparpays(P,CHOIXMONTANT);
	    2 ->P = paysparnom(PAYS,"Union Européenne"),calculparpays(P,CHOIXMONTANT);
	    3 ->P = paysparnom(PAYS,"Angleterre"),calculparpays(P,CHOIXMONTANT);
	    4 ->P = paysparnom(PAYS,"Suisse"),calculparpays(P,CHOIXMONTANT);
	    5 ->P = paysparnom(PAYS,"Japon"),calculparpays(P,CHOIXMONTANT);
	    6 ->P = paysparnom(PAYS,"Arabie Saoudite"),calculparpays(P,CHOIXMONTANT);
	    7 ->P = paysparnom(PAYS,"Afrique du sud"),calculparpays(P,CHOIXMONTANT);
	    8 ->P = paysparnom(PAYS,"Argentine"),calculparpays(P,CHOIXMONTANT);
	    9 ->P = paysparnom(PAYS,"Australie"),calculparpays(P,CHOIXMONTANT);
	    10->P = paysparnom(PAYS,"Bahamas"),calculparpays(P,CHOIXMONTANT);
	    11->P = paysparnom(PAYS,"Barbade"),calculparpays(P,CHOIXMONTANT);
	    12->P = paysparnom(PAYS,"Brésil"),calculparpays(P,CHOIXMONTANT);
	    _-> io:fwrite("Mauvais numéro entrer~n"), choixpays(PAYS)
	end.

printvisite([]) -> main();
printvisite([H|T]) ->
	{F,S,SS} = H,
	io:format("~s ~f ~s ~n", [F,SS,S]),
	printvisite(T).
	

printdevise(T,D) ->  
     io:format("~f ~s ~n", [T,D]),
     main().
