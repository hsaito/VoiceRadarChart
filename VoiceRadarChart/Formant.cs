using CsvHelper.Configuration.Attributes;

public class Formant
{
    public static double[] ExtractFormants(FormantRecord r)
    {
        return new double[]
        {
            r.F1,
            r.F2,
            r.F3,
            r.F4,
            r.F5
        };
    }

    public class FormantRecord
    {
        [Name("time(s)")]
        public double Time { get; set; }

        [Name("nformants")]
        public int NFormants { get; set; }

        [Name("F1(Hz)")]
        public double F1 { get; set; }

        [Name("B1(Hz)")]
        public double B1 { get; set; }

        [Name("F2(Hz)")]
        public double F2 { get; set; }

        [Name("B2(Hz)")]
        public double B2 { get; set; }

        [Name("F3(Hz)")]
        public double F3 { get; set; }

        [Name("B3(Hz)")]
        public double B3 { get; set; }

        [Name("F4(Hz)")]
        public double F4 { get; set; }

        [Name("B4(Hz)")]
        public double B4 { get; set; }

        [Name("F5(Hz)")]
        public double F5 { get; set; }

        [Name("B5(Hz)")]
        public double B5 { get; set; }
    }
}