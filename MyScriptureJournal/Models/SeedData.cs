using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;
using System;
using System.Linq;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Book = "Jacob",
                        Chapter = "4",
                        Verse = "7",
                        Note = "Atonement",
                        CreatedDate = new DateTime(2017,3,1)
                    },

                    new Scripture
                    {
                        Book = "Alma",
                        Chapter = "6",
                        Verse = "12",
                        Note = "Christ Sacrifice",
                        CreatedDate = new DateTime(2019, 10, 11)
                    },

                    new Scripture
                    {
                        Book = "Moroni",
                        Chapter = "10",
                        Verse = "10",
                        Note = "Holy Ghost",
                        CreatedDate = new DateTime(2021, 2, 1)
                    },

                    new Scripture
                    {
                        Book = "Either",
                        Chapter = "7",
                        Verse = "21",
                        Note = "Repentance",
                        CreatedDate = new DateTime(2020, 9, 21)
                    }
                );
                context.SaveChanges();
            }
        }
    }
}