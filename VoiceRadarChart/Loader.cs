using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

public class Loader
{
    public static List<Formant.FormantRecord> LoadCsv(string path)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
            MissingFieldFound = null,
            HeaderValidated = null
        };

        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, config);

        csv.Context.TypeConverterCache.AddConverter<double>(new LenientDoubleConverter());

        return csv.GetRecords<Formant.FormantRecord>().ToList();
    }

    private sealed class LenientDoubleConverter : DoubleConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text) || text == "--undefined--")
                return double.NaN;

            if (double.TryParse(text, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out double value))
                return value;

            return double.NaN;
        }
    }
}