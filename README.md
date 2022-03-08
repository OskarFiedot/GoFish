# GoFish

## Opis: 
Powyższy program, jest to bardzo prosta gra w terminalu, oparta na grze karcianej Go Fish. 
Został napisany w ramach projektu z przedmiotu Podstawy Programowania, na pierwszym semestrze podjętych przeze mnie studiów i jest pierwszym większym programem, 
który napisałem w życiu. Oryginalnie napisany w C++, bez użycia klas, przepisany później na C# w ramach treningu, kiedy uczyłem się podstaw składni tego języka.
W grę gra się "z komputerem", chociaż nie ma tu zaimplementowanej żadnej sztucznej inteligencji, po prostu program losuje za pomocą klasy random, wysokości kart, 
o jakie chce zapytać gracza.

## Zasady:
Gracz na początku podaje swoją nazwę, po czym wyświetla się w terminalu cała talia kart, z której będą losowane karty dla obydwu graczy. Następnie podaje się liczbę kart, jaką
program ma rozlosować na początek, domyślnie dla dwóch graczy (a tylko w tyle można grać w tym programie, z czego jeden to komputer) powinna to być liczba 7. 
Program rozlosowuje karty i zaczyna się właściwa część rozgrywki. Zaczyna gracz typu człowiek, pytając komputer o jakąś konkretną wysokość karty 
(gracz musi posiadać te wysokość w swoich kartach). Jeśli komputer posiada karty o takiej wysokości, przekazuje wszystkie takie karty graczowi, 
a gracz może pytać o następną wysokość. Jeśli komputer nie posiadał żadnej karty tej wysokości, gracz typu człowiek dolosowuje sobie kartę z talii kart,
po czym następuje kolej komputera, na pytanie gracza o wysokość karty. W analogiczny sposób gra toczy się, dopóki nie skończą się karty w talii. 
Gdy któryś z graczy zbierze wszystkie karty danej wysokości (czyli 4), znikają one z jego ręki i są odkładane na stos. Wygrywa gracz, który uzbierał w trakcie 
gry więcej takich stosów. 

## Oznaczenie kart
Karty przedstawiane są w formacie: |{wysokość karty}{kolor karty}|  

Wysokości kart:  
A - As  
K - Król  
D - Dama  
W - Walet  
2-10 - po prostu wysokości kart wyrażone w cyfrach  

Kolory kart:  
T - Trefl  
K - Karo  
k - Kier  
P - Pik  

#### Gra jest napisana w C#, bez zastosowania żadnych zewnętrznych bibliotek, do odpalenia potrzebny jest zainstalowany .Net 6 na komputerze. 

