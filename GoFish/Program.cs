using GoFish;

var talia = new Talia();

Console.WriteLine("Podaj swoją nazwę: ");
var czlowiek = new Gracz(Console.ReadLine(), false);
var komputer = new Gracz("komputer", true);

talia.WyswieltTalie();
LosujKarty(czlowiek, komputer, talia);
czlowiek.SprawdzStosy();
komputer.SprawdzStosy();
Tura(czlowiek, komputer, talia);


void LosujKarty(Gracz pierwszy, Gracz drugi, Talia talia)
{
    Console.WriteLine("\nIle kart losować na start?: ");

    var ileLosowac = int.Parse(Console.ReadLine());

    if (ileLosowac > 10)
    {
        // wyjątek              
    }

    var random = new Random();
    int losowyIndeksKarty;

    for (int i = 0; i < ileLosowac; i++)
    {
        losowyIndeksKarty = random.Next(talia.Karty.Count);

        pierwszy.Karty.Add(talia.Karty[losowyIndeksKarty]);

        talia.Karty.RemoveAt(losowyIndeksKarty);

        losowyIndeksKarty = random.Next(talia.Karty.Count);

        drugi.Karty.Add(talia.Karty[losowyIndeksKarty]);

        talia.Karty.RemoveAt(losowyIndeksKarty);
    }
}

void Tura(Gracz pytajacy, Gracz pytany, Talia talia)
{
    talia.WyswietlLiczbeKartWTalii();
    pytajacy.WyswietlStosyGracza();
    pytany.WyswietlStosyGracza();

    if (pytajacy.Karty.Count == 0)
    {
        Separator();
        Console.WriteLine($"Gracz {pytajacy.Nazwa} nie posiada w swoich kartach, wysokości, o którą mógłby spytać...");
        DolosujKarte(pytajacy, talia);
        CzyKoniec(pytajacy, pytany, talia);
        Tura(pytany, pytajacy, talia);
    }

    if (!pytajacy.Symulacja)
    {
        pytajacy.WyswietlKartyGracza();

        Console.WriteLine("\n\nO jaką wysokość karty pytasz?: ");
        var wysokosc = Console.ReadLine();
        var posiada = false;

        foreach (var karta in pytajacy.Karty)
        {
            if (karta.Wysokosc == wysokosc)
            {
                posiada = true;
                break;
            }
        }

        if (!posiada)
        {
            Console.WriteLine($"\n\nNie posiadasz żadnej karty o wysokości {wysokosc}");
            Tura(pytajacy, pytany, talia);
        }
        else
        {
            PrzekazKarty(pytajacy, pytany, talia, wysokosc);
        }
    }
    else
    {
        var random = new Random();
        string wysokosc = pytajacy.Karty[random.Next(pytajacy.Karty.Count)].Wysokosc;

        //pytajacy.WyswietlKartyGracza();

        Console.WriteLine($"\n\nRuch gracza {pytajacy.Nazwa}...\n\n{pytajacy.Nazwa} pyta o wysokość: {wysokosc}");

        PrzekazKarty(pytajacy, pytany, talia, wysokosc);
    }
}


void PrzekazKarty(Gracz pytajacy, Gracz pytany, Talia talia, string wysokosc)
{
    List<Karta> znalezioneKarty = pytany.SprawdzKarty(wysokosc);

    if (znalezioneKarty.Count != 0)
    {
        Separator();
        Console.Write($"Gracz {pytany.Nazwa} przekazuje graczowi {pytajacy.Nazwa} karty:");

        foreach (var karta in znalezioneKarty)
        {
            Console.Write($"{karta}");
        }
        Separator();

        pytajacy.Karty.AddRange(znalezioneKarty);
        pytajacy.SprawdzStosy();
        CzyKoniec(pytajacy, pytany, talia);
        Tura(pytajacy, pytany, talia);
    }
    else
    {
        Separator();
        Console.WriteLine($"Gracz {pytany.Nazwa} nie posiada kart o wysokości {wysokosc}");
        DolosujKarte(pytajacy, talia);
        pytajacy.SprawdzStosy();
        CzyKoniec(pytajacy, pytany, talia);
        Tura(pytany, pytajacy, talia);
    }
}

void DolosujKarte(Gracz gracz, Talia talia)
{
    var random = new Random();

    int losowyIndeksKarty = random.Next(talia.Karty.Count);

    gracz.Karty.Add(talia.Karty[losowyIndeksKarty]);

    Console.Write($"\n\nGracz {gracz.Nazwa} otrzymuje losową kartę z talii");
    Separator();

    talia.Karty.RemoveAt(losowyIndeksKarty);
}

void CzyKoniec(Gracz gracz_1, Gracz gracz_2, Talia talia)
{
    if (talia.Karty.Count == 0)
    {
        if (gracz_1.Stosy.Count > gracz_2.Stosy.Count)
        {
            Separator();
            Console.Write($"Karty w talii się skończyły - gra dobiega końca..\n\nGrę wygrał gracz {gracz_1.Nazwa}! Brawo!\n\nStosy:");
            gracz_1.WyswietlStosyGracza();
            gracz_2.WyswietlStosyGracza();
            Separator();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        else if (gracz_2.Stosy.Count > gracz_1.Stosy.Count)
        {
            Separator();
            Console.Write($"Karty w talii się skończyły - gra dobiega końca..\n\nGrę wygrał gracz {gracz_2.Nazwa}! Brawo!\n\nStosy:");
            gracz_2.WyswietlStosyGracza();
            gracz_1.WyswietlStosyGracza();
            Separator();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        else
        {
            Separator();
            Console.Write("Karty w talii się skończyły - gra dobiega końca..\n\nMamy remis!\n\nStosy:");
            gracz_1.WyswietlStosyGracza();
            gracz_2.WyswietlStosyGracza();
            Separator();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}

void Separator()
{
    Console.Write("\n---------------------------------------------------------------------------------------\n");
}