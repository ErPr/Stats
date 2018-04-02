using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            //string currentDirectory = Directory.GetCurrentDirectory();
            //DirectoryInfo directory = new DirectoryInfo(currentDirectory);

            //var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            //var fileContents = ReadSoccerResults(fileName);

            ////foreach(var game in fileContents)
            ////{
            ////    Console.WriteLine(game.TeamName);
            ////}

            //fileName = Path.Combine(directory.FullName, "players.json");
            //var players = DeserializePlayers(fileName);
            //var topTenPlayers = GetTopTenPlayers(players);

            //foreach(var player in topTenPlayers)
            //{
            //    Console.WriteLine("Name " + player.FirstName + " PPG: " + player.PointsPerGame);
            //}

            //fileName = Path.Combine(directory.FullName, "topten.json");
            //SerializePlayersToFile(topTenPlayers, fileName);

            //Console.WriteLine(GetGoogleHomePage());

            Console.WriteLine(GetNewsForPlayer("Marco Pappa"));
        }

        public static string ReadFile(string fileName)
        {
            using (var CSVReader = new StreamReader(fileName))
            {
                return CSVReader.ReadToEnd();
            }
        }

        public static List<GameResult> ReadSoccerResults(string fileName)
        {
            var soccerResults = new List<GameResult>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                //reader.ReadLine()'s function here is to read the first line of 'headers' before the while loop.  That they are sort of thrown away for now.'
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    var gameResult = new GameResult();
                    string[] values = line.Split(',');
                    // replaced: gameResult.GameDate = DateTime.Parse(values[0]);

                    DateTime gameDate;
                    if (DateTime.TryParse(values[0], out gameDate))
                    {
                        gameResult.GameDate = gameDate;
                    }
                    gameResult.TeamName = values[1];

                    HomeOrAway homeOrAway;
                    if(Enum.TryParse(values[2], out homeOrAway))
                    {
                        gameResult.HomeOrAway = homeOrAway;
                    }

                    int parseInt;
                    if (int.TryParse(values[3], out parseInt))
                    {
                        gameResult.Goals = parseInt;
                    }

                    if (int.TryParse(values[4], out parseInt))
                    {
                        gameResult.GoalAttempts = parseInt;
                    }

                    if (int.TryParse(values[5], out parseInt))
                    {
                        gameResult.ShotsOnGoal = parseInt;
                    }

                    if (int.TryParse(values[6], out parseInt))
                    {
                        gameResult.ShotsOffGoal = parseInt;
                    }

                    double pocessionPercent;
                    if (double.TryParse(values[7], out pocessionPercent))
                    {
                        gameResult.PocessionPercent = pocessionPercent;
                    }

                    // a way to calculate and store the ConverstionRate
                    //gameResult.ConversionRate = (double)gameResult.Goals / gameResult.GoalAttempts;

                    soccerResults.Add(gameResult);
                }
            }
            return soccerResults;
        }

        public static List<Player> DeserializePlayers(string fileName)
        {
            var players = new List<Player>();
            var serializer = new JsonSerializer();

            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
             players = serializer.Deserialize<List<Player>>(jsonReader);
            }

            return players;
        }

        public static List<Player> GetTopTenPlayers(List<Player> players)
        {
            var topTenPlayers = new List<Player>();
            players.Sort(new PlayerComparer());

            int counter = 0;
            foreach(var player in players)
            {
                topTenPlayers.Add(player);
                counter++;

                if (counter >= 10)
                {
                    break;
                }
            }

            return topTenPlayers;
        }

        public static void SerializePlayersToFile(List<Player> players, string fileName)
        {
            var serializer = new JsonSerializer();

            using (var writer= new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, players);
            }
        }

        public static string GetGoogleHomePage()
        {
            var webClient = new WebClient();
            byte[] googleHome = webClient.DownloadData("https://www.google.com");

            using (var stream = new MemoryStream(googleHome))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<NewsResult> GetNewsForPlayer(string playerName)
        {
            var results = new List<NewsResult>();
            var webClient = new WebClient();
            webClient.Headers.Add("Ocp-Apim-Subscription-Key", "4584b815873847faa9c79da363daac3a");
            byte[] searchResults = webClient.DownloadData(string.Format("https://api.cognitive.microsoft.com/bing/v7.0/news/search?q={0}&mkt=en-us", playerName));

            var serializer = new JsonSerializer();

            using (var stream = new MemoryStream(searchResults))
            using (var reader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(reader))
            {
                results = serializer.Deserialize<NewsSearch>(jsonReader).NewsResults;
            }
            return results;
        }

    }
}