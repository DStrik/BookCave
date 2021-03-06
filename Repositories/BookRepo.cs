using System.Collections.Generic;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using System.Linq;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        private DataContext _db;
        private UserRepo _userRepo;
        public BookRepo()
        {
            _db = new DataContext();
            _userRepo = new UserRepo();
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

        public void RemoveBookGenreConnection(BookGenreConnection connection)
        {
            _db.Remove(connection);
            _db.SaveChanges();
        }

        public void AddBookAuthorConnection(BookAuthorConnection connection)
        {
            _db.Add(connection);
            _db.SaveChanges();
        }

        public void RemoveBookAuthorConnection(BookAuthorConnection connection)
        {
            _db.Remove(connection);
            _db.SaveChanges();
        }

        public void AddImage(CoverImage img)
        {
            _db.Add(img);
            _db.SaveChanges();
        }

        public void ModImage(CoverImage img)
        {
            _db.Update(img);
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

        public void AddReview(BookReview review)
        {
            _db.Add(review);
            _db.SaveChanges();
            UpdateRating(review.BookId);
        }

        private void UpdateRating(int bookId)
        {
            var newRating = (from r in _db.BookReviews
                             where r.BookId == bookId
                             select r.Rating).DefaultIfEmpty(0).Average();
            
            var rating = (from r in _db.BookRatings
                          where r.BookId == bookId
                          select r).SingleOrDefault();
            
            if(rating != null)
            {

                rating.Rating = newRating;                
                _db.Update(rating);
            }
            else
            {
                var firstRating = new BookRating
                {
                    BookId = bookId,
                    Rating = newRating
                };
                _db.Add(firstRating);
            }
            
            _db.SaveChanges();
        }

        public List<BookListViewModel> GetBookList()
        {
            var books = new List<BookListViewModel>();
            foreach(var b in _db.Books)
            {
                var book = new BookListViewModel
                {
                    BookId = b.Id,
                    Title = b.Title,
                    Isbn = b.Isbn,
                    Type = b.Type,
                    PublishingYear = b.PublishingYear,
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
                               Reviewer = r.Reviewer,
                               Rating = r.Rating,
                               Review = r.Review,
                               ProfileImg = _userRepo.GetReviewUserImage(r.UserId).Img
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
        
        private byte[] GetCoverImageAsync(int bookId)
        {
            var img = (from ci in _db.CoverImages
                       where ci.BookId == bookId
                       select ci).SingleOrDefault();
            if(img == null)
            {
                
                using (var memoryStream = new MemoryStream())
                {
                    new FileInfo("wwwroot/images/nopic.jpg").OpenRead().CopyTo(memoryStream);
                    var image =  memoryStream.ToArray();
                    return image;
                }
            }
            
            return img.Img;
        }

        private double GetRating(int bookId)
        {
            double? rating = (from r in _db.BookRatings
                          where r.BookId == bookId
                          select r.Rating).SingleOrDefault();
            
            if(rating == null)
            {
                return 0;
            }
                          
            return (double)rating;
        }

        public BookDetailViewModel GetBookDetails(int bookId)
        {
            var book = GetBook(bookId);

            if(book == null)
            {
                return null;
            }

            var authors = GetAuthors(bookId);
            var genres = GetGenres(bookId);
            var publisher = GetPublisher(bookId);
            var details = GetDetails(bookId);
            var reviews = GetReviews(bookId);
            var coverImage = GetCoverImageAsync(bookId);
            var rating = GetRating(bookId);
            
            var bookDetails = new BookDetailViewModel
            {
                BookId = book.Id,
                Title = book.Title,
                Isbn = book.Isbn,
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
                Rating = rating,
                CoverImage = coverImage
            };

            return bookDetails;
        }

        public void DeleteBook(int bookId)
        {
            var book = new Book { Id = bookId };
            _db.Books.Attach(book);
            _db.Books.Remove(book);
            
            var bookDetails = GetDetails(bookId);
            _db.BookDetails.Attach(bookDetails);
            _db.BookDetails.Remove(bookDetails);

            var genreConnection = (from bgc in _db.BookGenreConnections
                                   where bgc.BookId == bookId
                                   select bgc).ToList();
            
            foreach(var g in genreConnection)
            {
                _db.BookGenreConnections.Remove(g);
            }

            var authorConnection = (from bac in _db.BookAuthorConnections
                                    where bac.BookId == bookId
                                    select bac).ToList();
            
            foreach(var a in authorConnection)
            {
                _db.BookAuthorConnections.Remove(a);
            }

            var reviews = (from r in _db.BookReviews
                           where r.BookId == bookId
                           select r).ToList();

            foreach(var r in reviews)
            {
                _db.BookReviews.Remove(r);
            }

            var rating = (from r in _db.BookRatings
                          where r.BookId == bookId
                          select r).SingleOrDefault();
            _db.BookRatings.Remove(rating);

            var img = (from i in _db.CoverImages
                       where i.BookId == bookId
                       select i).SingleOrDefault();
            _db.CoverImages.Remove(img);
            _db.SaveChanges();
        }

        public List<int> GetTop10()
        {
            var top10 = (from b in _db.BookRatings
                         orderby b.Rating descending
                         select b.BookId);

            if(top10.Count() < 10)
            {
                return top10.ToList();
            }
            else
            {
                return top10.Take(10).ToList();
            }
        }

        public List<BookViewModel> GetSearchResults(SearchInputModel search)
        {
             var books = (from b in _db.Books
                         where b.Title.Contains(search.Title) || search.Title == null
                         where b.Isbn.ToString().Contains(search.Isbn.ToString()) || search.Isbn == null
                         select b);
            


            if(search.AuthorIds != null)
            {
                books = (from bac in _db.BookAuthorConnections
                         join a in search.AuthorIds on bac.AuthorId equals a
                         join b in books on bac.BookId equals b.Id
                         select b);
            }

            if(search.GenreIds != null)
            {
                books = (from bgc in _db.BookGenreConnections
                         join g in search.GenreIds on bgc.GenreId equals g
                         join b in books on bgc.BookId equals b.Id
                         select b);
            }

            if(search.PublisherIds != null)
            {
                books = (from b in books
                         join p in search.PublisherIds on b.PublisherId equals p
                         select b);
            }

            if(search.Types != null)
            {
                books = (from b in books
                         join t in search.Types on b.Type equals t
                         select b);
            }

            var results = new List<BookViewModel>();
            foreach(var b in books)
            {
                var authors = GetAuthors(b.Id);
                var coverImage = GetCoverImageAsync(b.Id);
                var rating = GetRating(b.Id);

                var book = new BookViewModel
                {
                    BookId = b.Id,
                    Title = b.Title,
                    Type = b.Type,
                    Price = b.Price,
                    Author = authors,
                    CoverImage = coverImage,
                    Rating = rating
                };

                results.Add(book);
        }
        return results;
     }

        public BookViewModel GetBookById(int id)
        {
            var book = GetBook(id);
            
            if(book == null)
            {
                return null;
            }

            var authors = GetAuthors(id);
            var coverImage = GetCoverImageAsync(id);
            var rating = GetRating(id);
            var retBook = new BookViewModel
            {
                BookId = id,
                Title = book.Title,
                Type = book.Type,
                Price = book.Price,
                Author = authors,
                CoverImage = coverImage,
                Rating = rating
            };

                return retBook;
        }

        public BookModifyInputModel GetBookModify(int bookId)
        {
            var book = GetBook(bookId);
            var details = GetDetails(bookId);
            var coverImage = GetCoverImageAsync(bookId);

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

            var bookDetails = new BookModifyInputModel
            {
                BookId = book.Id,
                Title = book.Title,
                Isbn = book.Isbn,
                Author = authorIds,
                Publisher = publisherId,
                Genre = genreIds,
                Description = details.Description,
                Price = book.Price,
                Type = book.Type,
                Font = details.Font,
                PublishingYear = book.PublishingYear,
                PageCount = details.PageCount,
                Length = details.Length,
                CurrentCoverImage = coverImage
            };

            return bookDetails;
        }
            public BookCartViewModel GetCartBookById(CartItem item)
        {
            var book = GetBook(item.BookId);
            if(book == null)
            {
                return null;
            }
            var coverImage = GetCoverImageAsync(item.BookId);

            var retBook = new BookCartViewModel
            {
                Title = book.Title,
                Type = book.Type,
                Price = book.Price,
                Quantity = item.Quantity,
                CoverImage = coverImage,
                CartItemId = item.Id
            };

                return retBook;
        }

        public int GetDetailsId(int bookId)
        {
            var id = (from d in _db.BookDetails
                      where d.BookId == bookId
                      select d.Id).SingleOrDefault();
            return id;
        }

        public List<BookAuthorConnection> GetBookAuthorConnections(int bookId)
        {
            var bac = (from a in _db.BookAuthorConnections
                       where a.BookId == bookId
                       select a).ToList();

            return bac;
        }

        public List<BookGenreConnection> GetBookGenreConnections(int bookId)
        {
            var bgc = (from g in _db.BookGenreConnections
                       where g.BookId == bookId
                       select g).ToList();

            return bgc;
        }

        public int GetCoverImageId(int bookId)
        {
            var id = (from c in _db.CoverImages
                      where c.BookId == bookId
                      select c.Id).SingleOrDefault();

            return id;
        }
    }
}