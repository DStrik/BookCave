using System.Collections.Generic;
using System.IO;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class BookService
    {
        private BookRepo _bookRepo;
        public BookService()
        {
            _bookRepo = new BookRepo();
        }
        public List<BookViewModel> GetTop10()
        {
            return null;
        }
        public List<BookViewModel> GetNewReleases()
        {
            return _bookRepo.GetNewReleases();
        }
        public BookDetailViewModel GetBookDetails(int bookId)
        {
            return _bookRepo.GetBookDetails(bookId);
        }
        public BookModifyViewModel GetBookInputModel(int bookId)
        {
            return _bookRepo.GetBookModify(bookId);
        }
        public void ModifyBook(BookModifyInputModel book)
        {
            var bookEntity = new Book
            {
                Id = book.BookId,
                Title = book.Title,
                Isbn = book.Isbn,
                PublishingYear = book.PublishingYear,
                Type = book.Type,
                Price = book.Price,
                PublisherId = book.PublisherId
            };
            
            var details = new BookDetails
            {
                BookId = book.BookId,
                Description = book.Description,
                Font = book.Font,
                PageCount = book.PageCount,
                Length = book.Length
            };

            _bookRepo.ModBookDetails(details);

            foreach(var id in book.Author)
            {
                var AuthorConnection = new BookAuthorConnection
                {
                    BookId = book.BookId,
                    AuthorId = id
                };

                _bookRepo.ModBookAuthorConnection(AuthorConnection);
            }

            foreach(var id in book.Genre)
            {
                var GenreConnection = new BookGenreConnection
                {
                    BookId = book.BookId,
                    GenreId = id
                };
                _bookRepo.ModBookGenreConnection(GenreConnection);
            }
        }
        public async void AddBook(BookInputModel book)
        {   
            var bookEntity = new Book
            {
                Title = book.Title,
                Isbn = book.Isbn,
                PublishingYear = book.PublishingYear,
                Type = book.Type,
                Price = book.Price,
                PublisherId = book.PublisherId
            };

            var bookId = _bookRepo.AddBook(bookEntity);
            
            var details = new BookDetails
            {
                BookId = bookId,
                Description = book.Description,
                Font = book.Font,
                PageCount = book.PageCount,
                Length = book.Length
            };

            _bookRepo.AddBookDetails(details);

            foreach(var id in book.Author)
            {
                var AuthorConnection = new BookAuthorConnection
                {
                    BookId = bookId,
                    AuthorId = id
                };

                _bookRepo.AddBookAuthorConnection(AuthorConnection);
            }

            foreach(var id in book.Genre)
            {
                var GenreConnection = new BookGenreConnection
                {
                    BookId = bookId,
                    GenreId = id
                };
                _bookRepo.AddBookGenreConnection(GenreConnection);
            }

            var memoryStream = new MemoryStream();
            await book.CoverImage.CopyToAsync(memoryStream);
            var img = new CoverImage
            {
                BookId = bookId,
                Img = memoryStream.ToArray()

            };
            _bookRepo.AddImage(img);
        }

        public void AddAuthor(AuthorInputModel author)
        {
            var authorEntity = new Author
            {
                Name = author.Name
            };

            _bookRepo.AddAuthor(authorEntity);

        }

        public void AddGenre(GenreInputModel genre)
        {
            var genreEntity = new Genre
            {
                Name = genre.Name
            };

            _bookRepo.AddGenre(genreEntity);
        }
        
        public void AddPublisher(PublisherInputModel publisher)
        {
            var publisherEntity = new Publisher
            {
                Name = publisher.Name
            };

            _bookRepo.AddPublisher(publisherEntity);
        }

        public List<BookViewModel> GetAllBooks()
        {
            return _bookRepo.GetAllBooks();
        }

        public List<GenreViewModel> GetAllGenres()
        {
            return _bookRepo.GetAllGenres();
        }

        public List<AuthorViewModel> GetAllAuthors()
        {
            return _bookRepo.GetAllAuthors();
        }

        public List<PublisherViewModel> GetAllPublishers()
        {
            return _bookRepo.GetAllPublishers();
        }

        public BookViewModel GetBookById(int bookId)
        {
            return _bookRepo.GetBookById(bookId);
        }
    }
}