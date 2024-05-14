%% ----------------------------------
%% @author Samuel Dextraze et Raphael Bernatchez
%% @copyright 2019
%% @doc
%% @end
%% ----------------------------------

-module(addresse).
-export([classeip/1,adressetointtable/1,creationpays/2,creationpays/3,trouverpays/2,paysip/3,retourbinaire/3,iptobin/1]).
-include("./addresse.hrl").
-include("./pays.hrl").



classeip([A, B, C, D]) ->
	if (A > 247) or (A < 0) or (B > 255) or (B < 0) or (C < 0) or (D < 0) or (C > 255) or (D >255) or ((A == 192) andalso (D == 0) andalso (B == 0) andalso (C == 0)) or ((A == 223) andalso (D == 255) andalso (B == 255) andalso (C == 255)) or ((A == 0) andalso (D == 0) andalso (B == 0) andalso (C == 0)) or ((A == 126) andalso (D == 255) andalso (B == 255) andalso (C == 255)) or ((A == 128) andalso (D == 0) andalso (B == 0) andalso (C == 0)) or ((A == 191) andalso (D == 255) andalso (B == 255) andalso (C == 255)) ->
			CLASSE = "Erreur",
			CLASSE;
	    A == 127 ->
			CLASSE = "Boucle locale",
			CLASSE;
		(A == 10) or (A == 172 andalso (B > 15 andalso B < 32 )) or (A == 192 andalso B == 168) ->
			CLASSE = "Privee",
			CLASSE;
		A > 239 ->
			CLASSE = "E",
			CLASSE;
		A > 223 ->
			CLASSE = "D",
			CLASSE;
		A > 191 ->
			CLASSE = "C",
			CLASSE;
		A > 127 ->
			CLASSE = "B",
			CLASSE;
		A >= 0 ->
			CLASSE = "A",
			CLASSE
	end.

paysip([A, B, C, D], [AMIN, BMIN, CMIN, DMIN],[AMAX,BMAX,CMAX,DMAX]) ->
	if (A >= AMIN) andalso (A =< AMAX) andalso (B >= BMIN) andalso (B =< BMAX) andalso (C >= CMIN) andalso (C =< CMAX) andalso (D >= DMIN) andalso (D =< DMAX) ->
			"TRUE";
	    true ->
			"FALSE"
	end.

adressetointtable(A) ->
	[A1, B1, C1, D1] = string:tokens(A, "."),
	A2 = list_to_integer(A1),
	B2 = list_to_integer(B1),
	C2 = list_to_integer(C1),
	D2 = list_to_integer(D1),
	[A2,B2,C2,D2].

creationpays(LIST, LISTPAYS,IP) ->
		try  [H|T] = LIST,
			F = re:split(H, "-", [{return, list}]),
			[MIN|[Q]] = F,
			O = string:strip(Q, right, $)),
			[MAX,NOM] = string:tokens(O, "("),
			PAYS = [#pays{nom=NOM,ip_min=MIN,ip_max=MAX}],
			creationpays(T,lists:append(LISTPAYS,PAYS),IP)
		catch
			_:_ -> F2 = re:split(LIST, "-", [{return, list}]),
			[MIN2|[Q2]] = F2,
			[MAX2,NOM2] = string:tokens(string:strip(Q2, right, $)),"("),
			PAYS2 = [#pays{nom=NOM2,ip_min=MIN2,ip_max=MAX2}],
			LFINAL = lists:append(LISTPAYS,PAYS2),
			trouverpays(LFINAL,IP)
		end.

creationpays(LIST,IP) ->
		try  [H|T] = LIST,
			F = re:split(H, "-", [{return, list}]),
			[MIN|[Q]] = F,
			O = string:strip(Q, right, $)),
			[MAX,NOM] = string:tokens(O, "("),
			PAYS = #pays{nom=NOM,ip_min=MIN,ip_max=MAX},
			creationpays(T,[PAYS],IP)
		catch
			_:_ -> F2 = re:split(LIST, "-", [{return, list}]),
			[MIN2|[Q2]] = F2,
			[MAX2,NOM2] = string:tokens(string:strip(Q2, right, $)),"("),
			trouverpays([#pays{nom=NOM2,ip_min=MIN2,ip_max=MAX2}],IP)
		end.


trouverpays([],_) -> "Inconnu";
trouverpays([H|T],IP) ->
	P = paysip(adressetointtable(IP),adressetointtable(H#pays.ip_min),adressetointtable(H#pays.ip_max)),
	if P == "TRUE" ->
			H#pays.nom;
		true ->
			trouverpays(T,IP)
	end.


retourbinaire([],[],RETOUR) -> RETOUR;
retourbinaire([H|T],[H1|T1],RETOUR) ->
	if ([H] == [H1]) andalso ([H] == "1") ->
			retourbinaire(T,T1,RETOUR++"1");
		true ->
			retourbinaire(T,T1,RETOUR++"0")
	end.

iptobin(IP) ->
	[A|[B|[C|[D]]]] = adressetointtable(IP),
	A1 = integer_to_list(A, 2),
	B1 = integer_to_list(B, 2),
	C1 = integer_to_list(C, 2),
	D1 = integer_to_list(D, 2),
	string:join([A1,B1,C1,D1],"").




