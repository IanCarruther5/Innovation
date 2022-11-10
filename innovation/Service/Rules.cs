using System.Text.Json;
using innovation.Interface;
using innovation.Model;

namespace innovation.Service
{
    public class Rules:IRules
    {
        private readonly string _FileLocation;
        public Rules(string fileLocation)
        {
            _FileLocation = fileLocation;
        }

        public List<OrderRule> ReadRules()
        {
            if (!File.Exists(_FileLocation))
                return new List<OrderRule>();

            string Rules = File.ReadAllText(_FileLocation);

            return Rules == null ? new List<OrderRule>() : JsonSerializer.Deserialize<List<OrderRule>>(Rules) ?? new List<OrderRule>();
        }
    }
}

