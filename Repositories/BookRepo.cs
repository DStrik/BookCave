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
                var authors = GetAuthors(b.Id);
                var genres = GetGenres(b.Id);
                var coverImage = GetCoverImage(b.Id);

                var book = new BookViewModel
                {
                    Title = b.Title,
                    Isbn = b.Isbn,
                    Type = b.Type,
                    PublishingYear = b.PublishingYear,
                    Price = b.Price,
                    Author = authors,
                    Genre = genres,
                    CoverImage = coverImage.Img
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

        private Book GetBook(int bookId)
        {
            var book = (from b in _db.Books
                        where b.Id == bookId
                        select b).SingleOrDefault();
            return book;
        }
        
        private List<AuthorViewModel> GetAuthors(int bookId)
        {
            var authors = (from bac in _db.BookAuthorConnections
                           where bac.BookId == bookId
                           join a in _db.Authors on bac.AuthorId equals a.Id
                           select new AuthorViewModel
                           {
                                Id = a.Id,
                                Name = a.Name
                           }).ToList();
            return authors; 
        }

        private List<GenreViewModel> GetGenres(int bookId)
        {
            var genres = (from bgc in _db.BookGenreConnections
                          where bgc.BookId == bookId
                          join g in _db.Genres on bgc.GenreId equals g.Id
                          select new GenreViewModel
                          {
                                Id = g.Id,
                                Name = g.Name
                          }).ToList();
            return genres;        
        }

        private PublisherViewModel GetPublisher(int publisherId)
        {
            var publisher = (from p in _db.Publishers
                             where p.Id == publisherId
                             select new PublisherViewModel
                             {
                                 Id = p.Id,
                                 Name = p.Name
                             }).SingleOrDefault();
            return publisher;
        }

        private List<ReviewViewModel> GetReviews(int bookId)
        {
            var reviews = (from r in _db.BookReviews
                           where r.BookId == bookId
                           select new ReviewViewModel
                           {
                               Grade = r.Grade,
                               Review = r.Review
                           }).ToList();
            return reviews;
        }

        private BookDetails GetDetails(int bookId)
        {
            var details = (from d in _db.BookDetails
                           where d.BookId == bookId
                           select d).SingleOrDefault();
            return details;
        }
        
        private CoverImage GetCoverImage(int bookId)
        {
            var img = (from ci in _db.CoverImages
                       where ci.BookId == bookId
                       select ci).SingleOrDefault();
            return img;
        }

        public BookDetailViewModel GetBookDetails(int bookId)
        {
            var book = GetBook(bookId);
            var authors = GetAuthors(bookId);
            var genres = GetGenres(bookId);
            var publisher = GetPublisher(bookId);
            var details = GetDetails(bookId);
            var reviews = GetReviews(bookId);
            var coverImage = GetCoverImage(bookId);
            
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
                CoverImage = coverImage.Img
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
                var authors = GetAuthors(b.Id);
                var genres = GetGenres(b.Id);

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

        /*public List<BookViewModel> GetSearchResults(BookInputModel search)
        {
            
        }*/
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
                var authors = GetAuthors(b.Id);
                var genres = GetGenres(b.Id);
                var coverImage = GetCoverImage(b.Id);

                var book = new BookViewModel
                {
                    Title = b.Title,
                    Isbn = b.Isbn,
                    Type = b.Type,
                    PublishingYear = b.PublishingYear,
                    Price = b.Price,
                    Author = authors,
                    Genre = genres,
                    CoverImage = coverImage.Img
                };

                results.Add(book);
        }
        return results;
     }

        public BookViewModel GetBookById(int id)
        {
            var book = GetBook(id);
            var authors = GetAuthors(id);
            var genres = GetGenres(id);
            var coverImage = GetCoverImage(id);

            var retBook = new BookViewModel
            {
                Title = book.Title,
                Isbn = book.Isbn,
                Type = book.Type,
                PublishingYear = book.PublishingYear,
                Price = book.Price,
                Author = authors,
                Genre = genres,
                CoverImage = coverImage.Img
            };

                return retBook;
        }

        public BookModifyViewModel GetBookModify(int bookId)
        {
            var book = GetBook(bookId);
            var details = GetDetails(bookId);
            var coverImage = GetCoverImage(bookId);

            var authorIds = (from bac in _db.BookAuthorConnections
                            where bac.BookId == bookId
                            join a in _db.Authors on bac.AuthorId equals a.Id
                            select a.Id).ToList(); 
                
            var genreIds = (from bgc in _db.BookGenreConnections
                          where bgc.BookId == bookId
                          join g in _db.Genres on bgc.GenreId equals g.Id
                          select g.Id).ToList();
            
            var publisherId = (from p in _db.Publishers
                             where p.Id == book.PublisherId
                             select p.Id).SingleOrDefault();

            var bookDetails = new BookModifyViewModel
            {
                BookId = book.Id,
                Title = book.Title,
                Isbn = book.Isbn,
                Author = authorIds,
                PublisherId = publisherId,
                Genre = genreIds,
                Description = details.Description,
                Price = book.Price,
                Type = book.Type,
                Font = details.Font,
                PublishingYear = book.PublishingYear,
                PageCount = details.PageCount,
                Length = details.Length,
                CoverImage = coverImage.Img
            };

            return bookDetails;
        }
    }
}