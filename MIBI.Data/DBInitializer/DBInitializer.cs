﻿namespace MIBI.Data.DBInitilizer
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using MIBI.Data.Context;
    using MIBI.Data.Entities;

    public static class DBInitializer
    {
        public static void SeedDb(MIBIContext context)
        {
            context.Database.EnsureCreated();
            SeedGroups(context);
            SeedTags(context);
            SeedNutrientAgarPlates(context);
            //SeedSamples(context); 
        }

        private static void SeedSamples(MIBIContext context)
        {
            var dummyDescriptionText = @"Contrary to popular belief, Lorem Ipsum is not simply random text.
            It has roots in a piece of classical Latin literature from 45 BC,
            making it over 2000 years old. Richard McClintock, a Latin professor at
            Hampden-Sydney College in Virginia, looked up one of the more obscure Latin
            words, consectetur, from a Lorem Ipsum passage, and going through the cites
            of the word in classical literature, discovered the undoubtable source. Lorem
            Ipsum comes from sections 1.10.32 and 1.10.33 of de Finibus Bonorum et Malorum(The Extremes of Good and Evil)
            by Cicero, written in 45 BC. This book is a treatise on the theory of ethics,
            very popular during the Renaissance. The first line of Lorem Ipsum, comes from a line in
            section 1.10.32.The standard chunk of Lorem Ipsum used since the 1500s is reproduced
            below for those interested. Sections 1.10.32 and 1.10.33 from by Cicero are also
            reproduced in their exact original form, accompanied by English versions from the
            1914 translation by H.Rackham.";

            var step = 200;
            var samples = new List<Sample>();
            for (int i = 0; i < 100000; i++)
            {
                var newSapmple = new Sample()
                {
                    Name = $"test{i}",
                    Description = dummyDescriptionText,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "Initializier",
                    Images = new List<SampleImage>()
                    {
                        new SampleImage()
                        {
                            Url = "00ac5511-e30c-44c4-86c9-4bd3ec0bbb9b.jpg"
                        },
                        new SampleImage()
                        {
                            Url = "07741d33-746a-45d2-b15a-848957f59f0a.jpg"
                        },
                        new SampleImage()
                        {
                            Url = "09eeb01e-48a1-4ca2-8d10-00ae537fa097.jpg"
                        },
                    }
                };

                samples.Add(newSapmple);

                if (step == i)
                {
                    context.Samples.AddRange(samples);
                    context.SaveChanges();

                    samples.Clear();
                    step += 200;
                }
            }
        }

        private static void SeedNutrientAgarPlates(MIBIContext context)
        {
            var nutrients = new List<NutrientAgarPlate>();
            var existingNutrients = context.NutrientAgarPlates.ToList();
            var newNutriens = new List<NutrientAgarPlate>()
            {
                new NutrientAgarPlate() { Name = "tryptic-soy-agar(TSA)" },
                new NutrientAgarPlate() { Name = "sabouraud-dextrose-agar(SDA)" },
                new NutrientAgarPlate() { Name = "malt-extracta-agar(MEA)" },
                new NutrientAgarPlate() { Name = "malt-extract-agar(MEA)" },
                new NutrientAgarPlate() { Name = "TTC-tergitol 7 Agar" },
                new NutrientAgarPlate() { Name = "Slanetz Bartley Agar" },
                new NutrientAgarPlate() { Name = "Cetrimid Agar" },
            };

            if (existingNutrients.Count() > 0)
            {
                foreach (var newNutr in newNutriens)
                {
                    var contains = false;
                    foreach (var existingTag in existingNutrients)
                    {
                        if (newNutr.Name == existingTag.Name)
                        {
                            contains = true;
                        }
                    }

                    if (!contains)
                    {
                        nutrients.Add(newNutr);
                    }
                }

                context.NutrientAgarPlates.AddRange(nutrients);
                context.SaveChanges();
            }
            else
            {
                context.NutrientAgarPlates.AddRange(newNutriens);
                context.SaveChanges();
            }
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
                new Tag() { IconUrl ="flat.png", Name = "flat", Category= "Elevations" },
                new Tag() { IconUrl ="raised.png", Name = "raised", Category= "Elevations" },
                new Tag() { IconUrl = "umbonate.png", Name = "umbonate", Category= "Elevations" },
                new Tag() { IconUrl = "crateriform.png", Name = "crateriform", Category= "Elevations"  },
                new Tag() { IconUrl = "convex.png", Name = "convex", Category= "Elevations" },
                new Tag() { IconUrl = "pulvinate.png", Name = "pulvinate", Category= "Elevations" },
                new Tag() { IconUrl = "circular.png", Name = "circular", Category= "Form" },
                new Tag() { IconUrl = "irregular.png", Name = "irregular", Category= "Form" },
                new Tag() { IconUrl= "filamentous.png", Name = "filamentous", Category= "Form" },
                new Tag() { IconUrl = "rhizoid.png", Name = "rhizoid", Category= "Form" },
                new Tag() { IconUrl = "curled.png", Name = "curled", Category= "Form" },
                new Tag() { Name = "shiny", Category= "Surface appearance" },
                new Tag() { Name = "dull", Category= "Surface appearance" },
                new Tag() { Name = "smooth", Category= "Surface appearance" },
                new Tag() { Name = "rough", Category= "Surface appearance" },
                new Tag() { Name = "wrinkled", Category= "Surface appearance" },
                new Tag() { Name = "glistening", Category= "Surface appearance" },
                new Tag() { Name = "dry", Category="Consistency" },
                new Tag() { Name = "moist", Category="Consistency" },
                new Tag() { Name = "brittle/friable", Category="Consistency" },
                new Tag() { Name = "mucoid", Category="Consistency" },
                new Tag() { Name = "transparent", Category="Colors" },
                new Tag() { Name = "Milky", Category="Colors" },
                new Tag() { Color = "#FFFFFF", Name = "white", Category="Colors" },
                new Tag() { Color = "#DFDEDE", Name = "grey-light", Category="Colors" },
                new Tag() { Color = "#474646", Name = "grey-dark", Category="Colors" },
                new Tag() { Color = "#F6DDD0", Name = "beige-light ", Category="Colors" },
                new Tag() { Color = "#F3BFA5", Name = "beige", Category="Colors" },
                new Tag() { Color = "#E48E63", Name = "beige-dark", Category="Colors" },
                new Tag() { Color = "#FCEE94", Name = "yellow-white", Category="Colors" },
                new Tag() { Color = "#F2DD55", Name = "yellow", Category="Colors" },
                new Tag() { Color = "#E6C803", Name = "yellow-dark", Category="Colors" },
                new Tag() { Color = "#FFB266", Name = "orange-light", Category="Colors" },
                new Tag() { Color = "#FC9024", Name = "orange", Category="Colors" },
                new Tag() { Color = "#DE6F00", Name = "orange-dark", Category="Colors" },
                new Tag() { Color = "#F7DCDC", Name = "rose-light-1", Category="Colors" },
                new Tag() { Color = "#EFAAAA", Name = "rose-light-2", Category="Colors" },
                new Tag() { Color = "#F7ADAD", Name = "rose", Category="Colors" },
                new Tag() { Color = "#E67878", Name = "rose-dark", Category="Colors" },
                new Tag() { Color = "#B35151", Name = "rose-dark-2", Category="Colors" },
                new Tag() { Color = "#F9D1F2", Name = "pink-light", Category="Colors" },
                new Tag() { Color = "#FF86EB", Name = "pink", Category="Colors" },
                new Tag() { Color = "#E111BE", Name = "pink-dark", Category="Colors" },
                new Tag() { Color = "#FF6F6F", Name = "red-light", Category="Colors" },
                new Tag() { Color = "#FF4343", Name = "red", Category="Colors" },
                new Tag() { Color = "#CE0606", Name = "red-dark", Category="Colors" },
                new Tag() { Color = "#D8B6FF", Name = "purple-light", Category="Colors" },
                new Tag() { Color = "#924FDE", Name = "purple", Category="Colors" },
                new Tag() { Color = "#45177A", Name = "purple-dark", Category="Colors" },
                new Tag() { Color = "#CCE5FF", Name = "blue-light", Category="Colors" },
                new Tag() { Color = "#3C84D5", Name = "blue", Category="Colors" },
                new Tag() { Color = "#07458D", Name = "blue-dark", Category="Colors" },
                new Tag() { Color = "#D1F0CB", Name = "green-light", Category="Colors" },
                new Tag() { Color = "#00CC00", Name = "green", Category="Colors" },
                new Tag() { Color = "#0C610C", Name = "green-dark", Category="Colors" },
                new Tag() { Color = "#C1996B", Name = "brown-light", Category="Colors" },
                new Tag() { Color = "#644829", Name = "brown-dark", Category="Colors" },
                new Tag() { Color = "#39342F", Name = "black", Category="Colors" },
                new Tag() { Color = "#110900", Name = "black-dark", Category="Colors" },
            };

            if (existingTags.Count() > 0)
            {
                foreach (var newTag in newTags)
                {
                    var contians = false;
                    foreach (var existingTag in existingTags)
                    {
                        if (newTag.Name == existingTag.Name)
                        {
                            contians = true;
                        }
                    }

                    if (!contians)
                    {
                        tags.Add(newTag);
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
                    var contains = false;
                    foreach (var existingGroup in existingGroups)
                    {
                        if (newGroup.Name == existingGroup.Name)
                        {
                            contains = true;
                        }
                    }

                    if (!contains)
                    {
                        groups.Add(newGroup);
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
