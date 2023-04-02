using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CoursesAPI.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CoursesAPIContext(
            serviceProvider.GetRequiredService<DbContextOptions<CoursesAPIContext>>()))
            {
                context.Database.EnsureCreated();
                // Look for any Course.
                if (context.Course.Any())
                {
                    return; // DB has been seeded
                }
                context.Course.AddRange(
                new Course { Title = "Enzymology", Department = "Biology"},
                new Course { Title = "Bacterial Genetics", Department = "Biology"},
                new Course { Title = "Immunology", Department = "Biology"},
                new Course { Title = "Black and White Photography", Department = "Art"},
                new Course { Title = "Studio Art and Theory", Department = "Art"}
                );
                context.SaveChanges();
            }
        }
    }
}
