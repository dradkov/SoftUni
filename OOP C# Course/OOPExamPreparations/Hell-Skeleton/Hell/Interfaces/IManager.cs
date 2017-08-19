using System;
using System.Collections.Generic;

public interface IManager
{
    string AddHero(List<string> arguments);

    string AddItemToHero(List<string> arguments, IHero hero);

    string AddRecepieToHero(List<string> arguments, IHero hero);

    string CreateGame();

    string Inspect(List<String> arguments);

    string Quit();
}

