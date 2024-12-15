using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace csh_wf_guess_number_game
{
    public class GameLogic
    {
        private int randomNumber; //number to guess

        public int Attempts { get; private set; } // count of user attempts

        private Random random;


        public GameLogic()
        {
            random = new Random();
        }

        // Starts new game by generating a random number and resetting attempts
        public void StartGame(int min, int max)
        {
            randomNumber = random.Next(min, max + 1); // random number in range

            Attempts = 0; // reset attempts counter
        }

        //public int GetRandomNumber()
        //{
        //    return randomNumber;
        //}

        public string CheckGuess(int userGuess) 
        {
            Attempts++;

            // non-SRP compliant: move strings out of here
            if (userGuess < randomNumber)
            {
                //labelMessage.Text = "Number is bigger.";
                return "Number is bigger.";
            }
            else if (userGuess > randomNumber)
            {
                //labelMessage.Text = "Number is smaller.";
                return "Number is smaller.";
            }
            else
            {
                return "Correct!";

                //MessageBox.Show($"Congrats! You guessed it for {attempts} attempts.", "Win");
                //StartGame();
            }
        }

        // Validates if input a valid number
        //public bool Validate(string input, out int result)
        //{
        //    return int.TryParse(input, out result);
        //}
    }

    // Data model layer
    public class GameRecord
    {
        public string PlayerName { get; set; }
        public int Attempts { get; set; }
        public int TimeTaken { get; set; } // time in seconds
        public DateTime Date { get; set; }
    }

    // Access data model over interface
    public interface IData
    {
        void AddRecord(GameRecord record);

        List<GameRecord> GetAllRecords();
    }

    // keep records in memory
    public class InMemoryData : IData
    {
        private readonly List<GameRecord> records = new List<GameRecord>();

        // no ctor needed

        public void AddRecord(GameRecord record)
        {
            records.Add(record);
        }

        public List<GameRecord> GetAllRecords()
        {
            return new List<GameRecord>(records);
        }

    }

    // read and write data on local disk
    public class FileData : IData
    {
        private readonly string _path; // _local _private syntax

        public FileData(string filePath)
        {
            _path = filePath;

            // create file
            if (!File.Exists(_path))
            {
                //File.WriteAllText(_path, "[]"); // JSON serialization

                SaveRecords(new List<GameRecord>()); // XML serialization
            }
        }

        public void AddRecord(GameRecord record)
        {
            try
            {
                var records = GetAllRecords();

                records.Add(record); // get add save

                SaveRecords(records);
            }
            catch (Exception)
            {
                // sure?
                throw;
            }

        }

        public List<GameRecord> GetAllRecords()
        {
            try
            {
                // read records from deserialized xml over a stream
                using (var stream = new FileStream(_path, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(List<GameRecord>));

                    return (List<GameRecord>)serializer.Deserialize(stream) ?? new List<GameRecord>();
                }
            }
            catch
            {
                return new List<GameRecord>(); // recreate and return empty
            }
        }

        private void SaveRecords(List<GameRecord> records)
        {
            // save records to a stream and to serialized xml
            using (var stream = new FileStream(_path, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(List<GameRecord>));

                serializer.Serialize(stream, records);
            }
        }
    }
}
