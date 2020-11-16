using CsvHelper.Configuration.Attributes;
using System;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace cw2
{
    [Serializable]
    public class Student
    {
        [Index(0)]
        [JsonPropertyName("Imie")]
        [XmlElement(ElementName = "Imie")]
        public string FirstName { get; set; }

        [Index(1)]
        [JsonPropertyName("Nazwisko")]
        [XmlElement(ElementName = "Nazwisko")]
        public string LastName { get; set; }
        [Index(2)]
        [JsonPropertyName("Kierunek")]
        [XmlElement(ElementName = "Kierunek")]
        public string FieldOfStudy { get; set; }
        [Index(3)]
        [JsonPropertyName("Tryb")]
        [XmlElement(ElementName = "Tryb")]
        public string Mode { get; set; }
        [Index(4)]
        [JsonPropertyName("Numer indeksu")]
        [XmlElement(ElementName = "Numer indeksu")]
        public string IndexNumber { get; set; }
        [Index(5)]
        [JsonPropertyName("Data urodzenia")]
        [XmlElement(ElementName = "Data urodzenia")]
        public DateTime BirthDate { get; set; }
        [Index(6)]
        [JsonPropertyName("Imie matki")]
        [XmlElement(ElementName = "Imie matki")]
        public string MotherFirstName { get; set; }
        [Index(7)]
        [JsonPropertyName("Imie ojca")]
        [XmlElement(ElementName = "Imie ojca")]
        public string FatherFirstName { get; set; }
    }
}