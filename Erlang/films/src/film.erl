%% ----------------------------------
%% @author Samuel Dextraze et Raphael Bernatchez
%% @copyright 2019
%% @doc
%% @end
%% ----------------------------------

-module(film).
-export([titresfilmcher/1,titresfilmcher/3,titresfilmcheap/1,titresfilmcheap/3,chiffreaffaire/1,chiffreaffaire/2,trie/1,trie/2,listfilmheadtail/1,listfilmhead/1,parcour/3,tail/1,meilleurprofit/1,meilleurprofit/3,profittotal/1,profittotal/2,titrefilm/2,titrefilm/3,titredate/3,titredate/4]).
-include("./film.hrl").


titresfilmcher([],_,TITRES) -> TITRES;
titresfilmcher([H|T],MAX,TITRES) ->
	P = H#film.prix,
	if P > MAX ->
			titresfilmcher(T,P,[H#film.nom]);
	   P == MAX ->
			titresfilmcher(T,P,lists:append(TITRES,[H#film.nom]));
	   true ->
			titresfilmcher(T,MAX,TITRES)
	end.



titresfilmcheap([],_,TITRES) -> TITRES;
titresfilmcheap([H|T],MIN,TITRES) ->
	P = H#film.prix,
	if P < MIN ->
			titresfilmcheap(T,P,[H#film.nom]);
	   P == MIN ->
			titresfilmcheap(T,P,lists:append(TITRES,[H#film.nom]));
	   true ->
			titresfilmcheap(T,MIN,TITRES)
	end.


chiffreaffaire([],FILMS) -> FILMS;
chiffreaffaire([H|T],FILMS) ->
	N = H#film.moyenne,
	if N > 7.0 ->
			F = #film{id=H#film.id,nom=H#film.nom,type=H#film.type,moyenne=H#film.moyenne,acteurs=H#film.acteurs,prix=(H#film.prix + (H#film.prix * 0.10)),nbvendu=H#film.nbvendu,datesortie=H#film.datesortie} ,
			chiffreaffaire(T,lists:append(FILMS,[F]));
	   N =< 7 ->
			F = #film{id=H#film.id,nom=H#film.nom,type=H#film.type,moyenne=H#film.moyenne,acteurs=H#film.acteurs,prix=(H#film.prix - (H#film.prix * 0.05)),nbvendu=H#film.nbvendu,datesortie=H#film.datesortie} ,
			chiffreaffaire(T,lists:append(FILMS,[F]))
	end.

listfilmheadtail([]) ->
	U = listfilmhead([]),
	U;

listfilmheadtail([_|T]) ->
	U = listfilmhead(T),
	U.

listfilmhead([]) -> #film{id = 0,nom = "",type= "",moyenne = 0.0,acteurs = "",prix = 0.0,nbvendu = 0,datesortie = {0,0,0}};
listfilmhead([H|_]) -> H.
tail([]) -> #film{id = 0,nom = "",type= "",moyenne = 0.0,acteurs = "",prix = 0.0,nbvendu = 0,datesortie = {0,0,0}};
tail([_|T]) -> T.

trie([],FILMS) -> FILMS;

trie([H|T],FILMS) ->
	HEAD = listfilmhead(FILMS),
	HTAIL = listfilmheadtail(FILMS),
	TAIL = tail(FILMS),

	if H#film.prix > HEAD#film.prix ->
			trie(T,lists:append([H],FILMS));

	   H#film.prix == HEAD#film.prix ->
			trie(T,lists:append([H],FILMS));

	   (H#film.prix < HEAD#film.prix) and (H#film.prix > HTAIL#film.prix) ->
			trie(T,lists:append([HEAD],lists:append([H],TAIL)));

	   (H#film.prix < HEAD#film.prix) and (H#film.prix < HTAIL#film.prix) ->
			trie(T,parcour(H,FILMS,[]))
	end.




parcour(VALEUR,[H|T],DEBUT) ->

	HTAIL = listfilmhead(T),

	if (VALEUR#film.prix < H#film.prix) and (VALEUR#film.prix < HTAIL#film.prix) ->
			parcour(VALEUR,T,lists:append(DEBUT,[H]));

	   (VALEUR#film.prix < H#film.prix) and (VALEUR#film.prix > HTAIL#film.prix) ->
			U = lists:append(lists:append(lists:append(DEBUT,[H]),[VALEUR]),T),
			U
	end.


meilleurprofit([],_,MEILLEUR) -> MEILLEUR;
meilleurprofit([H|T],MAX ,MEILLEUR) ->
	ACTUELLE = H#film.prix * H#film.nbvendu,
	if ACTUELLE > MAX ->
			meilleurprofit(T,ACTUELLE,[H]);
		ACTUELLE == MAX ->
			meilleurprofit(T,ACTUELLE,lists:append([H],MEILLEUR));
		ACTUELLE < MAX ->
			meilleurprofit(T,MAX,MEILLEUR)
	end.


profittotal([],PROFIT) -> PROFIT;
profittotal([H|T],PROFIT)->
	profittotal(T,PROFIT + (H#film.prix * H#film.nbvendu)).


titrefilm([],_,LISTFILM) -> LISTFILM;
titrefilm([H|T],ACTEUR,LISTFILM) ->
	OK = string:str(H#film.acteurs,ACTEUR) > 0,
	if OK == true ->
			titrefilm(T,ACTEUR,lists:append(LISTFILM,[H#film.nom]));
	   OK == false ->
			titrefilm(T,ACTEUR,LISTFILM)
	end.


titredate([],FILMS,_,_) -> FILMS;
titredate([H|T],FILMS,DATEDEBUT,DATEFIN) ->
	DEBUT = calendar:datetime_to_gregorian_seconds({DATEDEBUT,{0,0,0}}),
	FIN = calendar:datetime_to_gregorian_seconds({DATEFIN,{0,0,0}}),
	DATEACTUELLE = calendar:datetime_to_gregorian_seconds({H#film.datesortie,{0,0,0}}),
	if (DATEACTUELLE >= DEBUT) and (DATEACTUELLE =< FIN) ->
			titredate(T,lists:append(FILMS,[{H#film.id,H#film.nom}]),DATEDEBUT,DATEFIN);
		true->
			titredate(T,FILMS,DATEDEBUT,DATEFIN)
	end.

titredate(FILM,DATEDEBUT,DATEFIN) -> titredate(FILM,[],DATEDEBUT,DATEFIN).
titrefilm(FILMS,ACTEUR) -> titrefilm(FILMS,ACTEUR,[]).
profittotal(FILMS) -> profittotal(FILMS,0).
meilleurprofit(FILMS) -> meilleurprofit(FILMS,0,[]).
chiffreaffaire(FILMS) -> chiffreaffaire(FILMS,[]).
titresfilmcher(LIST) -> titresfilmcher(LIST,0,"").
titresfilmcheap(LIST) -> titresfilmcheap(LIST,10000,"").
trie(LIST) -> trie(LIST,[]).







