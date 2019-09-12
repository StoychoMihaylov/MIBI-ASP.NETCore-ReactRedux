namespace MIBI.Data.DBInitilizer
{
    using MIBI.Data.Context;
    using MIBI.Data.Entities;
    using System.Collections.Generic;
    using System.Linq;

    public static class DBInitializer
    {
        public static void SeedDb(MIBIContext context)
        {
            context.Database.EnsureCreated();
            SeedGroups(context);
            SeedTags(context);
        }

        private static void SeedTags(MIBIContext context)
        {
            var tags = new List<Tag>();
            var existingTags = context.Tags.ToList();
            var newTags = new List<Tag>()
            {
                new Tag() { Name = "small size(<5mm)" },
                new Tag() { Name = "small size(<5mm)" },
                new Tag() { Name = "medium size(6-10mm)" },
                new Tag() { Name = "big size (>10 mm)" },        
                new Tag() { Name = "flat" },
                new Tag() { Name = "raised" },
                new Tag() { Name = "umbonate" },
                new Tag() { Name = "crateriform" },
                new Tag() { Name = "convex" },
                new Tag() { Name = "pulvinate" },
                new Tag() { Name = "circular" },
                new Tag() { Name = "irregular" },
                new Tag() { Name = "filamentous" },
                new Tag() { Name = "rhizoid" },
                new Tag() { Name = "curled" },
                new Tag() { Name = "shiny" },
                new Tag() { Name = "dull" },
                new Tag() { Name = "smooth" },
                new Tag() { Name = "rough" },
                new Tag() { Name = "wrinkled" },
                new Tag() { Name = "glistening" },
                new Tag() { Name = "dry" },
                new Tag() { Name = "moist" },
                new Tag() { Name = "brittle/friable" },
                new Tag() { Name = "mucoid" },
                new Tag() { Name = "transparent" },
                new Tag() { Name = "Milky" },
                new Tag() { Color = "#FFFFFF", Name = "white" },
                new Tag() { Color = "#DFDEDE", Name = "grey-light" },
                new Tag() { Color = "#474646", Name = "grey-dark" },
                new Tag() { Color = "#F6DDD0", Name = "beige-light " },
                new Tag() { Color = "#F3BFA5", Name = "beige" },
                new Tag() { Color = "#E48E63", Name = "beige-dark" },
                new Tag() { Color = "#F2DD55", Name = "yellow" },
                new Tag() { Color = "#E6C803", Name = "yellow-dark" },
                new Tag() { Color = "#FFB266", Name = "orange-light" },
                new Tag() { Color = "#FC9024", Name = "orange" },
                new Tag() { Color = "#DE6F00", Name = "orange-dark" },
                new Tag() { Color = "#F7DCDC", Name = "rose-light-1" },
                new Tag() { Color = "#EFAAAA", Name = "rose-light-2" },
                new Tag() { Color = "#F7ADAD", Name = "rose" },
                new Tag() { Color = "#E67878", Name = "rose-dark" },
                new Tag() { Color = "#B35151", Name = "rose-dark-2" },
                new Tag() { Color = "#F9D1F2", Name = "pink-light" },
                new Tag() { Color = "#FF86EB", Name = "pink" },
                new Tag() { Color = "#E111BE", Name = "pink-dark" },
                new Tag() { Color = "#FF6F6F", Name = "red-light" },
                new Tag() { Color = "#FF4343", Name = "red" },
                new Tag() { Color = "#CE0606", Name = "red-dark" },
                new Tag() { Color = "#D8B6FF", Name = "purple-light" },
                new Tag() { Color = "#924FDE", Name = "purple" },
                new Tag() { Color = "#45177A", Name = "purple-dark" },
                new Tag() { Color = "#CCE5FF", Name = "blue-light" },
                new Tag() { Color = "#3C84D5", Name = "blue" },
                new Tag() { Color = "#07458D", Name = "blue-dark" },
                new Tag() { Color = "#D1F0CB", Name = "green-light" },
                new Tag() { Color = "#00CC00", Name = "green" },
                new Tag() { Color = "#0C610C", Name = "green-dark" },
                new Tag() { Color = "#C1996B", Name = "brown-light" },
                new Tag() { Color = "#644829", Name = "brown-dark" },
                new Tag() { Color = "#39342F", Name = "black" },
                new Tag() { Color = "#110900", Name = "black-dark" },
            };

            if (existingTags.Count() > 0)
            {
                foreach (var newTag in newTags)
                {
                    foreach (var existingTag in existingTags)
                    {
                        if (newTag == existingTag)
                        {
                            tags.Add(newTag);
                        }
                    }
                }

                context.Tags.AddRange(tags);
                context.SaveChanges();
            }
            else
            {
                context.Tags.AddRange(newTags);
                context.SaveChanges();
            }
        }

        private static void SeedGroups(MIBIContext context)
        {
            var groups = new List<Group>();
            var existingGroups = context.Groups.ToList();
            var newGroups = new List<Group>()
            {
                new Group() { Name = "g+co" },
                new Group() { Name = "g+rod" },
                new Group() { Name = "g+rodsp-" },
                new Group() { Name = "g+rodsp+" },
                new Group() { Name = "g-rods" },
                new Group() { Name = "actinomyces" },
                new Group() { Name = "yeast" },
                new Group() { Name = "mold" },
            };

            if (existingGroups.Count() > 0)
            {
                foreach (var newGroup in newGroups)
                {
                    foreach (var existingGroup in existingGroups)
                    {
                        if (newGroup == existingGroup)
                        {
                            groups.Add(newGroup);
                        }
                    }
                }

                context.Groups.AddRange(groups);
                context.SaveChanges();
            }
            else
            {
                context.Groups.AddRange(newGroups);
                context.SaveChanges();
            }
        }
    }
}
