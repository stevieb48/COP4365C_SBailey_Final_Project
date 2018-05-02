using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BooksExamples;

/*
 * This form ...
 * 
 * author: Stephen Bailey
 * course: COP4365C
 * assignment: Final Project
 * date: 04/30/2018
 * file name: TitleQueries.cs
 * version: 1.0
 */
namespace DisplayQueryResult
{
    public partial class TitleQueries : Form
    {
        // constructor
        public TitleQueries()
        {
            InitializeComponent();
        } // end contructor

        public class BookEntry
        {
            public string BookTitle { get; set; }
            public string FirstNameAuthor { get; set; }
            public string LastNameAuthor { get; set; }
        }

        public class AuthorEntry
        {
            public List<string> BookTitles { get; set; }
            public string FirstNameAuthor { get; set; }
            public string LastNameAuthor { get; set; }
        }

        // enitity framework DbContext
        private BooksExamples.BooksEntities dbcontext = new BooksExamples.BooksEntities();

        // when combo box changes change the textbox
        private void CmbbxQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Return db results into object
            var BookEntryList = (from a in dbcontext.Authors
                                 join at in dbcontext.AuthorISBNs on a.AuthorID equals at.AuthorID
                                 join t in dbcontext.Titles on at.ISBN equals t.ISBN
                                 orderby t.Title1
                                 select new BookEntry() { FirstNameAuthor = a.FirstName, LastNameAuthor = a.LastName, BookTitle = t.Title1 }).ToList();

            // set data displayed according to what is selected
            switch (cmbbxQueries.SelectedIndex)
            {
                case 0: // List All titles with their authors. Sorted by title

                    // header
                    txtbxResults.AppendText("\r\n\r\nList All titles with their authors, Sorted by title:");

                    foreach (var entry in BookEntryList)
                    {
                        txtbxResults.AppendText("\r\n\t" + entry.BookTitle + " " + entry.FirstNameAuthor + " " + entry.LastNameAuthor + ":");
                    }

                    break;
                case 1: // All titles and the authors. Sorted by title. For each title sort authors A-Z last name, then first

                    // header
                    txtbxResults.AppendText("\r\n\r\nList All titles and the authors, Sorted by title, and For each title sort authors A-Z last name, then first name:");

                    foreach (var entry in BookEntryList)
                    {
                        txtbxResults.AppendText("\r\n\t" + entry.BookTitle + " " + entry.LastNameAuthor + " " + entry.FirstNameAuthor + ":");
                    }

                    break;
                case 2: // List All authors, Group by title, Sorted by title, and For each title sort authors A-Z last name, then A-Z first name

                    //Gets all distinct Authors
                    var distinctAuthors = BookEntryList.Select(m => new { m.LastNameAuthor, m.FirstNameAuthor }).Distinct();

                    var list = new List<AuthorEntry>();

                    // header
                    txtbxResults.AppendText("\r\n\r\nList All authors, Group by title, Sorted by title, and For each title sort authors A-Z last name, then A-Z first name:");

                    foreach (var a in distinctAuthors)
                    {
                        var entry = new AuthorEntry();
                        entry.FirstNameAuthor = a.FirstNameAuthor;
                        entry.LastNameAuthor = a.LastNameAuthor;
                        entry.BookTitles = BookEntryList.Where(x =>
                            x.FirstNameAuthor == a.FirstNameAuthor && x.LastNameAuthor == a.LastNameAuthor).Select(y => y.BookTitle).ToList();
                        list.Add(entry);
                    }

                    foreach (var author in list)
                    {
                        txtbxResults.AppendText("\r\n\t" + author.LastNameAuthor + " " + author.FirstNameAuthor + ":");
                        foreach (var title in author.BookTitles)
                        {
                            txtbxResults.AppendText("\r\n\t\t" + title);
                        }
                    }

                    break;
            } // end switch
        } // end method cmbbxQueries_SelectedIndexChanged
    } // end class TitleQueries
} // end namespace DisplayQueryResults