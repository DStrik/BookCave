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
            var top10BookIds = _bookRepo.GetTop10();
            var top10 = new List<BookViewModel>();
            foreach(int i in top10BookIds)
            {
                var book = GetBookById(i);
                top10.Add(book);
            }
            return top10;
        }
        public List<BookViewModel> GetNewReleases()
        {
            return _bookRepo.GetNewReleases();
        }
        public BookDetailViewModel GetBookDetails(int bookId)
        {
            return _bookRepo.GetBookDetails(bookId);
        }
        public BookModifyInputModel GetBookModifyModel(int bookId)
        {
            return _bookRepo.GetBookModify(bookId);
        }
        public async void ModifyBook(BookModifyInputModel book)
        {
            var bookEntity = new Book
            { 
                Id = book.BookId,
                Title = book.Title,
                Isbn = book.Isbn,
                PublishingYear = book.PublishingYear ?? default(int),
                Type = book.Type,
                Price = book.Price ?? default(double),
                PublisherId = book.Publisher ?? default(int)
            };
            
            var details = new BookDetails
            {
                BookId = book.BookId,
                Description = book.Description,
                Font = book.Font,
                PageCount = book.PageCount ?? default(int),
                Length = book.Length ?? default(int)
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

            if (book.NewCoverImage != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await book.NewCoverImage.CopyToAsync(memoryStream);
                    var img = new CoverImage
                    {
                        BookId = book.BookId,
                        Img = memoryStream.ToArray()
                    };
                    _bookRepo.ModImage(img);
                }
            }
        }
        public async void AddBook(BookInputModel book)
        {   
            var bookEntity = new Book
            {
                Title = book.Title,
                Isbn = book.Isbn,
                PublishingYear = book.PublishingYear ?? default(int),
                Type = book.Type,
                Price = book.Price ?? default(double),
                PublisherId = book.PublisherId ?? default(int)
            };

            var bookId = _bookRepo.AddBook(bookEntity);
            
            var details = new BookDetails
            {
                BookId = bookId,
                Description = book.Description,
                Font = book.Font,
                PageCount = book.PageCount ?? default(int),
                Length = book.Length ?? default(int)
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

            using (var memoryStream = new MemoryStream())
            {
                await book.CoverImage.CopyToAsync(memoryStream);
                var img = new CoverImage
                {
                    BookId = bookId,
                    Img = memoryStream.ToArray()

                };
                _bookRepo.AddImage(img);
            }
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

        public List<BookListViewModel> GetBookList()
        {
            return _bookRepo.GetBookList();
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

        public void RemoveBookById(int id) 
        {
            _bookRepo.DeleteBook(id);
        }
        public BookCartViewModel GetCartBookById(CartItem item)
        {
            return _bookRepo.GetCartBookById(item);
        }
    }
}