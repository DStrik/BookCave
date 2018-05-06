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
        private BookRepo repo;
        public BookService()
        {
            repo = new BookRepo();
        }
        public List<BookViewModel> GetTop10()
        {
            return null;
        }
        public List<BookViewModel> GetNewReleases()
        {
            return null;
        }
        public BookDetailViewModel GetBookDetails(int BookId)
        {
            //TO DO!!!
            return null;
        }
        public BookInputModel GetBookInputModel()
        {
            return null;
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

            repo.ModBookDetails(details);

            foreach(var id in book.Author)
            {
                var AuthorConnection = new BookAuthorConnection
                {
                    BookId = book.BookId,
                    AuthorId = id
                };

                repo.ModBookAuthorConnection(AuthorConnection);
            }

            foreach(var id in book.Genre)
            {
                var GenreConnection = new BookGenreConnection
                {
                    BookId = book.BookId,
                    GenreId = id
                };
                repo.ModBookGenreConnection(GenreConnection);
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

            var bookId = repo.AddBook(bookEntity);
            
            var details = new BookDetails
            {
                BookId = bookId,
                Description = book.Description,
                Font = book.Font,
                PageCount = book.PageCount,
                Length = book.Length
            };

            repo.AddBookDetails(details);

            foreach(var id in book.Author)
            {
                var AuthorConnection = new BookAuthorConnection
                {
                    BookId = bookId,
                    AuthorId = id
                };

                repo.AddBookAuthorConnection(AuthorConnection);
            }

            foreach(var id in book.Genre)
            {
                var GenreConnection = new BookGenreConnection
                {
                    BookId = bookId,
                    GenreId = id
                };
                repo.AddBookGenreConnection(GenreConnection);
            }

            var memoryStream = new MemoryStream();
            await book.CoverImage.CopyToAsync(memoryStream);
            var img = new CoverImage
            {
                BookId = bookId,
                Img = memoryStream.ToArray()

            };
            repo.AddImage(img);
        }

        public void AddAuthor(AuthorInputModel author)
        {
            var authorEntity = new Author
            {
                Name = author.Name
            };

            repo.AddAuthor(authorEntity);

        }

        public void AddGenre(GenreInputModel genre)
        {
            var genreEntity = new Genre
            {
                Name = genre.Name
            };

            repo.AddGenre(genreEntity);
        }
        
        public void AddPublisher(PublisherInputModel publisher)
        {
            var publisherEntity = new Publisher
            {
                Name = publisher.Name
            };

            repo.AddPublisher(publisherEntity);
        }

        public List<BookViewModel> GetAllBooks()
        {
            return repo.GetAllBooks();
        }

        public List<GenreViewModel> GetAllGenres()
        {
            return repo.GetAllGenres();
        }

        public List<AuthorViewModel> GetAllAuthors()
        {
            return repo.GetAllAuthors();
        }

        public List<PublisherViewModel> GetAllPublishers()
        {
            return repo.GetAllPublishers();
        }

    }
}