namespace Pokemontrainer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PokemonStartUp
    {
        static void Main(string[] args)
        {
            var pokemonInfo = Console.ReadLine();

            var trainerList = new Dictionary<string, List<Pokemon>>();

            var trainer = new List<Trainer>();

            while (pokemonInfo != "Tournament")
            {
                var splitInfo = pokemonInfo.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                var name = splitInfo[0];
                var pokemon = splitInfo[1];
                var pokElement = splitInfo[2];
                var pokHealth = int.Parse(splitInfo[3]);

                var pokemons = new Pokemon(pokemon, pokElement, pokHealth);

                if (!trainerList.ContainsKey(name))
                {
                    trainerList.Add(name, new List<Pokemon>());
                }
                trainerList[name].Add(pokemons);

                pokemonInfo = Console.ReadLine();
            }

            foreach (var name in trainerList)
            {
                trainer.Add(new Trainer(name.Key, 0, name.Value));
            }

            var elementInfo = Console.ReadLine().Trim();
            while (elementInfo != "End")
            {
                switch (elementInfo)
                {
                    case "Fire": FindElement(trainer, elementInfo); break;
                    case "Electricity": FindElement(trainer, elementInfo); break;
                    case "Water": FindElement(trainer, elementInfo); break;
                    default:
                        break;
                }

                elementInfo = Console.ReadLine().Trim();
            }

            var result = trainer.OrderByDescending(x => x.Badges).ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} {item.Badges} {item.Pokemons.Count()}");
            }
        }

        private static void FindElement(List<Trainer> trainer, string elementInfo)
        {
            foreach (var tr in trainer)
            {
                foreach (var pok in tr.Pokemons)
                {
                    if (pok.Element == elementInfo)
                    {
                        tr.Badges += 1;
                        break;
                    }
                    else
                    {
                        pok.Health -= 10;
                        if (pok.Health <= 0)
                        {
                            tr.Pokemons.Remove(pok);
                            break;
                        }
                    }
                }
            }
        }
    }
}

