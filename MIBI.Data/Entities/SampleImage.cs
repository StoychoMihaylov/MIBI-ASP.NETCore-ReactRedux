namespace MIBI.Data.Entities
{
    public class SampleImage
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string UniqueName { get; set; }

        public string Type { get; set; }

        public virtual Sample Sample { get; set; }
    }
}
