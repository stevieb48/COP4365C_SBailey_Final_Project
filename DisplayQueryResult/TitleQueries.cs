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
using BookClasses;
using BooksExamples;

/*
 * This form is used to display data stored in the Books database which contains 3 tables
 * (Titles, Authors, AuthorISBN) using Entity framework and LINQ.
 * 
 * It also contains a combobox at the bottom with 3 choices of what user can display in the 
 * textbox from the DB.
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

        // enitity framework DbContext
        private BooksExamples.BooksEntities dbcontext = new BooksExamples.BooksEntities();

        // when combo box changes change the textbox
        private void CmbbxQueries_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Return db results into object
            var BookEntryList = (from a in dbcontext.Authors
                                 join at in dbcontext.AuthorISBNs on a.AuthorID equals at.AuthorID
                                 join t in dbcontext.Titles on at.ISBN equals t.ISBN
                                 orderby t.Title1, a.LastName, a.FirstName
                                 select new BookEntry() { FirstNameAuthor = a.FirstName, LastNameAuthor = a.LastName, BookTitle = t.Title1 }).ToList();

            // set data displayed according to what is selected
            switch (cmbbxQueries.SelectedIndex)
            {
                case 0: // List All titles with their authors. Sorted by title

                    // header
                    txtbxResults.AppendText("\r\n\r\nList All titles with their authors, Sorted by title:");

                    // for each entry in the result list
                    foreach (var entry in BookEntryList)
                    {
                        // add to the text box
                        txtbxResults.AppendText("\r\n\t" + entry.BookTitle + " " + entry.FirstNameAuthor + " " + entry.LastNameAuthor + ":");
                    }

                    break;
                case 1: // All titles and the authors. Sorted by title. For each title sort authors A-Z last name, then first

                    // header
                    txtbxResults.AppendText("\r\n\r\nList All titles and the authors, Sorted by title, and For each title sort authors A-Z last name, then first name:");

                    // for each entry in the results
                    foreach (var entry in BookEntryList)
                    {
                        // add to the text box
                        txtbxResults.AppendText("\r\n\t" + entry.BookTitle + " " + entry.LastNameAuthor + " " + entry.FirstNameAuthor + ":");
                    }

                    break;
                case 2: // List All authors, Group by title, Sorted by title, and For each title sort authors A-Z last name, then A-Z first name

                    //Gets all distinct Authors
                    var distinctAuthors = BookEntryList.Select(m => new { m.LastNameAuthor, m.FirstNameAuthor }).Distinct();

                    // list of authors
                    var list = new List<AuthorEntry>();

                    // header
                    txtbxResults.AppendText("\r\n\r\nList All authors, Group by title, Sorted by title, and For each title sort authors A-Z last name, then first name:");

                    // for each author in distinct authors list
                    foreach (var a in distinctAuthors)
                    {
                        // add an entry
                        var entry = new AuthorEntry
                        {
                            FirstNameAuthor = a.FirstNameAuthor,
                            LastNameAuthor = a.LastNameAuthor,
                            BookTitles = BookEntryList.Where(x => x.FirstNameAuthor == a.FirstNameAuthor
                                && x.LastNameAuthor == a.LastNameAuthor).Select(y => y.BookTitle).ToList()
                        };

                        // add entry to list
                        list.Add(entry);
                    }

                    // for each author in list
                    foreach (var author in list)
                    {
                        // add to the text box
                        txtbxResults.AppendText("\r\n\t" + author.LastNameAuthor + " " + author.FirstNameAuthor + ":");

                        // for each title in author
                        foreach (var title in author.BookTitles)
                        {
                            // add to the text box
                            txtbxResults.AppendText("\r\n\t\t" + title);
                        }
                    }

                    break;
            } // end switch
        } // end method cmbbxQueries_SelectedIndexChanged
    } // end class TitleQueries
} // end namespace DisplayQueryResults