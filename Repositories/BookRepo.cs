using System.Collections.Generic;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using System.Linq;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        private DataContext _db;

        public BookRepo()
        {
            _db = new DataContext();
        }
        public int AddBook(Book book)
        {
            _db.Add(book);
            _db.SaveChanges();
            return book.Id;
        }

        public void ModBook(Book book)
        {
            _db.Update(book);
            _db.SaveChanges();
        }
        
        public void AddBookDetails(BookDetails details)
        {
            _db.Add(details);
            _db.SaveChanges();
        }

        public void ModBookDetails(BookDetails details)
        {
            _db.Update(details);
            _db.SaveChanges();
        }

        public void AddBookGenreConnection(BookGenreConnection connection)
        {
            _db.Add(connection);
            _db.SaveChanges();
        }

        public void ModBookGenreConnection(BookGenreConnection connection)
        {
            _db.Update(connection);
            _db.SaveChanges();
        }

        public void AddBookAuthorConnection(BookAuthorConnection connection)
        {
            _db.Add(connection);
            _db.SaveChanges();
        }

        public void ModBookAuthorConnection(BookAuthorConnection connection)
        {
            _db.Update(connection);
            _db.SaveChanges();
        }

        public void AddImage(CoverImage img)
        {
            _db.Add(img);
            _db.SaveChanges();
        }
        public void AddAuthor(Author author)
        {
            _db.Add(author);
            _db.SaveChanges();
        }

        public int AddGenre(Genre genre)
        {
            _db.Add(genre);
            _db.SaveChanges();
            return genre.Id;
        }

        public int AddPublisher(Publisher publisher)
        {
            _db.Add(publisher);
            _db.SaveChanges();
            return publisher.Id;
        }

        public List<BookViewModel> GetAllBooks()
        {
            var books = new List<BookViewModel>();
            foreach(var b in _db.Books)
            {
                var authors = (from bac in _db.BookAuthorConnections
                            where bac.BookId == b.Id
                            join a in _db.Authors on bac.AuthorId equals a.Id
                            select new AuthorViewModel
                            {
                                Id = a.Id,
                                Name = a.Name
                            }).ToList(); 
                
                var genres = (from bgc in _db.BookGenreConnections
                              where bgc.BookId == b.Id
                              join g in _db.Genres on bgc.GenreId equals g.Id
                              select new GenreViewModel
                              {
                                  Id = g.Id,
                                  Name = g.Name
                              }).ToList();

                var book = new BookViewModel
                {
                    Title = b.Title,
                    Isbn = b.Isbn,
                    Type = b.Type,
                    PublishingYear = b.PublishingYear,
                    Price = b.Price,
                    Author = authors,
                    Genre = genres
                };

                books.Add(book);
            }

            return books; 
        }

        public List<GenreViewModel> GetAllGenres()
        {
            var genres = (from g in _db.Genres
                          select new GenreViewModel
                          {
                              Id = g.Id,
                              Name = g.Name
                          }).ToList();
            
            return genres;
        }

        public List<AuthorViewModel> GetAllAuthors()
        {
            var authors = (from a in _db.Authors
                           select new AuthorViewModel
                           {
                               Id = a.Id,
                               Name = a.Name
                           }).ToList();

            return authors;
        }

        public List<PublisherViewModel> GetAllPublishers()
        {
            var publishers = (from p in _db.Publishers
                              select new PublisherViewModel
                              {
                                  Id = p.Id,
                                  Name = p.Name
                              }).ToList();
            
            return publishers;
        }

        public BookDetailViewModel GetBookDetails(int BookId)
        {
            var book = (from b in _db.Books
                        where b.Id == BookId
                        select b).SingleOrDefault();

            var authors = (from bac in _db.BookAuthorConnections
                            where bac.BookId == BookId
                            join a in _db.Authors on bac.AuthorId equals a.Id
                            select new AuthorViewModel
                            {
                                Id = a.Id,
                                Name = a.Name
                            }).ToList(); 
                
            var genres = (from bgc in _db.BookGenreConnections
                          where bgc.BookId == BookId
                          join g in _db.Genres on bgc.GenreId equals g.Id
                          select new GenreViewModel
                          {
                                Id = g.Id,
                                Name = g.Name
                          }).ToList();
            
            var publisher = (from p in _db.Publishers
                             where p.Id == book.PublisherId
                             select new PublisherViewModel
                             {
                                 Id = p.Id,
                                 Name = p.Name
                             }).SingleOrDefault();
            
            var details = (from d in _db.BookDetails
                           where d.BookId == BookId
                           select d).SingleOrDefault();

            var reviews = (from r in _db.BookReviews
                           where r.BookId == BookId
                           select new ReviewViewModel
                           {
                               Grade = r.Grade,
                               Review = r.Review
                           }).ToList();
            
            var bookDetails = new BookDetailViewModel
            {
                Title = book.Title,
                Author = authors,
                Publisher = publisher,
                PublishingYear = book.PublishingYear,
                Genre = genres,
                Description = details.Description,
                Price = book.Price,
                Type = book.Type,
                Font = details.Font,
                PageCount = details.PageCount,
                Length = details.Length,
                Review = reviews,
            };

            return bookDetails;
        }

        public bool ContainsIsbn(int isbn)
        {

            return false;
        }
        public bool ContainsAuthorId(int authorId)
        {
            
            return false;
        }

        public bool ContainsGenreId(int genreId)
        {
            
            return false;
        }

        public bool ContainsPublisherId(int publisher)
        {
            
            return false;
        }

        public void DeleteBook(int BookId)
        {
            var book = new Book { Id = BookId };
            _db.Books.Attach(book);
            _db.Books.Remove(book);
            
            var bookDetails = new BookDetails { Id = BookId};
            _db.BookDetails.Attach(bookDetails);
            _db.BookDetails.Remove(bookDetails);

            var genreConnection = (from bgc in _db.BookGenreConnections
                                   where bgc.BookId == BookId
                                   select bgc).ToList();
            
            foreach(var g in genreConnection)
            {
                _db.BookGenreConnections.Remove(g);
            }

            var authorConnection = (from bac in _db.BookAuthorConnections
                                    where bac.BookId == BookId
                                    select bac).ToList();
            
            foreach(var a in authorConnection)
            {
                _db.BookAuthorConnections.Remove(a);
            }

            var reviews = (from r in _db.BookReviews
                           where r.BookId == BookId
                           select r).ToList();
            
            foreach(var r in reviews)
            {
                _db.BookReviews.Remove(r);
            }

            _db.SaveChanges();
        }

        public List<BookViewModel> GetTop10()
        {


            return new List<BookViewModel>();
        }

        public List<BookViewModel> GetNewReleases()
        {
            var newReleases = (from b in _db.Books
                               orderby b.PublishingYear ascending
                               select b).Take(20);
            
            var books = new List<BookViewModel>();
            foreach(var b in newReleases)
            {
                var authors = (from bac in _db.BookAuthorConnections
                            where bac.BookId == b.Id
                            join a in _db.Authors on bac.AuthorId equals a.Id
                            select new AuthorViewModel
                            {
                                Id = a.Id,
                                Name = a.Name
                            }).ToList(); 
                
                var genres = (from bgc in _db.BookGenreConnections
                              where bgc.BookId == b.Id
                              join g in _db.Genres on bgc.GenreId equals g.Id
                              select new GenreViewModel
                              {
                                  Id = g.Id,
                                  Name = g.Name
                              }).ToList();

                var book = new BookViewModel
                {
                    Title = b.Title,
                    Isbn = b.Isbn,
                    Type = b.Type,
                    PublishingYear = b.PublishingYear,
                    Price = b.Price,
                    Author = authors,
                    Genre = genres
                };

                books.Add(book);
            }

            return books; 
        }

        
        public List<BookViewModel> GetSearchResults(BookInputModel search)
        {
            var books = (from b in _db.Books
                         where b.Title.Contains(search.Title)
                         where b.Isbn.ToString().Contains(search.Isbn.ToString())
                         where b.PublisherId == search.PublisherId || search.PublisherId == 0
                         select b);
            
            if(search.Author.Any())
            {
                books = (from bac in _db.BookAuthorConnections
                         join a in search.Author on bac.AuthorId equals a
                         join b in books on bac.BookId equals b.Id
                         select b);
            }

            if(search.Genre.Any())
            {
                books = (from bgc in _db.BookGenreConnections
                         join g in search.Genre on bgc.GenreId equals g
                         join b in books on bgc.GenreId equals b.Id
                         select b);
            }

            var results = new List<BookViewModel>();
            foreach(var b in books)
            {
                var authors = (from bac in _db.BookAuthorConnections
                            where bac.BookId == b.Id
                            join a in _db.Authors on bac.AuthorId equals a.Id
                            select new AuthorViewModel
                            {
                                Id = a.Id,
                                Name = a.Name
                            }).ToList(); 
                
                var genres = (from bgc in _db.BookGenreConnections
                              where bgc.BookId == b.Id
                              join g in _db.Genres on bgc.GenreId equals g.Id
                              select new GenreViewModel
                              {
                                  Id = g.Id,
                                  Name = g.Name
                              }).ToList();

                var book = new BookViewModel
                {
                    Title = b.Title,
                    Isbn = b.Isbn,
                    Type = b.Type,
                    PublishingYear = b.PublishingYear,
                    Price = b.Price,
                    Author = authors,
                    Genre = genres
                };

                results.Add(book);
        }
        return results;
     }

        public List<BookViewModel> GetBooksByIds(List<int> Ids)
        {
            var requestedBooks = new List<BookViewModel>();
            foreach(var id in Ids)
            {
                var books = (from b in _db.Books
                         where b.Id == id
                         select b);
                foreach(var b in books)
                {
                    var authors = (from bac in _db.BookAuthorConnections
                                   where bac.BookId == b.Id
                                   join a in _db.Authors on bac.AuthorId equals a.Id
                                   select new AuthorViewModel
                                   {
                                       Id = a.Id,
                                       Name = a.Name
                                   }).ToList(); 
                
                    var genres = (from bgc in _db.BookGenreConnections
                              where bgc.BookId == b.Id
                              join g in _db.Genres on bgc.GenreId equals g.Id
                              select new GenreViewModel
                              {
                                  Id = g.Id,
                                  Name = g.Name
                              }).ToList();

                    var book = new BookViewModel
                    {
                        Title = b.Title,
                        Isbn = b.Isbn,
                        Type = b.Type,
                        PublishingYear = b.PublishingYear,
                        Price = b.Price,
                        Author = authors,
                        Genre = genres
                    };

                    requestedBooks.Add(book);
                }       
            }
            return requestedBooks;
        }

        public BookModifyViewModel GetBookModify(int bookId)
        {
            var book = (from b in _db.Books
                        where b.Id == bookId
                        select b).SingleOrDefault();

            var authors = (from bac in _db.BookAuthorConnections
                            where bac.BookId == bookId
                            join a in _db.Authors on bac.AuthorId equals a.Id
                            select a.Id).ToList(); 
                
            var genres = (from bgc in _db.BookGenreConnections
                          where bgc.BookId == bookId
                          join g in _db.Genres on bgc.GenreId equals g.Id
                          select g.Id).ToList();
            
            var publisher = (from p in _db.Publishers
                             where p.Id == book.PublisherId
                             select p.Id).SingleOrDefault();
            
            var details = (from d in _db.BookDetails
                           where d.BookId == bookId
                           select d).SingleOrDefault();

            var bookDetails = new BookModifyViewModel
            {
                BookId = book.Id,
                Title = book.Title,
                Isbn = book.Isbn,
                Author = authors,
                PublisherId = publisher,
                Genre = genres,
                Description = details.Description,
                Price = book.Price,
                Type = book.Type,
                Font = details.Font,
                PublishingYear = book.PublishingYear,
                PageCount = details.PageCount,
                Length = details.Length
            };

            return bookDetails;
        }
    }
}