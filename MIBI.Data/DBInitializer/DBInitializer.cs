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
                new Tag() { Name = "bright white" },
                new Tag() { Name = "white" },
                new Tag() { Name = "white-grey" },
                new Tag() { Name = "light" },
                new Tag() { Name = "yellow" },
                new Tag() { Name = "medium yellow" },
                new Tag() { Name = "dark yellow" },
                new Tag() { Name = "light orange" },
                new Tag() { Name = "medium orange" },
                new Tag() { Name = "dark orange" }
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
                new Group() { Name = "g+Co" },
                new Group() { Name = "g+Rod S-" },
                new Group() { Name = "g+Rod S+" },
                new Group() { Name = "g-Rod" },
                new Group() { Name = "actinomyces spp." },
                new Group() { Name = "mold" }
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
