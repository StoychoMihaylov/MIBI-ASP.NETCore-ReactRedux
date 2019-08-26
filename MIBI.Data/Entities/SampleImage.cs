namespace MIBI.Data.Entities
{
    public class SampleImage
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public virtual Sample Sample { get; set; }
    }
}
