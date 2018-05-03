using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * This class represents an author entry with a list of book titles
 * 
 * author: Stephen Bailey
 * course: COP4365C
 * assignment: Final Project
 * date: 04/30/2018
 * file name: AuthorEntry.cs
 * version: 1.0
 */
namespace BookClasses
{
    public class AuthorEntry
    {
        public List<string> BookTitles { get; set; }
        public string FirstNameAuthor { get; set; }
        public string LastNameAuthor { get; set; }
    }
}
