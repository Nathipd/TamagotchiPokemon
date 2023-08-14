using System;
using System.Text.Json;
using RestSharp;

namespace TamagotchiPokemon
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose your Pokémon: ");
            Console.WriteLine("1 - Charmander");
            Console.WriteLine("2 - Pikachu");
            Console.WriteLine("3 - Squirtle");

            var _chosenPokemon = Console.ReadLine();
            string _pokemonData = "";


            if (_chosenPokemon == "1")
            {
                _pokemonData = CallGet("charmander"); // Get the pokemon
            }
            else if (_chosenPokemon == "2")
            {
                _pokemonData = CallGet("pikachu"); // Get the pokemon
            }
            else if(_chosenPokemon == "3")
            {
                _pokemonData = CallGet("squirtle"); // Get the pokemon
            }
            else
            {
                Console.WriteLine("Invalid option");
            }

            Console.WriteLine(_pokemonData);
        }

        private static string CallGet(string pokemonName)
        {
            var client = new RestClient($" https://pokeapi.co/api/v2/pokemon/{pokemonName}/"); //the client

            RestRequest request = new RestRequest("", Method.Get); //get method

            var response = client.ExecuteAsync(request).GetAwaiter().GetResult(); //the response

            if (response.StatusCode == System.Net.HttpStatusCode.OK) //if works write the content
                return response.Content;
            else
            {
               return response.ErrorMessage; //if doesn't work write the error message
            }
          
        }


        public class Mascote
        {
            public List<AbilitiesClass> abilities
            {
                get; set;
            }

        }

    }


}
